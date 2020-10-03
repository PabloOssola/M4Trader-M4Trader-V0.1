﻿using M4Trader.ordenes.server.ApplicationServices.EventHelperDequeueProcessors;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class EventHelperServiceStarter : IApplicationServiceStarter
    {
        private ManualResetEvent manualResetEvent;

        public string ServiceName { get { return "EventHelperService"; } }

        public void SetWaitHandler(ManualResetEvent manualResetEvent)
        {
            this.manualResetEvent = manualResetEvent;
        }

        public void Start()
        {
            EventHelperService.Start();
        }

        public void Stop()
        {

        }
    }

    public class EventHelperService
    {
        private BlockingCollection<Notificacion> notificacionQueue = null;
        private Dictionary<byte, IDequeueProcessor> processor = null;

        private EventHelperService()
        {
            this.InstanciarProcesadores();

            this.notificacionQueue = new BlockingCollection<Notificacion>();
            Task.Factory.StartNew(Dispatch);
        }

        private void Dispatch()
        {
            Notificacion entidad = null;
            while (this.notificacionQueue.TryTake(out entidad, -1))
            {
                if (entidad == null)
                {
                    break;
                }
                else
                {
                    DeQueueMessage(entidad);
                }
            }
        }

        private void InstanciarProcesadores()
        {
            this.processor = new Dictionary<byte, IDequeueProcessor>();
            this.processor.Add((byte)TiposNotificaciones.OrdenActivaMercado, new OrdenActivaMercadoProcessor());
            this.processor.Add((byte)TiposNotificaciones.OrdenCancelarMercado, new OrdenCancelarMercadoProcessor());
            this.processor.Add((byte)TiposNotificaciones.OrdenRechazoMercado, new OrdenRechazoMercadoProcessor());
            this.processor.Add((byte)TiposNotificaciones.OrdenReemplazarMercado, new OrdenReemplazarMercadoProcessor());
            this.processor.Add((byte)TiposNotificaciones.EstadoSistema, new EstadoSistemaProcessor());
            this.processor.Add((byte)TiposNotificaciones.RefrescarCache, new RefrescarCacheProcessor());
            this.processor.Add((byte)TiposNotificaciones.CollateralReport, new CollateralReportProcessor());
            this.processor.Add((byte)TiposNotificaciones.AsociacionProductoPortfolio, new AsociacionProductoPortfolioProcessor());
            this.processor.Add((byte)TiposNotificaciones.DesAsociacionProductoPortfolio, new DesAsociacionProductoPortfolioProcessor());
            this.processor.Add((byte)TiposNotificaciones.HeartBeat, new HeartBeatProcessor());
        }

        private static volatile EventHelperService _instance;

        public static EventHelperService Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("Instancia no inicializada");
                }
                return _instance;
            }
        }

        public static void Start()
        {
            if (_instance == null)
            {
                lock (typeof(EventHelperService))
                {
                    if (_instance == null)
                        _instance = new EventHelperService();
                }
            }
        }

        private void DeQueueMessage(object state)
        {
            Notificacion notificacion = (Notificacion)state;

            var inCourseRequest = InCourseRequest.New();
            LoggingService.Instance.AgregarLog(new LogCommandEntity(notificacion.CommandName, "NOTI", inCourseRequest.Id, notificacion));
            try
            {
                this.processor[notificacion.IdTipoNotificacion].Dispatch(inCourseRequest, notificacion);
            }
            catch (Exception ex)
            {
                LoggingService.Instance.AgregarLog(new LogCommandEntity(notificacion.CommandName, "NOTI-ERR", inCourseRequest.Id, ex));
            }

        }


        public void EnQueueMessage(Notificacion notificacion)
        {
            this.notificacionQueue.Add(notificacion);
        }
    }

    public enum TiposNotificaciones
    {
        OrdenActivaMercado = 1,
        OrdenReemplazarMercado = 2,
        OrdenCancelarMercado = 3,
        OrdenRechazoMercado = 4,
        EstadoSistema = 5,
        RefrescarCache = 6,
        CollateralReport = 7,
        AsociacionProductoPortfolio = 8,
        DesAsociacionProductoPortfolio = 9,
        TradeCaptureReport = 10,
        HeartBeat = 11,
    }
}

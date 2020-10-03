using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class NotificacionesServiceStarter : IApplicationServiceStarter
    {
        private ManualResetEvent manualResetEvent;

        public string ServiceName { get { return "NotificacionesHelperService"; } }

        public void SetWaitHandler(ManualResetEvent manualResetEvent)
        {
            this.manualResetEvent = manualResetEvent;
        }

        public void Start()
        {
            NotificacionesHelperService.Start();
        }

        public void Stop()
        {

        }
    }

    public class NotificacionesHelperService
    {
        private BlockingCollection<NotificacionesEntity> notificacionesQueue = null; 

        private NotificacionesHelperService()
        {
            this.notificacionesQueue = new BlockingCollection<NotificacionesEntity>();
            Task.Factory.StartNew(Dispatch);
        }

        private void Dispatch()
        {
            NotificacionesEntity notificacionEntity = null;
            while (this.notificacionesQueue.TryTake(out notificacionEntity, -1))
            {
                //NotificacionDAL.InsertarNotificacion(notificacionEntity);
            }
        }

        private static volatile NotificacionesHelperService _instance;

        public static NotificacionesHelperService Instance
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
                lock (typeof(NotificacionesHelperService))
                {
                    if (_instance == null)
                        _instance = new NotificacionesHelperService();
                }
            }
        }

        public void EnQueueMessage(NotificacionesEntity notificacionEntity)
        {
            this.notificacionesQueue.Add(notificacionEntity);
        }
    }
}

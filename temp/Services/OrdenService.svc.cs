using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.ServiceModel;

namespace M4Trader.ordenes.server.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class OrdenService : IOrdenService
    {
        public void RecibirOrdenRespuesta(FixOrdenRespuestaEntity ordenMercado)
        {
            OrdenEntity ordenInterna = new OrdenEntity();
            var inCourseRequest = InCourseRequest.New();
            try
            {
                CommandLog.Start("RecibirOrdenRespuesta", ordenMercado, inCourseRequest, "ORSInRes");
                OrdenHelper.RecibirOrdenRespuesta(ordenMercado, ordenInterna, inCourseRequest.Id);
                CommandLog.FinishOK("RecibirOrdenRespuesta", ordenInterna, inCourseRequest, "ORSInRes-OK");
            }
            catch (Exception e)
            {
                CommandLog.FinishWithError("RecibirOrdenRespuesta", e, inCourseRequest, "ORSInRes-ERROR");
            }

        }

        public void RecibirGarantiasRespuesta(FixGarantiasEntity garantia)
        {
            var inCourseRequest = InCourseRequest.New();
            try
            {
                CommandLog.Start("RecibirGarantiasRespuesta", garantia, inCourseRequest, "ORSGInRes");
                OrdenHelper.RecibirGarantiasRespuesta(garantia, inCourseRequest.Id);
                CommandLog.FinishOK("RecibirGarantiasRespuesta", garantia, inCourseRequest, "ORSGInRes-OK");
            }
            catch (Exception e)
            {
                CommandLog.FinishWithError("RecibirGarantiasRespuesta", e, inCourseRequest, "ORSGInRes-ERROR");
            }

        }

        public void RecibirTradeCaptureReportRespuesta(FixTradeCaptureReportInfo tradeCaptureReport)
        {
            var inCourseRequest = InCourseRequest.New();
            try
            {
                CommandLog.Start("RecibirTradeCaptureReportRespuesta", tradeCaptureReport, inCourseRequest, "ORSGInRes");
                OrdenHelper.RecibirTradeCaptureReportRespuesta(tradeCaptureReport, inCourseRequest.Id);
                CommandLog.FinishOK("RecibirTradeCaptureReportRespuesta", tradeCaptureReport, inCourseRequest, "ORSGInRes-OK");
            }
            catch (Exception e)
            {
                CommandLog.FinishWithError("RecibirTradeCaptureReportRespuesta", e, inCourseRequest, "ORSGInRes-ERROR");
            }
        }

        public void RecibirHeartBeat()
        {
            OrdenHelper.RecibirHeartBeat();
        }

        public FixOrdenesResponseEntity EnviarOrdenesAlMercado(FixOrdenesEntity orden)
        {
            FixOrdenesResponseEntity respuesta = new FixOrdenesResponseEntity();
            return respuesta;
        }

        public FixOrdenesResponseEntity ReRegistrarse(string mercado)
        {
            FixOrdenesResponseEntity respuesta = new FixOrdenesResponseEntity();
            return respuesta;
        }
    }
}

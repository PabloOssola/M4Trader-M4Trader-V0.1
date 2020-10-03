using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Services;
using System;

namespace M4Trader.ordenes.server.ApplicationServices.EventHelperDequeueProcessors
{
    public class CollateralReportProcessor : IDequeueProcessor
    {
        public void Dispatch(InCourseRequest inCourseRequest, Notificacion notificacion)
        {
            NotificacionGarantias noti = (NotificacionGarantias)notificacion;
            //throw new NotImplementedException("Javi, tenes que cablear esto");
            //WCFHelper.ExecuteService<IOfertasResponseService>(ConfiguracionSistemaURLsEnumDestino.NotificacionesDMAFIX, i => i.OrdenReemplazarMercado(notificacion));
        }
    }
}
 
 

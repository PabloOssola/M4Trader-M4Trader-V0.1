using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Services;

namespace M4Trader.ordenes.server.ApplicationServices.EventHelperDequeueProcessors
{
    public class OrdenReemplazarMercadoProcessor : IDequeueProcessor
    {
        public void Dispatch(InCourseRequest inCourseRequest, Notificacion notificacion)
        {
            WCFHelper.ExecuteService<IOfertasResponseService>(ConfiguracionSistemaURLsEnumDestino.NotificacionesDMAFIX, i => i.OrdenReemplazarMercado((NotificacionOrden)notificacion));
        }
    }
}
 
 

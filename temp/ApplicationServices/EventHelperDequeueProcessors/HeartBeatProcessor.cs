using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Services;

namespace M4Trader.ordenes.server.ApplicationServices.EventHelperDequeueProcessors
{
    public class HeartBeatProcessor : IDequeueProcessor
    {
        public void Dispatch(InCourseRequest inCourseRequest, Notificacion notificacion)
        {
            if (((NotificacionHeartBeat)notificacion).MarketData)
            {
                //TOD: aqui va el servicio de notificacion de MD
                //WCFHelper.ExecuteService<IOfertasResponseService>(ConfiguracionSistemaURLsEnumDestino.NotificacionesDMAFIX, i => i.HeartBeat((NotificacionHeartBeat)notificacion));
            }
            else
            {
                WCFHelper.ExecuteService<IOfertasResponseService>(ConfiguracionSistemaURLsEnumDestino.NotificacionesDMAFIX, i => i.HeartBeat((NotificacionHeartBeat)notificacion));
            }
        }
    }
}



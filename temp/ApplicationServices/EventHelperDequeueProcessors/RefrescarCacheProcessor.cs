using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Services;

namespace M4Trader.ordenes.server.ApplicationServices.EventHelperDequeueProcessors
{
    public class RefrescarCacheProcessor : IDequeueProcessor
    { 

        public void Dispatch(InCourseRequest inCourseRequest, Notificacion notificacion)
        {
            WCFHelper.ExecuteService<IOfertasResponseService>(ConfiguracionSistemaURLsEnumDestino.NotificacionesDMAFIX, i => i.RefrescarCache((NotificacionRefrescarCache)notificacion));
            //var cmd = new DesconectarCommand();

            //var s = JsonConvert.SerializeObject(cmd, Formatting.Indented, new JsonSerializerSettings
            //{
            //    TypeNameHandling = TypeNameHandling.Auto
            //});

            //JSCommand command = new JSCommand();
            //string encryptName = string.Empty;
            //command.d = s;
            //command.k = "RefCachCom";
            //command.b = true;
            //command.a = (byte)TipoAplicacion.API;
            //string url = string.Empty;
            //NotificacionRefrescarCache notificacionRefrescar = (NotificacionRefrescarCache)notificacion;
            //notificacionRefrescar.NotificacionPropiedades.TryGetValue("url", out url);
            //WCFHelper.ExecuteServiceLocal<ICommandExtranetService>(url, string.Empty, i => i.c(command));
            //LoggingHelper.Instance.AgregarLog(new LogCommandApiEntity("RefrescarCacheProcessor", "CMD-API", inCourseRequest.Id, null));
        }
    }
}

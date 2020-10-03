using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("LogOEXTCom", (int)IdAccion.Login, TipoAplicacion.WEBEXTERNA, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.DMA, TipoAplicacion.COMPLEMENTODMA,TipoAplicacion.API)]

    public class LogoutCommandWebExterna : LoginCommand
    { 
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            InfoCliente infoCliente = new InfoCliente(IP, "WebExterna");
            LoginHelper.Logout(sessionId, (byte)TipoAplicacion.WEBEXTERNA);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = true, Message = "Logout Satisfactorio" });
        }

        [DataMember]
        public string sessionId { get; set; }

    }
}
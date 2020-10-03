using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server
{ 
    [CommandType("LogDMACom", (int)IdAccion.Login, TipoAplicacion.API)]

    public class LoginCommandDMA: LoginCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            InfoCliente infoCliente = new InfoCliente(IP, "WebExterna");
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(LoginHelper.Login(UserName, Password, infoCliente, TipoAplicacion.DMA));
        }
    }
}
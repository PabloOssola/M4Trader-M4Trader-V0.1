using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using MAE.Clearing.BusinessComponentLayer.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Web;

namespace M4Trader.ordenes.server
{
    public class LoginCommandWeb : LoginCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            InfoCliente infoCliente = new InfoCliente(Utils.GetIpAddress(), "");
            HttpRequest req = HttpContext.Current.Request;
            if (req.UserAgent != null && req.UserAgent.Contains("Edge"))
                infoCliente.Dispositivo = "Edge - Versión: " + req.UserAgent.Substring(req.UserAgent.IndexOf("Edge") + 5);
            else
                infoCliente.Dispositivo = req.Browser.Browser + " - Versión: " + req.Browser.Version;
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(LoginHelper.Login(UserName, Password, infoCliente, TipoAplicacion.ORDENES));
        }
    }
}
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using System;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;
using System.Web;

namespace M4Trader.ordenes.server
{      
    [CommandType("TokCom", (int)IdAccion.Login, TipoAplicacion.API, TipoAplicacion.WEBEXTERNA, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.COMPLEMENTODMA, TipoAplicacion.DMA)]

    public class TokenCommand : ABMContextCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            string browser;
            try
            {
                HttpRequest req = HttpContext.Current.Request;
                if (req.UserAgent != null && req.UserAgent.Contains("Edge"))
                    browser = "Edge - Versión: " + req.UserAgent.Substring(req.UserAgent.IndexOf("Edge") + 5);
                else
                    browser = req.Browser.Browser + " - Versión: " + req.Browser.Version;
            }
            catch {
                browser = "Desconocido";
            }

            return ExecutionResult.ReturnInmediatelyAndQueueOthers(LoginHelper.ValidateToken(UserName, SecurityToken, IP, GuidToken, browser, tipoAplicacion));
        }
    
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Login;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string SecurityToken { get; set; }
        public string IP { get; set; }
        [DataMember]
        public Guid GuidToken { get; set; }
        [DataMember]
        public TipoAplicacion tipoAplicacion { get; set; }

        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }
    }
}
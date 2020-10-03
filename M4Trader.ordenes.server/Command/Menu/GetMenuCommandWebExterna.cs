using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{ 
    [CommandType("GetMenCom", (int)IdAccion.Menu, TipoAplicacion.WEBEXTERNA, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.API)]

    public class GetMenuCommandWebExterna : ABMContextCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            //InfoCliente infoCliente = new InfoCliente(IP, "WebExterna");
            MAEUserSession session = SessionHelper.GetSesionExistente(sessionId, (byte)TipoAplicacion.WEBEXTERNA);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(session);
        }
         
        [DataMember]
        public string sessionId { get; set; }
        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }
        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Menu;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

    }
}
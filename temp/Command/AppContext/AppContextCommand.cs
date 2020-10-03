using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server
{
    [CommandType("AppContextCommand", (int)IdAccion.AppContext, TipoAplicacion.API)]
    public class AppContextCommand : ABMContextCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(ContextHelper.get(inCourseRequest, WebUrlName));
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

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
                return (int)IdAccion.AppContext;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        public string WebUrlName { get; set; }
    }
}
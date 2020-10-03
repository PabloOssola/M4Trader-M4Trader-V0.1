using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server
{
    [CommandType("AppLitCom", (int)IdAccion.CachingManager, TipoAplicacion.WEBEXTERNA, TipoAplicacion.MOBILE, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.DMA, TipoAplicacion.API)]
    public class AppLiteralesCommand : ABMContextCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(LiteralesTraducidos.Instance.GetFullLists());
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
                return (int)IdAccion.CachingManager;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }
    }
}
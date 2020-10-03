using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class ObtenerEstadoSistemaCommand : ABMCommand
    {
        public override void Validate()
        {
            
        }

        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            try
            {
                var estado = CachingManager.Instance.GetFechaSistema();
                return ExecutionResult.ReturnInmediatelyAndQueueOthers(estado);
            }
            catch
            {
                return ExecutionResult.ReturnInmediatelyAndQueueOthers(null);
            }
        }


        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.EstadoSistema;
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
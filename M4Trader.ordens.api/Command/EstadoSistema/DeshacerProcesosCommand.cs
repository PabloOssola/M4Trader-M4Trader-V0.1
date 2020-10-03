using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class DeshacerProcesosCommand : ABMContextCommand
    {
        public DeshacerProcesosCommand(string singularEntityName, string pluralEntityName)
        {

        }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            int idEstadoSistema = context.EstadoSistema.Where(p1 => p1.IdEstadoSistema != 0).Max(r => r.IdEstadoSistema);
            var entidad = context.EstadoSistema.Where(p => p.IdEstadoSistema == idEstadoSistema).FirstOrDefault();

            if (entidad!=null)
            {
                entidad.EjecucionValidacion = false;
            }
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(entidad);
        }
        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            
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
                return (int)TipoPermiso.EJECUCION;
            }
        }
    }
}
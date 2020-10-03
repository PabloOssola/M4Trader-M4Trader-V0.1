using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class GetAccionCommand : ABMCommand
    {

        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            AccionEntity accion = CachingManager.Instance.GetAccionById(IdAccion);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { permisos = accion.HabilitarPermisos });
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }


        public override int GetIdAccion
        {
            get
            {
                return (int)M4Trader.ordenes.server.Entities.IdAccion.AccionRol;
            }
        }


        [DataMember]
        public short IdAccion { get; set; }
    }
}
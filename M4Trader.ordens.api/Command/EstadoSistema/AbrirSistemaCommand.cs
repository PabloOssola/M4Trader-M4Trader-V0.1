using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using System;
using M4Trader.ordenes.server.Helpers;
using System.Linq;
using System.Runtime.Serialization;
using System.Transactions;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class AbrirSistemaCommand : ABMContextCommand
    {
        public AbrirSistemaCommand()
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
            SistemaHelper.AbrirElDia((int)inCourseRequest.Identity_rid);

            int idEstadoSistema = context.EstadoSistema.Where(p1 => p1.IdEstadoSistema != 0).Max(r => r.IdEstadoSistema);
            var entidad = context.EstadoSistema.Where(p => p.IdEstadoSistema == idEstadoSistema).FirstOrDefault();
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(entidad);
        }
        
        public override void ExecuteAfterSuccess()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Suppress))
                {
                    SqlServerHelper.ExecuteNonQuery("shared_owner.SESSION_DELETE", null);
                    ts.Complete();
                }
            }
            catch { }
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
                /* Esto se debe a que cuando el sistema esta cerrado se resetean todos los permisos a CONSULTA*/
                return (int)TipoPermiso.EJECUCION;
            }
        }

        [DataMember]
        public DateTime FechaSistema { get; set; }

    }
}
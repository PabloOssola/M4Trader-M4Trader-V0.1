using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class ValidarProcesosCommand : ABMContextCommand
    {
        public ValidarProcesosCommand(string singularEntityName, string pluralEntityName)
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

            if (entidad != null)
            {
                entidad.EjecucionValidacion = true;
                var parms = new List<SqlParameter>();

                var parm = new SqlParameter("@FechaSistema", SqlDbType.Date)
                {
                    Value = CachingManager.Instance.GetFechaSistema().FechaSistema
                };
                parms.Add(parm);

                parm = new SqlParameter
                {
                    Direction = ParameterDirection.ReturnValue
                };
                parms.Add(parm);

                SqlServerHelper.ExecuteNonQuery("orden_owner.ESTSIS_ValidarCondicionesCambioEstadoParaFechaActual", parms);
                var hayProblemas = (int)parms[1].Value > 0;

                entidad.EjecucionValidacion = !hayProblemas;
            }
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(entidad);
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.EjecutarProcesosEncadenados;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.EJECUCION;
            }
        }

        public override void Validate()
        {

        }
    }
}
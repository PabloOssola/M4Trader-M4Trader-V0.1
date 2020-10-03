using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using M4Trader.ordenes.server.Helpers;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class CerrarSistemaCommand : ABMContextCommand
    {
        public CerrarSistemaCommand(string singularEntityName, string pluralEntityName)
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
            SistemaHelper.CerrarElDia((int)inCourseRequest.Identity_rid);

            OperacionHelper.ImpactarEnSaldosHistoricos(CachingManager.Instance.GetFechaSistema().FechaSistema);
        
            int idEstadoSistema = context.EstadoSistema.Where(p1 => p1.IdEstadoSistema != 0).Max(r => r.IdEstadoSistema);
            var entidad = context.EstadoSistema.Where(p => p.IdEstadoSistema == idEstadoSistema).FirstOrDefault();
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(entidad);

        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            //var parms = new List<SqlParameter>();
            //var parm = new SqlParameter("@FechaSistema", SqlDbType.Date);
            //parm.Value = CachingManager.Instance.GetFechaSistema().FechaSistema;
            //parms.Add(parm);

            //var res = SqlServerHelper.ExecuteScalar("orden_owner.ESTSIS_ValidarCondicionesCambioEstadoParaFechaActual", parms.ToList());
            //var hayProblemas = Convert.ToInt32(res) > 0;

            //if (hayProblemas)
            //{
            //    var keyArray = new KeyArray();
            //    keyArray.Codigo = CodigosMensajes.FE_HAY_OPERACIONES_SIN_LIQUIDAR;
            //    keyArray.Parametros.Add("EstadoSistema");
            //    var fe = new FunctionalException();
            //    fe.DataValidations.Add(keyArray);
            //    throw fe;
            //}
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
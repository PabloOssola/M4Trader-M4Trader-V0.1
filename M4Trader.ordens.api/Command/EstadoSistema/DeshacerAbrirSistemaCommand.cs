using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class DeshacerAbrirSistemaCommand : ABMContextCommand
    {
        public DeshacerAbrirSistemaCommand(string singularEntityName, string pluralEntityName)
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
                EstadoSistemaEntity request = entidad;
                request.EjecucionValidacion = true;
                request.EstadoAbierto = false;
                request.FechaCierre = AddWorkDays(entidad.FechaSistema,-1);
                request.FechaApertura = AddWorkDays(entidad.FechaSistema, -1);
                request.FechaSistema = AddWorkDays(entidad.FechaSistema, -1);
                request.IdUsuarioCierre = null;
                
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

        public static DateTime AddWorkDays(DateTime date, int workingDays)
        {
            int direction = workingDays < 0 ? -1 : 1;
            DateTime newDate = date;
            while (workingDays != 0)
            {
                newDate = newDate.AddDays(direction);
                if (newDate.DayOfWeek != DayOfWeek.Saturday &&
                    newDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays -= direction;
                }
            }
            return newDate;
        }
    }
}
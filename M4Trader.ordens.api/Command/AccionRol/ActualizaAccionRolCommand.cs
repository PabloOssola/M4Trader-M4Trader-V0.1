using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;

namespace M4Trader.ordenes.server
{
    public class ActualizaAccionRolCommand : AccionRolCommand
    {

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.AccionRol where d.IdAccionRol == r_id select d);
            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            AccionRolEntity request = entidad.FirstOrDefault();
            request.IdAccion = IdAccion;
            request.IdRol = IdRol;
            request.Permiso = sumUpPermissions();
            request.UltimaActualizacion = GetUltimaActualizacion(UltimaActualizacion);
            return null;
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }

        public override IQueryable<AccionRolEntity> GetAccionRoles()
        {
            return (from d in context.AccionRol where d.IdAccionRol != r_id && d.IdRol == IdRol && d.IdAccion == IdAccion select d);
        }
    }
}
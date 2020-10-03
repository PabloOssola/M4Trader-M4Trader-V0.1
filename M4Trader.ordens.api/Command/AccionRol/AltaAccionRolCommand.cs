using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;

namespace M4Trader.ordenes.server
{
    public class AltaAccionRolCommand : AccionRolCommand
    {

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            AccionRolEntity request = new AccionRolEntity()
            {
                IdAccion = IdAccion,
                IdRol = IdRol,
                Permiso = sumUpPermissions()
            };
            this.AgregarAlContextoParaAlta(request);
            return null;
        }

        public override IQueryable<AccionRolEntity> GetAccionRoles()
        {
            return (from d in context.AccionRol where d.IdRol == IdRol && d.IdAccion == IdAccion select d);
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)M4Trader.ordenes.server.Entities.IdAccion.AccionRol;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.ALTA;
            }
        }
    }
}
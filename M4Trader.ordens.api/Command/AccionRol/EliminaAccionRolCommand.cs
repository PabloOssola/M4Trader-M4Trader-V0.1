using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class EliminaAccionRolCommand : AccionRolCommand
    {

        public override void Validate()
        {
            NombreEntidad = "AccionRol";
            foreach (int id in Ids)
            {
                var accionRol = (from d in context.AccionRol where d.IdAccionRol == id select d);
                ValidateExiste(accionRol.Count(), id, CodigosMensajes.ERR_ELIMINA_ACCION_ROL_INEXISTENTE2);
            }
            if (!valida)
            {
                throw fe;
            }

        }

        public override IQueryable<AccionRolEntity> GetAccionRoles()
        {
            return null;
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            AccionRolEntity request;

            foreach (var id in Ids)
            {
                request = (from d in context.AccionRol where d.IdAccionRol == id select d).Single();
                context.Remove(request);
            }
            return null;
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.BAJA;
            }
        }


        [DataMember]
        public short[] Ids { get; set; }

    }
}
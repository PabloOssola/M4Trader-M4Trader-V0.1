using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;

namespace M4Trader.ordenes.server
{
    public class ActualizaAccionCommand : AccionCommand
    {

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.Acciones where d.IdAccion == r_id select d);
            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            AccionEntity request = entidad.FirstOrDefault();
            request.Descripcion = Descripcion;
            request.HabilitarPermisos = sumUpPermissions();
            return null;
        }

        public override void Validate()
        {
            NombreEntidad = "Accion";

            #region Requerido
            ValidateInt(sumUpPermissions(), "Permisos", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(Descripcion, "Descripción", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            #endregion Requerido

            #region Unicidad

            var coleccionDesc = (from d in context.Acciones where d.Descripcion == Descripcion && d.IdAccion != r_id select d);
            ValidateUnicidad(coleccionDesc, Descripcion, NombreEntidad, CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }


    }
}
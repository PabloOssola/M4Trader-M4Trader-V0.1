using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class AltaAccionCommand : AccionCommand
    {

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            AccionEntity request = new AccionEntity()
            {
                IdAccion = IdAccion,
                Descripcion = Descripcion,
                HabilitarPermisos = sumUpPermissions()
            };
            this.AgregarAlContextoParaAlta(request);
            return null;
        }

        public override void Validate()
        {
            NombreEntidad = "Accion";

            #region Requerido
            ValidateInt(IdAccion, "IdAcción", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateInt(sumUpPermissions(), "Permisos", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(Descripcion, "Descripción", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            #endregion Requerido

            #region Unicidad

            var coleccionDesc = (from d in context.Acciones where d.Descripcion == Descripcion select d);
            ValidateUnicidad(coleccionDesc, Descripcion, NombreEntidad, CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            var coleccionAcciones = (from d in context.Acciones where d.IdAccion == r_id select d);
            ValidateUnicidad(coleccionAcciones, r_id.ToString(), NombreEntidad, CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }
        }

        [DataMember]
        public short IdAccion { get; set; }

        public override int GetIdAccion
        {
            get
            {
                return (int)server.Entities.IdAccion.Accion;
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
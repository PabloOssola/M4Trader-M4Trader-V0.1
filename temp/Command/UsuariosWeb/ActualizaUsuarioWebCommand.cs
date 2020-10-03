using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System.Linq;

namespace M4Trader.ordenes.server
{
    [CommandType("ActualizaUsuarioWebCommand", (int)IdAccion.AdministracionUsuariosWeb, TipoAplicacion.WEBEXTERNASECURITY)]
    public class ActualizaUsuarioWebCommand : UsuarioWebCommand
    {
        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "Usuario";

            #region Requerido
            ValidateString(UserName, "Usuario", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(Name, "Nombre", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateInt(this.IdPersona, "Id Persona", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);


            #endregion Requerido


            #region Unicidad

            var coleccion = (from d in context.Usuario where d.Username == UserName && d.IdUsuario != r_id select d);
            ValidateUnicidad(coleccion, UserName, NombreEntidad, CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }

        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.Usuario where d.IdUsuario == r_id select d);
            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            MCContext.Entidades.UsuarioEntity request = entidad.FirstOrDefault();
            
            request.IdPersona = IdPersona;
            request.Username = UserName;
            request.Nombre = Name;
            request.Email = Email;
            SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.ActualizaUser, "Usuario actualizado: " + request.Username, (byte)TipoAplicacion.ORDENES);
            return null;
        }

        
        public override void ExecuteAfterSuccess()
        {

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
using M4Trader.ordenes.server.CQRSFramework;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System;
using System.Linq;

namespace M4Trader.ordenes.server
{

    public class AltaUsuarioCommand : UsuarioCommand
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
            ValidateString(Nombre, "Nombre", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(Password, "Contraseña", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(ConfirmPassword, "Confirmar Contraseña", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateInt(this.IdPersona, "Id Persona", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(RolesUsuario, "Roles", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);


            #endregion Requerido


            #region Unicidad

            var coleccion = (from d in context.Usuario where d.Username == UserName select d);
            ValidateUnicidad(coleccion, UserName, NombreEntidad, CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            
            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }

        }

        
        public override void ExecuteAfterSuccess()
        {
            // enviar correo de bienvenida
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            MCContext.Entidades.UsuarioEntity requestUsuario = new MCContext.Entidades.UsuarioEntity()
            {
                Username = UserName,
                Pass = MAETools.HashMD5(Password),
                Nombre = Nombre,
                Bloqueado = Bloqueado,
                NoControlarInactividad = NoControlarInactividad,
                Proceso = Proceso,
                IdPersona = IdPersona,
                UltimaModificacionPassword = DateTime.Now,
                UltimoLoginExitoso = DateTime.Now,
                ConfiguracionRegional = "es-AR"
            };
            foreach (string idRol in RolesUsuario.Split(','))
            {
                RolUsuarioEntity request = new RolUsuarioEntity()
                {
                    IdRol = short.Parse(idRol)

                };
                requestUsuario.RolUsuarioItems.Add(request);
            }
            this.AgregarAlContextoParaAlta(requestUsuario);
            SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.AltaUsuario, "Nuevo user: " + UserName, (byte)TipoAplicacion.ORDENES);
            return null;
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
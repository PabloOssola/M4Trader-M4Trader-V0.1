using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using M4Trader.ordenes.server.CQRSFramework;
using System;
using M4Trader.ordenes.server.Helpers;

namespace M4Trader.ordenes.server
{ 
    [CommandType("RegUsrCom", (int)IdAccion.RegistroUsuario, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.WEBEXTERNA)]
    public class RegistroUsuarioCommand : ABMContextCommand
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
            ValidateString(Email, "Email", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);

            ValidateEquality(Password, ConfirmPassword, "Confirma Password", CodigosMensajes.ERR_CONTRASENAS_DISTINTAS);
            ValidateEmail(Email, "Email", CodigosMensajes.ERR_MAL_FORMATO_MAIL);


            #endregion Requerido


            #region Unicidad
            List<MCContext.Entidades.UsuarioEntity> coleccion = new List<MCContext.Entidades.UsuarioEntity>();
            var user = CachingManager.Instance.GetUsuarioByUsername(UserName);
            if (user != null)
                coleccion.Add(user);
            ValidateUnicidad(coleccion.AsQueryable(), UserName, NombreEntidad, CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

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
            int PersonaId = (from d in context.Persona where d.MarketCustomerNumber == "000" select d).FirstOrDefault().IdParty;
            MCContext.Entidades.UsuarioEntity requestUsuario = new MCContext.Entidades.UsuarioEntity()
            {
                Username = UserName,
                Pass = MAETools.HashMD5(Password),
                Nombre = Nombre,
                Bloqueado = false,
                NoControlarInactividad = false,
                Proceso = false,
                IdPersona = PersonaId,
                UltimaModificacionPassword = DateTime.Now,
                UltimoLoginExitoso = DateTime.Now,
                Email = Email
            };
            AgregarRolesPorDefecto(requestUsuario);
            AgregarAlContextoParaAlta(requestUsuario);
            return null;
        }

        private void AgregarRolesPorDefecto(MCContext.Entidades.UsuarioEntity usuario)
        {
            List<RolEntity> listaRoles = CachingManager.Instance.GetAllRoles();
            RolUsuarioEntity request = new RolUsuarioEntity()
            {
                Usuario = usuario,
                IdRol = listaRoles.Find(x => x.Descripcion == "Anónimo").IdRol

            };
            usuario.RolUsuarioItems.Add(request);
            request = new RolUsuarioEntity()
            {
                Usuario = usuario,
                IdRol = listaRoles.Find(x => x.Descripcion == "Ingreso al Sistema").IdRol

            };
            usuario.RolUsuarioItems.Add(request);
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.ALTA;
            }
        }
        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.RegistroUsuario;
            }
        }


        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        public string RolesUsuario { get; set; }
    }
}

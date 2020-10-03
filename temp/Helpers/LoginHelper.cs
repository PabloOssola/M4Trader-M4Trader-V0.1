using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using MAE.Clearing.BusinessComponentLayer.Helpers;
using System;
using System.Linq;
using TokenResult = M4Trader.ordenes.services.Entities.TokenResult;

namespace M4Trader.ordenes.server.Helpers
{
    public static class LoginHelper
    {
        public static MAEUserSessionLogin Login(string userName, string password, InfoCliente infoCliente, TipoAplicacion tipoAplicacion, bool passHashed = false)
        {
            UserValido resultValidacion = new UserValido();

            try
            {
                resultValidacion = ValidateUser(userName, password, infoCliente, tipoAplicacion, passHashed);
            }

            catch (SessionException ex)
            {
                resultValidacion.NeedNewPassword = true;
                resultValidacion.IsOK = false;
                resultValidacion.MensajeError = ex.Code;
                resultValidacion.TokenGuid = "";
            }
            MAEUserSession usuarioSession = null;
            if(MAEUserSession.InstanciaCargada)
                usuarioSession = MAEUserSession.Instancia;
            

            MAEUserSessionLogin userSessionLogin = new MAEUserSessionLogin()
            {
                Ok = resultValidacion.IsOK,
                DobleAutenticacion = CachingManager.Instance.GetConfiguracionSeguridad().TieneDobleFactor,
                Message = resultValidacion.MensajeError,
                NeedNewPassword = resultValidacion.NeedNewPassword,
                TokenGuid = resultValidacion.TokenGuid,
                SessionId = (usuarioSession == null) ? "" : usuarioSession.ID,
                UserName = (usuarioSession == null) ? "" : usuarioSession.UserName,
                EstadoSistema = (usuarioSession == null) ? "" : usuarioSession.EstadoSistema,
                TipoPersona = (usuarioSession == null) ? "" : UserHelper.getNombreTipoPersona(usuarioSession.IdTipoPersona),
                NombrePersona = (usuarioSession == null) ? "" : UserHelper.GetNombrePersona(usuarioSession.IdPersona),
                FechaSistema = CachingManager.Instance.GetFechaSistema().FechaSistema,
                FechaFinalizacionSesion = (usuarioSession == null) ? DateTime.Now : usuarioSession.FechaFinalizacion,
                JavascriptAllowedCommands = (usuarioSession == null) ? new System.Collections.Generic.Dictionary<string, string>() :usuarioSession.JavascriptAllowedCommands,
                PermisosUsuario = (usuarioSession == null) ? new System.Collections.Generic.Dictionary<string, bool>() : usuarioSession.PermisosUsuario,
                LoginRealizado = (usuarioSession == null) ? false : usuarioSession.LoginRealizado,

            };
            return userSessionLogin;
        }

        public static void Login(InfoCliente infoCliente, UsuarioEntity datosLogin, bool isPassHash = false, TipoAplicacion idAplicacion = TipoAplicacion.ORDENES)
        {
            UsuarioEntity usuario = ValidateUser(datosLogin.Username);
            var configuracionSeguridad = CachingManager.Instance.GetConfiguracionSeguridad();
            ValidarAccesoAlSistema(usuario.IdUsuario);
            string userPass = isPassHash ? datosLogin.Pass : MAETools.HashMD5(datosLogin.Pass);
            if (usuario.Pass != userPass)
            {
                ManejarErrorDeAutenticacion(usuario, configuracionSeguridad, idAplicacion);
            }
            ValidarReseteoPassword(usuario);
            ValidarDiasCambioPassword(configuracionSeguridad.DiasCambioPassword, usuario);
            UserHelper.ValidaUsuarioActivo(configuracionSeguridad.MaximoDiasInactividad, usuario);

            if (usuario.Expiracion.HasValue && usuario.Expiracion.Value.Date <= DateTime.Now)
            {
                UserHelper.BlockUsuarios(usuario.IdUsuario, (byte)LogCodigoAccionSeguridad.UsuarioBloqueadoPorCtaExpirada);
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CUENTA_EXPIRADA, false, usuario.Username);
            }

            if (usuario.Proceso)
                SessionHelper.InitSession(infoCliente, usuario, idAplicacion);
        }

        public static TokenResult ValidateToken(string userName, string token, string iP, Guid guidToken, string browser, TipoAplicacion idAplicacion)
        {

            var result = OrdenesApplication.Instance.DoubleAuthenticationService.ValidateToken(guidToken, userName, token);
            TokenResult tokenResult = new TokenResult();
            if (result)
            {
                UsuarioEntity usuario = CachingManager.Instance.GetUsuarioByUsername(userName);
                InfoCliente infoCliente = new InfoCliente(Utils.GetIpAddress(), browser);

                SessionHelper.InitSession(infoCliente, usuario, idAplicacion);
                tokenResult.Ok = true;
                tokenResult.IdSesion = MAEUserSession.Instancia.ID;
                return tokenResult;
            }
            else
            {
                tokenResult.Ok = false;
            }
            return tokenResult;
        }


        private static UserValido ValidateUser(string UserName, string Password, InfoCliente infoCliente, TipoAplicacion tipoAplicacion, bool passHashed)
        {
            var configuracionSeguridad = CachingManager.Instance.GetConfiguracionSeguridad();

            Guid tokenGuid;
            UserValido response = new UserValido();
            response.IsOK = false;
            try
            {
                if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
                {
                    response.MensajeError = "El nombre de usuario y la contraseña no pueden estar vacíos.";
                    response.IsOK = false;
                    return response;
                }

                tokenGuid = DoLogIn(UserName, Password, infoCliente, tipoAplicacion, passHashed);

                if (tokenGuid != Guid.Empty)
                {
                    response.IsOK = true;
                    response.TokenGuid = tokenGuid.ToString();
                    int IdUsuario = CachingManager.Instance.GetUsuarioByUsername(UserName).IdUsuario;
                    DTOPortfolio portfolioPorDefecto = CachingManager.Instance.GetPortfolioDefaultByIdUsuario(IdUsuario);
                    if (portfolioPorDefecto == null)
                    {
                        response.MensajeError = "El Usuario debe tener al menos un portfolio por defecto!.";
                        response.IsOK = false;
                        return response;
                    }
                }
                else
                {
                    response.MensajeError = "Verifique el nombre de usuario y contraseña.";
                    response.IsOK = false;
                }
            }
            catch (M4TraderApplicationException ex)
            {
                if (ex.Codigo == "W100002")
                {
                    response.MensajeError = "Por políticas de seguridad debe cambiar la contraseña.";
                    response.IsOK = false;
                    response.NeedNewPassword = true;
                    return response;
                }
                else
                {
                    response.MensajeError = ex.Message;
                    response.IsOK = false;
                }
            }
            catch (SessionException ex)
            {
                if (ex.Code == "W100002")
                {
                    response.NeedNewPassword = true;
                    response.MensajeError = "Por políticas de seguridad debe cambiar la contraseña.";
                    response.IsOK = false;
                    return response;
                }
                else
                {
                    response.MensajeError = ex.Message;
                    response.IsOK = false;
                }
            }
            catch (Exception ex)
            {
                response.MensajeError = ex.Message;
                response.IsOK = false;
            }
            return response;
        }

        private static UsuarioEntity ValidateUser(string Username)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            using (OrdenesContext mcc = new OrdenesContext())
            {
                usuario = (from d in mcc.Usuario where d.Username.Equals(Username) select d).FirstOrDefault();
            }
            if (usuario == null)
            {
                SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.UsuarioInexistente, "Username ingresado: " + Username, (byte)TipoAplicacion.ORDENES);
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_AUTHENTICATEUSUARIO, false);
            }
            if (usuario.BajaLogica)
            {
                SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.UsuarioBajaLogica, null, (byte)TipoAplicacion.ORDENES);
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_AUTHENTICATEUSUARIO, false);
            }
            if (usuario.Bloqueado)
            {
                SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.UsuarioBloqueado, null, (byte)TipoAplicacion.ORDENES);
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_USUARIOBLOQUEADO, false, usuario.Username);
            }
            return usuario;
        }

        private static Guid DoLogIn(string userName, string Password, InfoCliente infoCliente, TipoAplicacion tipoAplicacion, bool passHashed)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.Username = userName;
            usuario.Pass = Password;
            ResponseDoubleAuthentication response = new ResponseDoubleAuthentication();

            Login(infoCliente, usuario, idAplicacion: tipoAplicacion);

            var configuracionSeguridad = CachingManager.Instance.GetConfiguracionSeguridad();
            if (!configuracionSeguridad.TieneDobleFactor || (TipoAplicacion.ORDENES != tipoAplicacion && TipoAplicacion.WEBEXTERNA != tipoAplicacion && TipoAplicacion.DMA != tipoAplicacion && TipoAplicacion.COMPLEMENTODMA != tipoAplicacion))
            {
                using (OrdenesContext mcc = new OrdenesContext())
                {
                    usuario = (from d in mcc.Usuario where d.Username.Equals(userName) select d).FirstOrDefault();
                }
                SessionHelper.InitSession(infoCliente, usuario, idAplicacion: tipoAplicacion);
                SetLoginExitoso(MAEUserSession.Instancia.IdUsuario);

                return MAEUserSession.Instancia.InternalId;
            }

            var url = OrdenesApplication.Instance.ContextoAplicacion.Urls.Find(f => f.TipoUrl == ConfiguracionSistemaURLsEnumDestino.DoubleAuthentication);

            Guid guidToken = Guid.NewGuid();
            var telefono = CachingManager.Instance.GetPersonaById((int)CachingManager.Instance.GetUsuarioByUsername(userName).IdPersona).Phone;
            response = OrdenesApplication.Instance.DoubleAuthenticationService.GetToken(guidToken, telefono, url.Url);


            if (!response.IsOk)
            {
                throw new M4TraderApplicationException(response.Error);
            }

            return guidToken;
        }




        public static void ValidarAccesoAlSistema(int idUsuario)
        {
            RolEntity rolAccesoSistema = CachingManager.Instance.GetRolByValorNumerico(OrdenesApplication.Instance.RolIngreso);
            RolUsuarioEntity rolUsuarioId = CachingManager.Instance.GetRolesUsuario(idUsuario).Find(d => d.IdRol == rolAccesoSistema.IdRol);
            if (rolUsuarioId == null || rolUsuarioId.IdRol != rolAccesoSistema.IdRol)
            {
                var codigo = CodeMensajes.ERR_SIN_PERMISO_ACCESO;
                AdministradorControlErrores.EnviarExcepcion(codigo, false);
            }
        }



        private static int? IncreaseIntentos(UsuarioEntity user)
        {
            UsuarioEntity usuario = null;
            using (OrdenesContext context = new OrdenesContext())
            {
                usuario = (from d in context.Usuario
                           where d.BajaLogica == false
                           && d.IdUsuario == user.IdUsuario
                           select d).FirstOrDefault();
                usuario.CantidadIntentos += 1;
                context.SaveChanges();
            }
            return usuario.CantidadIntentos;
        }

        private static void ValidarReseteoPassword(UsuarioEntity user)
        {
            if (user.ResetPassword)
            {
                var codigo = CodeMensajes.WAR_CAMBIAR_CLAVE_ACCESO;
                AdministradorControlErrores.EnviarExcepcion(codigo, false);
            }
        }

        private static void ValidarDiasCambioPassword(int diasCambioPassword, UsuarioEntity user)
        {
            if (user.Proceso)
            {
                return;
            }
            if (!user.UltimaModificacionPassword.HasValue || diasCambioPassword == 0)
                return;
            if (MAEDateTimeTools.DateTimeAdd(user.UltimaModificacionPassword.Value, diasCambioPassword, "d").Date <= DateTime.Now.Date)
            {
                var codigo = CodeMensajes.WAR_CAMBIAR_CLAVE_ACCESO;
                AdministradorControlErrores.EnviarExcepcion(codigo, false);
            }
        }

        public static void SetLoginExitoso(int idUsuario)
        {
            try
            {
                using (OrdenesContext context = new OrdenesContext())
                {
                    UsuarioEntity user = (from d in context.Usuario
                                          where d.IdUsuario == idUsuario
                                          && d.BajaLogica == false
                                          select d).FirstOrDefault();
                    user.UltimaModificacionPassword = (user.UltimaModificacionPassword == null) ? DateTime.Now : user.UltimaModificacionPassword;
                    user.UltimoLoginExitoso = DateTime.Now;
                    user.LoginRealizado = true;
                    user.CantidadIntentos = 0;
                    context.SaveChanges();
                }
            }
            catch
            {
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_SET_LOGINEXITOSO_USUARIO, false);
            }
        }

        private static void ManejarErrorDeAutenticacion(UsuarioEntity usuario, ConfiguracionSeguridadEntity configuracionSeguridad, TipoAplicacion idAplicacion = TipoAplicacion.ORDENES)
        {
            string codigo = CodeMensajes.ERR_AUTHENTICATEUSUARIO;

            usuario.CantidadIntentos = IncreaseIntentos(usuario);

            if (configuracionSeguridad.CantidadIntentosMaximo > 0)
            {
                if (usuario.CantidadIntentos >= configuracionSeguridad.CantidadIntentosMaximo)
                {
                    UserHelper.BlockUsuarios(usuario.IdUsuario, (byte)LogCodigoAccionSeguridad.MaximosIntentos);
                    codigo = CodeMensajes.ERR_ALCANZO_MAXIMO_INTENTOS;
                }
            }
            AdministradorControlErrores.EnviarExcepcion(codigo, false, usuario.Username);
        }

        public static void Logout(string sessionId, byte IdAplicacion = (byte)TipoAplicacion.ORDENES)
        {
            try
            {
                Guid id = OrdenesApplication.Instance.GetSessionIdFromRequest(sessionId);
                MAEUserSession userSession = SessionHelper.GetByIDSesiones(id);
                if (userSession != null)
                { 
                    userSession.FechaFinalizacion = DateTime.Now;
                    SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.CierreSesionExitoso, "usuario: " + userSession.UserName, IdAplicacion);
                    UsuarioEntity user = CachingManager.Instance.GetByIdUsuario(userSession.IdUsuario);
                    SessionHelper.UpdateSesionesContext(userSession, true);
                    //CachingManager.Instance.ClearSession(userSession.InternalId);
                }
            }
            catch (Exception e)
            {
                SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.CierreSesionNoExitoso, "Error: " + e.Message, IdAplicacion);
                throw new M4TraderApplicationException("Error al desloguearse de la aplicación: " + e.Message);
            }
        }


        private class UserValido
        {
            public bool IsOK { get; set; }
            public string MensajeError { get; set; }
            public bool NeedNewPassword { get; set; }
            public string TokenGuid { get; set; }
        }


    }


}

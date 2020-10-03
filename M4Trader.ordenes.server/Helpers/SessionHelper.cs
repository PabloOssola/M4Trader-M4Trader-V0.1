using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using Sodium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace M4Trader.ordenes.server.Helpers
{

    public static class SessionHelper
    {
        private static object syncSession = new object();

        public static string SaldosXmlPath
        {
            get
            {
                return

                    Path.Combine(HostingEnvironment.MapPath("~/XMLFiles/Saldos/SaldoEntity.xml"));
            }
        }

        public static void InsertarLogSeguridad(byte codigo, string descripcion, byte IdAplicacion = (byte)TipoAplicacion.ORDENES)
        {
            MAEUserSession M4TraderUserSession = MAEUserSession.InstanciaCargada ? MAEUserSession.Instancia : null;
            LogSeguridadEntity lse = new LogSeguridadEntity
            {
                IdLogCodigoAccion = codigo,
                Fecha = DateTime.Now,
                Descripcion = descripcion,
                IdAplicacion = IdAplicacion,
                IdUsuario = M4TraderUserSession?.IdUsuario
            };
            LoggingService.Instance.AgregarLog(lse);
        }


        public static MAEUserSession GetSesionExistente(string idsession, byte IdAplicacion = (byte)TipoAplicacion.ORDENES)
        {
            Guid id = OrdenesApplication.Instance.GetSessionIdFromRequest(idsession);
            return GetSesionExistente(id, IdAplicacion);
        }

        public static MAEUserSession GetSesionExistente(Guid idSesion, byte IdAplicacion = (byte)TipoAplicacion.ORDENES)
        {
            MAEUserSession session = GetByIDSesiones(idSesion);

            // OK existe la sesion?

            if (session == null)
            {
                InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.SesionExpirada, null, IdAplicacion);
                throw new SessionException(CodeMensajes.ERR_EXPIRO_SESION);
            }
            //Compara las fechas de las sesiones
            if (session.FechaFinalizacion < DateTime.Now)
            {
                UsuarioEntity u = UserHelper.GetByIDUsuarios(session.IdUsuario);
                if (!u.Proceso)
                {
                    InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.SesionExpirada, null, IdAplicacion);
                    throw new SessionException("La sesión se ha vencido.");
                }
                else
                {
                    var _beSeteos = CachingManager.Instance.GetConfiguracionSeguridad();
                    ExtenderSesion(session, _beSeteos);
                }
            }
            else
            {
                // Intenta extender la pass
                var _beSeteos = CachingManager.Instance.GetConfiguracionSeguridad();
                if (session.FechaFinalizacion <
                    (MAEDateTimeTools.DateTimeAdd(DateTime.Now, _beSeteos.TimeOutInicialSesion + _beSeteos.TimeOutExtensionSesion, "s")))
                {
                    ExtenderSesion(session, _beSeteos);
                }
            }
            MAEUserSession.CargarInstancia(session);
            return session;
        }

        private static void ExtenderSesion(MAEUserSession session, ConfiguracionSeguridadEntity _beSeteos)
        {
            session.FechaInicio = DateTime.Now;
            session.FechaFinalizacion = MAEDateTimeTools.DateTimeAdd(DateTime.Now, _beSeteos.TimeOutInicialSesion, "s");
            UpdateSesionesContext(session);
        }

        public static MAEUserSession GetByIDSesiones(Guid idSesion)
        {
            SesionEntity se = PersistSessionHelper.Instance.GetSessionById(idSesion);
            if (se != null)
            {
                if (se.MaeUserSession == null)
                {
                    PartyEntity pe = CachingManager.Instance.GetPersonaById(se.IdPersona);
                    UsuarioEntity us = CachingManager.Instance.GetByIdUsuario(se.IdUsuario);
                    se.MaeUserSession = new MAEUserSession();
                    se.MaeUserSession.ID = OrdenesApplication.Instance.GetSessionIdForRequest(se.IdSesion.ToString());
                    se.MaeUserSession.InternalId = se.IdSesion;
                    se.MaeUserSession.IdUsuario = se.IdUsuario;
                    se.MaeUserSession.Ip = se.Ip;
                    se.MaeUserSession.FechaInicio = se.FechaInicio;
                    se.MaeUserSession.FechaFinalizacion = se.FechaFinalizacion;
                    se.MaeUserSession.IdAplicacion = se.IdAplicacion;
                    se.MaeUserSession.UltimaActualizacion = se.UltimaActualizacion;
                    se.MaeUserSession.IdPersona = se.IdPersona;
                    se.MaeUserSession.IdTipoPersona = pe.IdPartyType;
                    se.MaeUserSession.UserName = us.Nombre;
                    //se.MaeUserSession.IdEmpresa = pe.IdEmpresa;
                    se.MaeUserSession.Global = se.Global;
                    se.MaeUserSession.PrivateKey = se.PrivateKey;
                    se.MaeUserSession.PublicKey = se.PublicKey;
                    se.MaeUserSession.ClientPublic = se.ClientPublic;
                    se.MaeUserSession.ClientSecret = se.ClientSecret;
                    se.MaeUserSession.ServerPublic = se.ServerPublic;
                    se.MaeUserSession.ServerSecret = se.ServerSecret;
                    se.MaeUserSession.Nonce = se.Nonce;
                    se.MaeUserSession.JavascriptAllowedCommands = se.JavascriptAllowedCommands;
                    se.MaeUserSession.PermisosUsuario = se.PermisosUsuario;
                    se.MaeUserSession.AllowedCommands = se.AllowedCommands;
                    se.MaeUserSession.ConfiguracionRegional = se.ConfiguracionRegional;
                    se.MaeUserSession.LoginRealizado = CachingManager.Instance.GetByIdUsuario(se.IdUsuario).LoginRealizado;
                }
                return se.MaeUserSession;
            }
            return null;
        }

        private static void CreateSesiones(MAEUserSession be, byte idAplicacion)
        {
            SesionEntity se = new SesionEntity();
            se.IdUsuario = be.IdUsuario;
            se.Ip = be.Ip;
            se.FechaInicio = be.FechaInicio;
            se.FechaFinalizacion = be.FechaFinalizacion;
            se.IdAplicacion = be.IdAplicacion;
            se.IdPersona = be.IdPersona;
            se.IdSesion = Guid.NewGuid();
            se.modifiedOrNew = true;
            se.Global = be.Global;
            se.PrivateKey = be.PrivateKey;
            se.PublicKey = be.PublicKey;
            se.ServerPublic = be.ServerPublic;
            se.ServerSecret = be.ServerPublic;
            se.ClientPublic = be.ClientPublic;
            se.ClientSecret = be.ClientSecret;
            se.Nonce = be.Nonce;
            se.JavascriptAllowedCommands = be.JavascriptAllowedCommands;
            se.PermisosUsuario = be.PermisosUsuario;
            se.AllowedCommands = be.AllowedCommands;
            se.ConfiguracionRegional = be.ConfiguracionRegional;
            PersistSessionHelper.Instance.AddOrUpdate(se);
            be.InternalId = se.IdSesion;
            be.ID = OrdenesApplication.Instance.GetSessionIdForRequest(se.IdSesion.ToString());
            GetSesionExistente(se.IdSesion, idAplicacion);
        }

        public static void InitSession(InfoCliente infoCliente, UsuarioEntity usuario, TipoAplicacion idAplicacion = TipoAplicacion.ORDENES)
        {
            MAEUserSession userSession = new MAEUserSession();
            var configuracionSeguridad = CachingManager.Instance.GetConfiguracionSeguridad();
            userSession.IdPersona = (int)usuario.IdPersona;
            userSession.IdUsuario = usuario.IdUsuario;
            userSession.Ip = infoCliente.Ip;
            userSession.Dispositivo = infoCliente.Dispositivo;
            userSession.FechaInicio = DateTime.Now;
            userSession.FechaFinalizacion = MAEDateTimeTools.DateTimeAdd(DateTime.Now, configuracionSeguridad.TimeOutInicialSesion, "s");
            userSession.IdAplicacion = (byte)idAplicacion;
            userSession.UltimaActualizacion = usuario.UltimaActualizacion;
            userSession.ConfiguracionRegional = usuario.ConfiguracionRegional;

            //AESEncryptor encryptor = new AESEncryptor();
            //userSession.Global = encryptor.GetUniqueKey();
            //SecurityHelper.GetRSAKey(ref userSession);
            var clientKeyPair = PublicKeyBox.GenerateKeyPair();
            var serverKeyPair = PublicKeyBox.GenerateKeyPair();
            userSession.PrivateKey = Convert.ToBase64String(clientKeyPair.PrivateKey);
            userSession.PublicKey = Convert.ToBase64String(clientKeyPair.PublicKey);

            userSession.ClientPublic = Convert.ToBase64String(clientKeyPair.PublicKey);
            userSession.ClientSecret = Convert.ToBase64String(clientKeyPair.PrivateKey);
            userSession.ServerPublic = Convert.ToBase64String(serverKeyPair.PublicKey);
            userSession.ServerSecret = Convert.ToBase64String(serverKeyPair.PrivateKey);
            userSession.Nonce = Convert.ToBase64String(PublicKeyBox.GenerateNonce());
            userSession.AllowedCommands = new Dictionary<string, Type>();
            userSession.JavascriptAllowedCommands = new Dictionary<string, string>();
            userSession.PermisosUsuario = new Dictionary<string, bool>();
            List<Permiso> PermisosUsuario = CachingManager.Instance.GetAllPermisosByIdUsuario(userSession.IdUsuario);
            Dictionary<string, int> mapeoAcciones = new Dictionary<string, int>();
            var Acciones = CachingManager.Instance.GetAllAcciones();
            OrdenesApplication.Instance.GetComandosHabilitados(idAplicacion)
                .ForEach(cmd =>
                {
                    var k = OrdenesApplication.Instance.Encryptor.DynamicEncryption(cmd.FullName);
                    userSession.AllowedCommands.Add(k, cmd.CommandType);
                    userSession.JavascriptAllowedCommands.Add(cmd.Key, k);
                    mapeoAcciones.Add(k, cmd.IdAccion);
                });
            foreach (KeyValuePair<string, int> kv in mapeoAcciones)
            {
                Permiso p = PermisosUsuario.Find(x => x.IdAccion == kv.Value);
                if (p != null)
                {
                    var permisoAccion = Acciones.Find(x => x.IdAccion == kv.Value).HabilitarPermisos;
                    bool habilitado = (p.Permisos & permisoAccion) != 0;
                    userSession.PermisosUsuario.Add(kv.Key, habilitado);
                }
            }
            CreateSesiones(userSession, (byte)idAplicacion);
            InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.InicioSesion, "Inicio de sesión exitoso", (byte)idAplicacion);
        }

        public static void Logout(MAEUserSession be)
        {
            try
            {
                be.FechaFinalizacion = DateTime.Now;
                UsuarioEntity user = CachingManager.Instance.GetByIdUsuario(be.IdUsuario);
                string descripcion = CodeMensajes.GetDescripcionMensaje(CodeMensajes.INF_CIERRE_SESION);
                UpdateSesionesContext(be);
                //CachingManager.Instance.ClearSession(be.InternalId);
                //PersistSessionHelper.Instance.DeleteSession(be.ID);
            }
            catch (Exception e)
            {
                throw new M4TraderApplicationException("Error al desloguearse de la aplicación: " + e.Message);
            }
        }


        public static void UpdateSesionesContext(MAEUserSession be, bool finalizadaPorLogout = false)
        {
            lock (syncSession)
            {
                SesionEntity se = PersistSessionHelper.Instance.GetSessionById(be.InternalId);
                se.FechaFinalizacion = be.FechaFinalizacion;
                se.IdPersona = be.IdPersona;
                se.modifiedOrNew = true;
                se.FinalizadaPorLogout = finalizadaPorLogout;
                PersistSessionHelper.Instance.AddOrUpdate(se);
            }
        }
    }
}

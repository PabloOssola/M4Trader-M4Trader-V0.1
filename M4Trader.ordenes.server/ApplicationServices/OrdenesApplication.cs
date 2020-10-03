using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.Configuration;
using M4Trader.ordenes.server.CQRSFramework.Cryptography;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using Mae.Ordenes.Framework;
using MAE.Clearing.BusinessComponentLayer.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading;
using System.Web.Hosting;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public enum RolesIngresoAplicacion : int
    {
        WEB = 1,
        MOBILE = 1,
        API = 1,
        EXTRANET = 1
    }

    public interface DMAOperationContext
    {
        string GetSecurityTokenIdFromHeader();
        string GetSecurityAgenciaFromHeader();
    }


    public class HttpOperationContext : DMAOperationContext
    {
        public string GetSecurityTokenIdFromHeader()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string securitytokenid = headers["securitytokenid"];
            return securitytokenid;
        }
        public string GetSecurityAgenciaFromHeader()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string agencia = headers["Agencia"];
            return agencia;
        }
    }

    public class TcpOperationContext : DMAOperationContext
    {
        public string GetSecurityTokenIdFromHeader()
        {
            return OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("securitytokenid", "ns").ToString();
        }
        public string GetSecurityAgenciaFromHeader()
        {
            return OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("Agencia", "ns").ToString();
        }
        
    }


    public class OrdenesApplication
    {
        #region Singleton
        private List<IApplicationServiceStarter> services = null;
        private List<Thread> threads = null;
        private List<ManualResetEvent> manualResetEvents = null;
        private MAEUserSession sessionUsuarioProceso = null;
        private Dictionary<TipoAplicacion, List<AtributoComando>> comandosHabilitadosPorTipoAplicacion = null;
        private Dictionary<TipoAplicacion, List<AtributoComando>> comandosIniciales = null;
        private DMAOperationContext DMAOC;


        private static OrdenesApplication _instance = null;

        private static object syncRoot = new object();

        public static OrdenesApplication Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new ApplicationException("La aplicacion no esta inicializada, por favor configure en Global.AplicationStart el inicio de OrdenesApplication");
                }
                return _instance;
            }
        }
        #endregion


        private void setOperationContext()
        {
            if (OperationContext.Current.IncomingMessageHeaders.To.ToString().StartsWith("net.tcp"))
            {
                DMAOC = new TcpOperationContext();
            }
            else
            {
                DMAOC = new HttpOperationContext();
            }
        }

        public Guid GetSecurityTokenIdFromHeader()
        {

            if (DMAOC == null)
            {
                setOperationContext();
            }
            string securitytokenid = DMAOC.GetSecurityTokenIdFromHeader();
            return GetSessionIdFromRequest(securitytokenid);
        }

        public string GetSecurityAgenciaFromHeader()
        {

            if (DMAOC == null)
            {
                setOperationContext();
            }
            string agencia = DMAOC.GetSecurityAgenciaFromHeader();
            return agencia;
        }

        public int RolIngreso { get; set; }
        public IEncryptable Encryptor { get; private set; }
        public ContextoAplicacion ContextoAplicacion { get; set; }
        public IEncryptable CommandEncryptor { get; private set; }

        public IDoubleAuthenticationService DoubleAuthenticationService { get; set; }
        public MAEUserSession SessionUsuarioProceso { get => sessionUsuarioProceso; }
        public List<AtributoComando> GetComandosHabilitados(TipoAplicacion tipo)
        {
            List<AtributoComando> comandos = new List<AtributoComando>();
            comandosHabilitadosPorTipoAplicacion.TryGetValue(tipo, out comandos);
            return comandos;
        }
        public List<AtributoComando> GetComandosIniciales(TipoAplicacion tipo)
        {
            List<AtributoComando> comandos = new List<AtributoComando>();
            comandosIniciales.TryGetValue(TipoAplicacion.API, out comandos);
            return comandos;
        }



        public List<TipoAplicacion> Commands { get; set; }

        private OrdenesApplication()
        {
            this.services = new List<IApplicationServiceStarter>();
            this.threads = new List<Thread>();
            this.comandosHabilitadosPorTipoAplicacion = new Dictionary<TipoAplicacion, List<AtributoComando>>();
            this.comandosIniciales = new Dictionary<TipoAplicacion, List<AtributoComando>>();
            this.manualResetEvents = new List<ManualResetEvent>();
        }

        public void AddService(IApplicationServiceStarter service)
        {
            services.Add(service);
        }

        public static void StartApplication(
            List<IApplicationServiceStarter> services,
            RolesIngresoAplicacion rolIngreso,// List<TipoAplicacion> commands,
            IEncryptable encriptor = null, IEncryptable commandEncryptor = null)
        {
            if (_instance != null)
                throw new ApplicationException("La aplicacion ya se encuentra inicializada");

            lock (syncRoot)
            {
                if (_instance == null)
                {
                    _instance = new OrdenesApplication();
                    _instance.RolIngreso = (int)rolIngreso;
                    _instance.Encryptor = encriptor ?? new NonEncryptor();
                    _instance.CommandEncryptor = commandEncryptor ?? new NonEncryptor();
                    _instance.ContextoAplicacion = new ContextoAplicacion();
                    _instance.services.AddRange(services);
                    //_instance.Commands = commands;
                }
            }
        }
        private void LoginProcessUser()
        {
            UsuarioEntity usuario = new UsuarioEntity();
            usuario.Username = "UsuarioProceso";
            usuario.Pass = "YvanEhtNioj";
            InfoCliente infoCliente = new InfoCliente(Utils.GetIpAddress(), "LoginProcessUser");
            LoginHelper.Login(infoCliente, usuario, false, TipoAplicacion.API);
            sessionUsuarioProceso = MAEUserSession.Instancia;
        }

        public void StartAllServices()
        {

            this.CargarComandosHabilitados();
            this.InicializarDatos();
            this.LoginProcessUser();
            this.InicializarDobleAutenticacion();


            foreach (IApplicationServiceStarter service in this.services)
            {
                Thread t = new Thread(new ThreadStart(service.Start));
                t.Name = service.ServiceName;
                this.threads.Add(t);
            }

            Guid guid = Guid.NewGuid();
            this.threads.ForEach(s =>
            {
                try
                {
                    LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Descripcion = s.Name, IdLogCodigoAccion = (byte)LogCodigoAccionSeguridad.IniciandoServicio, Fecha = DateTime.Now });

                    s.Start();

                    LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Descripcion = s.Name, IdLogCodigoAccion = (byte)LogCodigoAccionSeguridad.ServicioIniciadoCorrectamente, Fecha = DateTime.Now });
                }
                catch (Exception ex)
                {
                    LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Descripcion = s.Name, IdLogCodigoAccion = (byte)LogCodigoAccionSeguridad.ServicioIniciadoConError, Fecha = DateTime.Now, Exception = ex });

                }
            });
        }

        private void InicializarDobleAutenticacion()
        {
            var configuracionSeguridad = CachingManager.Instance.GetConfiguracionSeguridad();

            if (configuracionSeguridad.TieneDobleFactor)
            {
                Type tp = Type.GetType(configuracionSeguridad.DobleAutenticacion);
                if (tp != null)
                {
                    this.DoubleAuthenticationService = (IDoubleAuthenticationService)Activator.CreateInstance(tp);
                }
            }
        }

        private void InicializarDatos()
        {
            this.RefreshConfiguracionSistema(false);
            LiteralesTraducidos.Instance.Init();
            TraductorLiterales.ObtenerMensajes("es-AR");
            TraductorLiterales.ObtenerMensajes("pt-BR");
            TraductorLiterales.ObtenerMensajes("en-US");

            TraductorLiterales.ObtenerTraducciones("es-AR");
            TraductorLiterales.ObtenerTraducciones("pt-BR");
            TraductorLiterales.ObtenerTraducciones("en-US");
            
        }

        private void CargarComandosHabilitados()
        {
            var assembly = typeof(LoginCommand).Assembly;
            var commandAttruibute = typeof(CommandTypeAttribute);
            CommandTypeAttribute aa = null;
            //List<AtributoComando> dmaComandos = new List<AtributoComando>();
            List<AtributoComando> apiComandos = new List<AtributoComando>();
            //List<AtributoComando> extranetComandos = new List<AtributoComando>();
            //List<AtributoComando> securityComandos = new List<AtributoComando>();
            //List<AtributoComando> ordenesComandos = new List<AtributoComando>();
            //List<AtributoComando> complementoDMAComandos = new List<AtributoComando>();
            AtributoComando comando = null;

            foreach (var t in assembly.GetTypes())
            {
                comando = new AtributoComando();
                var custom = t.GetCustomAttributes(commandAttruibute, false);
                if (custom.Length == 0)
                    continue;

                aa = (CommandTypeAttribute)custom[0];
                comando.FullName = t.FullName;
                comando.Key = aa.Key;
                comando.IdAccion = aa.IdAccion;
                comando.CommandType = aa.GetType();
                comando.CommandType = t;

                if (aa.TipoAplicacion.Contains(TipoAplicacion.API))
                {
                    apiComandos.Add(comando);
                }
                //if (aa.TipoAplicacion.Contains(TipoAplicacion.DMA))
                //{
                //    dmaComandos.Add(comando);
                //}
                //if (aa.TipoAplicacion.Contains(TipoAplicacion.WEBEXTERNA))
                //{
                //    extranetComandos.Add(comando);
                //}
                //if (aa.TipoAplicacion.Contains(TipoAplicacion.WEBEXTERNASECURITY))
                //{
                //    securityComandos.Add(comando);
                //}
                //if (aa.TipoAplicacion.Contains(TipoAplicacion.ORDENES))
                //{
                //    ordenesComandos.Add(comando);

                //}
                //if (aa.TipoAplicacion.Contains(TipoAplicacion.COMPLEMENTODMA))
                //{
                //    complementoDMAComandos.Add(comando);
                //}
            }
            //comandosHabilitadosPorTipoAplicacion.Add(TipoAplicacion.DMA, dmaComandos);
            //comandosHabilitadosPorTipoAplicacion.Add(TipoAplicacion.WEBEXTERNA, extranetComandos);
            //comandosHabilitadosPorTipoAplicacion.Add(TipoAplicacion.WEBEXTERNASECURITY, securityComandos);
            comandosHabilitadosPorTipoAplicacion.Add(TipoAplicacion.API, apiComandos);
            //comandosHabilitadosPorTipoAplicacion.Add(TipoAplicacion.ORDENES, ordenesComandos);
            //comandosHabilitadosPorTipoAplicacion.Add(TipoAplicacion.COMPLEMENTODMA, complementoDMAComandos);
            comandosIniciales.Add(TipoAplicacion.API, apiComandos);
        }


        public void StopAllServices()
        {
            ManualResetEvent mre = null;
            this.services.ForEach(s =>
            {
                mre = new ManualResetEvent(true);
                this.manualResetEvents.Add(mre);
                s.SetWaitHandler(mre);
                s.Stop();

            });

            if (this.manualResetEvents != null && this.manualResetEvents.Count > 0)
                WaitHandle.WaitAll(this.manualResetEvents.ToArray());
        }

        public Guid GetSessionIdFromRequest(string sessionId)
        {
            return new Guid(this.Encryptor.Desencriptar(sessionId));
        }

        public string GetSessionIdForRequest(string sessionId)
        {
            return this.Encryptor.Encriptar(sessionId);
        }

        public void RefreshConfiguracionSistema(bool notificar = true)
        {
            Instance.ContextoAplicacion.PathDirectorioVirtual = HostingEnvironment.MapPath("~/");
            using (OrdenesContext context = new OrdenesContext())
            {
                ConfiguracionSistemaEntity entidad = (from d in context.ConfiguracionSistema
                                                      .Include(d => d.ConfiguracionSistemaUrls)
                                                      select d).SingleOrDefault();

                Instance.ContextoAplicacion.Urls = new List<ConfiguracionSistemaUrls>();
                if (entidad != null)
                {
                    this.ContextoAplicacion.IdConfiguracionSistema = entidad.IdConfiguracionSistema;
                    this.ContextoAplicacion.OcultarErroresBaseDeDatos = entidad.OcultarErroresBaseDeDatos;
                    this.ContextoAplicacion.PathSalida = entidad.PathSalida;
                    this.ContextoAplicacion.TiempoLogSQL = entidad.TiempoLogSQL;
                    this.ContextoAplicacion.PermiteProcesamientoParalelo = entidad.PermiteProcesamientoParalelo;
                    this.ContextoAplicacion.EnviaNotificaciones = entidad.EnviaNotificaciones;
                    this.ContextoAplicacion.AbsoluteServicesURL = entidad.AbsoluteServicesURL;
                    this.ContextoAplicacion.EnviarAgentCode = entidad.EnviarAgentCode;
                    this.ContextoAplicacion.ApiServicePort = entidad.ApiServicePort;
                    this.ContextoAplicacion.JwtSecretKey = entidad.JwtSecretKey;
                    this.ContextoAplicacion.JwtAudienceToken = entidad.JwtAudienceToken;
                    this.ContextoAplicacion.JwtIssuerToken = entidad.JwtIssuerToken;
                    this.ContextoAplicacion.MaxOperationRows = entidad.MaxOperationRows;
                    this.ContextoAplicacion.MinOperationRows = entidad.MinOperationRows;

                    if (entidad.ConfiguracionSistemaUrls != null && entidad.ConfiguracionSistemaUrls.Count > 0)
                    {
                        foreach (var item in entidad.ConfiguracionSistemaUrls)
                        {
                            ConfiguracionSistemaUrls unaUrl = new ConfiguracionSistemaUrls();
                            unaUrl.IdConfiguracionSistema = item.IdConfiguracionSistema;
                            unaUrl.IdConfiguracionSistemaUrls = item.IdConfiguracionSistemaUrls;
                            unaUrl.Usuario = item.Usuario;
                            unaUrl.Password = item.Password;
                            unaUrl.Url = item.Url;
                            unaUrl.Parametros = item.Parametros;
                            unaUrl.TipoUrl = (ConfiguracionSistemaURLsEnumDestino)Enum.Parse(typeof(ConfiguracionSistemaURLsEnumDestino), item.TipoUrl);
                            Instance.ContextoAplicacion.Urls.Add(unaUrl);
                        }
                    }

                }
            }
            if (notificar)
            {
                Dictionary<string, string> NotificacionProp = new Dictionary<string, string>();
                string uri = string.Empty;

                uri = Instance.ContextoAplicacion.Urls.Find(x => x.TipoUrl == ConfiguracionSistemaURLsEnumDestino.API).Url;
                NotificacionProp.Add("url", uri);
                EventHelperService.Instance.EnQueueMessage(new NotificacionRefrescarCache() { IdTipoNotificacion = (byte)TiposNotificaciones.RefrescarCache, CommandName = "RefreshConfiguracionSistema", NotificacionPropiedades = NotificacionProp });
                LiteralesTraducidos.Instance.Init();
            }
        }

    }
}

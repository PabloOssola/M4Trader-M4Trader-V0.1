using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace M4Trader.ordenes.server.Caching
{
    public class CachingManager : ICachingManager
    {
        private static object syncSession = new object();
        #region FirstOrDefaultton

        public CachingManager()
        {

        }

        private static volatile CachingManager _instance;

        public static CachingManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(CachingManager))
                    {
                        if (_instance == null)
                            _instance = new CachingManager();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region RefreshAll
        public void RefreshAll()
        {
            CacheLayer.ClearAll();
        }
        #endregion

        #region Keys
        public const string KEY_SFC_INGRESO_OP_NOVEDAD = "SFC_TipoAcciones.OPERACIONES_TipoPermiso.IMPORTACION";

        private const string KEY_INGRESO_OP_FECHA_SISTEMA = "FECHA_SISTEMA";
        private const string KEY_AUTHORIZE = "AUTHORIZE";
        private const string KEY_PRODUCTO_BY_ID = "KEY_PRODUCTO_BY_ID";
        private const string KEY_PERMISOS_PRODUCTOS = "KEY_PERMISOS_PRODUCTOS";
        private const string KEY_PRODUCTO_ALL = "KEY_PRODUCTO_ALL";
        private const string KEY_PERSONA_BY_ID = "KEY_PERSONA_BY_ID";
        private const string KEY_PADRE_BY_ID_HIJO = "KEY_PADRE_BY_ID_HIJO";
        private const string KEY_SESSION_BY_ID = "KEY_SESSION_BY_ID";
        private const string KEY_SESSION_BY_ID_LOGIN = "KEY_SESSION_BY_ID_LOGIN";
        private const string KEY_PERSONA_BY_NROCLIENTE = "KEY_PERSONA_BY_NROCLIENTE";
        private const string KEY_PERSONA_BY_NRO_TIPO = "KEY_PERSONA_BY_NRO_TIPO";
        private const string KEY_PERSONAPARTE_BY_USUARIOLOGIN = "KEY_PERSONAPARTE_BY_USUARIOLOGIN";
        private const string KEY_ALL_MERCADOS = "KEY_ALL_MERCADOS";
        private const string KEY_MONEDA_BY_ID = "KEY_MONEDA_BY_ID";
        private const string KEY_FECHA_LIQUIDACION_PRODUCTO_PLAZO = "KEY_FECHA_LIQUIDACION_PRODUCTO_PLAZO";


        private const string KEY_CONFIG_SEGURIDAD = "KEY_CONFIG_SEGURIDAD";

       
        private const string KEY_CONFIG_SISTEMA = "KEY_CONFIG_SISTEMA";
        private const string KEY_ALL_MONEDAS = "KEY_ALL_MONEDAS";
        private const string KEY_USUARIO_BY_ID = "KEY_USUARIO_BY_ID";
        private const string KEY_ROL = "KEY_ROL";
        private const string KEY_ROLES_USUARIOS = "KEY_ROLES_USUARIOS";
        private const string KEY_USUARIO_BY_USERNAME = "KEY_USUARIO_BY_USERNAME";
        private const string KEY_USUARIOS_PARTIES = "KEY_USUARIOS_PARTIES";
        private const string KEY_USUARIO_PROCESO = "KEY_USUARIO_PROCESO";
        private const string KEY_PERMISO_BY_ID = "KEY_PERMISO_BY_ID";
        private const string KEY_ACCION_BY_ID = "KEY_ACCION_BY_ID";
        private const string KEY_ALL_MOTIVOS_RECHAZOS = "KEY_ALL_MOTIVOS_RECHAZOS";
        private const string KEY_PERIMISOS_BY_USUARIO_ID = "KEY_PERIMISOS_BY_USUARIO_ID";
        private const string KEY_ALL_ACCIONES = "KEY_ALL_ACCIONES";
        private const string KEY_CONFIGURACION_EXPORTACION = "KEY_CONFIGURACION_EXPORTACION";
        private const string KEY_ALL_PRECIOS = "KEY_ALL_PRECIOS";
        private const string KEY_MERCADO_BY_ID = "KEY_MERCADO_BY_ID";
        private const string KEY_AUTOCONFIRMA = "KEY_AUTOCONFIRMA";
        private const string KEY_ALL_TIPOSORDEN = "KEY_ALL_TIPOSORDEN";
        private const string KEY_GETALLROLES = "KEY_GETALLROLES";
        private const string KEY_GETALLUSUARIOS = "KEY_GETALLUSUARIOS";
        private const string KEY_PLAZO_ALL = "KEY_PLAZO_ALL";
        private const string PORTFOLIOS_ALL = "PORTFOLIOS_ALL";
        private const string PRODUCTOS_COMPOSICION = "PRODUCTOS_COMPOSICION";
        private const string PRODUCTOS_BY_PORTFOLIO = "PRODUCTOS_BY_PORTFOLIO";
        private const string KEY_PORTFOLIO_DEFAULT_USUARIO = "KEY_PORTFOLIO_DEFAULT_USUARIO";
        private const string KEY_PORTFOLIO_CODIGO = "KEY_PORTFOLIO_CODIGO";
        private const string KEY_PORTFOLIOCOMPOSICION_CODIGO_USUARIO = "KEY_PORTFOLIOCOMPOSICION_CODIGO_USUARIO";
        private const string KEY_PRODUCTO_POR_MERCADO = "KEY_PRODUCTO_POR_MERCADO";
        private const string KEY_PORTFOLIO_BY_PERSONA = "KEY_PORTFOLIO_BY_PERSONA";
        private const string KEY_USUARIOS_CHATS = "KEY_USUARIOS_CHATS";

        #endregion

        #region Custom
        public static T Get<T>(string key)
        {
            return (T)CacheLayer.Get(key);
        }
        public static void Insert(string key, object valor, DateTime fechaExperacion)
        {
            CacheLayer.Add(valor, key, fechaExperacion);
        }

        #endregion

        #region Sistema
        public EstadoSistemaEntity GetFechaSistema()
        {
            //string keyCache = KEY_INGRESO_OP_FECHA_SISTEMA;
            EstadoSistemaEntity estadoSistema;// = CacheLayer.Get<EstadoSistemaEntity>(keyCache);
                                              //if (estadoSistema == null)
                                              //{
            using (OrdenesContext dbContext = new OrdenesContext())
            {
                int idEstadoSistema = dbContext.EstadoSistema.Where(p1 => p1.IdEstadoSistema != 0).Max(r => r.IdEstadoSistema);
                estadoSistema = dbContext.EstadoSistema.Where(p => p.IdEstadoSistema == idEstadoSistema).FirstOrDefault();
                //if (estadoSistema != null)
                //{
                //    CacheLayer.Add<EstadoSistemaEntity>(estadoSistema, keyCache);
                //}
            }
            //}
            return estadoSistema;
        }
        #endregion

        #region Accion
        public List<AccionEntity> GetAllAcciones()
        {
            string keyCache = KEY_ALL_ACCIONES;
            List<AccionEntity> acciones = CacheLayer.Get<List<AccionEntity>>(keyCache);

            if (acciones == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    acciones =
                        (from d in dbContext.Acciones select d).ToList();
                }
                if (acciones != null)
                {
                    CacheLayer.Add<List<AccionEntity>>(acciones, keyCache);
                }
            }


            return acciones;
        }

        public AccionEntity GetAccionById(short idAccion)
        {
            return GetAllAcciones().Find(a => a.IdAccion == idAccion);
        }
        #endregion

        #region Authorization
        public AutorizationType GetAutorizacion(int idUsuario, short idAccion, TipoPermiso tipo_permiso)
        {
            string keyCache = KEY_AUTHORIZE + idUsuario + idAccion + tipo_permiso;
            AutorizationType autorizacion = CacheLayer.Get<AutorizationType>(keyCache);
            if (autorizacion == null)
            {
                autorizacion = new AutorizationType();
                autorizacion.tipoAutorizacion = SecurityHelper.AuthorizeAccion(idUsuario, (short)idAccion.GetHashCode(), tipo_permiso);
                if (autorizacion != null)
                {
                    Insert(keyCache, autorizacion, DateTime.Now.AddMinutes(30));
                }
            }
            return autorizacion;
        }
        #endregion

        #region Plazos
        public List<PlazoEntity> GetAllPlazos()
        {
            string keyCache = KEY_PLAZO_ALL;
            List<PlazoEntity> plazos = CacheLayer.Get<List<PlazoEntity>>(keyCache);

            if (plazos == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    plazos = (from p in mc.Plazos select p).ToList();
                }
                if (plazos != null)
                {
                    CacheLayer.Add<List<PlazoEntity>>(plazos, keyCache);
                }
            }

            return plazos;
        }
        #endregion



        #region Producto
        public List<ProductoEntity> GetAllProductos()
        {
            string keyCache = KEY_PRODUCTO_ALL;
            List<ProductoEntity> productos = CacheLayer.Get<List<ProductoEntity>>(keyCache);

            if (productos == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    productos = (from p in mc.Producto where p.BajaLogica == false && p.Habilitado == true select p).ToList();
                }
                if (productos != null)
                {
                    CacheLayer.Add<List<ProductoEntity>>(productos, keyCache);
                }
            }

            return productos;
        }

        public ProductoEntity GetProductoById(int idProducto)
        {
            string keyCache = KEY_PRODUCTO_BY_ID + "#" + idProducto.ToString();
            ProductoEntity producto = CacheLayer.Get<ProductoEntity>(keyCache);

            if (producto == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    producto = (from p in mc.Producto where p.IdProducto == idProducto select p).FirstOrDefault();
                }
                if (producto != null)
                {
                    CacheLayer.Add<ProductoEntity>(producto, keyCache);
                }
            }

            return producto;
        }

        public ProductoEntity GetProductoByCodigoAndIdMoneda(string codigoProducto, Int64 idMoneda, string rueda)
        {
            string keyCache = KEY_PRODUCTO_BY_ID + "#" + codigoProducto + "#" + idMoneda + "#" + rueda;
            ProductoEntity producto = CacheLayer.Get<ProductoEntity>(keyCache);

            if (producto == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    producto = (from p in mc.Producto where p.Codigo.Equals(codigoProducto.Trim()) && p.IdMoneda == idMoneda && p.Rueda == rueda select p).FirstOrDefault();
                }
                if (producto != null)
                {
                    CacheLayer.Add<ProductoEntity>(producto, keyCache);
                }
            }

            return producto;
        }
        public ProductoEntity GetProductoByCodigoMonedaDefaultAndRueda(string codigoProducto, byte idMercado, string rueda)
        {
            string keyCache = KEY_PRODUCTO_BY_ID + "#" + codigoProducto + "#" + idMercado + "#" + rueda + "#DEFAULT";
            ProductoEntity producto = CacheLayer.Get<ProductoEntity>(keyCache);

            if (producto == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    producto = (from p in mc.Producto
                                join ppm in mc.ProductosPorMercado on p.IdProducto equals ppm.IdProducto
                                where p.Codigo.Equals(codigoProducto.Trim()) && ppm.IdMercado == idMercado && p.Rueda == rueda
                                select p).FirstOrDefault();
                }
                if (producto != null)
                {
                    CacheLayer.Add<ProductoEntity>(producto, keyCache);
                }
            }

            return producto;
        }

        public ProductoPorMercadoEntity GetProductoPorMercadoByProductoYMercado(byte idMercado, int idProducto)
        {
            string keyCache = KEY_PRODUCTO_POR_MERCADO + "#" + idProducto + "#" + idMercado;
            ProductoPorMercadoEntity productoPorMercado = CacheLayer.Get<ProductoPorMercadoEntity>(keyCache);

            if (productoPorMercado == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    productoPorMercado = (from ppm in mc.ProductosPorMercado
                                          where ppm.IdMercado == idMercado && ppm.IdProducto == idProducto
                                          select ppm).FirstOrDefault();
                }
                if (productoPorMercado != null)
                {
                    CacheLayer.Add<ProductoPorMercadoEntity>(productoPorMercado, keyCache);
                }
            }

            return productoPorMercado;
        }


        public DTOProducto GetProductoByCodeDefaultCurrencyAndRueda(string producto, byte idMercado, string rueda)
        {
            ProductoEntity pe = GetProductoByCodigoMonedaDefaultAndRueda(producto, idMercado, rueda);
            return new DTOProducto()
            {
                BajaLogica = pe.BajaLogica,
                IdProducto = pe.IdProducto,
                Codigo = pe.Codigo,
                Descripcion = pe.Descripcion,
                ISIN = pe.ISIN,
                Habilitado = pe.Habilitado,
                IdMoneda = pe.IdMoneda,
                Rueda = pe.Rueda
            };
        }

        public List<DTOPermisosProductoParty> GetPermisosProductos(Int64 idProducto)
        {
            string keyCache = KEY_PERMISOS_PRODUCTOS + "#" + idProducto;
            List<DTOPermisosProductoParty> productosPermisos = CacheLayer.Get<List<DTOPermisosProductoParty>>(keyCache);

            if (productosPermisos == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    productosPermisos = (from p in mc.PermisosProductosEmpresas
                                         join per in mc.Persona on p.IdParty equals per.IdParty
                                         where p.IdProducto == idProducto
                                         select new DTOPermisosProductoParty
                                         {
                                             IdParty = p.IdParty,
                                             IdProducto = p.IdProducto
                                         }).ToList();
                }
                if (productosPermisos != null)
                {
                    CacheLayer.Add(productosPermisos, keyCache);
                }
            }

            return productosPermisos;
        }

        public DTOProducto GetProductoByCodeIdMonedaAndRueda(string producto, byte idMoneda, string rueda)
        {
            ProductoEntity pe = GetProductoByCodigoAndIdMoneda(producto, idMoneda, rueda);
            return new DTOProducto()
            {
                BajaLogica = pe.BajaLogica,
                IdProducto = pe.IdProducto,
                Codigo = pe.Codigo,
                Descripcion = pe.Descripcion,
                ISIN = pe.ISIN,
                Habilitado = pe.Habilitado,
                IdMoneda = pe.IdMoneda,
                Rueda = pe.Rueda

            };
        }

        public DTOPortfolio GetPortfolioByIdProducto(int idProducto)
        {
            string keyCache = PORTFOLIOS_ALL;
            List<DTOPortfolio> dtoPortfolios = CacheLayer.Get<List<DTOPortfolio>>(keyCache);
            PortfolioComposicionEntity pce = new PortfolioComposicionEntity();


            using (OrdenesContext mc = new OrdenesContext())
            {
                pce = (from pc in mc.PortfoliosComposicion
                       where pc.IdProducto == idProducto
                       select pc).FirstOrDefault();
                if (dtoPortfolios == null)
                {
                    dtoPortfolios = (from p in mc.Portfolios
                                     select new DTOPortfolio()
                                     {
                                         IdPortfolio = p.IdPortfolio,
                                         Nombre = p.Nombre,
                                         Codigo = p.Codigo,
                                         EsDeSistema = p.EsDeSistema
                                     }).ToList();
                    CacheLayer.Add(dtoPortfolios, keyCache);
                }
            }

            return dtoPortfolios.Find(x => x.IdPortfolio == pce.IdPortfolio);
        }

        public List<DTOProducto> GetProductosByCodigoPortfolio(string codigoPortfolio)
        {

            string keyCache = PORTFOLIOS_ALL + "#" + codigoPortfolio;
            string keyCachePortfolioComposicion = PRODUCTOS_COMPOSICION + "#" + keyCache;
            string keyPortfolioProductos = PRODUCTOS_BY_PORTFOLIO + "#" + keyCachePortfolioComposicion;
            List<DTOProducto> productos = CacheLayer.Get<List<DTOProducto>>(keyPortfolioProductos);
            if (productos != null && productos.Count > 0)
            {
                return productos;
            }

            PortfolioEntity portfolio = CacheLayer.Get<PortfolioEntity>(keyCache);
            List<PortfolioComposicionEntity> pce = CacheLayer.Get<List<PortfolioComposicionEntity>>(keyCachePortfolioComposicion);

            if (portfolio == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    portfolio = (from p in mc.Portfolios
                                 where p.Codigo == codigoPortfolio
                                 select p).FirstOrDefault();
                    if (portfolio != null)
                    {
                        pce = (from p in mc.PortfoliosComposicion
                               where p.IdPortfolio == portfolio.IdPortfolio
                               select p).ToList();
                    }
                    if (pce != null)
                    {
                        List<int> Ids = pce.Select(x => x.IdProducto).ToList();
                        productos = (from p in mc.Producto
                                     where Ids.Contains(p.IdProducto)
                                     select new DTOProducto()
                                     {
                                         IdProducto = p.IdProducto,
                                         Codigo = p.Codigo,
                                         Descripcion = p.Descripcion,
                                         IdMoneda = p.IdMoneda,
                                         ISIN = p.ISIN,
                                         Habilitado = p.Habilitado,
                                         BajaLogica = p.BajaLogica
                                     }).ToList();
                    }
                }
                if (portfolio != null)
                {
                    CacheLayer.Add(portfolio, keyCache);
                }
                if (pce != null)
                {
                    CacheLayer.Add(pce, keyCachePortfolioComposicion);
                }
                if (productos != null)
                {
                    CacheLayer.Add(productos, keyPortfolioProductos);
                }
            }

            return productos;
        }


        //public DateTime? GetFechaLiquidacion(int idProducto, byte? plazo)
        //{
        //    string keyCache = KEY_FECHA_LIQUIDACION_PRODUCTO_PLAZO;
        //    List<DTOPortfolio> dtoPortfolios = CacheLayer.Get<List<DTOPortfolio>>(keyCache);
        //    PortfolioComposicionEntity pce = new PortfolioComposicionEntity();


        //    using (OrdenesContext mc = new OrdenesContext())
        //    {
        //        pce = (from pc in mc.PortfoliosComposicion
        //               where pc.IdProducto == idProducto
        //               select pc).FirstOrDefault();
        //        if (dtoPortfolios == null)
        //        {
        //            dtoPortfolios = (from p in mc.Portfolios
        //                             select new DTOPortfolio()
        //                             {
        //                                 IdPortfolio = p.IdPortfolio,
        //                                 Nombre = p.Nombre,
        //                                 Codigo = p.Codigo,
        //                                 EsDeSistema = p.EsDeSistema
        //                             }).ToList();
        //            CacheLayer.Add(dtoPortfolios, keyCache);
        //        }
        //    }

        //    return dtoPortfolios.Find(x => x.IdPortfolio == pce.IdPortfolio);
            
        //    throw new NotImplementedException();
        //}
        #endregion

        #region Portfolios

        public DTOPortfolio GetPortfolioDefaultByIdUsuario(int idUsuario)
        {
            string keyCache = KEY_PORTFOLIO_DEFAULT_USUARIO + "#" + idUsuario;
            DTOPortfolio dtoPortfolio = CacheLayer.Get<DTOPortfolio>(keyCache);

            if (dtoPortfolio == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {

                    dtoPortfolio = (from p in mc.Portfolios
                                    join pu in mc.PortfoliosUsuario on p.IdPortfolio equals pu.IdPortfolio
                                    where pu.IdUsuario == idUsuario
                                    && pu.PorDefecto
                                    select new DTOPortfolio()
                                    {
                                        IdPortfolio = p.IdPortfolio,
                                        Nombre = p.Nombre,
                                        Codigo = p.Codigo,
                                        EsDeSistema = p.EsDeSistema
                                    }).FirstOrDefault();
                    if (dtoPortfolio == null)
                    {
                        dtoPortfolio = (from p in mc.Portfolios
                                        join pu in mc.PortfoliosUsuario on p.IdPortfolio equals pu.IdPortfolio
                                        where pu.IdUsuario == idUsuario
                                        select new DTOPortfolio()
                                        {
                                            IdPortfolio = p.IdPortfolio,
                                            Nombre = p.Nombre,
                                            Codigo = p.Codigo,
                                            EsDeSistema = p.EsDeSistema
                                        }).FirstOrDefault();
                    }

                }
                if (dtoPortfolio != null)
                {
                    CacheLayer.Add(dtoPortfolio, keyCache);
                }
            }

            return dtoPortfolio;
        }

        public DTOPortfolio GetPortfolioByCodigo(string codigo)
        {
            string keyCache = KEY_PORTFOLIO_CODIGO + "#" + codigo;
            DTOPortfolio dtoPortfolio = CacheLayer.Get<DTOPortfolio>(keyCache);

            if (dtoPortfolio == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {

                    dtoPortfolio = (from p in mc.Portfolios
                                    where p.Codigo == codigo
                                    select new DTOPortfolio()
                                    {
                                        IdPortfolio = p.IdPortfolio,
                                        Nombre = p.Nombre,
                                        Codigo = p.Codigo,
                                        EsDeSistema = p.EsDeSistema
                                    }).FirstOrDefault();
                }
                if (dtoPortfolio != null)
                {
                    CacheLayer.Add(dtoPortfolio, keyCache);
                }
            }

            return dtoPortfolio;
        }

        public PortfolioComposicionEntity GetPortfolioComposicionByPortfolioAndProducto(short idPortfolio, int idProducto, byte idPlazo)
        {
            PortfolioComposicionEntity pc = new PortfolioComposicionEntity();

            using (OrdenesContext mc = new OrdenesContext())
            {

                pc = (from p in mc.PortfoliosComposicion
                                where p.IdPortfolio == idPortfolio && p.IdProducto == idProducto && p.IdPlazo == idPlazo
                      select new PortfolioComposicionEntity()
                                {
                                    IdPortfolio = p.IdPortfolio,
                                    IdProducto = p.IdProducto,
                                    IdPlazo = p.IdPlazo,
                                    IdPortfoliosComposicion = p.IdPortfoliosComposicion
                                }).FirstOrDefault();
            }

            return pc;
        }

        public List<DTOPortfolio> GetPortfoliosByIdPersona(int idPersona)
        {
            string keyCache = KEY_PORTFOLIO_BY_PERSONA + "#" + idPersona;
            List<DTOPortfolio> dtoPortfolio = CacheLayer.Get<List<DTOPortfolio>>(keyCache);

            if (dtoPortfolio == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {

                    dtoPortfolio = (from p in mc.Portfolios
                                    join pu in mc.PortfoliosUsuario on p.IdPortfolio equals pu.IdPortfolio
                                    join u in mc.Usuario on pu.IdUsuario equals u.IdUsuario
                                    where u.IdPersona == idPersona
                                    select new DTOPortfolio()
                                    {
                                        IdPortfolio = p.IdPortfolio,
                                        Nombre = p.Nombre,
                                        Codigo = p.Codigo,
                                        EsDeSistema = p.EsDeSistema
                                    }).Distinct().ToList();
                }
                if (dtoPortfolio != null)
                {
                    CacheLayer.Add(dtoPortfolio, keyCache);
                }
            }

            return dtoPortfolio;
        }

        public DTOPortfolio GetPortfolioById(int idPortfolio)
        {
            string keyCache = PORTFOLIOS_ALL;
            List<DTOPortfolio> dtoPortfolios = CacheLayer.Get<List<DTOPortfolio>>(keyCache);

            if (dtoPortfolios == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {

                    dtoPortfolios = (from p in mc.Portfolios
                                     select new DTOPortfolio()
                                     {
                                         IdPortfolio = p.IdPortfolio,
                                         Nombre = p.Nombre,
                                         Codigo = p.Codigo,
                                         EsDeSistema = p.EsDeSistema
                                     }).ToList();
                }
                if (dtoPortfolios != null)
                {
                    CacheLayer.Add(dtoPortfolios, keyCache);
                }
            }

            return dtoPortfolios.Find(x => x.IdPortfolio == idPortfolio);
        }
        #endregion

        #region Personas
        public PartyEntity GetPersonaById(int idPersona)
        {
            string keyCache = KEY_PERSONA_BY_ID + idPersona;
            PartyEntity persona = CacheLayer.Get<PartyEntity>(keyCache);

            if (persona == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    persona =
                        (from d in dbContext.Persona where d.IdParty == idPersona select d).FirstOrDefault();
                }
                if (persona != null)
                {
                    CacheLayer.Add(persona, keyCache);
                }
            }
            return persona;
        }

        public PartyEntity GetPadreByIdHijo(int idHijo)
        {
            string keyCache = KEY_PADRE_BY_ID_HIJO + idHijo;
            PartyEntity persona = CacheLayer.Get<PartyEntity>(keyCache);

            if (persona == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    persona = (from p in dbContext.Persona
                               join ph in dbContext.PartyHierarchyEntities on p.IdParty equals ph.IdPartyFather
                               where ph.IdPartyHijo == idHijo
                               select p).FirstOrDefault();
                }
                if (persona != null)
                {
                    CacheLayer.Add(persona, keyCache);
                }
            }
            return persona;
        }


        public PartyEntity GetPersonaByNroCliente(string nroCliente)
        {
            string keyCache = KEY_PERSONA_BY_NROCLIENTE + nroCliente;
            PartyEntity persona = CacheLayer.Get<PartyEntity>(keyCache);

            if (persona == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    persona =
                        (from d in dbContext.Persona where d.MarketCustomerNumber.Equals(nroCliente) select d).FirstOrDefault();
                }
                if (persona != null)
                {
                    CacheLayer.Add<PartyEntity>(persona, keyCache);
                }
            }
            return persona;
        }

        public PartyEntity GetPersonaByNroClienteTipo(string nroCliente, TipoPersona tipoPersona)
        {
            string keyCache = KEY_PERSONA_BY_NRO_TIPO + "_" + nroCliente + tipoPersona;
            PartyEntity persona = CacheLayer.Get<PartyEntity>(keyCache);

            if (persona == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    persona =
                        (from d in dbContext.Persona
                         where d.IdPartyType == (byte)tipoPersona
                         && (string.IsNullOrEmpty(nroCliente) || d.MarketCustomerNumber.Equals(nroCliente.Trim()))
                         select d).FirstOrDefault();
                }
                if (persona != null)
                {
                    CacheLayer.Add(persona, keyCache);
                }
            }
            return persona;
        }

        public PartyEntity getPersonaParteByIdUsuarioLogin(long? identity_rid)
        {
            string keyCache = KEY_PERSONAPARTE_BY_USUARIOLOGIN + "_" + identity_rid;
            PartyEntity persona = CacheLayer.Get<PartyEntity>(keyCache);

            if (persona == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    persona =
                        (from d in dbContext.Persona
                         join u in dbContext.Usuario on d.IdParty equals u.IdPersona
                         where u.IdUsuario == identity_rid
                         select d).FirstOrDefault();
                }
                if (persona != null)
                {
                    CacheLayer.Add(persona, keyCache);
                }
            }
            return persona;
        }

        public int GetIdPersonaAdministradaById(int idPersona)
        {
            int IdPersona = 0;
            using (OrdenesContext dbContext = new OrdenesContext())
            {
                IdPersona =
                        (from d in dbContext.UsuariosAdminitradorParties

                         where d.IdAdministrador == idPersona
                         select d).FirstOrDefault().IdParty;
            }
            return IdPersona;
        }
        #endregion

        #region ConfirmacionManual
        public bool GetConfirmacionManual(int idProducto, int idPersona, byte source)
        {
            string keyCache = KEY_AUTOCONFIRMA + "#" + idProducto.ToString() + "#" + idPersona.ToString() + "#" + source.ToString();
            List<ConfirmacionManualEntity> ConfirmacionManual = CacheLayer.Get<List<ConfirmacionManualEntity>>(keyCache);

            if (ConfirmacionManual == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    ConfirmacionManual = (from p in mc.ConfirmacionManual where p.IdProducto == idProducto && p.IdParty == idPersona && p.IdSourceApplication == source select p).ToList();
                }
                if (ConfirmacionManual != null)
                {
                    CacheLayer.Add<List<ConfirmacionManualEntity>>(ConfirmacionManual, keyCache);
                }
            }

            return (ConfirmacionManual.Count > 0);
        }
        #endregion

        #region Mercados
        public List<DTOMercado> GetAllMercados()
        {
            string keyCache = KEY_ALL_MERCADOS;
            List<DTOMercado> mercados = CacheLayer.Get<List<DTOMercado>>(keyCache);

            if (mercados == null)
            {
                List<MercadoEntity> mercadoEntities;
                using (var ctx = new OrdenesContext())
                {

                    mercadoEntities = (from d in ctx.Mercado select d).ToList<MercadoEntity>();
                }
                if (mercadoEntities != null)
                {
                    mercados = new List<DTOMercado>();
                    foreach (MercadoEntity mercado in mercadoEntities)
                    {
                        mercados.Add(new DTOMercado()
                        {
                            IdMercado = mercado.IdMercado,
                            Codigo = mercado.Codigo,
                            Descripcion = mercado.Descripcion,
                            EsInterno = mercado.EsInterno,
                            ProductoHabilitadoDefecto = mercado.ProductoHabilitadoDefecto
                        });
                    }
                    CacheLayer.Add<List<DTOMercado>>(mercados, keyCache);
                }
            }
            return mercados;
        }

        public DTOMercado GetMercadoByCodigo(string mercadoCodigo)
        {
            if (!string.IsNullOrEmpty(mercadoCodigo))
                return this.GetAllMercados().Find(c => c.Codigo.Equals(mercadoCodigo.Trim()));
            else
                return null;
        }

        public MercadoEntity GetMercadoById(byte idMercado)
        {
            string keyCache = KEY_MERCADO_BY_ID + "#" + idMercado.ToString();
            MercadoEntity mercado = CacheLayer.Get<MercadoEntity>(keyCache);

            if (mercado == null)
            {
                using (OrdenesContext mc = new OrdenesContext())
                {
                    mercado = (from p in mc.Mercado where p.IdMercado == idMercado select p).FirstOrDefault();
                }
                if (mercado != null)
                {
                    CacheLayer.Add<MercadoEntity>(mercado, keyCache);
                }
            }

            return mercado;
        }


        public DTOMercado GetMercadoByCode(string Codigo)
        {
            return GetAllMercados().Find(c => c.Codigo.Equals(Codigo.Trim()));
        }

        #endregion

        #region Moneda
        public MonedaEntity GetMonedaById(byte idMoneda)
        {
            return this.GetAllMonedas().Find(d => d.IdMoneda == idMoneda);

        }

        public MonedaEntity GetMonedaByCodigoISO(string Codigo)
        {
            return this.GetAllMonedas().Find(d => d.CodigoISO == Codigo);
        }

        public DTOMoneda GetMonedaByISOCode(string Codigo)
        {
            MonedaEntity me = GetMonedaByCodigoISO(Codigo);
            return new DTOMoneda()
            {
                IdMoneda = me.IdMoneda,
                Codigo = me.Codigo,
                CodigoISO = me.CodigoISO,
                Descripcion = me.Descripcion,
                TipoMoneda = me.TipoMoneda
            };
        }

        public List<MonedaEntity> GetAllMonedas()
        {
            string keyCache = KEY_ALL_MONEDAS;

            List<MonedaEntity> monedas = CacheLayer.Get<List<MonedaEntity>>(keyCache);

            if (monedas == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    monedas = (from d in dbContext.Moneda select d).ToList<MonedaEntity>();
                }
                if (monedas != null)
                {
                    CacheLayer.Add<List<MonedaEntity>>(monedas, keyCache);
                }
            }
            return monedas;
        }
        #endregion

        #region ConfiguracioSeguridad

        public ConfiguracionSeguridadEntity GetConfiguracionSeguridad()
        {
            string keyCache = KEY_CONFIG_SEGURIDAD;
            ConfiguracionSeguridadEntity config = CacheLayer.Get<ConfiguracionSeguridadEntity>(keyCache);

            if (config == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    config =
                        (from d in dbContext.ConfiguracionSeguridad select d).FirstOrDefault();
                }
                if (config != null)
                {
                    CacheLayer.Add<ConfiguracionSeguridadEntity>(config, keyCache);
                }
            }

            return config;
        }
        #endregion

        #region Roles
        public List<RolEntity> GetAllRoles()
        {
            string keyCache = KEY_GETALLROLES;
            List<RolEntity> roles = CacheLayer.Get<List<RolEntity>>(keyCache);

            if (roles == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    roles =
                        (from d in dbContext.Rol select d).ToList();
                }
                if (roles != null)
                {
                    CacheLayer.Add<List<RolEntity>>(roles, keyCache);
                }
            }

            return roles;
        }

        public RolEntity GetRolByValorNumerico(int valornumerico)
        {
            string keyCache = KEY_ROL + valornumerico;
            RolEntity Rol = CacheLayer.Get<RolEntity>(keyCache);

            if (Rol == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    Rol =
                        (from d in dbContext.Rol where d.ValorNumerico == valornumerico select d).FirstOrDefault();
                }
                if (Rol != null)
                {
                    CacheLayer.Add<RolEntity>(Rol, keyCache);
                }
            }

            return Rol;
        }


        public List<RolUsuarioEntity> GetRolesUsuario(int idusuario)
        {
            string keyCache = KEY_ROLES_USUARIOS + idusuario;
            List<RolUsuarioEntity> Roles = CacheLayer.Get<List<RolUsuarioEntity>>(keyCache);

            if (Roles == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    Roles =
                        (from d in dbContext.RolUsuario where d.IdUsuario == idusuario select d).ToList();
                }
                if (Roles != null)
                {
                    CacheLayer.Add<List<RolUsuarioEntity>>(Roles, keyCache);
                }
            }

            return Roles;
        }
        #endregion

        #region Usuarios

        public UsuarioEntity GetByIdUsuario(int idusuario)
        {
            string keyCache = KEY_USUARIO_BY_ID + idusuario;
            UsuarioEntity user = CacheLayer.Get<UsuarioEntity>(keyCache);

            if (user == null)
            {
                using (OrdenesContext context = new OrdenesContext())
                {
                    user = (from d in context.Usuario
                            where d.IdUsuario == idusuario
                            select d).FirstOrDefault();
                }
                if (user != null)
                {
                    CacheLayer.Add<UsuarioEntity>(user, keyCache);
                }
            }

            return user;
        }

        public void ClearUser(int idusuario)
        {
            string keyCache = KEY_USUARIO_BY_ID + idusuario;
            UsuarioEntity user = CacheLayer.Get<UsuarioEntity>(keyCache);

            if (user != null)
            {
                CacheLayer.Clear(keyCache);
            }
        }

        public UsuarioEntity GetUsuarioByUsername(string Username)
        {
            string keyCache = KEY_USUARIO_BY_USERNAME + Username;
            UsuarioEntity user = CacheLayer.Get<UsuarioEntity>(keyCache);

            if (user == null)
            {
                using (OrdenesContext context = new OrdenesContext())
                {
                    user = (from d in context.Usuario
                            where d.Username == Username
                            select d).FirstOrDefault();
                }
                if (user != null)
                {
                    CacheLayer.Add<UsuarioEntity>(user, keyCache);
                }
            }

            return user;
        }

        public void ClearUser(string Username)
        {
            string keyCache = KEY_USUARIO_BY_USERNAME + Username;
            UsuarioEntity user = CacheLayer.Get<UsuarioEntity>(keyCache);

            if (user != null)
            {
                CacheLayer.Clear(keyCache);
            }
        }


        public DTOUsuario GetUsuariosPartiesDTO(Int64 idUsuario)
        {
            string keyCache = KEY_USUARIOS_PARTIES + "#" + idUsuario;
            DTOUsuario usuarioParty = CacheLayer.Get<DTOUsuario>(keyCache);

            if (usuarioParty == null)
            {
                using (OrdenesContext context = new OrdenesContext())
                {
                    usuarioParty = (from d in context.Usuario
                                    where d.IdUsuario == idUsuario
                                    select new DTOUsuario()
                                    {
                                        IdParty = d.IdPersona,
                                        IdUsuario = d.IdUsuario
                                    }
                                ).FirstOrDefault();
                }
                if (usuarioParty != null)
                {
                    CacheLayer.Add(usuarioParty, keyCache);
                }
            }

            return usuarioParty;
        }

        public List<UsuarioEntity> GetAllUsuarios()
        {
            string keyCache = KEY_GETALLUSUARIOS;
            List<UsuarioEntity> usuarios = CacheLayer.Get<List<UsuarioEntity>>(keyCache);

            if (usuarios == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    usuarios =
                        (from d in dbContext.Usuario select d).ToList();
                }
                if (usuarios != null)
                {
                    CacheLayer.Add<List<UsuarioEntity>>(usuarios, keyCache);
                }
            }

            return usuarios;
        }
        #endregion

        #region Limites
        public UsuariosLimitesDiariosEntity GetUsuariosLimiteDiariosByIdUsuario(int idUsuario)
        {

            UsuariosLimitesDiariosEntity limiteDiario;
            using (OrdenesContext context = new OrdenesContext())
            {
                limiteDiario = (from d in context.UsuariosLimitesDiarios
                                where d.IdUsuario == idUsuario
                                && d.Fecha.Date == DateTime.Now.Date
                                select d
                                ).FirstOrDefault();
            }


            return limiteDiario;
        }

        public UsuariosLimitesEntity GetUsuariosLimiteByIdUsuario(int idUsuario)
        {

            UsuariosLimitesEntity limite;
            using (OrdenesContext context = new OrdenesContext())
            {
                limite = (from d in context.UsuariosLimites
                                where d.IdUsuario == idUsuario
                                select d
                                ).FirstOrDefault();
            }


            return limite;
        }
        #endregion

        #region Permisos

        public List<Permiso> GetAllPermisosByIdUsuario(int idUsuario)
        {
            string keyCache = KEY_PERIMISOS_BY_USUARIO_ID + idUsuario;
            List<Permiso> permisos = CacheLayer.Get<List<Permiso>>(keyCache);

            if (permisos == null)
            {
                permisos = SecurityDAL.GetAllPermisos(idUsuario);
                if (permisos != null)
                {
                    CacheLayer.Add(permisos, keyCache);
                }
            }

            return permisos;
        }

        public Permiso GetByIdPermisos(int idUsuario, short idAccion)
        {
            List<Permiso> permisos = GetAllPermisosByIdUsuario(idUsuario);
            if (permisos != null)
                return permisos.Find(p => p.IdAccion == idAccion);

            return null;
        }
        #endregion

        #region "Ordenes"
        public TipoOrdenEntity GetTipoOrdenByCodigo(string Codigo)
        {
            return this.GetAllTipoOrden().Find(d => d.Codigo == Codigo);
        }

        public TipoOrdenEntity GetTipoOrdenById(byte idTipoOrden)
        {
            return this.GetAllTipoOrden().Find(d => d.IdTipoOrden == idTipoOrden);
        }

        public List<TipoOrdenEntity> GetAllTipoOrden()
        {
            string keyCache = KEY_ALL_TIPOSORDEN;

            List<TipoOrdenEntity> TiposOrdenes = CacheLayer.Get<List<TipoOrdenEntity>>(keyCache);

            if (TiposOrdenes == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    TiposOrdenes = (from d in dbContext.TiposOrden select d).ToList<TipoOrdenEntity>();
                }
                if (TiposOrdenes != null)
                {
                    CacheLayer.Add<List<TipoOrdenEntity>>(TiposOrdenes, keyCache);
                }
            }
            return TiposOrdenes;
        }
        #endregion

        #region Session
        //public void ClearSession(Guid idSesion)
        //{
        //    string keyCache = KEY_SESSION_BY_ID + idSesion.ToString();
        //    MAEUserSession session = CacheLayer.Get<MAEUserSession>(keyCache);

        //    if (session != null)
        //    {
        //        CacheLayer.Clear(keyCache);
        //    }
        //}

        public MAEUserSessionLogin GetMaeUserSessionLogin(string idSesion, long idAplicacion = (long)TipoAplicacion.ORDENES)
        {
            string keyCache = KEY_SESSION_BY_ID_LOGIN + idSesion.ToString();
            MAEUserSessionLogin session = CacheLayer.Get<MAEUserSessionLogin>(keyCache);

            if (session == null)
            {
                Dictionary<string, string> javascriptAllowedCommands = new Dictionary<string, string>();
                Guid IdSesion = OrdenesApplication.Instance.GetSessionIdFromRequest(idSesion);
                int IdUsuario = 0;
                Dictionary<string, int> mapeoAcciones = new Dictionary<string, int>();
                var Acciones = CachingManager.Instance.GetAllAcciones();
                OrdenesApplication.Instance.GetComandosHabilitados((TipoAplicacion)idAplicacion)
                .ForEach(cmd =>
                {
                    var k = OrdenesApplication.Instance.Encryptor.DynamicEncryption(cmd.FullName);
                    javascriptAllowedCommands.Add(cmd.Key, k);
                    mapeoAcciones.Add(k, cmd.IdAccion);
                });
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    var sesion = dbContext.Sesion.Where(x => x.IdSesion == IdSesion).FirstOrDefault();
                    IdUsuario = sesion.IdUsuario;
                    int idEstadoSistema = dbContext.EstadoSistema.Where(p1 => p1.IdEstadoSistema != 0).Max(r => r.IdEstadoSistema);
                    var estadoSistema = dbContext.EstadoSistema.Where(p => p.IdEstadoSistema == idEstadoSistema).FirstOrDefault();
                    session = (from s in dbContext.Sesion
                               join u in dbContext.Usuario on s.IdUsuario equals u.IdUsuario
                               join p in dbContext.Persona on u.IdPersona equals p.IdParty
                               where s.IdSesion == IdSesion
                               select new MAEUserSessionLogin()
                               {
                                   Ok = true,
                                   NombrePersona = p.Name,
                                   TipoPersona = UserHelper.getNombreTipoPersona(p.IdPartyType),
                                   EstadoSistema = estadoSistema.EstadoAbierto ? "Abierto" : "Cerrado",
                                   UserName = u.Nombre,
                                   JavascriptAllowedCommands = javascriptAllowedCommands,
                                   FechaFinalizacionSesion = s.FechaFinalizacion,
                                   PermisosUsuario = new Dictionary<string, bool>()
                               }
                               ).FirstOrDefault();
                }
                if (session != null)
                {
                    List<Permiso> PermisosUsuario = CachingManager.Instance.GetAllPermisosByIdUsuario(IdUsuario);
                    foreach (KeyValuePair<string, int> kv in mapeoAcciones)
                    {
                        Permiso p = PermisosUsuario.Find(x => x.IdAccion == kv.Value);
                        if (p != null)
                        {
                            var permisoAccion = Acciones.Find(x => x.IdAccion == kv.Value).HabilitarPermisos;
                            bool habilitado = (p.Permisos & permisoAccion) != 0;
                            session.PermisosUsuario.Add(kv.Key, habilitado);
                        }
                    }
                    CacheLayer.Add(session, keyCache);
                }
                else
                {
                    session = new MAEUserSessionLogin()
                    {
                        Ok = false,
                        Message = "Sesión Expirada"
                    };
                }
            }
            return session;
        }
        #endregion

        #region configuracionSistema

        public ConfiguracionSistemaEntity GetConfiguracionSistema()
        {
            string keyCache = KEY_CONFIG_SISTEMA;
            ConfiguracionSistemaEntity config = CacheLayer.Get<ConfiguracionSistemaEntity>(keyCache);

            if (config == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    config =
                        (from d in dbContext.ConfiguracionSistema select d).FirstOrDefault();
                }
                if (config != null)
                {
                    CacheLayer.Add<ConfiguracionSistemaEntity>(config, keyCache);
                }
            }

            return config;
        }
        #endregion


        #region Chat
        public ConcurrentDictionary<int, List<DTOUsuario>> GetChatsUsuarios()
        {
            string keyCache = KEY_USUARIOS_CHATS;
            ConcurrentDictionary<int, List<DTOUsuario>> dicChatUsuarios = CacheLayer.Get<ConcurrentDictionary<int, List<DTOUsuario>>>(keyCache);

            if (dicChatUsuarios == null)
            {
                dicChatUsuarios = new ConcurrentDictionary<int, List<DTOUsuario>>();
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    List<ChatEntity> chats = (from d in dbContext.Chats
                                              select d).ToList();
                    foreach(ChatEntity chat in chats)
                    {
                        List<DTOUsuario> usuarios = (from d in dbContext.ChatUsuarios
                                                     where d.IdChat == chat.IdChat
                                                     select new DTOUsuario()
                                                     {
                                                         IdUsuario = d.IdUsuario
                                                     }).ToList();


                        //TODO validar que se puede hacer si no logra agregarlo
                        dicChatUsuarios.TryAdd(chat.IdChat, usuarios);
                    }

                    
                }
                if (dicChatUsuarios != null)
                {
                    CacheLayer.Add<ConcurrentDictionary<int, List<DTOUsuario>>>(dicChatUsuarios, keyCache);
                }
            }

            return dicChatUsuarios;
        }
        #endregion

        public Party GetPartyById(int id)
        {
            PartyEntity pe = GetPersonaById(id);
            return new Party()
            {
                IdParty = pe.IdParty,
                DocumentNumber = pe.DocumentNumber,
                Name = pe.Name,
                MarketCustomerNumber = pe.MarketCustomerNumber,
                IdPartyType = pe.IdPartyType,
                IdLegalPersonality = pe.IdLegalPersonality,
                TaxIdentificationNumber = pe.TaxIdentificationNumber,
                Phone = pe.Phone,
                BajaLogica = pe.BajaLogica,
                AgentCode = pe.AgentCode
            };
        }
    }

    #region  Clase CacheLayer
    public class CacheLayer
    {
        static ObjectCache Cache = MemoryCache.Default;

        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T)Cache[key];
            }
            catch
            {
                return null;
            }
        }

        public static object Get(string key)
        {
            try
            {
                return Cache[key];
            }
            catch
            {
                return null;
            }
        }

        public static void Add<T>(T objectToCache, string key) where T : class
        {
            Cache.Remove(key);
            Cache.Add(key, objectToCache, DateTime.Now.AddHours(1));
        }

        public static void Add<T>(T objectToCache, string key, DateTime expirationDate) where T : class
        {
            Cache.Remove(key);
            Cache.Add(key, objectToCache, expirationDate);
        }

        public static void AddObject(object objectToCache, string key)
        {
            Cache.Remove(key);
            Cache.Add(key, objectToCache, DateTime.Now.AddHours(1));
        }

        public static void Clear(string key)
        {
            Cache.Remove(key);
        }

        public static void ClearAll()
        {
            //Cache = MemoryCache.Default;
            List<string> cacheKeys = Cache.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                Cache.Remove(cacheKey);
            }
        }

        public static bool Exists(string key)
        {
            return Cache.Get(key) != null;
        }

        public static List<string> GetAll()
        {
            return Cache.Select(keyValuePair => keyValuePair.Key).ToList();
        }
    }
    #endregion

}


using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("AltaPortfolioEmpresaComposicionCommand", (int)IdAccion.PortfoliosEmpresas, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA)]
    public class AltaPortfolioEmpresaComposicionCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            //portfolio = CachingManager.Instance.GetPortfolioDefaultByIdUsuario(IdUsuario);
            var coleccion = (from d in context.PortfoliosComposicion where d.IdProducto == IdProducto && d.IdMercado == IdMercado && d.IdPortfolio == portfolio.IdPortfolio && d.IdPlazo == (byte)PlazoOrdenEnum.ContadoInmediato select d);
            if (coleccion.Count() == 0)
            {
                var request = new PortfolioComposicionEntity()
                {
                    IdMercado = IdMercado,
                    IdPortfolio = Convert.ToInt16(portfolio.IdPortfolio),
                    IdProducto = IdProducto,
                    IdPlazo = (byte)PlazoOrdenEnum.ContadoInmediato
                };
                this.AgregarAlContextoParaAlta(request);
            }

            List<PartyEntity> parties = new List<PartyEntity>();
            if (!IdPersonas.Equals("0"))
            {
                var personas = IdPersonas.Split(',').ToList();
                parties = (from d in context.Persona
                           where personas.Contains(d.IdParty.ToString())
                           select d).ToList();
            }
            else
            {
                //si IdPersonas solo tiene el 0, se selecciono "Todos"
                parties = (from d in context.Persona
                           where d.IdParty != IdEmpresa
                           select d).ToList();
            }
            string strParties = string.Empty;
            foreach (var party in parties)
            {
                strParties += party.Name + ",";
                if (!(from d in context.PermisosProductosEmpresas
                      where d.IdParty == party.IdParty && d.IdProducto == IdProducto
                      select d).Any())
                {
                    var requestUser = new PermisosProductosEntity()
                    {
                        IdProducto = IdProducto,
                        IdParty = party.IdParty,
                        PuedeBid = true,
                        PuedeSell = false,
                        Habilitado = false
                    };
                    this.AgregarAlContextoParaAlta(requestUser);
                }
            }
            strParties = strParties.Remove(strParties.Length - 1);
            var partyEmpresa = (from d in context.Persona
                                where d.IdParty == IdEmpresa
                                select d).ToList();
            foreach (var p in partyEmpresa)
            {
                if (!(from d in context.PermisosProductosEmpresas
                      where d.IdParty == IdEmpresa && d.IdProducto == IdProducto
                      select d).Any())
                {
                    var requestEmpresa = new PermisosProductosEntity()
                    {
                        IdProducto = IdProducto,
                        IdParty = p.IdParty,
                        PuedeBid = false,
                        PuedeSell = true,
                        Habilitado = false
                    };
                    this.AgregarAlContextoParaAlta(requestEmpresa);
                }
            }
            OrdenEntity orden = CreateOrder();
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = orden != null, orden, portfolio, strParties });
        }


        public OrdenEntity CreateOrder()
        {
            bool existeOrden = OrdenHelper.CheckOrdenActivaEnMercadoByIdProducto(IdProducto);
            if (Tasa != 0 && !existeOrden)
            {
                OrdenEntity orden = new OrdenEntity();
                ProductoEntity p = CachingManager.Instance.GetProductoById(IdProducto);

                orden.CompraVenta = "V";
                orden.FechaConcertacion = DateTime.Now.ToUniversalTime();
                orden.IdMercado = 1;
                orden.IdProducto = IdProducto;
                orden.IdMoneda = p.IdMoneda;
                orden.IdPersona = IdEmpresa;
                orden.IdEnNombreDe = null;
                orden.Cantidad = (decimal)PrecioReferencia;
                orden.IdSourceApplication = (byte)SourceEnum.Web;
                orden.PrecioLimite = Tasa;
                orden.IdTipoOrden = 1;
                orden.Plazo = (byte)PlazoOrdenEnum.ContadoInmediato;
                orden.IdEstado = (int)EstadoOrden.Ingresada;
                orden.IdTipoVigencia = TipoVigencia.NoAplica;
                orden.Rueda = p.Rueda;
                orden.Tasa = Tasa;
                orden.IdUsuario = MAEUserSession.InstanciaCargada ? (int?)MAEUserSession.Instancia.IdUsuario : null;
                if (p.IdTipoProducto == (byte)TiposProducto.FACTURAS)
                {
                    orden.OperoPorTasa = true;
                    orden.CantidadMinima = orden.Cantidad;
                }


                try
                {
                    OrdenHelper.AltaOrdenDMA(orden);

                    string key = orden.GetProductKey();
                    OrdenHelper.NotificarAsociacionProductoPortfolio(p, orden.Valorizacion, key, IdPersonas, IdEmpresa, portfolio, orden.IdMercado);
                }
                catch (Exception e)
                {
                    throw new M4TraderApplicationException(e.Message);
                }
                return orden;
            }
            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "PortfoliosEmpresasComposicion";

            #region Requerido

            #endregion Requerido

            #region Unicidad

            portfolio = CachingManager.Instance.GetPortfolioDefaultByIdUsuario(IdUsuario);

            //var coleccion = (from d in context.PortfoliosComposicion where d.IdProducto == IdProducto && d.IdMercado == IdMercado && d.IdPortfolio == portfolio.IdPortfolio select d);
            //ValidateUnicidad(coleccion, "Producto, Mercado y Plazo", "Producto", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            //if (coleccion.Any())
            //  valida = false;

            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.PortfoliosEmpresas;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.ALTA;
            }
        }

        [DataMember]
        public int IdPortfolio { get; set; }

        [DataMember]
        public int IdProducto { get; set; }

        [DataMember]
        public byte IdMercado { get; set; }

        [DataMember]
        public decimal? Precio { get; set; }

        [DataMember]
        public decimal? PrecioReferencia { get; set; }

        [DataMember]
        public decimal? Tasa { get; set; }

        [DataMember]
        public string IdPersonas { get; set; }

        [DataMember]
        public int IdEmpresa { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }

        DTOPortfolio portfolio { get; set; }

    }
}
using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;

namespace M4Trader.ordenes.server.Helpers
{
    public static class FixOrdenHelper
    {
        private static MonedasEnum TraducirMoneda(string moneda)
        {
            return (MonedasEnum)Enum.Parse(typeof(MonedasEnum), moneda, true);
        }

        public static FixOrdenEntity FixOrden_AccionIngresar(OrdenEntity orden, FixTipoAccionEnum fixAccion,
         PartyEntity persona, MercadoEntity mercado, ProductoEntity producto, MonedaEntity moneda, TipoOrdenEntity tipoOrden, PartyEntity personaEnNombreDe)
        {
            FixOrdenEntity fixOrden = new FixOrdenEntity();

            fixOrden.Accion = fixAccion;
            fixOrden.NumeroOrdenLocal = orden.IdOrden;
            fixOrden.Mercado = mercado.Codigo;
            fixOrden.Moneda = TraducirMoneda(moneda.CodigoISO);
            fixOrden.Producto = producto.Codigo;
            fixOrden.TipoOferta = FixTipoEntradaEnum.Offer;

            fixOrden.Cantidad = orden.Cantidad;
            fixOrden.CantidadMinima = orden.CantidadMinima;
            fixOrden.Side = orden.CompraVenta == "C" ? FixSideOrdenEnum.Buy : FixSideOrdenEnum.Sell;
            fixOrden.FechaVencimientoOrden = orden.FechaVencimiento;
            fixOrden.Rueda = orden.Rueda;
            fixOrden.OperoPorTasa = orden.OperoPorTasa;

            if (orden.PrecioLimite.HasValue)
            {
                fixOrden.TipoOrden = FixTipoOrdenEnum.Limit;
                fixOrden.Precio = orden.PrecioLimite.Value;
            }
            else
            {
                fixOrden.TipoOrden = FixTipoOrdenEnum.Market;
            }

            if (personaEnNombreDe != null)
            {
                fixOrden.ClienteId = personaEnNombreDe.TaxIdentificationNumber;
                fixOrden.ClienteRol = FixRolParticipanteEnum.Cliente;
                fixOrden.ClienteNro = personaEnNombreDe.MarketCustomerNumber;
            }

            if (orden.Plazo.HasValue && orden.Plazo.Value > 0)
            {
                fixOrden.TipoPlazoLiquidacionOrden = (PlazoOrdenEnum)orden.Plazo;
                //if (orden.Plazo.Value > (byte)PlazoOrdenEnum.Hr96)
                //{
                //    orden.FechaLiquidacion = CachingManager.Instance.GetFechaLiquidacion(orden.IdProducto,orden.Plazo);
                //}
            }
            fixOrden.TipoDuracionOrden = traducirTipoOrden(tipoOrden);
            if (OrdenesApplication.Instance.ContextoAplicacion.EnviarAgentCode && !string.IsNullOrEmpty(persona.AgentCode))
            {
                fixOrden.AgenteNegociadorId = persona.AgentCode;
            }
            return fixOrden;
        }

        private static FixTipoDuracionOrdenEnum traducirTipoOrden(TipoOrdenEntity tipoOrden)
        {
            if (string.IsNullOrEmpty(tipoOrden.Codigo))
            {
                return FixTipoDuracionOrdenEnum.GTC;
            }
            return (FixTipoDuracionOrdenEnum)tipoOrden.Codigo.ToCharArray()[0];
        }

        public static FixOrdenEntity FixOrden_AccionActualizar(OrdenEntity orden, FixTipoAccionEnum fixAccion,
          PartyEntity persona, MercadoEntity mercado, ProductoEntity producto, MonedaEntity moneda)
        {
            FixOrdenEntity fixOrden = new FixOrdenEntity();

            fixOrden.Accion = fixAccion;
            fixOrden.Cantidad = orden.Cantidad;
            fixOrden.CantidadMinima = orden.CantidadMinima;
            fixOrden.Rueda = orden.Rueda;
            if (orden.PrecioLimite.HasValue)
                fixOrden.Precio = orden.PrecioLimite.Value;

            fixOrden.Side = orden.CompraVenta == "C" ? FixSideOrdenEnum.Buy : FixSideOrdenEnum.Sell;

            fixOrden.NumeroOrdenLocal = orden.IdOrden;
            fixOrden.Mercado = mercado.Codigo;
            fixOrden.Moneda = TraducirMoneda(moneda.CodigoISO);
            fixOrden.Producto = producto.Codigo;
            fixOrden.NumeroOrdenMercado = orden.NumeroOrdenMercado;

            fixOrden.TipoOferta = FixTipoEntradaEnum.Offer;
            if (orden.PrecioLimite.HasValue)
            {
                fixOrden.TipoOrden = FixTipoOrdenEnum.Limit;
                fixOrden.Precio = orden.PrecioLimite.Value;
            }
            else
            {
                fixOrden.TipoOrden = FixTipoOrdenEnum.Market;
            }

            if (orden.Plazo.HasValue && orden.Plazo.Value > 0)
            {
                fixOrden.TipoPlazoLiquidacionOrden = (PlazoOrdenEnum)orden.Plazo;
            }
            if (OrdenesApplication.Instance.ContextoAplicacion.EnviarAgentCode && !string.IsNullOrEmpty(persona.AgentCode))
            {
                fixOrden.AgenteNegociadorId = persona.AgentCode;
            }
            fixOrden.TipoDuracionOrden = FixTipoDuracionOrdenEnum.GTC;

            return fixOrden;
        }

        public static FixOrdenEntity FixOrden_AccionCancelar(OrdenEntity orden, FixTipoAccionEnum fixAccion,
         PartyEntity persona, MercadoEntity mercado, ProductoEntity producto, MonedaEntity moneda)
        {
            FixOrdenEntity fixOrden = new FixOrdenEntity();
            fixOrden.Rueda = orden.Rueda;

            fixOrden.Mercado = mercado.Codigo;
            fixOrden.Producto = producto.Codigo;
            fixOrden.NumeroOrdenLocal = orden.IdOrden;
            fixOrden.NumeroOrdenMercado = orden.NumeroOrdenMercado;

            fixOrden.Side = orden.CompraVenta == "C" ? FixSideOrdenEnum.Buy : FixSideOrdenEnum.Sell;
            fixOrden.Cantidad = orden.Cantidad;
            fixOrden.CantidadMinima = orden.CantidadMinima;
            fixOrden.FechaTransaccion = DateTime.Now.ToUniversalTime();
            if (OrdenesApplication.Instance.ContextoAplicacion.EnviarAgentCode && !string.IsNullOrEmpty(persona.AgentCode))
            {
                fixOrden.AgenteNegociadorId = persona.AgentCode;
            }
            return fixOrden;
        }
    }
}

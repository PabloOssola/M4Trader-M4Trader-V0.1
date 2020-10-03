using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class FixDAL
    {
        public static long InsertarPrecioHistorico(PrecioHistoricoEntity precioHistorico)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", precioHistorico.IdProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", precioHistorico.IdMercado));
            lista.Add(SqlServerHelper.GetParam("@IdMoneda", precioHistorico.IdMoneda));
            lista.Add(SqlServerHelper.GetParam("@Precio", precioHistorico.Precio));
            lista.Add(SqlServerHelper.GetParam("@Cantidad", precioHistorico.Cantidad));
            lista.Add(SqlServerHelper.GetParam("@Fecha", precioHistorico.Fecha));
            lista.Add(SqlServerHelper.GetParam("@CompraVenta", precioHistorico.Side.Equals(FixSideOrdenEnum.Buy) ? "C" : "V"));
            SqlParameter p = SqlServerHelper.GetParamStringOuput("@IdPrecioHistorico");
            lista.Add(p);

            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_InsertarPrecioHistorico", lista);
            precioHistorico.IdPrecioHistorico = long.Parse(p.Value.ToString());
            return precioHistorico.IdPrecioHistorico;
        }

        public static void InsertarOferta20Min(MejoresPuntasOfertaEntity mejorPunta)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", mejorPunta.IdProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMoneda", mejorPunta.IdMoneda));
            lista.Add(SqlServerHelper.GetParam("@PrecioCompra", mejorPunta.PrecioCompra));
            lista.Add(SqlServerHelper.GetParam("@PrecioVenta", mejorPunta.PrecioVenta));
            lista.Add(SqlServerHelper.GetParam("@FechaHoy", DateTime.Now));
            lista.Add(SqlServerHelper.GetParam("@IdPlazo", mejorPunta.IdPlazo));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", mejorPunta.IdMercado));
            lista.Add(SqlServerHelper.GetParam("@Rueda", mejorPunta.Rueda));
            SqlServerHelper.ExecuteNonQuery("precios_owner.HIS_ActualizarOfertas20Min", lista);
        }


        //public void AgregarPrecio(byte idMercado, byte idMoneda, int idProducto, byte tipoPlazoLiquidacionOrden, List<FixEntryType> infoTrade, FixEntryType settlementPrice, FixEntryType highValue, FixEntryType lowValue, FixEntryType tradeVolume)
        public static short AgregarPrecio(byte idMercado, byte idMoneda, int idProducto, byte tipoPlazoLiquidacionOrden, TradeInfo trade, FixEntryType settlementPrice, FixEntryType highValue, FixEntryType lowValue, FixEntryType tradeVolume, FixEntryType closingPrice, FixEntryType openingPrice, FixEntryType equivalentRate)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", idMercado));
            lista.Add(SqlServerHelper.GetParam("@Precio", trade.Precio));
            if (closingPrice != null)
            {
                lista.Add(SqlServerHelper.GetParam("@PrecioUltimoCierre", closingPrice.Precio));
            }
            if (openingPrice != null)
            {
                lista.Add(SqlServerHelper.GetParam("@PrecioApertura", openingPrice.Precio));
            }
            if (equivalentRate != null)
            {
                lista.Add(SqlServerHelper.GetParam("@EquivalentRate", equivalentRate.Precio));
            }
            //if (settlementPrice != null)
            //{
            //    lista.Add(SqlServerHelper.GetParam("@settlementPrice", settlementPrice.Precio));
            //}
            if (highValue != null)
            {
                lista.Add(SqlServerHelper.GetParam("@HighValue", highValue.Precio));
            }
            if (lowValue != null)
            {
                lista.Add(SqlServerHelper.GetParam("@LowValue", lowValue.Precio));
            }
            if (tradeVolume != null)
            {
                lista.Add(SqlServerHelper.GetParam("@TradeVolume", tradeVolume.Cantidad));
            }
            lista.Add(SqlServerHelper.GetParam("@Cantidad", trade.Cantidad));
            lista.Add(SqlServerHelper.GetParam("@Fecha", trade.Fecha));
            lista.Add(SqlServerHelper.GetParam("@IdPlazo", tipoPlazoLiquidacionOrden));
            lista.Add(SqlServerHelper.GetParam("@CompraVenta", trade.Side == FixSideOrdenEnum.Buy ? "C" : "V"));
            SqlParameter p = SqlServerHelper.GetParamStringOuput("@IdPrecio");
            lista.Add(p);

            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_AgregarPrecio", lista);
            return short.Parse(p.Value.ToString());
        }

        public static void AgregarProductoSecurityList(DTOProducto producto, byte idMercado, string segmentMarketId, decimal? cantidadMinima, byte IdPlazo)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@Codigo", producto.Codigo));
            lista.Add(SqlServerHelper.GetParam("@Descripcion", producto.Descripcion));
            lista.Add(SqlServerHelper.GetParam("@IdMoneda", producto.IdMoneda));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", idMercado));
            lista.Add(SqlServerHelper.GetParam("@SegmentMarketId", segmentMarketId));
            lista.Add(SqlServerHelper.GetParam("@CantidadMinima", cantidadMinima));
            lista.Add(SqlServerHelper.GetParam("@IdTipoProducto", producto.IdTipoProducto));
            lista.Add(SqlServerHelper.GetParam("@IdPlazo", IdPlazo));
            if (producto.FechaLiquidacion != DateTime.MinValue)
            {
                lista.Add(SqlServerHelper.GetParam("@FechaLiquidacion", producto.FechaLiquidacion));
            }

            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_InsertarProductoSecurityList", lista);
        }

        public static void AgregarNoticia(string newsId, string titulo, DateTime fecha, string remitente, string destinatarios, string mensaje, byte idMercado)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@NewsId", newsId));
            lista.Add(SqlServerHelper.GetParam("@Titulo", titulo));
            lista.Add(SqlServerHelper.GetParam("@Mensaje", mensaje));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", idMercado));
            lista.Add(SqlServerHelper.GetParam("@Fecha", fecha));
            lista.Add(SqlServerHelper.GetParam("@Remitente", remitente));
            lista.Add(SqlServerHelper.GetParam("@Destinatarios", destinatarios));
            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_InsertarNoticia", lista);
        }

        public static void LimpiarProductosSecurityList(byte idMercado, string segmentMarketId)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdMercado", idMercado));
            lista.Add(SqlServerHelper.GetParam("@SegmentMarketId", segmentMarketId));
            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_LimpiarProductosSecurityList", lista);
        }

        public static void AgregarOferta(OfertaEntity oferta)
        {
            if (oferta.Precio == 0 && oferta.Cantidad == 0)
            {
                return;
            }
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", oferta.IdProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", oferta.IdMercado));
            lista.Add(SqlServerHelper.GetParam("@Precio", oferta.Precio));
            lista.Add(SqlServerHelper.GetParam("@Cantidad", oferta.Cantidad));
            lista.Add(SqlServerHelper.GetParam("@CompraVenta", oferta.CompraVenta));
            lista.Add(SqlServerHelper.GetParam("@NumeroPosicion", oferta.NumeroPosicion));
            lista.Add(SqlServerHelper.GetParam("@Fecha", oferta.Fecha));
            lista.Add(SqlServerHelper.GetParam("@Plazo", oferta.IdPlazo));
            lista.Add(SqlServerHelper.GetParam("@NumeroDeOfertas", oferta.NumeroDeOfertas));
            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_AgregarOferta", lista);

        }

        public static void PersistirOferta(byte IdMercado, byte IdMoneda, int IdProducto, byte tipoPlazoLiquidacionOrden, FixOfertaEntity oferta)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", IdProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", IdMercado));
            lista.Add(SqlServerHelper.GetParam("@Precio", oferta.Precio));
            lista.Add(SqlServerHelper.GetParam("@Cantidad", oferta.Cantidad));
            lista.Add(SqlServerHelper.GetParam("@CompraVenta", oferta.TipoOferta == FixTipoEntradaEnum.Bid ? "C" : "V"));
            lista.Add(SqlServerHelper.GetParam("@NumeroPosicion", oferta.NumeroPosicion));
            lista.Add(SqlServerHelper.GetParam("@EquivalentRate", oferta.SpotRate));
            lista.Add(SqlServerHelper.GetParam("@Fecha", oferta.Fecha));
            lista.Add(SqlServerHelper.GetParam("@Plazo", tipoPlazoLiquidacionOrden));
            lista.Add(SqlServerHelper.GetParam("@NumeroDeOfertas", oferta.NumeroDeOfertas));
            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_AgregarOferta", lista);
        }

        public static void PersistirProductoPorMercado(int IdMercado, int IdProducto, FixEntryType openPrice, FixEntryType closePrice, FixEntryType referencePrice)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", IdProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", IdMercado));

            if (openPrice != null)
            {
                lista.Add(SqlServerHelper.GetParam("@OpenPrice", openPrice.Precio));
            }
            if (closePrice != null)
            {
                lista.Add(SqlServerHelper.GetParam("@ClosePrice", closePrice.Precio));
            }
            if (referencePrice != null)
            {
                lista.Add(SqlServerHelper.GetParam("@ReferencePrice", referencePrice.Precio));
            }
            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_AgregarProductoPorMercado", lista);
        }

        public static void BorrarOferta(OfertaEntity oferta, bool todas)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", oferta.IdProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", oferta.IdMercado));
            if (!todas)
            {
                lista.Add(SqlServerHelper.GetParam("@NumeroPosicion", oferta.NumeroPosicion));
                lista.Add(SqlServerHelper.GetParam("@CompraVenta", oferta.CompraVenta));
            }
            lista.Add(SqlServerHelper.GetParam("@Plazo", oferta.IdPlazo));

            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_BorrarOferta", lista);
        }

        public static void BorrarOfertas(byte idMercado, int idProducto, byte idPlazo)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", idMercado));
            lista.Add(SqlServerHelper.GetParam("@Plazo", idPlazo));
            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_BorrarOfertas", lista);
        }
        public static byte InsertarMercado(DTOMercado mercado)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@Codigo", mercado.Codigo));
            lista.Add(SqlServerHelper.GetParam("@Descripcion", mercado.Descripcion));
            lista.Add(SqlServerHelper.GetParam("@EsInterno", mercado.EsInterno));
            lista.Add(SqlServerHelper.GetParam("@ProductoHabilitadoDefecto", mercado.ProductoHabilitadoDefecto));
            SqlParameter p = SqlServerHelper.GetParamStringOuput("@IdMercado");
            lista.Add(p);

            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_InsertarMercado", lista);
            mercado.IdMercado = byte.Parse(p.Value.ToString());
            return mercado.IdMercado;
        }
    }
}

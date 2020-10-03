using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;
using System;

namespace M4Trader.ordenes.server.DataAccess
{
    public class FixDALCaller : IFixDAL
    {
        public void EncolarPrecioHistoricos(PrecioHistoricoEntity precioHistorico)
        {
            PreciosHelperService.Instance.EnQueueMessage(precioHistorico);
        }

        public void EncolarMejorOferta20Minutos(byte idMercado, byte idMoneda, int idProducto, byte tipoPlazoLiquidacionOrden, FixOfertasEntity ofertas)
        {
            MejoresPuntasOfertaEntity MPO = new MejoresPuntasOfertaEntity();
            MPO.IdMercado = idMercado;
            MPO.IdMoneda = idMoneda;
            MPO.IdProducto = idProducto;
            MPO.IdPlazo = tipoPlazoLiquidacionOrden;
            FixOfertaEntity oferta = ofertas.Ofertas.Find(x => x.NumeroPosicion == 1 && x.TipoOferta == FixTipoEntradaEnum.Bid);
            MPO.PrecioCompra = oferta?.Precio;
            oferta = ofertas.Ofertas.Find(x => x.NumeroPosicion == 1 && x.TipoOferta == FixTipoEntradaEnum.Offer);
            MPO.PrecioVenta = oferta?.Precio;
            MPO.Rueda = CachingManager.Instance.GetProductoById(idProducto).Rueda;
            OfertasHelperService.Instance.EnQueueMessage(MPO);
        }

        //FixTipoEntradaEnum tipoOferta no se usa, pero es necesario para implementar la interfaz, porque se usa en otros lados
        public void AgregarOferta(OfertaEntity oferta, FixTipoEntradaEnum tipoOferta)
        {
            FixDAL.AgregarOferta(oferta);
        }

        public void BorrarOferta(OfertaEntity oferta, bool todas)
        {
            FixDAL.BorrarOferta(oferta, todas);
        }

        public void BorrarOfertas(byte idMercado, int idProducto, byte idPlazo)
        {
            FixDAL.BorrarOfertas(idMercado, idProducto, idPlazo);
        }



        public int GetIdUsuarioProceso()
        {
            return OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario;
        }

        public void ProcesarTradingSessionStatusClosing(FixTradingSessionStatusEntity tradingSessionStatus, Guid guid, int idUsuarioProceso)
        {
            try
            {
                //El mercado se cerro, hacer el cierre del dia
                SistemaHelper.CerrarElDia(idUsuarioProceso);
                //loguear la recepcion de este mensaje
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "ProcesarTradingSessionStatus: .Msg: Se cerro el dia.", IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado, IdUsuario = idUsuarioProceso });
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "ProcesarTradingSessionStatus: .Msg: " + e.Message, Exception = e, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado, IdUsuario = idUsuarioProceso });
            }
        }

        public void ProcesarTradingSessionStatusOpening(FixTradingSessionStatusEntity tradingSessionStatus, Guid guid, int idUsuarioProceso)
        {
            try
            {
                //El mercado se abrio, hacer la apertura del dia
                SistemaHelper.AbrirElDia(idUsuarioProceso);
                //loguear la recepcion de este mensaje
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "ProcesarTradingSessionStatus: .Msg: Se abrio el dia.", IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado, IdUsuario = idUsuarioProceso });
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "ProcesarTradingSessionStatus: .Msg: " + e.Message, Exception = e, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado, IdUsuario = idUsuarioProceso });
            }
        }

        public void LimpiarProductosSecurityList(byte idMercado, string segmentMarketId, Guid guid, int idUsuarioProceso)
        {
            try
            {
                FixDAL.LimpiarProductosSecurityList(idMercado, segmentMarketId);
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "InformarSecurityList. Msg: " + e.Message, Exception = e, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado, IdUsuario = idUsuarioProceso });
                throw e;
            }
        }

        public void AgregarProductoSecurityList(DTOProducto producto, byte idMercado, string segmentMarketId, Guid guid, int idUsuarioProceso, decimal? cantidadMinima)
        {
            try
            {
                byte IdPlazo = Byte.Parse(producto.Plazo);//CachingbManager.Instance.GetAllPlazos().Find(x => x.Descripcion == producto.Plazo).IdPlazo;
                FixDAL.AgregarProductoSecurityList(producto, idMercado, segmentMarketId, cantidadMinima, IdPlazo);
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "InformarSecurityList. Msg: " + e.Message, Exception = e, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado, IdUsuario = idUsuarioProceso });
                throw e;
            }
        }

        public void AgregarNoticia(string newsId, string titulo, DateTime fecha, string remitente, string destinatarios, string mensaje, byte idMercado, Guid guid, int idUsuarioProceso)
        {
            try
            {
                FixDAL.AgregarNoticia(newsId, titulo, fecha, remitente, destinatarios, mensaje, idMercado);
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "InformarNoticia. Msg: " + e.Message, Exception = e, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado, IdUsuario = idUsuarioProceso });
                throw e;
            }
        }

        public void PersistirOferta(byte IdMercado, byte IdMoneda, int IdProducto, byte tipoPlazoLiquidacionOrden, FixOfertaEntity oferta)
        {
            FixDAL.PersistirOferta(IdMercado, IdMoneda, IdProducto, tipoPlazoLiquidacionOrden, oferta);
        }

        public void PersistirProductoPorMercado(int IdMercado, int IdProducto, FixEntryType openPrice, FixEntryType closePrice, FixEntryType referencePrice)
        {
            FixDAL.PersistirProductoPorMercado(IdMercado, IdProducto, openPrice, closePrice, referencePrice);
        }

        //public void AgregarPrecio(byte idMercado, byte idMoneda, int idProducto, byte tipoPlazoLiquidacionOrden, TradeInfo infoTrade, FixEntryType settlementPrice, FixEntryType highValue, FixEntryType lowValue, FixEntryType tradeVolume, FixEntryType ClosingPrice)
        //{
        //    FixDAL.AgregarPrecio(idMercado, idMoneda, idProducto, tipoPlazoLiquidacionOrden, infoTrade, settlementPrice, highValue, lowValue, tradeVolume, ClosingPrice);
        //}

        public void AgregarPrecio(byte idMercado, byte idMoneda, int idProducto, byte tipoPlazoLiquidacionOrden, TradeInfo trade, FixEntryType closePrice, FixEntryType openPrice)
        {
            FixEntryType highValue = null;
            FixEntryType lowValue = null;
            FixEntryType tradeVolume = null;
            FixEntryType settlementPrice = null;
            FixEntryType equivalentRate = null;
            if (trade.InfoTrade != null && trade.InfoTrade.Count > 0)
            {
                highValue = trade.InfoTrade.Find(it => it.TipoOferta == FixTipoEntradaEnum.TradingSessionHighPrice);
                lowValue = trade.InfoTrade.Find(it => it.TipoOferta == FixTipoEntradaEnum.TradingSessionLowPrice);
                tradeVolume = trade.InfoTrade.Find(it => it.TipoOferta == FixTipoEntradaEnum.TradeVolume);
                settlementPrice = trade.InfoTrade.Find(it => it.TipoOferta == FixTipoEntradaEnum.SettlementPrice);
                equivalentRate = trade.InfoTrade.Find(it => it.TipoOferta == FixTipoEntradaEnum.MarginRate);
            }

            FixDAL.AgregarPrecio(idMercado, idMoneda, idProducto, tipoPlazoLiquidacionOrden, trade, settlementPrice, highValue, lowValue, tradeVolume, closePrice, openPrice, equivalentRate);
        }
    }
}

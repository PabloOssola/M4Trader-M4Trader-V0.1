using M4Trader.ordenes.server.MCContext.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class OperacionesHistoricasDAL
    {
        public static void InsertarOperacionHistorica(OperacionHistoricoEntity operacionHistorico)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            if (operacionHistorico.FechaLiquidacion.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@FechaLiquidacion", operacionHistorico.FechaLiquidacion));
            }
            lista.Add(SqlServerHelper.GetParam("@Rueda", operacionHistorico.Rueda));
            lista.Add(SqlServerHelper.GetParam("@TradeReportID", operacionHistorico.TradeReportID));
            //lista.Add(SqlServerHelper.GetParam("@IdTipoNegociacion", operacionHistorico.IdTipoNegociacion));
            lista.Add(SqlServerHelper.GetParam("@IdProducto", operacionHistorico.IdProducto));
            if (operacionHistorico.IdPlazo.HasValue)
                lista.Add(SqlServerHelper.GetParam("@IdPlazo", operacionHistorico.IdPlazo));
            if (operacionHistorico.IdMoneda.HasValue)
                lista.Add(SqlServerHelper.GetParam("@IdMoneda", operacionHistorico.IdMoneda));
            lista.Add(SqlServerHelper.GetParam("@PrecioTasa", operacionHistorico.PrecioTasa));            
            lista.Add(SqlServerHelper.GetParam("@Cantidad", operacionHistorico.Cantidad));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", operacionHistorico.IdMercado));
            lista.Add(SqlServerHelper.GetParam("@EsAlta", operacionHistorico.EsAlta));
            lista.Add(SqlServerHelper.GetParam("@OperaPorTasa", operacionHistorico.OperoPorTasa));
            lista.Add(SqlServerHelper.GetParam("@Fecha", operacionHistorico.Fecha));
            lista.Add(SqlServerHelper.GetParam("@ProductoNombreLargo", operacionHistorico.ProductoNombreLargo));
            lista.Add(SqlServerHelper.GetParam("@LastSpotRate", operacionHistorico.LastSpotRate));
            if (operacionHistorico.ReferencePrice.HasValue)
                lista.Add(SqlServerHelper.GetParam("@ReferencePrice", operacionHistorico.ReferencePrice));
            if (operacionHistorico.Valorizacion.HasValue)
                lista.Add(SqlServerHelper.GetParam("@Valorizacion", operacionHistorico.Valorizacion));
            lista.Add(SqlServerHelper.GetParam("@PartyComprador", operacionHistorico.PartyComprador));
            lista.Add(SqlServerHelper.GetParam("@PartyVendedor", operacionHistorico.PartyVendedor));
            lista.Add(SqlServerHelper.GetParam("@MensajeTextoPlano", operacionHistorico.MensajeTextoPlano));
            SqlServerHelper.ExecuteNonQuery("orden_owner.FIX_AgregarOperacionHistorico", lista);
        }
    }
}
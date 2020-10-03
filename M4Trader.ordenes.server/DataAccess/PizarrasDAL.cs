using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.server.MCContext.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class PizarrasDAL
    { 

        public static decimal ObtenerPrecioActual(byte idmoneda, string compraOVenta)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdMoneda", idmoneda));
            lista.Add(SqlServerHelper.GetParam("@compraOVenta", compraOVenta));
            SqlParameter Precio = SqlServerHelper.GetParamDecimalOuput("@Precio");
            lista.Add(Precio); 

            SqlServerHelper.ExecuteNonQuery("[orden_owner].[PIZ_GetPrecioByMonedaCompraYVenta]", lista);
            return (decimal)(Precio.Value);
        }
         
    }
}

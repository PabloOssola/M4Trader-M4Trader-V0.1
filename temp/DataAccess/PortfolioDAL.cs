using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class PortfolioDAL
    {
        public static void SetearPorDefecto(int idPortfolioUsuario, int idUsuario)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdPortfolioUsuario", idPortfolioUsuario));
            lista.Add(SqlServerHelper.GetParam("@IdUsuario", idUsuario));

            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_ActualizarPortfolioUsuarioSetearPorDefecto", lista);
        }


        public static void DesAsociarPortfoliosProductosFCE()
        {
            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_DesAsociarPortfoliosProductosFCE", null);
        }

        public static void HabilitarPortfoliosProductosFCE(int idProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));
            SqlServerHelper.ExecuteNonQuery("orden_owner.PROD_HabilitarPortfoliosProductosFCE", lista);
        }

        public static void DesHabilitarPortfoliosProductosFCE(int idProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));
            SqlServerHelper.ExecuteNonQuery("orden_owner.PROD_DesHabilitarPortfoliosProductosFCE", lista);
        }

        public static void DesAsociarProdutoParty(int idProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));

            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_DesAsociarPortfolioParty", lista);
        }
    }
}

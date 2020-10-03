using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class ProductosDAL
    {
        public static void ProcessFromXml(List<SqlParameter> lista)
        {
            
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[XML_PRODUCTOS_PROCESSING]", lista);
        }

        public static void EliminarProducto(int idProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));

            SqlServerHelper.ExecuteNonQuery("orden_owner.PROD_ELIMINARPRODUCTO", lista);
        }

        public static void EliminarPortfolioComposicion(int idProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));

            SqlServerHelper.ExecuteNonQuery("orden_owner.PROD_ELIMINARPORTFOLIOCOMPOSICION", lista);
        }
    }
}

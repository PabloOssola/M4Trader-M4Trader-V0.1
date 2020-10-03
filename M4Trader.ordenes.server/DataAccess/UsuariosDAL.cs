using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class UsuariosDAL
    {
        public static void ProcessFromXml(List<SqlParameter> lista)
        {
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[XML_PRODUCTOS_PROCESSING]", lista);
        }

        public static void EliminarUsuario(int idUsuario)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdUsuario", idUsuario));

            SqlServerHelper.ExecuteNonQuery("orden_owner.USUARIO_EliminarUsuario", lista);
        }

        public static void ActualizarUsuario(int idUsuario, string nombre, decimal limiteOferta, decimal limiteOperacion, bool bloqueado)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdUsuario", idUsuario));
            lista.Add(SqlServerHelper.GetParam("@Nombre", nombre));
            lista.Add(SqlServerHelper.GetParam("@LimiteOferta", limiteOferta));
            lista.Add(SqlServerHelper.GetParam("@LimiteOperacion", limiteOperacion));
            lista.Add(SqlServerHelper.GetParam("@Bloqueado", bloqueado));

            SqlServerHelper.ExecuteNonQuery("orden_owner.USUARIO_ActualizarUsuario", lista);
        }

        public static void CrearUsuario(int idParty, int idUsuario, string nombre, decimal limiteOferta, decimal limiteOperacion, bool bloqueado)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdParty", idParty));
            lista.Add(SqlServerHelper.GetParam("@IdUsuario", idUsuario));
            lista.Add(SqlServerHelper.GetParam("@Nombre", nombre));
            lista.Add(SqlServerHelper.GetParam("@LimiteOferta", limiteOferta));
            lista.Add(SqlServerHelper.GetParam("@LimiteOperacion", limiteOperacion));
            lista.Add(SqlServerHelper.GetParam("@Bloqueado", bloqueado));

            SqlServerHelper.ExecuteNonQuery("orden_owner.USUARIO_CrearUsuario", lista);
        }

        public static void EliminarPortfolioComposicion(int idProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));

            SqlServerHelper.ExecuteNonQuery("orden_owner.PROD_ELIMINARPORTFOLIOCOMPOSICION", lista);
        }
    }
}

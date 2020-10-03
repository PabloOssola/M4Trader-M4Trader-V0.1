using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class MensajesDAL
    {
        public static string ObtenerMensajeByCodigo(string codigo)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@Codigo", codigo));
            SqlParameter p = SqlServerHelper.GetParamStringOuput("@Mensaje");
            lista.Add(p);

            SqlServerHelper.ExecuteNonQuery("orden_owner.MSG_ObtenerMensajeByCodigo", lista);
            return (string)p.Value;
        }
    }
}

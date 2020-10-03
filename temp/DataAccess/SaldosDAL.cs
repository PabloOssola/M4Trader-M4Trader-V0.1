using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.server.MCContext.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace M4Trader.ordenes.server.DataAccess
{
    public class SaldosDAL
    {
        public static void CleanSaldos()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[ORD_CleanSaldos]", lista);
        }

        public static void ProcessFromXml(List<SqlParameter> lista)
        {
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[XML_SALDOS_PROCESSING]", lista);
        }
    }
}

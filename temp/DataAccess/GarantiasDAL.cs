using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class GarantiasDAL
    {
        public static void InsertarCollateralReport(FixGarantiasEntity garantia, byte idMoneda)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@ClearingHouse", garantia.ClearingHouse));
            lista.Add(SqlServerHelper.GetParam("@Dador", garantia.Dador));
            lista.Add(SqlServerHelper.GetParam("@Receptor", garantia.Receptor));
            lista.Add(SqlServerHelper.GetParam("@IdMoneda", idMoneda));
            lista.Add(SqlServerHelper.GetParam("@TotalAmount", garantia.TotalAmount));
            lista.Add(SqlServerHelper.GetParam("@ConsumedAmount", garantia.ConsumedAmount));
            lista.Add(SqlServerHelper.GetParam("@ConsumedChips", garantia.ConsumedChips));
            SqlParameter p1 = SqlServerHelper.GetParamStringOuput("@IdCollateralReport");
            lista.Add(p1);

            SqlServerHelper.ExecuteNonQuery("precios_owner.GAR_InsertarCollateralReport", lista);
            garantia.IdCollateralReport = int.Parse(p1.Value.ToString());
        }
    }
}

using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class MarketWatchDAL
    {

        public static List<PrecioHubModel> PreciosYOfertas(int idUsuario, int idPortfolio)
        {
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(SqlServerHelper.GetParam("@IdUsuario", idUsuario));
            lstParams.Add(SqlServerHelper.GetParam("@IdPortfolio", idPortfolio));
            lstParams.Add(SqlServerHelper.GetParam("@PageNumber", 1));
            lstParams.Add(SqlServerHelper.GetParam("@PageSize", 100));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.QRY_SCRN_PORTFOLIO_GRID_MAIN_ALL", lstParams))
            {
                return reader.DataReaderMapToList<PrecioHubModel>();
            }
        }
    }
}

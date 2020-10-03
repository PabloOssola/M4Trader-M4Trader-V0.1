using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Interfaces;
using M4Trader.ordenes.server.DataAccess;

namespace M4Trader.ordenes.mvc
{
    public class LogSeguridadCustomQueryById : ICustomQuery
    {
        public object Execute(Query query)
        {
            return SqlServerHelper
                .RunFullRecordDictionary("orden_owner.QRY_SCRN_LOGSEGURIDAD_VIEW_MAIN_ALL", query.Filters);
        }
    }
}
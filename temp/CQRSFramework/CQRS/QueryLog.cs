using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.services.CQRSFramework.CQRS;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using System;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;

namespace M4Trader.ordenes.server.CQRSFramework.CQRS
{
    public class QueryLog
    {
        public static void Start(Query query, InCourseRequest inCourseRequest)
        {
            ILogCommandEntity log = LoggingService.Instance.GetLogCommand();
      
            log.CommandName = query.Name;

            log.Codigo = "QUERY";
            log.StartDatetime = DateTime.Now;
            log.RequestId = inCourseRequest.Id;
            log.Data = new
            {
                Type = query.Type,
                Filters = query.Filters,
                Options = query.Options
            };
            LoggingHelper.Instance.AgregarLog(log);
        }
        
        public static void FinishWithError(string query, QueryResult result, Exception ex, InCourseRequest inCourseRequest)
        {
            ILogCommandEntity log = LoggingService.Instance.GetLogCommand();
            log.CommandName = query;
            log.Codigo = "QUERY-ERROR";
            log.StartDatetime = DateTime.Now;
            log.RequestId = inCourseRequest.Id;
            log.Data = ex;
            LoggingService.Instance.AgregarLog(log);
        }

        public static void FinishWithError(Query query, QueryResult result, Exception ex, InCourseRequest inCourseRequest)
        {
            ILogCommandEntity log = LoggingService.Instance.GetLogCommand();
            if (!query.IsMobile)
                log.CommandName = query.Name;
            else
                log.CommandName = query.Name;
            log.Codigo = "QUERY-ERROR";
            log.StartDatetime = DateTime.Now;
            log.RequestId = inCourseRequest.Id;
            log.Data = ex;
            LoggingHelper.Instance.AgregarLog(log);
        }

        public static void FinishOK(Query query, QueryResult result, InCourseRequest inCourseRequest)
        {
            ILogCommandEntity log = LoggingService.Instance.GetLogCommand();
            
            log.CommandName = query.Name;
            log.Codigo = "QUERY-OK";
            log.StartDatetime = DateTime.Now;
            log.RequestId = inCourseRequest.Id;
            log.Data = result.Status;
            LoggingHelper.Instance.AgregarLog(log);
        }
    }
}

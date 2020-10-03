using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.services.CQRSFramework.CQRS;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;
using System;

namespace M4Trader.ordenes.server.CQRSFramework.CQRS
{
    public class CommandLog
    {
        public static void Start(Command command, InCourseRequest inCourseRequest)
        {
            ILogCommandEntity log = LoggingService.Instance.GetLogCommand();
            log.CommandName = command.GetType().Name;
            log.Codigo = "CMD";
            log.StartDatetime = DateTime.Now;
            log.RequestId = inCourseRequest.Id;
            log.Data = command;
            LoggingHelper.Instance.AgregarLog(log);
        }

        public static void Start(string command, object data, InCourseRequest inCourseRequest, string codigo = "CMD")
        {
            ILogCommandEntity log = LoggingService.Instance.GetLogCommand();
            log.CommandName = command;
            log.Codigo = codigo;
            log.StartDatetime = DateTime.Now;
            log.RequestId = inCourseRequest.Id;
            log.Data = data;
            LoggingService.Instance.AgregarLog(log);
        }

        public static void FinishWithError(string command, Exception ex, InCourseRequest inCourseRequest, string codigo = "CMD-ERROR")
        {
            ILogCommandEntity log = LoggingService.Instance.GetLogCommand();
            log.CommandName = command;
            log.Codigo = codigo;
            log.StartDatetime = DateTime.Now;
            log.RequestId = inCourseRequest.Id;
            log.Data = ex;
            LoggingService.Instance.AgregarLog(log);
        }

        public static void FinishOK(string command, object result, InCourseRequest inCourseRequest, string codigo = "CMD-OK")
        {
            ILogCommandEntity log = LoggingService.Instance.GetLogCommand();
            log.CommandName = command;
            log.Codigo = codigo;
            log.StartDatetime = DateTime.Now;
            log.RequestId = inCourseRequest.Id;
            if (result != null)
            {
                if (result is CommandResult)
                {
                    log.Data = ((CommandResult)result).Status;
                }
                else
                {
                    log.Data = result;
                }
            }
            LoggingService.Instance.AgregarLog(log);
        }

        public static void StartDesencriptado(string jsonDesEncry, InCourseRequest inCourseRequest)
        {
            if (string.IsNullOrEmpty(jsonDesEncry))
                return;
            ILogCommandEntity log = LoggingHelper.Instance.GetLogCommand();
            log.CommandName = "CMD-ENCRY";
            log.Codigo = "CMD";
            log.StartDatetime = DateTime.Now;
            log.RequestId = inCourseRequest.Id;
            log.Data = jsonDesEncry;
            LoggingHelper.Instance.AgregarLog(log);
            
        }
    }
}

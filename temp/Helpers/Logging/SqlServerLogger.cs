using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.Helpers.Logging
{
    public class SqlServerLogger : LoggerBase, ILogger<LogSqlEntity>
    {
        private ConcurrentQueue<LogSqlEntity> logs = new ConcurrentQueue<LogSqlEntity>();
        
        public void AddToLog(object tmp)
        {
            LogSqlEntity log = (LogSqlEntity)tmp;
            this.FillLog(log);
            this.logs.Enqueue(log);
        }

        public LogSqlEntity FillLog(LogSqlEntity log)
        {
            if(MAEUserSession.InstanciaCargada)
            {
                log.IdUsuario = MAEUserSession.Instancia.IdUsuario;
                log.RequestId = MAEUserSession.Instancia.InCourseRequest;
            }

            if( log.Exception != null)
                log.StackTrace = log.Exception.StackTrace;
            try
            {
                log.CallStack = GetCallStack();
            }
            catch { }
            if (log.Parametros != null && log.Parametros.Count > 0)
            {
                foreach (var item in log.Parametros)
                {
                    if (!string.IsNullOrEmpty(log.ParametrosSP))
                    {
                        log.ParametrosSP = log.ParametrosSP + ", ";
                    }
                    log.ParametrosSP = log.ParametrosSP +
                        (item.ParameterName.StartsWith("@") ? item.ParameterName : "@" + item.ParameterName) + "=" + (item.Value == DBNull.Value || item.Value == null ? "null" : FormatearParametroParaLogSegunTipo(item.Value, item.SqlDbType));
                }
            }
            return log;
        }

        public void Persistir()
        {
            if (logs != null && logs.Count > 0)
            {
                LogSqlEntity log = null;
                while (logs.TryDequeue(out log))
                {
                    if (log.Exception != null)
                    {
                        log.MensajeError = GetExceptionDescription(log.Exception);
                    }
                    Insertar(log);
                }
            }
        }

        private void Insertar(LogSqlEntity log)
        {

            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@Fecha", log.Fecha));
            lista.Add(SqlServerHelper.GetParam("@TipoSentenciaSQL", log.TipoSentenciaSQL));
            lista.Add(SqlServerHelper.GetParam("@StackTrace", log.StackTrace));
            lista.Add(SqlServerHelper.GetParam("@ParametrosSP", log.ParametrosSP));
            lista.Add(SqlServerHelper.GetParam("@NombreSP", log.NombreSP));
            lista.Add(SqlServerHelper.GetParam("@MensajeError  ", log.MensajeError));
            lista.Add(SqlServerHelper.GetParam("@CallStack", log.CallStack));
            lista.Add(SqlServerHelper.GetParam("@IdUsuario  ", log.IdUsuario));
            lista.Add(SqlServerHelper.GetParam("@RequestId", log.RequestId));

            SqlServerHelper.ExecuteNonQuery("orden_owner.LOG_SqlErroresInsert", lista);
        }
    }
}

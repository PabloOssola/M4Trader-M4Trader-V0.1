using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.Helpers.Logging
{
    public class ProcesosLogger : LoggerBase, ILogger<LogProcesoEntity>
    {
        private ConcurrentQueue<LogProcesoEntity> logs = new ConcurrentQueue<LogProcesoEntity>();
        
        public void AddToLog(object tmp)
        {
            LogProcesoEntity log = (LogProcesoEntity)tmp;
            this.Fill(log);
            this.logs.Enqueue(log);
        }

        private void Fill(LogProcesoEntity log)
        {
            if(MAEUserSession.InstanciaCargada)
            {
                log.IdUsuario = MAEUserSession.Instancia.IdUsuario;
            }
            
        }

        public void Persistir()
        {
            if (logs != null && logs.Count > 0)
            {
                LogProcesoEntity log = null;
                while (logs.TryDequeue(out log))
                {
                    if (log.Exception != null)
                    {
                        log.Resultado = GetCallStack() + "\r\nException" + GetExceptionDescription(log.Exception);
                    }
                    Insertar(log);
                }
            }
        }

        private void Insertar(LogProcesoEntity log)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdUsuario", log.IdUsuario));
            lista.Add(SqlServerHelper.GetParam("@descripcion", log.Descripcion));
            lista.Add(SqlServerHelper.GetParam("@fecha", log.Fecha));
            lista.Add(SqlServerHelper.GetParam("@resultado  ", log.Resultado));
            lista.Add(SqlServerHelper.GetParam("@RequestId", log.RequestId));
            lista.Add(SqlServerHelper.GetParam("@IdLogCodigoAccion", log.IdLogCodigoAccion));
            SqlServerHelper.ExecuteNonQuery("orden_owner.LOG_ProcesosInsert", lista);
        }
    }
}

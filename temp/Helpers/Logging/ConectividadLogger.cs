using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.Helpers.Logging
{
    public class ConectividadLogger : LoggerBase, ILogger<LogSeguridadEntity>
    {
        private ConcurrentQueue<LogConectividadEntity> logs = new ConcurrentQueue<LogConectividadEntity>();
        
        public void AddToLog(object tmp)
        {
            LogConectividadEntity log = (LogConectividadEntity)tmp;
            this.logs.Enqueue(log);
        }
        
        public void Persistir()
        {
            if (logs != null && logs.Count > 0)
            {
                LogConectividadEntity log = null;
                while (logs.TryDequeue(out log))
                {
                    Insertar(log);
                }
            }
        }

        private void Insertar(LogConectividadEntity log)
        {

            List<SqlParameter> lista = new List<SqlParameter>();
            
            lista.Add(SqlServerHelper.GetParam("@IdPersona", log.IdPersona));
            lista.Add(SqlServerHelper.GetParam("@Fecha", log.Fecha));
            lista.Add(SqlServerHelper.GetParam("@Mensaje", log.Mensaje));
            SqlServerHelper.ExecuteNonQuery("orden_owner.LOG_ConectividadInsert", lista);


        }
    }
}

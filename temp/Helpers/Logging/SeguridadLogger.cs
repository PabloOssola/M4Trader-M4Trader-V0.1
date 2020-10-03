using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.Helpers.Logging
{
    public class SeguridadLogger : LoggerBase, ILogger<LogSeguridadEntity>
    {
        private ConcurrentQueue<LogSeguridadEntity> logs = new ConcurrentQueue<LogSeguridadEntity>();
        
        public void AddToLog(object tmp)
        {
            LogSeguridadEntity log = (LogSeguridadEntity)tmp;
            this.logs.Enqueue(log);
        }
        
        public void Persistir()
        {
            if (logs != null && logs.Count > 0)
            {
                LogSeguridadEntity log = null;
                while (logs.TryDequeue(out log))
                {
                    Insertar(log);
                }
            }
        }

        private void Insertar(LogSeguridadEntity log)
        {

            List<SqlParameter> lista = new List<SqlParameter>();
            
            lista.Add(SqlServerHelper.GetParam("@idusuario", log.IdUsuario));
            lista.Add(SqlServerHelper.GetParam("@fecha", log.Fecha));
            lista.Add(SqlServerHelper.GetParam("@descripcion", log.Descripcion));
            lista.Add(SqlServerHelper.GetParam("@IdLogCodigoAccion  ", log.IdLogCodigoAccion));
            lista.Add(SqlServerHelper.GetParam("@RequestId", log.RequestId));
            lista.Add(SqlServerHelper.GetParam("@IdAplicacion", log.IdAplicacion));


            SqlServerHelper.ExecuteNonQuery("orden_owner.LOG_SeguridadInsert", lista);


        }
    }
}

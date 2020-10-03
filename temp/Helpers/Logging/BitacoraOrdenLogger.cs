using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.Helpers.Logging
{
    public class BitacoraOrdenLogger : LoggerBase, ILogger<LogBitacoraOrdenEntity>
    {
        private ConcurrentQueue<LogBitacoraOrdenEntity> logsBO = null;
        public BitacoraOrdenLogger()
        {
            logsBO = new ConcurrentQueue<LogBitacoraOrdenEntity>();
        }

        public void AddToLog(object tmp)
        {
            LogBitacoraOrdenEntity log = (LogBitacoraOrdenEntity)tmp;
            this.logsBO.Enqueue(log);
        }

        public void Persistir()
        {
            if (logsBO != null && logsBO.Count > 0)
            {
                LogBitacoraOrdenEntity log = null;
                while (logsBO.TryDequeue(out log))
                {
                    Insertar(log);
                }
            }
        }

        private void Insertar(LogBitacoraOrdenEntity log)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdOrden", log.IdOrden));
            lista.Add(SqlServerHelper.GetParam("@IdUsuario", log.IdUsuario));
            lista.Add(SqlServerHelper.GetParam("@Fecha", log.Fecha));
            lista.Add(SqlServerHelper.GetParam("@CodigoAccion", log.CodigoAccion));
            lista.Add(SqlServerHelper.GetParam("@DetalleAccion", log.DetalleAccion));
            lista.Add(SqlServerHelper.GetParam("@IdEstadoOrden", log.IdEstadoOrden));
            lista.Add(SqlServerHelper.GetParam("@IdMotivoCancelacion", log.IdMotivoCancelacion));
            lista.Add(SqlServerHelper.GetParam("@RequestId", log.RequestId));
            lista.Add(SqlServerHelper.GetParam("@IdSourceApplication", log.IdSourceApplication));

            SqlServerHelper.ExecuteNonQuery("orden_owner.LOG_BitacoraOrdenInsert", lista);
        }
    }
}

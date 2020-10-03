using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.Helpers.Logging
{
    public class CommandLogger : LoggerBase, ILogger<LogCommandEntity>
    {
        private ConcurrentQueue<ILogCommandEntity> logs = new ConcurrentQueue<ILogCommandEntity>();
        
        public void AddToLog(object tmp)
        {
            ILogCommandEntity log = (ILogCommandEntity)tmp;
            this.FillLog(log);
            this.logs.Enqueue(log);
        }

        public ILogCommandEntity FillLog(ILogCommandEntity log)
        {
            int? idUsuario = null;
            Guid? idSesion = null;
            if(MAEUserSession.InstanciaCargada)
            { 
                idUsuario = MAEUserSession.Instancia.IdUsuario;
                idSesion = MAEUserSession.Instancia.InternalId;
            }
            log.IdUsuario = idUsuario;
            log.StartDatetime = DateTime.Now;
            
            if(log.Data is Exception)
                log.Argument = ((Exception)log.Data).Message + ((Exception)log.Data).StackTrace + GetCallStack();
            else if(log.Data is string)
                log.Argument = log.Data == null ? null : log.Data.ToString() ;
            else
                log.Argument = JsonConvert.SerializeObject(log.Data);
            log.IdSesion = idSesion;
            return log;
        }
        
        public void Persistir()
        {
            if (logs != null && logs.Count > 0)
            {
                ILogCommandEntity log = null;
                while (logs.TryDequeue(out log))
                {
                    Insertar(log);
                }
            }
        }

        private void Insertar(ILogCommandEntity log)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdUsuario", log.IdUsuario));
            lista.Add(SqlServerHelper.GetParam("@CommandName", log.CommandName));
            lista.Add(SqlServerHelper.GetParam("@Codigo", log.Codigo));
            lista.Add(SqlServerHelper.GetParam("@StartDateTime", log.StartDatetime));
            lista.Add(SqlServerHelper.GetParam("@RequestId", log.RequestId));
            lista.Add(SqlServerHelper.GetParam("@Argument", log.Argument));
            lista.Add(SqlServerHelper.GetParam("@IdSesion", log.IdSesion));

            SqlServerHelper.ExecuteNonQuery(log.GetSchema() + ".LOG_CommandInsert", lista);
        }
    }
}

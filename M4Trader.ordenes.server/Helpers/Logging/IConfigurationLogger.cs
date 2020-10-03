using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Helpers;
using System.Collections.Generic;

namespace M4Trader.ordenes.server.Helpers.Logging
{
    public interface IConfigurationLogger
    {
        Dictionary<string, ILogger> GetConfiguracion();

        ILogCommandEntity GetLogCommandEntity();
    }

    public class DefaultConfigurationLogger : IConfigurationLogger
    {
        public Dictionary<string, ILogger> GetConfiguracion()
        {
            Dictionary<string, ILogger> loggers = new Dictionary<string, ILogger>();
            loggers.Add(typeof(LogCommandEntity).FullName, new CommandLogger());
            loggers.Add(typeof(ILogCommandEntity).FullName, new CommandLogger());
            loggers.Add(typeof(LogSqlEntity).FullName, new SqlServerLogger()); 
            loggers.Add(typeof(LogSeguridadEntity).FullName, new SeguridadLogger());
            loggers.Add(typeof(LogProcesoEntity).FullName, new ProcesosLogger());
            loggers.Add(typeof(LogConectividadEntity).FullName, new ConectividadLogger());

            return loggers;

        }

        public ILogCommandEntity GetLogCommandEntity()
        {
            return new LogCommandEntity();
        }
    }
}
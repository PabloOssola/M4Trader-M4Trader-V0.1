using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Helpers.Logging;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using M4Trader.ordenes.services.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class LoggingHelper : ILogueador
    {
        #region Singleton
        private Timer timer;
        private static volatile LoggingHelper _instance;
        private static IConfigurationLogger configurationLogger;
        private Dictionary<string, ILogger> loggers = new Dictionary<string, ILogger>();

        private LoggingHelper()
        {
            this.loggers = configurationLogger.GetConfiguracion();

            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            timer.Interval = OrdenesApplication.Instance.ContextoAplicacion.TiempoLogSQL;
            timer.Enabled = true;
        }

        public static void SetConfigurator(IConfigurationLogger configLogger)
        {
            configurationLogger = configLogger;
        }

        public ILogCommandEntity GetLogCommand()
        {
            return configurationLogger.GetLogCommandEntity();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Persistir();
        }

        public static LoggingHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(LoggingHelper))
                    {
                        if (_instance == null)
                        {
                            if (configurationLogger == null)
                                configurationLogger = new DefaultConfigurationLogger();
                            _instance = new LoggingHelper();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        public void AgregarLog<T>(T log)
        {
            ILogger logger = null;
            if (this.loggers.TryGetValue(typeof(T).FullName, out logger))
                logger.AddToLog(log);
        }


        public void NoHayConexcionConLaBase(string cnString)
        {
            string path = OrdenesApplication.Instance.ContextoAplicacion.PathSalida ?? OrdenesApplication.Instance.ContextoAplicacion.PathDirectorioVirtual;
            path = Path.Combine(path, "loginterno");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + "\\Ordenes_NoHayConexionConBaseDeDatos.txt"))
            {
                var f = File.Create(path + "\\Ordenes_NoHayConexionConBaseDeDatos.txt");
                f.Close();
            }
            using (StreamWriter st = File.AppendText(path + "\\Ordenes_NoHayConexionConBaseDeDatos.txt"))
            {
                st.WriteLine("Fecha y Hora: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " conexion utilizada : " + cnString);
                st.Close();
            }
        }

        public static void HandleException(Exception ex)
        {
            if (OrdenesApplication.Instance.ContextoAplicacion.OcultarErroresBaseDeDatos)
            {
                throw new MAESqlException("Ha ocurrido un error en la base de datos");
            }
            else
            {
                throw new MAESqlException(ex.Message, ex);
            }
        }

        public void Persistir()
        {
            try
            {
                this.timer.Stop();
                if (this.loggers != null && this.loggers.Count > 0)
                {
                    if (SqlServerHelper.CheckConnection())
                    {
                        foreach (var item in this.loggers.Values)
                        {
                            item.Persistir();
                        }
                    }
                }
            }
            finally
            {
                this.timer.Start();
            }
        }

        public void AgregarCommandLog(string command, object data, InCourseRequest inCourseRequest, string codigo = "CMD")
        {
            CommandLog.Start(command, data, inCourseRequest, codigo);
        }
    }
}

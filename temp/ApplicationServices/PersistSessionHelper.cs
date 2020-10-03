using M4Trader.ordenes.server.Configuration;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades;
using System;
using System.Timers;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class PersistSessionHelper
    {
        #region Singleton
        private Timer timer;
        private static volatile PersistSessionHelper _instance;
        private SessionPersistenceManager sessionPersistenceManager = new SessionPersistenceManager();

        private PersistSessionHelper()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            timer.Interval = OrdenesApplication.Instance.ContextoAplicacion.TiempoLogSQL;
            timer.Enabled = true;
        }


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Persistir();
        }

        public static PersistSessionHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(PersistSessionHelper))
                    {
                        if (_instance == null)
                        {
                            _instance = new PersistSessionHelper();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        public void AddOrUpdate(SesionEntity session)
        {
            sessionPersistenceManager.AddOrUpdate(session);
        }

        public void Persistir()
        {
            try
            {
                this.timer.Stop();
                if (SqlServerHelper.CheckConnection())
                {
                    sessionPersistenceManager.Persistir();
                }
            }
            finally
            {
                this.timer.Start();
            }
        }

        public SesionEntity GetSessionById(Guid idSesion)
        {
                return sessionPersistenceManager.GetSessionById(idSesion);
        }

        public void DeleteSession(Guid idSesion)
        {
                sessionPersistenceManager.DeleteSession(idSesion);
        }
    }
}

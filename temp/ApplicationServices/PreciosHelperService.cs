using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class PreciosHelperServiceStarter : IApplicationServiceStarter
    {
        private ManualResetEvent manualResetEvent;

        public string ServiceName { get { return "PreciosHelperService"; } }

        public void SetWaitHandler(ManualResetEvent manualResetEvent)
        {
            this.manualResetEvent = manualResetEvent;
        }

        public void Start()
        {
            PreciosHelperService.Start();
        }

        public void Stop()
        {

        }
    }

    public class PreciosHelperService
    {
        private BlockingCollection<PrecioHistoricoEntity> preciosHistoricosQueue = null;
        public static IFixDAL FixDalInterface { get; set; }

        private PreciosHelperService()
        {
            this.preciosHistoricosQueue = new BlockingCollection<PrecioHistoricoEntity>();
            Task.Factory.StartNew(Dispatch);
        }

        private void Dispatch()
        {
            PrecioHistoricoEntity precioHistorico = null;
            while (this.preciosHistoricosQueue.TryTake(out precioHistorico, -1))
            {
                FixDAL.InsertarPrecioHistorico(precioHistorico);
                GraphDAL.InsertarPrecio(precioHistorico);
            }
        }

        private static volatile PreciosHelperService _instance;

        public static PreciosHelperService Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("Instancia no inicializada");
                }
                return _instance;
            }
        }

        public static void Start()
        {
            if (_instance == null)
            {
                lock (typeof(PreciosHelperService))
                {
                    if (_instance == null)
                        _instance = new PreciosHelperService();
                }
            }
        }

        public void EnQueueMessage(PrecioHistoricoEntity precioHistorico)
        {
            this.preciosHistoricosQueue.Add(precioHistorico);
        }
    }
}

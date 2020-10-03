using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class OfertasHelperServiceStarter : IApplicationServiceStarter
    {
        private ManualResetEvent manualResetEvent;

        public string ServiceName { get { return "OfertasHelperService"; } }

        public void SetWaitHandler(ManualResetEvent manualResetEvent)
        {
            this.manualResetEvent = manualResetEvent;
        }

        public void Start()
        {
            OfertasHelperService.Start();
        }

        public void Stop()
        {

        }
    }

    public class OfertasHelperService
    {
        private BlockingCollection<MejoresPuntasOfertaEntity> ofertasQueue = null;
        public static IFixDAL FixDalInterface { get; set; }

        private OfertasHelperService()
        {
            this.ofertasQueue = new BlockingCollection<MejoresPuntasOfertaEntity>();
            Task.Factory.StartNew(Dispatch);
        }

        private void Dispatch()
        {
            MejoresPuntasOfertaEntity ofertaEntity = null;
            while (this.ofertasQueue.TryTake(out ofertaEntity, -1))
            {
                FixDAL.InsertarOferta20Min(ofertaEntity);
            }
        }

        private static volatile OfertasHelperService _instance;

        public static OfertasHelperService Instance
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
                lock (typeof(OfertasHelperService))
                {
                    if (_instance == null)
                        _instance = new OfertasHelperService();
                }
            }
        }

        public void EnQueueMessage(MejoresPuntasOfertaEntity ofertaEntity)
        {
            this.ofertasQueue.Add(ofertaEntity);
        }
    }
}

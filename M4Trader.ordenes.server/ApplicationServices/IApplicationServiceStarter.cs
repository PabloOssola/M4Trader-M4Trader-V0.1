using System.Threading;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public interface IApplicationServiceStarter
    {
        string ServiceName { get; }
        void SetWaitHandler(ManualResetEvent manualResetEvent);

        void Start();
        void Stop();
    }
}

using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.server.Helpers.Logging
{

    public interface ILogger
    {
        void AddToLog(object log);

        void Persistir();
    }
    public interface ILogger<T> : ILogger
    {
        //void AddToLog(T log);

    }
}

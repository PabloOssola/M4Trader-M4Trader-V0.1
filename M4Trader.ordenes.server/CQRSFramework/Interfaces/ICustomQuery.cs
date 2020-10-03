using M4Trader.ordenes.server.CQRSFramework.CQRS;

namespace M4Trader.ordenes.server.CQRSFramework.Interfaces
{
    public interface ICustomQuery
    {
        object Execute(Query query);
    }

}
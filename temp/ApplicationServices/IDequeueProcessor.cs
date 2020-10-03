using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public interface IDequeueProcessor
    {   void Dispatch(InCourseRequest inCourseRequest, Notificacion notificacion);
    }
}

using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.services.Helpers
{
    public interface ILogueador
    {
        void AgregarLog<T>(T log);
        void AgregarCommandLog(string command, object data, InCourseRequest inCourseRequest, string codigo = "CMD");

    }
}

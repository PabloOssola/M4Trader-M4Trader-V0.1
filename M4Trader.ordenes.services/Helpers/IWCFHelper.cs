using M4Trader.ordenes.services.CQRSFramework.CQRS;
using M4Trader.ordenes.services.Entities;
using System;

namespace M4Trader.ordenes.services.Helpers
{
    public interface IWCFHelper
    {

        T DeserializarCommand<T>(string stream);
        O ExecuteService<S, O>(ServiciosEnum destino, string securitytokenid, Func<S, string> methodName);
        string ExecuteQueryService<S>(ServiciosEnum destino, Func<S, string> methodName);
        QueryResult ExecuteQueryServiceApiDMA<S>(ServiciosEnum destino, Func<S, string> methodName, string securitytokenid);
        //string GetSecurityTokenIdFromHeader();

    }
}

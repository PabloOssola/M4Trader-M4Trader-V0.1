using System;
using System.Threading;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public interface IDoubleAuthenticationService
    {
        ResponseDoubleAuthentication GetToken(Guid tokenGuid, string param, string url);
        bool ValidateToken(Guid tokenGuid, string username, string token);
    }
}

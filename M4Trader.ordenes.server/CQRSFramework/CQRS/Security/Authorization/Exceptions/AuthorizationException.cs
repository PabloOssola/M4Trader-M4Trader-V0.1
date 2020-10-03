using M4Trader.ordenes.server.CQRSFramework.Exceptions;

namespace M4Trader.ordenes.server.CQRSFramework.CQRS.Security.Authorization.Exceptions
{
    public class AuthorizationException : FunctionalException
    {
        public AuthorizationException(int code)
            : base(code)
        {
        }
    }
}

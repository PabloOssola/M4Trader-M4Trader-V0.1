using System;

namespace M4Trader.ordenes.server.CQRSFramework.Exceptions
{
    public class TechnicalException : Exception
    {
        public TechnicalException(Exception innerException)
            :base(null, innerException)
        {
            
        }

        public TechnicalException()
            : base(null)
        {

        }
    }
}
using System;

namespace M4Trader.ordenes.services.Exceptions
{
    public class MAESqlException : Exception
    {
        public MAESqlException(string mensaje) : base(mensaje)
        {
        }

        public MAESqlException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }
    }
}

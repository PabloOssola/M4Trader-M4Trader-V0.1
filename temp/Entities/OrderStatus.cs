using System;
using System.Runtime.Serialization;
using System.Linq;


namespace M4Trader.ordenes.server.Entities
{
    [DataContract(Name = "OrdStatus", Namespace = "http://schemas.datacontract.org/2004/07/M4Trader.fix.client.interfaces.Entities")]
    public class OrdStatus 
    {
        private char _current;

        public const char NEW = '0';
        public const char PARTIALLY_FILLED = '1';
        public const char FILLED = '2';
        public const char DONE_FOR_DAY = '3';
        public const char CANCELED = '4';
        public const char PENDING_CANCEL = '6';
        public const char STOPPED = '7';
        public const char REJECTED = '8';
        public const char SUSPENDED = '9';

        public const char PENDING_NEW = 'A';
        public const char CALCULATED = 'B';
        public const char EXPIRED = 'C';
        public const char ACCEPTED_FOR_BIDDING = 'D';
        public const char PENDING_REPLACE = 'E';

        public OrdStatus()
        {
            _current = OrdStatus.PENDING_NEW;
        }

        public OrdStatus(char data) {

            if (!validar(data) )
                throw new Exception("Status inexistente");

            _current = data;
        }

        public char GetValue()
        {
            return _current;
        }

        private bool validar(char data)
        {
            var lista = this.GetType().GetProperties();
            return  lista.Any(p => p.GetValue(this).ToString() == data.ToString()); 
        }
    }
}

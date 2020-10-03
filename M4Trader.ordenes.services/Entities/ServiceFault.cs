using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.Entities
{
    [DataContract]
    public class ServiceFault
    {
        public ServiceFault(string message)
        {
            Message = message;
        }

        [DataMember]
        public string Message { get; set; }
    }
}

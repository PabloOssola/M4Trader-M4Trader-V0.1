using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.CQRSFramework.CQRS
{

    [DataContract]
    public class Querye
    {
        [DataMember]
        public string d
        {
            get;
            set;
        }
    }
}

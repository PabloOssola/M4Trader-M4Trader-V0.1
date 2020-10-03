using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.Command
{
    [DataContract]
    public class Commande
    {
        [DataMember]
        public string d { get; set; }
    }
}

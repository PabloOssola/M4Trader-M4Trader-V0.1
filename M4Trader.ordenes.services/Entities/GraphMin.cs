using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.Entities
{
    [DataContract]
    public class GraphMin
    {
        [DataMember]
        public string key { get; set; }
        [DataMember]
        public string rueda { get; set; }
        [DataMember]
        public string market { get; set; }
    }
}
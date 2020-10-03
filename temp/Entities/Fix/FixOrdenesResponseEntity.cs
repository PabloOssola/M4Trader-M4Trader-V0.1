using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract(Name = "FixOrdenesResponseEntity", Namespace = "http://schemas.datacontract.org/2004/07/M4Trader.fix.client.interfaces.Entities")]
    public class FixOrdenesResponseEntity
    {
        [DataMember]
        public bool RespuestaOk { get; set; }
        [DataMember]
        public string DescripcionError { get; set; }
    }
}

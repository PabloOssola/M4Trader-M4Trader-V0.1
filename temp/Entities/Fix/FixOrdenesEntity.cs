using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract(Name = "FixOrdenesEntity", Namespace = "http://schemas.datacontract.org/2004/07/M4Trader.fix.client.interfaces.Entities")]
    public class FixOrdenesEntity
    {
        public FixOrdenesEntity()
        {
            Ordenes = new List<FixOrdenEntity>();
        }

        [DataMember]
        public List<FixOrdenEntity> Ordenes { get; set; }
        [DataMember]
        public FixAccionEnum Accion { get; set; }
    }
}

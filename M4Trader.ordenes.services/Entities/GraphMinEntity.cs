using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.Entities
{
    [DataContract]
    public class GraphMinEntity
    {
        [DataMember]
        public decimal? precio_of_c { get; set; }

        [DataMember]
        public decimal? precio_of_v { get; set; }

        [DataMember]
        public long secuencia { get; set; }
    }
}
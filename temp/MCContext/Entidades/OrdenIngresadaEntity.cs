using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [DataContract]

    [KnownType(typeof(OrdenIngresadaEntity))]
    public class OrdenIngresadaEntity
    {
        [Key]
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public string Side { get; set; }
        [DataMember]
        public string Instrument { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public string Market { get; set; }
        [DataMember]
        public string Client { get; set; }
        [DataMember]
        public DateTime InputDate { get; set; }
        [DataMember]
        public decimal Quantity { get; set; }
        [DataMember]
        public decimal? Price { get; set; }
        [DataMember]
        public string Status { get; set; } //codestado
        [DataMember]
        public int OrderNumber { get; set; }
        [DataMember]
        public DateTime ExpireDate { get; set; } //fecha de vigencia
        [DataMember]
        public DateTime SettlementDate { get; set; } //fecha de liquidacion
        [DataMember]
        public string OrderType { get; set; } //Limite/Market
        [DataMember]
        public string SettlementType { get; set; } //Plazo
        [DataMember]
        public string Company { get; set; }
        [DataMember]
        public decimal? EquivalentRate { get; set; }
        [DataMember]
        public byte IdEstado { get; set; }
    }
}
 

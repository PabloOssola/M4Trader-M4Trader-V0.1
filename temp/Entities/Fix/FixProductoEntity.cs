using M4Trader.ordenes.services.Entities;
using System;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract(Name = "FixProductoEntity", Namespace = "http://schemas.datacontract.org/2004/07/M4Trader.fix.client.interfaces.Entities")]
    public class FixProductoEntity
    {
        [DataMember]
        public string Mercado { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string CodigoCFI { get; set; }
        [DataMember]
        public string MaturityMonthYear { get; set; }
        [DataMember]
        public string MaturityDate { get; set; }
        [DataMember]
        public decimal Factor { get; set; }
        [DataMember]
        public decimal ContractMultiplier { get; set; }
        [DataMember]
        public string SecurityExchange { get; set; }
        [DataMember]
        public string SecurityDesc { get; set; }
        [DataMember]
        public decimal MinPriceIncrement { get; set; }
        [DataMember]
        public MonedasEnum? Moneda { get; set; }
        [DataMember]
        public decimal RoundLot { get; set; }
        [DataMember]
        public decimal MinTradeVol { get; set; }
        [DataMember]
        public decimal MaxTradeVol { get; set; }
        [DataMember]
        public decimal LowLimitPrice { get; set; }
        [DataMember]
        public decimal HighLimitPrice { get; set; }
        [DataMember]
        public decimal TickSize { get; set; }
        [DataMember]
        public int InstrumentPricePrecision { get; set; }
        [DataMember]
        public int InstrumentSizePrecision { get; set; }
        [DataMember]
        public int ContractPositionNumber { get; set; }
        [DataMember]
        public string Plazo { get; set; }
        [DataMember]
        public SecurityTypeEnum IdTipoProducto { get; set; }
        [DataMember]
        public DateTime FechaLiquidacion { get; set; }
        [DataMember]
        public int? CuponActivo { get; set; }
    }
}

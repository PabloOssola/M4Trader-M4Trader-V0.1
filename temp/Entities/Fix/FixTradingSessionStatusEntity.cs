using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract(Name = "FixTradingSessionStatusEntity", Namespace = "http://schemas.datacontract.org/2004/07/M4Trader.fix.client.interfaces.Entities")]
    public class FixTradingSessionStatusEntity
    {
        [DataMember]
        public string Market { get; set; }
        [DataMember]
        public bool ReportMarketOpening { get; set; }
        [DataMember]
        public bool ReportMarketClosing { get; set; }
        [DataMember]
        public string MessageInPlainText { get; set; }
        [DataMember]
        public bool UnsolicitedIndicator { get; set; }
        [DataMember]
        public FixTradSesStatusEnum TradSesStatus { get; set; }
    }
}

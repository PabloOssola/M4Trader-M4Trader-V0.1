using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract]
    public enum FixSideOrdenEnum
    {
        [EnumMember]
        Buy = 'B',
        [EnumMember]
        Sell = 'S'
    }
}

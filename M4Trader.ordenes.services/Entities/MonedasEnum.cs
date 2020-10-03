using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.Entities
{
    [DataContract]
    public enum MonedasEnum : byte
    {
        [EnumMember]
        ARS = 1,
        [EnumMember]
        USD = 2,
        [EnumMember]
        EUR = 3,
    }
}

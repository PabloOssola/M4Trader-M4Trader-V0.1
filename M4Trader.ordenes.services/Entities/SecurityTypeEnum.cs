using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.Entities
{
    [DataContract]
    public enum SecurityTypeEnum : byte
    {
        [EnumMember]
        TB = 3,
        /*[EnumMember]
        MTN = ,
        [EnumMember]
        GO = ,
        [EnumMember]
        CORP = ,
        [EnumMember]
        MF = ,
        [EnumMember]
        STRUCT = ,
        [EnumMember]
        CS = ,*/
        [EnumMember]
        BOX = 7,
    }
}

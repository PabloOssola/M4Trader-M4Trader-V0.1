using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract]
    public enum FixTradSesStatusEnum
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        Halted = 1,
        [EnumMember]
        Open = 2,
        [EnumMember]
        Closed = 3,
        [EnumMember]
        PreOpen = 4,
        [EnumMember]
        PreClose = 5,
        [EnumMember]
        RequestRejected = 6
    }
}

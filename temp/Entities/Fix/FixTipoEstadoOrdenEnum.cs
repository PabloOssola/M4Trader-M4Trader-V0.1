using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract]
    public enum FixTipoEstadoOrdenEnum
    {
        [EnumMember]
        New = '0',
        [EnumMember]
        PartiallyFilled = '1',
        [EnumMember]
        Filled = '2',
        [EnumMember]
        DoneForDay = '3',
        [EnumMember]
        Canceled = '4',
        [EnumMember]
        PendingCancel = '6',
        [EnumMember]
        Stopped = '7',
        [EnumMember]
        Rejected = '8',
        [EnumMember]
        Suspended = '9',
        [EnumMember]
        PendingNew = 'A',
        [EnumMember]
        Calculated = 'B',
        [EnumMember]
        Expired = 'C',
        [EnumMember]
        AcceptedForBidding = 'D',
        [EnumMember]
        PendingReplace = 'E'
    }
}
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract]
    public enum FixTipoEjecucionOrdenEnum
    {
        [EnumMember]
        New = '0',
        [EnumMember]
        DoneForDay = '3',
        [EnumMember]
        Canceled = '4',
        [EnumMember]
        Replaced = '5',
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
        Restated = 'D',
        [EnumMember]
        PendingReplace = 'E',
        [EnumMember]
        Trade = 'F',
        [EnumMember]
        TradeCorrect = 'G',
        [EnumMember]
        TradeCancel = 'H',
        [EnumMember]
        OrderStatus = 'I',
        [EnumMember]
        TradeInAClearingHold = 'J',
        [EnumMember]
        TradeHasBeenReleasedToClearing = 'K',
        [EnumMember]
        TriggeredOrActivatedBySystem = 'L',
        [EnumMember]
        Locked = 'M',
        [EnumMember]
        Released = 'N'
    }
}
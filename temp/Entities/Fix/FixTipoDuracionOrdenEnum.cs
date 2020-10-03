using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract]
    public enum FixTipoDuracionOrdenEnum
    {
        [EnumMember]
        Day = '0',
        [EnumMember]
        GTC = '1', //Good Till Cancel
        [EnumMember]
        OPG = '2', //At the Opening
        [EnumMember]
        IOC = '3', // Inmediate or Cancel 
        [EnumMember]
        FOK = '4', // Fill Or Kill
        [EnumMember]
        GTX = '5', // Good Till Crossing
        [EnumMember]
        GTD = '6', // Good Till Date
        [EnumMember]
        AtClose = '7'
    }
}

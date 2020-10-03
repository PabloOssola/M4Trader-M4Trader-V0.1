using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract]
    public enum FixTipoOrdenEnum
    {
        [EnumMember]
        Market = 'M',
        [EnumMember]
        Limit = 'L'
    }
}

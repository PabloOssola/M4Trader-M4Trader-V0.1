using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract]
    public enum FixTipoMensajeMarketDataEnum : byte
    {
        [EnumMember]
        DESCONOCIDO = 0,
        [EnumMember]
        REFRESH = 1,
        [EnumMember]
        FULL = 2,
        [EnumMember]
        SECURITY_LIST = 3,
        [EnumMember]
        NOVEDAD = 4,
        [EnumMember]
        CAMBIO_PASSWORD = 5,
        [EnumMember]
        TRADE_SESSION_STATUS = 6,
    }
}

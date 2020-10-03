using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract]
    public enum FixAccionEnum
    {
        [EnumMember]
        ALTA_ORDEN,
        [EnumMember]
        ALTA_ORDEN_MULTIPLE,
        [EnumMember]
        MODIFICAR_ORDEN,
        [EnumMember]
        MODIFICAR_ORDEN_MULTIPLE,
        [EnumMember]
        REPORTE_ESTADO,
        [EnumMember]
        CANCELAR_ORDEN,
        [EnumMember]
        CANELAR_ORDEN_RECHAZADA,
        [EnumMember]
        STATUS_MASIVO_REQUEST,
        [EnumMember]
        CAMBIO_PASSWORD,
        [EnumMember]
        TRADE_CAPTURE_REPORT,
    }
}

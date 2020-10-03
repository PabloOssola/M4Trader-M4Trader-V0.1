namespace M4Trader.ordenes.server.Helpers
{
    public enum ConfiguracionSistemaURLsEnumDestino : byte
    {
        Mobile = 1,
        Swift = 2,
        RabbitQueue = 3,
        RabbitMobile = 4,
        OrdenesFIX = 5,
        DoubleAuthentication = 6,
        NotificacionesDMAFIX = 7,
        API = 8,
        OrdenesFIXTcp = 9,
        ChatService =10
    }
}
namespace M4Trader.ordenes.services.Command
{
    public class GetProductoByCodigoAndMonedaDefaultCommand 
    {
        public string codigoProducto { get; set; }
        public byte idMercado { get; set; }
        public string Rueda { get; set; }
    }
}
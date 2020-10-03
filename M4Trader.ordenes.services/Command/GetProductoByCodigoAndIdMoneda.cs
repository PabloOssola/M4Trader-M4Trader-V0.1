namespace M4Trader.ordenes.services.Command
{
    public class GetProductoByCodigoAndIdMoneda 
    {
        public string codigoProducto { get; set; }
        public byte idMercado { get; set; }
        public string rueda { get; set; }
    }
}
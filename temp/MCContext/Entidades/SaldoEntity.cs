namespace M4Trader.ordenes.server.MCContext.Entidades
{
    public class SaldoEntity
    {
        public int IdCliente { get; set; }
        public int IdEmpresa { get; set; }
        public string TipoProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioNacional { get; set; }
        public decimal? MontoNacional { get; set; }
        public string Moneda { get; set; }
    }
}
 

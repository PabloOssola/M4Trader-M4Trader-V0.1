namespace M4Trader.ordenes.server.MCContext.Entidades
{
    public class SaldoEntity
    {
        public int? IdCliente { get; set; }
        public int? IdEmpresa { get; set; }
        public string TipoProducto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioNacional { get; set; }
        public decimal? MontoNacional { get; set; }
        public byte? IdMoneda { get; set; }
        public byte[] UltimaActualizacion { get; set; }

    }

    public class SaldosDTO {
        public string Codigo { get; set; }
        public string NombreUsuario { get; set; }
        public string Moneda { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal MontoPendienteDeAcreditacion { get; set; }
    }
}
 

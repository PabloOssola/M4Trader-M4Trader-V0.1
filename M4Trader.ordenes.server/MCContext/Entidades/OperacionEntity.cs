using System;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    public class OperacionEntity
    {
        public int IdOperacion { get; set; }
        public string NroOperacion { get; set; }
        public string CompraVenta { get; set; }
        public int IdPersonaComprador { get; set; }
        public int IdPersonaVendedor { get; set; }
        public byte IdMonedaCompra { get; set; }
        public byte IdMonedaVenta { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaOperacion { get; set; }
        public byte[] UltimaModificacion { get; set; }
        public byte[] TimestampSaldoComprador { get; set; }
        public byte[] TimestampSaldoVendedor { get; set; }

    }
}


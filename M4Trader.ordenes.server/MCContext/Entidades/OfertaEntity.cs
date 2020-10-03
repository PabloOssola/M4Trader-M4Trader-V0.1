using System;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    public class OfertaEntity
    {
        public int IdOferta { get; set; }
        public int IdProducto { get; set; }
        public byte IdMercado { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public string CompraVenta { get; set; }
        public byte NumeroPosicion { get; set; }
        public DateTime? Fecha { get; set; }
        public byte Accion { get; set; }
        public byte IdPlazo { get; set; }
        public byte IdMoneda { get; set; }
    }
}
 

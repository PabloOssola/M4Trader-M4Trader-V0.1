using M4Trader.ordenes.server.Entities;
using System;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    public class PrecioEntity
    {
        public short IdPrecio { get; set; }
        public int IdProducto { get; set; }
        public byte IdMercado { get; set; }
        public byte IdMoneda { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal PrecioUltimoCierre { get; set; }
        public byte IdPlazo { get; set; }
        public FixSideOrdenEnum Side { get; set; }
    }
}
 

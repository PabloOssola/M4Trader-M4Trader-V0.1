using System.Collections.Generic;

namespace M4Trader.ordenes.services.Entities
{
    public class MejoresPuntasOfertaEntity
    {
        public byte IdMoneda { get; set; }
        public byte IdMercado { get; set; }
        public int IdProducto { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? PrecioVenta { get; set; }
        public string Rueda { get; set; }
        public byte IdPlazo { get; set; }
    }
}
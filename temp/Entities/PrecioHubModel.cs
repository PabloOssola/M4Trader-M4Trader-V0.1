using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M4Trader.ordenes.SignalHub
{
    public class PrecioHubModel
    {
        public string ProductoMercado { get; set; }
        public int IdPrecio { get; set; }
        public int IdProducto { get; set; }
        public byte IdMercado { get; set; }

        public byte IdMoneda { get; set; }
        public string ProductoCodigo { get; set; }
        public string ProductoDescripcion { get; set; }
        public string MercadoDescripcion { get; set; }
        public string MercadoCodigo { get; set; }
        public string MonedaCodigo { get; set; }
        public decimal PrecioApertura { get; set; }
        
        public decimal Precio { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal CantidadCompra { get; set; }
        public decimal CantidadVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Plazo { get; set; }
        public byte IdPlazo { get; set; }
        public DateTime FechaPrecio { get; set; }
        public string Sparklines { get; set; }

    }
}
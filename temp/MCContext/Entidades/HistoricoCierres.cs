using System;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    public class HistoricoCierres
    {
        public Int64 IdHistoricoCierres { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Double? PrecioCierre { get; set; }
        public Double? PrecioMaximo { get; set; }
        public Double? PrecioMinimo { get; set; }
        public Double? PrecioApertura { get; set; }
        public Double? Cantidad { get; set; }
        public Double? MontoOperado { get; set; }
        public string Producto { get; set; }
        public string Moneda { get; set; }
    }
}

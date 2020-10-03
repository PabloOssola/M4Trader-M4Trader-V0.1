using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.services.Command
{
    public class AltaOrdenCommand
    {
        public string CompraOVenta { get; set; }
        public string CodigoProducto { get; set; }
        public Int32? IdTipoVigencia { get; set; }
        public int Cantidad { get; set; }
        public decimal? PrecioLimite { get; set; }
        public string CodigoPlazoType { get; set; }
        public byte? StopType { get; set; }
        public string OrderType { get; set; }
        public int IdMercado { get; set; }
        public byte? Source { get; set; }
    }
}
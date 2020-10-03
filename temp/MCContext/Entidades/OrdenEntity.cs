using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using M4Trader.ordenes.services.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    public class OrdenEntity
    {
        public int IdOrden { get; set; }
        public string CompraVenta { get; set; }
        public int IdProducto { get; set; }
        public byte IdMoneda { get; set; }
        public byte IdMercado { get; set; }
        public int IdPersona { get; set; }
        public int? IdEnNombreDe { get; set; }
        public DateTime FechaConcertacion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CantidadMinima { get; set; }
        public decimal? PrecioLimite { get; set; }
        public byte IdEstado { get; set; }
        public byte? IdMotivoBaja { get; set; }
        public int NumeroOrdenInterno { get; set; }
        public TipoVigencia IdTipoVigencia { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string NumeroOrdenMercado { get; set; }
        public byte? Plazo { get; set; }
        public byte IdTipoOrden { get; set; }
        public byte[] Timestamp { get; set; }
        public string TimestampStr { get; set; }
        public byte? IdSourceApplication { get; set; }
        public int? IdOrdenDeReferencia { get; set; }
        public decimal? EquivalentRate { get; set; }
        public bool OperoPorTasa { get; set; }
        public decimal? Tasa { get; set; }
        public decimal? PrecioVinculado { get; set; }
        [SkipTracking]
        [NotMapped]
        public bool AutoConfirmar { get; set; }
        public string Rueda { get; set; }
        public decimal Ejecutadas { get; set; }
        public decimal? Valorizacion { get; set; }
        public DateTime? FechaLiquidacion { get; internal set; }
        public int? IdUsuario { get; set; }

        public string GetProductKey()
        {
            return IdProducto.ToString() + "_" + IdMercado + "_" + IdMoneda + "_" + Plazo + "_" + Rueda;
        }
    }
}


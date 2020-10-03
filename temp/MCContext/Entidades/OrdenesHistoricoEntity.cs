using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.OrdenHistorico)]
    [Table("OrdenesHistorico", Schema = "orden_owner")]
    public class OrdenesHistoricoEntity
    {
        [Key]
        public long IdOrdenHistorico { get; set; }
        public string CompraVenta { get; set; }
        public int IdProducto { get; set; }
        public byte IdMoneda { get; set; }
        public byte? IdMercado { get; set; }
        public int? IdPersona { get; set; }
        public DateTime FechaConcertacion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? PrecioLimite { get; set; }
        public byte IdEstado { get; set; }
        public byte? IdMotivoBaja { get; set; }
        public int NumeroOrdenInterno { get; set; }
        public byte? IdTipoVigencia { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        [MaxLength(100)]
        public string NumeroOrdenMercado { get; set; }
        public int? IdOrdenHistoricoDeReferencia { get; set; }
    }
}

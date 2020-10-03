using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [Table("OperacionHistorico", Schema = "orden_owner")]
    public class OperacionHistoricoEntity
    {
        [Key]
        public int IdOperacionHistorico { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public string Rueda { get; set; }
        public string TradeRequestID { get; set; }
        public string TradeReportID { get; set; }        
        public byte IdTipoNegociacion { get; set; }
        public int IdProducto { get; set; }
        public byte? IdPlazo { get; set; }
        public byte? IdMoneda { get; set; }
        public decimal PrecioTasa { get; set; }
        public decimal Cantidad { get; set; }
        public byte IdMercado { get; set; }
        public bool EsAlta { get; set; }
        public bool OperoPorTasa { get; set; }
        public DateTime Fecha { get; set; }
        public string ProductoNombreLargo { get; set; }
        public decimal LastSpotRate { get; set; }
        public decimal? ReferencePrice { get; set; }
        public decimal? Valorizacion { get; set; }
        public string PartyComprador { get; set; }
        public string PartyVendedor { get; set; }
        public string MensajeTextoPlano { get; set; }
    }
}
 

using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.services.Entities
{
    public class NotificacionTradeCaptureReport : Notificacion
    {
        public int TradeReportTransType { get; set; }
        public int TradeReportType { get; set; }
        public string TradeRequestID { get; set; }
        public int TrdType { get; set; }
        public bool EsAlta { get; set; }
        public bool UnsolicitedIndicator { get; set; }
        public bool PreviouslyReported { get; set; }
        public bool OperaPorTasa { get; set; }
        public string ProductoNombreLargo { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal LastSpotRate { get; set; }
        public DateTime TradeDate { get; set; }
        public List<NotificacionAgentesParticipantes> Participantes { get; set; }
        public string Producto { get; set; }
        public MonedasEnum? Moneda { get; set; }
        public DateTime? FechaLiquidacion { get; set; }
        public decimal? ReferencePrice { get; set; } 
    }
    public class NotificacionAgentesParticipantes
    {
        public string Codigo { get; set; }
        public char Side { get; set; }
    }
}

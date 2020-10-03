namespace M4Trader.ordenes.services.Entities
{
    public class NotificacionGarantias : Notificacion
    {
        public string ClearingHouse { get; set; }
        public string Dador { get; set; }
        public string Receptor { get; set; }
        public long ConsumedAmount { get; set; }
        public long ConsumedChips { get; set; }
        public MonedasEnum Moneda { get; set; }
        public long TotalAmount { get; set; }
    }
}

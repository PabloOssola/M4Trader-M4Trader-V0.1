using System;

namespace M4Trader.ordenes.services.Entities
{
    public class NotificacionHeartBeat : Notificacion
    {
        public NotificacionHeartBeat()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; set; }
        public bool MarketData { get; set; }
    }
}

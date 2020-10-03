using System.Collections.Generic;

namespace M4Trader.ordenes.services.Command
{
    public class CancelaOrdenCommand
    {
        public List<Order> Ordenes { get; set; }

        public byte IdMotivo { get; set; }

        public string Observaciones { get; set; }

        public int Source { get; set; }
    }

    public class Order
    {
        public int IdOrden { get; set; }
        public string Observaciones { get; set; }
        public string TimeStamp { get; set; }
    }
}
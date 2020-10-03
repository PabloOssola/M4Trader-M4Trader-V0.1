using System.Collections.Generic;

namespace M4Trader.ordenes.server.Models
{
    public class MenuOrdenes
    {
        public List<MenuOrdenesItem> top { get; set; }
        public List<MenuOrdenesItem> foot { get; set; }
    }
}
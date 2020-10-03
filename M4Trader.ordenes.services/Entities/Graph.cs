using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.services.Entities
{
    public class Graph
    {
        public int IdProduct { get; set; }
        public GraphType graphType { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}

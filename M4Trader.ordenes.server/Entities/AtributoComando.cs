using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server.Entities
{
    public class AtributoComando
    {
        public string FullName { get; set; }
        public string Key { get; set; }
        public int IdAccion { get; set; }
        public Type CommandType { get; set; }
    }
}

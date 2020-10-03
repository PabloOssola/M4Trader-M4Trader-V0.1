using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.services.Entities
{
    public class ResponseGenerico
    {
        public byte Resultado { get; set; }

        public object Detalle { get; set; }
    }
}

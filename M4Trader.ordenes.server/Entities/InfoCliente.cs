using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server.Entities
{
    public class InfoCliente
    {

        public InfoCliente(string ip, string origen)
        {
            this.Ip = ip;
            this.Dispositivo = origen;
        }

        public string Ip { get; set; }

        public string Dispositivo { get; set; }
    }
}

using M4Trader.ordenes.server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M4Trader.ordenes.services.Command
{
    public class TokenCommand
    {
        public string UserName { get; set; }
        public string SecurityToken { get; set; }
        public string IP { get; set; }
        public Guid GuidToken { get; set; }
        public TipoAplicacion tipoAplicacion { get; set; }

    }
}
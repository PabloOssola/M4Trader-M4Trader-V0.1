using System;
using System.Xml.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [Serializable]
	public class TokenResult
    {
        public bool Ok { get; set; }
        public string IdSesion { get; set; }
        public string Global { get; set; }
    }
}


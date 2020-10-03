using System.Collections.Generic;

namespace M4Trader.ordenes.server.CQRSFramework.Exceptions
{
    public class KeyArray
    {
        public string Codigo { get; set; }
        public List<string> Parametros { get; set; }

        public KeyArray()
        {
            Codigo = string.Empty;
            Parametros = new List<string>();
        }

    }
}

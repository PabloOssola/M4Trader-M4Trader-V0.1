using System;

namespace M4Trader.ordenes.services.Entities
{
    public class LogProcesoEntityAux
    {

        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public string Resultado { get; set; }
        public Exception Exception { get; set; }
        public byte IdLogCodigoAccion { get; set; }
    }
}

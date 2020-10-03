using System;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    public class LogAuditoriaOrdenEntity
    {
        public DateTime Fecha { get; set; }
        public string EstadoDescripcion { get; set; }
        public byte IdEstado { get; set; }
        public string UsuarioDescripcion { get; set; }
        public byte IdUsuario { get; set; }
        public string PersonaDescripcion { get; set; }
        public string Observaciones { get; set; }
        public string MotivoRechazo { get; set; }
        public string AccionDescripcion { get; set; }
        public string MotivoCancelacionDescripcion { get; set; }
        public string Source { get; set; }
    }
}
 

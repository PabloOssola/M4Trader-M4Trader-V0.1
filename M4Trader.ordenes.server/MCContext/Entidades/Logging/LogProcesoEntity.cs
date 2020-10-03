using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades.Logging
{
    [Table("LogProcesos", Schema = "orden_owner")]
    public class LogProcesoEntity
    {
        public LogProcesoEntity(Guid requestId, int idUsuario)
        {
            RequestId = requestId;
            IdUsuario = idUsuario;
        }

        [Key]
        public int IdLogProceso { get; set; }
        public int IdUsuario { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public string Resultado { get; set; }

        public Guid? RequestId { get; set; }
        [NotMapped]
        public Exception Exception { get; set; }
        public byte IdLogCodigoAccion { get; set; }
    }
}

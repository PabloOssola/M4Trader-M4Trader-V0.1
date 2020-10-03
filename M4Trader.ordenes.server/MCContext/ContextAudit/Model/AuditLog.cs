using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Model
{
    [Table("LogAuditoria", Schema = "shared_owner")]
    public class AuditLog : IUnTrackable
    {
        [Key]
        public int IdLogAuditoria { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public DateTime FechaEvento { get; set; }

        [Required]
        public short IdClase { get; set; }

        [Column("TipoEvento")]
        [Required]
        public EventType entityType { get; set; }


        public string ValorOriginal { get; set; }

        public string ValorNuevo { get; set; }

        [Required]
        [MaxLength(256)]
        public long IdRegistro { get; set; }

       // public virtual ICollection<AuditLogDetail> LogDetails { get; set; } = new List<AuditLogDetail>();

    }
}

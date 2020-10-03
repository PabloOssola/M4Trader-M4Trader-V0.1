using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("LimitesPorPersona", Schema = "shared_owner")]
    public class LimitesPorPersonaEntity
    {
        [Key]
        [Column("IdLimite")]
        public int IdLimite { get; set; }

        [ForeignKey("Parties")]
        [Column("IdPersona")]
        public int IdPersona { get; set; }

        [Column("Tope")]
        public decimal Tope { get; set; }

        [Column("TipoOperacion")]
        public string TipoOperacion { get; set; }

        [Column("IdTiempoLimite")]
        public int IdTiempoLimite { get; set; }
    }
}
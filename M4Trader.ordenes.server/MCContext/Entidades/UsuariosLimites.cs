using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("UsuariosLimites", Schema = "shared_owner")]
    public class UsuariosLimitesEntity
    {
        [Key]
        [Column("IdUsuarioLimite")]
        public int IdUsuarioLimite { get; set; }

        [ForeignKey("Usuarios")]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("LimiteOferta")]
        public decimal LimiteOferta { get; set; }

        [Column("LimiteOperacion")]
        public decimal LimiteOperacion { get; set; }
    }
}
using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.RolUsuario)]
    [Table("RolUsuario", Schema = "shared_owner")]
    public class RolUsuarioEntity
    {
        [Key]//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int IdRolUsuario { get; set; }


        [ForeignKey("Usuarios")]
        public int IdUsuario { get; set; }

        [Column("IdRol")]
        public short IdRol { get; set; }

        [Column("UltimaActualizacion")]
        [Timestamp]
        public byte[] UltimaActualizacion { get; set; }

        public UsuarioEntity Usuario { get; set; }
    }
}


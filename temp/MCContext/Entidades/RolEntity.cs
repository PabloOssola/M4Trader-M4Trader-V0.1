using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [TrackChanges(AuditoriaClase.Roles)]
    [Table("Roles", Schema = "shared_owner")]
    public class RolEntity
    {
        [Key]//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public short IdRol { get; set; }

        public string Descripcion { get; set; } 
        
        public short ValorNumerico { get; set; } 
        
        [Column("bajaLogica")]
        public bool BajaLogica { get; set; }

        [Column("UltimaActualizacion")]
        [Timestamp]
        public byte[] UltimaActualizacion { get; set; } 

    }
}
 

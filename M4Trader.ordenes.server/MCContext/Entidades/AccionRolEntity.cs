using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.AccionRol)]
    [Table("AccionRol", Schema = "shared_owner")]
    public class AccionRolEntity
    {
        [Key]//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public short IdAccionRol { get; set; }

        [ForeignKey("IdRol")]
        [Column("IdRol")]
        public short IdRol { get; set; }

        [ForeignKey("IdAccion")]
        [Column("IdAccion")]
        public short IdAccion { get; set; }

        [Column("Permiso")]
        public int Permiso { get; set; }

        [Column("UltimaActualizacion")]
        [Timestamp]
        public byte[] UltimaActualizacion { get; set; }

        [SkipTracking]
        [NotMapped]
        public bool Consulta { get { return ((1 & Permiso) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Salidas { get { return ((2 & Permiso) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Modificacion { get { return ((4 & Permiso) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Baja { get { return ((8 & Permiso) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Alta { get { return ((16 & Permiso) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Supervision { get { return ((32 & Permiso) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Importacion { get { return ((64 & Permiso) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Aprobacion_Automatica { get { return ((128 & Permiso) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Ejecucion { get { return ((256 & Permiso) != 0); } }
    }
}
 

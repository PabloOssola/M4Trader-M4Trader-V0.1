using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [TrackChanges(AuditoriaClase.Accion)]
    [Table("Acciones", Schema = "shared_owner")]
    public class AccionEntity
    {
        [Key]//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public short IdAccion { get; set; }
        public string Descripcion { get; set; }
        public int HabilitarPermisos { get; set; }

        [SkipTracking]
        [NotMapped]
        public bool Consulta { get { return ((1 & HabilitarPermisos) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Salidas { get { return ((2 & HabilitarPermisos) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Modificacion { get { return ((4 & HabilitarPermisos) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Baja { get { return ((8 & HabilitarPermisos) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Alta { get { return ((16 & HabilitarPermisos) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Importacion { get { return ((64 & HabilitarPermisos) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Aprobacion_Automatica { get { return ((128 & HabilitarPermisos) != 0); } }

        [SkipTracking]
        [NotMapped]
        public bool Ejecucion { get { return ((256 & HabilitarPermisos) != 0); } }
    }
}
 

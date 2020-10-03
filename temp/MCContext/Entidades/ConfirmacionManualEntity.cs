using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.ConfirmacionManual)]
    [Table("ConfirmacionManual", Schema = "orden_owner")]
    public class ConfirmacionManualEntity
    {
        [Key]
        public int IdConfirmacionManual { get; set; }

        public byte IdSourceApplication { get; set; }

        public int IdParty { get; set; }

        public int IdProducto { get; set; }
    }
}

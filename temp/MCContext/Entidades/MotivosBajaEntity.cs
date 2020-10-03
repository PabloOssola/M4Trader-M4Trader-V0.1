using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [TrackChanges(AuditoriaClase.Monedas)]
    [Table("MotivosBaja", Schema = "shared_owner")]
    public class MotivosBajaEntity
    {
        [Key]
        public byte IdMotivoBaja { get; set; }
        public string Descripcion { get; set; }
        public string EventoTipo { get; set; }
    }
}
 

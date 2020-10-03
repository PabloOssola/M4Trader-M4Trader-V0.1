using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [TrackChanges(AuditoriaClase.MensajesLiterales)]
    [Table("MensajesLiterales", Schema = "shared_owner")]
    public class MensajesLiteralesEntity
    {
        [Key]
        public int IdMensajesLiterales { get; set; }
        public string Idioma { get; set; }
        public string Referencia { get; set; }
        public string Valor { get; set; }

    }
}

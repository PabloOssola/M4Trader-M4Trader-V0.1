using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [TrackChanges(AuditoriaClase.Monedas)]
    [Table("Monedas", Schema = "shared_owner")]
    public class MonedaEntity
    {
        [Key]
        public byte IdMoneda { get; set; }
        public string Codigo { get; set; }
        public string CodigoISO { get; set; }
        public string Descripcion { get; set; }
        public byte TipoMoneda { get; set; }
        public bool EsMonedaNacional { get; set; }
    }
}
 

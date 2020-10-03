using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("TiposOrden", Schema = "orden_owner")]
    public class TipoOrdenEntity
    {
        [Key]
        public byte IdTipoOrden { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        
    }
}
 

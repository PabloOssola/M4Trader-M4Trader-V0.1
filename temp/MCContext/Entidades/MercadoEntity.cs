using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.Mercados)]
    [Table("Mercados", Schema = "shared_owner")]
    public class MercadoEntity
    {
        [Key]//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public byte IdMercado { get; set; }
        
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool EsInterno { get; set; }

        public bool ProductoHabilitadoDefecto { get; set; }
    }
}
 

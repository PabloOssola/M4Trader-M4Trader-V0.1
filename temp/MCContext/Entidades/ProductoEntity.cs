using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.Productos)]
    [Table("Productos", Schema = "orden_owner")]
    public class ProductoEntity
    {
        [Key]
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public byte IdMoneda { get; set; }
        public string ISIN { get; set; }
        public bool Habilitado { get; set; }
        public bool BajaLogica { get; set; }
        public decimal  CantidadContrato { get; set; }
        [Column("SegmentMarketId")]
        public string Rueda { get; set; }
        public decimal CantidadMinima { get; set; }

        public byte IdTipoProducto { get; set; }
    }
}
 

using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.Accion)]
    [Table("ProductosPorMercados", Schema = "orden_owner")]

    public class ProductoPorMercadoEntity
    {
        [Key]
        public int IdProductoPorMercado { get; set; }

        public byte IdMercado { get; set; }

        public int IdProducto { get; set; }

        public MercadoEntity Mercado { get; set; }

        public ProductoEntity Producto { get; set; }

        public decimal? PrecioReferencia { get; set; }
        public decimal? PrecioCierre { get; set; }
    }
}

using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.PortfoliosComposicion)]
    [Table("PortfoliosComposicion", Schema = "orden_owner")]
    public class PortfolioComposicionEntity
    {
        [Key]
        public int IdPortfoliosComposicion { get; set; }

        public short IdPortfolio { get; set; }

        public int IdProducto { get; set; }

        public byte IdMercado { get; set; }
        public byte IdPlazo { get; set; }

        public int Orden { get; set; }

        public PortfolioEntity Portfolio { get; set; }
    }
}

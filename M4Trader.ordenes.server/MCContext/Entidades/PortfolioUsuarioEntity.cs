using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.PortfolioUsuario)]
    [Table("PortfolioUsuario", Schema = "orden_owner")]
    public class PortfolioUsuarioEntity
    {
        [Key]
        public int IdPortfolioUsuario { get; set; }

        public int IdUsuario { get; set; }

        public short IdPortfolio { get; set; }

        public bool PorDefecto { get; set; }
        public PortfolioEntity Portfolio { get; set; }
    }
}

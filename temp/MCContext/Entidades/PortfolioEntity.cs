using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.Portfolios)]
    [Table("Portfolios", Schema = "orden_owner")]
    public class PortfolioEntity
    {
        [Key]
        public short IdPortfolio { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool EsDeSistema { get; set; }

        public bool EsFavorito { get; set; }
    }
}

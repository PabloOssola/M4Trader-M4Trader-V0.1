using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [TrackChanges(AuditoriaClase.Ordenes)]
    [Table("OrdenOperacion", Schema = "orden_owner")]
    public class OrdenOperacionEntity
    {
        [Key]
        public int IdOrdenOperacion { get; set; }
        public int IdOrden { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public string NroOperacionMercado { get; set; }
        public int? NroOperacionBoleto { get; set; }
        public decimal? SpotRate { get; set; }
        public bool OperoPorTasa { get; internal set; }
        public decimal? PrecioVinculado { get; internal set; }
        public decimal? Valorizacion { get; internal set; }
    }
}
 

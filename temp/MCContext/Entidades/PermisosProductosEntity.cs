using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("PermisosProductos", Schema = "shared_owner")]
    public class PermisosProductosEntity
    {

        [Key]
        public int IdPermisosProductos { get; internal set; }

        public int IdParty { get; set; }

        public int IdProducto { get; set; }

        public bool PuedeBid { get; set; }
        public bool PuedeSell { get; set; }
        public bool Habilitado { get; set; }
    }
}

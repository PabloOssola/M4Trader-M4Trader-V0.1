using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("UsuarioBloqueado", Schema = "shared_owner")]
    public class UsuarioBloqueadoEntity
    {
        [Key]
        [Column("IdUsurioBloqueado")]
        public int IdUsurioBloqueado { get; set; }

        [ForeignKey("Parties")]
        [Column("IdPersona")]
        public int IdPersona { get; set; }

        [Column("TipoOperacion")]
        public string TipoOperacion { get; set; }

        [Column("FechaBloqueoDesde")]
        public DateTime FechaBloqueoDesde { get; set; }

        [Column("FechaBloqueoHasta")]
        public DateTime FechaBloqueoHasta { get; set; }
    }
}
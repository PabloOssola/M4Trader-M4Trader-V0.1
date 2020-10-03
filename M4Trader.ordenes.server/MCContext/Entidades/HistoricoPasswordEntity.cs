using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.HistoricoPassword)]
    [Table("HistoricoPassword", Schema = "shared_owner")]
    public class HistoricoPasswordEntity
    {
        [Key]
        public int IdHistoricoPassword { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("Pass")]
        public string Pass { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; }
    }
}

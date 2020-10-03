using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("UsuariosLimitesDiarios", Schema = "shared_owner")]
    public class UsuariosLimitesDiariosEntity
    {
        [Key]
        [Column("IdUsuarioLimiteDiario")]
        public int IdUsuarioLimiteDiario { get; set; }

        [ForeignKey("Usuarios")]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("ConsumidoOferta")]
        public decimal ConsumidoOferta { get; set; }

        [Column("ConsumidoOperacion")]
        public decimal ConsumidoOperacion { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; }
    }
}
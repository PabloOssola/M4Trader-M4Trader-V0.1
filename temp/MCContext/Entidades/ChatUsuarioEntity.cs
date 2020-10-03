using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [Table("ChatUsuarios", Schema = "orden_owner")]
    public class ChatUsuarioEntity
    {
        [Key]
        public int IdChatUsuario { get; set; }

        public int IdUsuario { get; set; }

        public int IdChat { get; set; }

        public bool EsOwner { get; set; }
        public DateTime Fecha { get; set; }
    }
}

using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [Table("Chats", Schema = "orden_owner")]
    public class ChatEntity
    {
        public ChatEntity()
        {
            ChatUsuarioItems = new List<ChatUsuarioEntity>();
        }
        [Key]
        public int IdChat { get; set; }

        public string Nombre { get; set; }

        public bool EsGrupo { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<ChatUsuarioEntity> ChatUsuarioItems { get; set; }
    }
}

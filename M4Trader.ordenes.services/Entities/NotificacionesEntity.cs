using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.services.Entities
{
    public class NotificacionesEntity
    {
        public byte IdTipoNotificacion { get; set; }
        public byte IdSubTipoNotificacion { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? PrecioVenta { get; set; }
        public bool Leido { get; set; }
        public int IdDestinatario { get; set; }
    }
 
}
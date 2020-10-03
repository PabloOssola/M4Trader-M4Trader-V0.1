using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M4Trader.ordenes.server.MCContext.Entidades.Logging
{
    [Table("LogConectividad", Schema = "orden_owner")]
    public class LogConectividadEntity
    {
        [Key]
        public int IdLogConectividad { get; set; }

        //Interfgas de travel
        //        IdPersona,
        //        Fecha,
        //        mensaje
        public int IdPersona { get; set; }
        
        public DateTime Fecha { get; set; }

        public string Mensaje { get; set; }
    }
}

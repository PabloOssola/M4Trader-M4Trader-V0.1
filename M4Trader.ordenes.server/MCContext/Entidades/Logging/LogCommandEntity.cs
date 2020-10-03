using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using M4Trader.ordenes.services.Helpers;


namespace M4Trader.ordenes.server.MCContext.Entidades.Logging
{
    [Table("LogCommand", Schema = "orden_owner")]
    public class LogCommandEntity : ILogCommandEntity
    {
        public LogCommandEntity()
        {

        }
        public LogCommandEntity(string commandName, string codigo, Guid inCourseRequestId, object data)
        {
            this.CommandName = commandName;
            this.Codigo = codigo;
            this.StartDatetime = DateTime.Now;
            this.RequestId = inCourseRequestId;
            this.Data = data;
        }
        [Key]
        public int IdLogCommand { get; set; }
        public int? IdUsuario { get; set; }
        public string CommandName { get; set; }
        public string Codigo { get; set; }
        public DateTime StartDatetime { get; set; }
        public Guid RequestId { get; set; }
        public string Argument { get; set; }
        public Guid? IdSesion { get; set; }

        [NotMapped]
        public object Data { get; set; }

        public string GetSchema()
        {
            return "orden_owner";
        }
    }
}

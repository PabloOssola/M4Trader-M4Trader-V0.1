using M4Trader.ordenes.services.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades.Logging
{
    [Table("LogCommand", Schema = "api_owner")]

    public class LogCommandApiEntity : ILogCommandEntity
    {
        public LogCommandApiEntity(string commandName, string codigo, Guid inCourseRequestId, object data)
        {
            this.CommandName = commandName;
            this.Codigo = codigo;
            this.StartDatetime = DateTime.Now;
            this.RequestId = inCourseRequestId;
            this.Data = data;
        }

        public LogCommandApiEntity()
        {

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
            return "api_owner";
        }
    }

    public interface ILogCommandApiEntity
    {
        int IdLogCommand { get; set; }
        int? IdUsuario { get; set; }
        string CommandName { get; set; }
        string Codigo { get; set; }
        DateTime StartDatetime { get; set; }
        Guid RequestId { get; set; }
        string Argument { get; set; }
        Guid? IdSesion { get; set; }
        object Data { get; set; }

        string GetSchema();
    }
}

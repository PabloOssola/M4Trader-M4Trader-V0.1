using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.services.Helpers
{
    public class LogCommandEntityAux : ILogCommandEntity
    {
        public LogCommandEntityAux()
        {

        }
        public LogCommandEntityAux(string commandName, string codigo, Guid inCourseRequestId, object data)
        {
            this.CommandName = commandName;
            this.Codigo = codigo;
            this.StartDatetime = DateTime.Now;
            this.RequestId = inCourseRequestId;
            this.Data = data;
        }
        public int? IdUsuario { get; set; }
        public string CommandName { get; set; }
        public string Codigo { get; set; }
        public DateTime StartDatetime { get; set; }
        public Guid RequestId { get; set; }
        public string Argument { get; set; }
        public Guid? IdSesion { get; set; }
        public object Data { get; set; }
        public int IdLogCommand { get ; set; }

        public string GetSchema()
        {
            return string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace M4Trader.ordenes.server.MCContext.Entidades.Logging
{
    [Table("LogSqlErrores", Schema = "orden_owner") ]
    public class LogSqlEntity
    {
        public LogSqlEntity(string tipoSentenciaSQL, string nombreSP, List<SqlParameter> parametros, Exception ex)
        {
            this.TipoSentenciaSQL = tipoSentenciaSQL;
            this.NombreSP = nombreSP;
            this.Parametros = parametros;
            this.Exception = ex;
            this.Fecha = DateTime.Now;

        }
        [Key]public int IdLogSqlErrores { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoSentenciaSQL { get; set; }
        public string StackTrace { get; set; }
        public string ParametrosSP { get; set; }
        public string NombreSP { get; set; }
        public string MensajeError { get; set; }
        public string CallStack { get; set; }
        public int? IdUsuario { get; set; }
        public Guid? RequestId { get; set; }
        [NotMapped]
        public List<SqlParameter> Parametros { get; set; }
        [NotMapped]
        public Exception Exception { get; set; }
    }
}

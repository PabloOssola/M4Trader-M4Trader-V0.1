using System;
using System.Data;
using System.Globalization;

namespace M4Trader.ordenes.server.Helpers.Logging
{
    public class LoggerBase
    {

        protected static string FormatearParametroParaLogSegunTipo(object valor, SqlDbType tipo)
        {
            if (tipo.Equals(SqlDbType.Char)
                || tipo.Equals(SqlDbType.DateTime2)
                || tipo.Equals(SqlDbType.DateTimeOffset)
                || tipo.Equals(SqlDbType.SmallDateTime)
                || tipo.Equals(SqlDbType.Text)
                || tipo.Equals(SqlDbType.VarChar))
            {
                return "'" + valor.ToString() + "'";
            }
            else if (tipo.Equals(SqlDbType.DateTime))
            {
                return "'" + ((DateTime)valor).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else if (tipo.Equals(SqlDbType.Date))
            {
                return "'" + ((DateTime)valor).ToString("yyyy-MM-dd") + "'";
            }
            else if (tipo.Equals(SqlDbType.Time))
            {
                return "'" + ((DateTime)valor).ToString("HH:mm:ss") + "'";
            }
            else if (tipo.Equals(SqlDbType.Decimal))
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                return ((decimal)valor).ToString(nfi);
            }
            return valor.ToString();
        }

        protected static string GetCallStack()
        {
            var st = new System.Diagnostics.StackTrace(true);
            var frames = st.GetFrames();
            var traceString = "";

            foreach (var frame in frames)
            {
                if (frame.GetFileLineNumber() < 1)
                {
                    continue;
                }
                traceString += "File: " + frame.GetFileName() + ", Method:" + frame.GetMethod().Name + ", LineNumber: " + frame.GetFileLineNumber() + Environment.NewLine + "  -->  ";
            }
            return traceString;
        }

        protected string GetExceptionDescription(Exception exception)
        {
            string mensajeError = "", stackTrace = "";
            if (exception != null)
            {
                mensajeError = exception.Message;
                stackTrace = exception.StackTrace;


            }
            Exception inner = exception.InnerException;
            while (inner != null)
            {
                mensajeError += "\n\rINNER EXCEPTION" + inner.Message;
                stackTrace += "\n\rINNER EXCEPTION" + inner.StackTrace;
                inner = inner.InnerException;
            }

            return mensajeError + "STACK TRACE :" + stackTrace;
        }

    }
}

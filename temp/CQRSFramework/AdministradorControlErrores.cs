using M4Trader.ordenes.services.Exceptions;
using System;

namespace M4Trader.ordenes.server.CQRSFramework
{

    public sealed class AdministradorControlErrores
    {
        private const string SEPARADOR_MENSAJES = "||";
        private const string SEPARADOR_ENTIDAD_ERROR_BASE = "$$";

        public static void EnviarExcepcion(string codigo, string descripcion)
        {
            string _cadena = CodeMensajes.GetDescripcionMensaje(codigo);
            Exception _exGenerada = new MAEApplicationException(codigo, string.Format(_cadena, descripcion));
            throw _exGenerada;
        }

        public static void EnviarExcepcion(string codigo, bool soloTexto, params object[] parametros)
        {
            Exception _exGenerada = ObtenerExcepcion(codigo, soloTexto, null, parametros);

            throw _exGenerada;
        }

        public static string GetDescription(string codigo)
        {
            string _descripcion = CodeMensajes.GetDescripcionMensaje(codigo);
            return _descripcion;
        }

        private static MAEApplicationException ObtenerExcepcion(string codigo, bool solo_texto, Exception ex, params object[] parametros)
        {
            string _textExcepcion = "";

            if (ex != null)
            {
                if (solo_texto)
                {
                    _textExcepcion = string.Format("Detalle del Error: {0}", ex.Message);
                }
                else
                {
                    _textExcepcion = string.Format("Detalle del Error: {0}", ex);
                }
            }

            string _cadena = GetDescription(codigo);
            _cadena = _cadena.Replace("|", "");
            if (parametros.Length == 0)
            {
                return new MAEApplicationException(codigo, _cadena + _textExcepcion);
            }
            else
            {
                for (int i = 0; i < parametros.Length; i++)
                {
                    if (parametros[i] is string)
                    {
                        parametros[i] = Convert.ToString(parametros[i]);
                    }
                }
                return new MAEApplicationException(codigo, string.Format(_cadena, parametros) + _textExcepcion);
            }
        }
    }
}

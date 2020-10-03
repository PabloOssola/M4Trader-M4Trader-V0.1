using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using System.Collections.Generic;

namespace M4Trader.ordenes.server
{
    public class TraductorLiterales
    {
        public static string __LITERAL_SIN_TRADUCCION__ = "(literal sin valor)";

        static Dictionary<string, Dictionary<string, string>> dictTraducciones = new Dictionary<string, Dictionary<string, string>>();
        static Dictionary<string, Dictionary<string, string>> dictMensajes = new Dictionary<string, Dictionary<string, string>>();
        private static string DefaultIdioma = "es-AR";

        #region Mensajes

        public static Dictionary<string, Dictionary<string, string>> ObtenerMensajes(string idioma)
        {
            DefaultIdioma = idioma;
            var ts = new MensajesCustomQueryAll();
            var mensajes = ts.Execute(idioma);
            ConvertirListaMensajes(mensajes, idioma);
            return dictMensajes;
        }

        private static void ConvertirListaMensajes(List<MensajesLiteralesEntity> mensajes, string idioma)
        {
            var dict = new Dictionary<string, string>();

            foreach (MensajesLiteralesEntity msg in mensajes)
            {
                if (!dict.ContainsKey(msg.Referencia))
                    dict.Add(msg.Referencia, msg.Valor);
            }

            if (!dictMensajes.ContainsKey(idioma))
            {
                dictMensajes.Add(idioma, dict);
            } else
            {
                dictMensajes[idioma] = dict;
            }
        }

        public static bool ExistMessage(string s)
        {
            var idioma = (dictMensajes.ContainsKey(DefaultIdioma)) ? DefaultIdioma : "es-AR";
            return (dictMensajes[idioma].ContainsKey(s));
        }

        public static string GetTranslatedMessage(string s)
        {
            if (null == s)
            {
                var x = __LITERAL_SIN_TRADUCCION__;

                var e_fmt = GetTranslatedMessage("TranslatorNullKey");
                var e_msg = string.Format(e_fmt, x);
                return x;
            }

            var idioma = (dictMensajes.ContainsKey(DefaultIdioma)) ? DefaultIdioma : "es-AR";
            if (dictMensajes[idioma].ContainsKey(s))
            {
                var r = dictMensajes[idioma][s];

                if (null == r || string.IsNullOrEmpty(r.Trim()))
                {
                    var w_fmt = GetTranslatedMessage("TranslatorEmptyValue");
                    var w_msg = string.Format(w_fmt, s, r);
                }

                return r;
            }
            else
            {
                return s;
            }
        }

        #endregion

        #region Literales

        public static Dictionary<string, Dictionary<string, string>> ObtenerTraducciones(string idioma)
        {
            try
            {
                DefaultIdioma = idioma;
                var ts = new MensajesCustomQueryAll();
                var traducciones = ts.Execute(idioma);
                ConvertirListaTraducciones(traducciones, idioma);

            }
            catch
            {
                //throw new Exception("No se pudieron cargar las traducciones");
            }
            return dictTraducciones;
        }

        private static void ConvertirListaTraducciones(List<MensajesLiteralesEntity> traducciones, string idioma)
        {
            var dict = new Dictionary<string, string>();

            foreach (MensajesLiteralesEntity trd in traducciones)
            {
                if (!dict.ContainsKey(trd.Referencia))
                    dict.Add(trd.Referencia, trd.Valor);
            }

            if (!dictTraducciones.ContainsKey(idioma))
                dictTraducciones.Add(idioma, dict);
        }



        public static bool ExistLiteral(string s)
        {
            var idioma = (dictTraducciones.ContainsKey(DefaultIdioma)) ? DefaultIdioma : "es-AR";
            return (dictTraducciones[idioma].ContainsKey(s));
        }



        public static string GetTranslatedString(string s)
        {
            if (null == s)
            {
                var x = __LITERAL_SIN_TRADUCCION__;

                var e_fmt = GetTranslatedString("TranslatorNullKey");
                var e_msg = string.Format(e_fmt, x);
                return x;
            }

            // TODO: Revisar, es incoherente que bo_Idiomas.DefaultIdioma == null...
            var idioma = (dictTraducciones.ContainsKey(DefaultIdioma)) ? DefaultIdioma : "es-AR";
            if (dictTraducciones[idioma].ContainsKey(s))
            {
                var r = dictTraducciones[idioma][s];

                if (null == r || string.IsNullOrEmpty(r.Trim()))
                {
                    var w_fmt = GetTranslatedString("TranslatorEmptyValue");
                    var w_msg = string.Format(w_fmt, s, r);
                }

                return r;
            }
            else
            {
                return s;
            }
        }

        #endregion

    }
}
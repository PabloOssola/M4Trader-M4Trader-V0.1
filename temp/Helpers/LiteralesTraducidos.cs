﻿using M4Trader.ordenes.server;
using System.Collections.Generic;
using System.Web;

namespace M4Trader.ordenes.server.Helpers
{
    public class LiteralesTraducidos
    {
        private static LiteralesTraducidos _instance = new LiteralesTraducidos();

        
        private string _idiomaInicial;

        public LiteralesTraducidos()
        {
            _idiomaInicial = "es-ar";//Configuracion.Instance.BootLanguage;
        }


        public string IdiomaInicial
        {
            get { return _idiomaInicial; }
        }

        public static LiteralesTraducidos Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Init()
        {
            var dic = TraductorLiterales.ObtenerMensajes(_idiomaInicial);
            HttpRuntime.Cache["LITERALES_TRADUCIDOS"] = dic;
        }

        public string Translate(string codigoIdioma, string abztract)
        {
            var entradasIdioma = (Dictionary<string, Dictionary<string, string>>)HttpRuntime.Cache["LITERALES_TRADUCIDOS"];

            Dictionary<string, string> use = null;

            if (entradasIdioma.ContainsKey(codigoIdioma))
            {
                use = entradasIdioma[codigoIdioma];
            }
            else
            {
                var dic = TraductorLiterales.ObtenerMensajes(codigoIdioma);
                HttpRuntime.Cache["LITERALES_TRADUCIDOS"]  = dic;
                use = dic[codigoIdioma];

            }

            if (use.ContainsKey(abztract))
            {
                return use[abztract];
            }
            else
                return abztract;
        }



        public Dictionary<string, string> GetFullLists()
        {
            var idioma = IdiomaInicial;

            Dictionary<string, Dictionary<string, string>> entradasIdioma = (Dictionary<string, Dictionary<string, string>>)HttpRuntime.Cache["LITERALES_TRADUCIDOS"];

            return entradasIdioma[idioma];
        }

    }
}

using M4Trader.ordenes.server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server.Helpers
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class CommandTypeAttribute : Attribute
    {
        readonly string key;
        readonly int idAccion;
        readonly List<TipoAplicacion> tipoaplicacion;
        // This is a positional argument
        public CommandTypeAttribute(string key, int idAccion, params TipoAplicacion[] tipoaplicacion)
        {
            this.key = key;
            this.tipoaplicacion = tipoaplicacion.ToList();
            this.idAccion = idAccion;
        }

        public string Key
        {
            get { return key; }
        }

        public int IdAccion
        {
            get { return idAccion; }
        }

        public List<TipoAplicacion> TipoAplicacion
        {
            get { return tipoaplicacion; }
        }


        // This is a named argument
        public int NamedInt { get; set; }
    }
}

using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace M4Trader.ordenes.server.Helpers
{
    public class XMLBase<T>
    {
        XMLHelper<T> _service;

        public XMLBase()
        {

        }

        private XMLHelper<T> ObtenerServicioMock()
        {
            if (_service == null)
                _service = _service = new XMLHelper<T>();

            return _service;

        }

        internal List<T> ObtenerTodos(string file)
        {
            return ObtenerServicioMock().ObtenerTodos(file);
        }

        internal T ObtenerUno(Func<T, bool> predicado, string file)
        {
            return ObtenerServicioMock().ObtenerUno(predicado, file);
        }
    }
}

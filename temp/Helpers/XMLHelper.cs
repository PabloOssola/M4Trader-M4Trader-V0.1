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
    public class XMLHelper<T>
    {
        private FileStream _manejadorArchivo;

        public XMLHelper()
        {
        }

        public List<T> ObtenerTodos(string file)
        {
            if (!File.Exists(file))
                throw new Exception("No se encontrol el archivo mock");

            _manejadorArchivo = File.OpenRead(file);

            XmlSerializer ser = new XmlSerializer(typeof(List<T>));
            List<T> listaDeEntidad = (List<T>)ser.Deserialize(_manejadorArchivo);

            _manejadorArchivo.Close();
            _manejadorArchivo.Dispose();

            _manejadorArchivo = null;

            return listaDeEntidad;
        }

        public T ObtenerUno(Func<T, bool> predicado, string file)
        {
            if (!File.Exists(file))
                throw new Exception("No se encontrol el archivo mock");

            _manejadorArchivo = File.OpenRead(file);

            XmlSerializer ser = new XmlSerializer(typeof(List<T>));
            List<T> listaDeEntidad = (List<T>)ser.Deserialize(_manejadorArchivo);

            _manejadorArchivo.Close();
            _manejadorArchivo.Dispose();

            _manejadorArchivo = null;

            return listaDeEntidad.FirstOrDefault(predicado);
        }

    }
}

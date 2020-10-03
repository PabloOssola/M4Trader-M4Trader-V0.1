using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Xml;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class XmlProcessorHelper : IApplicationServiceStarter
    {
        #region Interface imp.
        public string ServiceName => "XmlProcessorHelper";

        public void SetWaitHandler(ManualResetEvent manualResetEvent)
        {

        }

        public void Start()
        {
            Clock.Start();
        }

        public void Stop()
        {
            Clock.Stop();
        }

        #endregion

        #region Properties

        public System.Timers.Timer Clock
        {
            get
            {
                var clock = new System.Timers.Timer(Intervals);

                clock.Elapsed += Clock_Elapsed;

                clock.AutoReset = false;

                return clock;
            }
        }

        public string BasePath { get; set; }

        #endregion

        #region Events

        private void Clock_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                ProcessXml(TipoXmlAProcesar.Productos, guid);
                ProcessXml(TipoXmlAProcesar.Clientes, guid);
                ProcessXml(TipoXmlAProcesar.Saldos, guid);
            }
            catch (Exception)
            {

                //throw;
            }
            finally
            {
                Clock.Start();

            }
        }

        public double Intervals { get; set; }


        #endregion

        #region Methods

        private void ProcessXml(TipoXmlAProcesar tipoXml, Guid guid)
        {
            Clock.Stop();
            string subPath = string.Empty;
            string parentNode = string.Empty;
            string prefix = string.Empty;


            // Get File Path
            switch (tipoXml)
            {
                case TipoXmlAProcesar.Clientes:
                    subPath = "Clientes";
                    parentNode = "BEPersonasParticipantes";
                    break;
                case TipoXmlAProcesar.Productos:
                    subPath = "Productos";
                    parentNode = "BEProductos";
                    break;
                case TipoXmlAProcesar.Saldos:
                    subPath = "Saldos";
                    parentNode = "SaldoEntity";
                    break;
                default:
                    break;
            }

            prefix = parentNode;


            var path = Path.Combine(BasePath, subPath);

            if (!Directory.Exists(path))
            {
                return;
            }

            MAEUserSession.CargarInstancia(OrdenesApplication.Instance.SessionUsuarioProceso);

            var file = Directory.GetFiles(path).FirstOrDefault();
            if (file == null)
                return;

            var xmldoc = new XmlDocument();
            XmlNodeList xmlnodes;

            var hasErrors = false;
            var filename = string.Empty;

            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    xmldoc.Load(fs);
                    xmlnodes = xmldoc.GetElementsByTagName(parentNode);

                    if (xmlnodes.Count > 0)
                    {
                        switch (tipoXml)
                        {
                            case TipoXmlAProcesar.Clientes:
                                var clientes = new List<ClienteXMLEntity>();
                                hasErrors = ReadXmlNodes<ClienteXMLEntity>(xmlnodes, TipoXmlAProcesar.Clientes, clientes, guid);
                                if (hasErrors)
                                    break;
                                SendXmlToDAL(clientes, TipoXmlAProcesar.Clientes);
                                break;
                            case TipoXmlAProcesar.Productos:
                                var productos = new List<ProductoXMLEntity>();
                                hasErrors = ReadXmlNodes<ProductoXMLEntity>(xmlnodes, TipoXmlAProcesar.Productos, productos, guid);
                                if (hasErrors)
                                    break;
                                SendXmlToDAL(productos, TipoXmlAProcesar.Productos);
                                break;
                            case TipoXmlAProcesar.Saldos:
                                var saldos = new List<SaldoXMLEntity>();
                                hasErrors = ReadXmlNodes<SaldoXMLEntity>(xmlnodes, TipoXmlAProcesar.Saldos, saldos, guid);
                                if (hasErrors)
                                    break;
                                SendXmlToDAL(saldos, TipoXmlAProcesar.Saldos);
                                break;
                            default:
                                break;
                        }
                        
                    }
                    var date = DateTime.Now;
                    if (hasErrors)
                    {
                        if (!Directory.Exists(Path.Combine(BasePath, subPath, "NoProcesados")))
                            Directory.CreateDirectory(Path.Combine(BasePath, subPath, "NoProcesados"));
                        filename = Path.Combine(BasePath, subPath, "NoProcesados", $"{prefix}{date.Year}{date.Month}{date.Day}{date.Hour}{date.Minute}.xml");

                    }
                    else
                    {
                        if (!Directory.Exists(Path.Combine(BasePath, subPath, "Procesados")))
                            Directory.CreateDirectory(Path.Combine(BasePath, subPath, "Procesados"));
                        filename = Path.Combine(BasePath, subPath, "Procesados" , $"{prefix}{date.Year}{date.Month}{date.Day}{date.Hour}{date.Minute}.xml");
                        LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, IdLogCodigoAccion = (byte)LogCodigoAccion.ProcesadoXMLCorrectamente, Descripcion = "Importar: " + tipoXml + ".Nombre Archivo: " + filename, IdUsuario = MAEUserSession.Instancia.IdUsuario });
                    }

                }
            }
            catch (Exception ex)
            {
                hasErrors = true;
                var date = DateTime.Now;
                if (!Directory.Exists(Path.Combine(BasePath, subPath, "NoProcesados")))
                    Directory.CreateDirectory(Path.Combine(BasePath, subPath, "NoProcesados"));
                filename = Path.Combine(BasePath, subPath, "NoProcesados", $"{prefix}{date.Year}{date.Month}{date.Day}{date.Hour}{date.Minute}.xml");
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, IdLogCodigoAccion = (byte)LogCodigoAccion.ProcesadoXMLConError, Descripcion = "Importar: " + tipoXml + ".Msg: " + ex.Message, Exception = ex, IdUsuario = MAEUserSession.Instancia.IdUsuario });
            }
            finally
            {
                var date = DateTime.Now;
                var dest = Path.Combine(BasePath, subPath, filename);
                File.Copy(file, dest);
                File.Delete(file);

            }


        }

        private bool ReadXmlNodes<T>(XmlNodeList xmlnodes, TipoXmlAProcesar tipo, List<T> entities, Guid guid)
        {
            foreach (XmlNode node in xmlnodes)
            {
                object entity = null;
                switch (tipo)
                {
                    case TipoXmlAProcesar.Clientes:
                        entity = MapXmlNodeToClienteXMLEntity(node, guid);
                        break;
                    case TipoXmlAProcesar.Productos:
                        entity = MapXmlNodeToProductoXMLEntity(node, guid);
                        break;
                    case TipoXmlAProcesar.Saldos:
                        entity = MapXmlNodeToSaldoXMLEntity(node, guid);
                        break;
                }
                 
                if (entity == null)
                {
                    return true;

                }
                entities.Add((T)(object)entity);
            }
            return false;
            
        }

        private ClienteXMLEntity MapXmlNodeToClienteXMLEntity(XmlNode node, Guid guid)
        {
            // Validate Fields
            if (node["NumeroDocumento"] == null)
            {
                LogXmlIntegrityError("NumeroDocumento", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["NombrePersona"] == null)
            {
                LogXmlIntegrityError("NombrePersona", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["NroCliente"] == null)
            {
                LogXmlIntegrityError("NroCliente", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["IdentificacionTributaria"] == null)
            {
                LogXmlIntegrityError("IdentificacionTributaria", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["NombreParticipante"] == null)
            {
                LogXmlIntegrityError("NombreParticipante", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["Telefono"] == null)
            {
                LogXmlIntegrityError("Telefono", TipoXmlAProcesar.Clientes, guid);
                return null;
            }

            // Map Fields
            var entity = new ClienteXMLEntity();
            entity.NroDocumento = node["NumeroDocumento"].InnerText;
            entity.NombrePersona = node["NombrePersona"].InnerText;
            entity.NroCliente = node["NroCliente"].InnerText;
            entity.TipoPersona = (int)TipoPersonas.CLIENTE;
            entity.IdPersoneriaJuridica = (byte)PersoneriaJuridica.PERSONA_FISICA;
            entity.NroIdentificacionTributaria = node["IdentificacionTributaria"].InnerText;
            entity.CodEmpresa = node["NombreParticipante"].InnerText;
            entity.Telefono = node["Telefono"].InnerText;
            return entity;
        }

        private ProductoXMLEntity MapXmlNodeToProductoXMLEntity(XmlNode node, Guid guid)
        {
            
            // Validate Fields
            if (node["CodigoMercado"] == null)
            {
                LogXmlIntegrityError("CodigoMercado", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["Descripcion"] == null)
            {
                LogXmlIntegrityError("Descripcion", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["MonedaDescripcion"] == null)
            {
                LogXmlIntegrityError("MonedaDescripcion", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["MercadoDescripcion"] == null)
            {
                LogXmlIntegrityError("MercadoDescripcion", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            

            // Map Fields
            var entity = new ProductoXMLEntity();
            entity.Codigo =  node["CodigoMercado"].InnerText;
            entity.Descripcion =  node["Descripcion"].InnerText;
            entity.CodMoneda =  node["MonedaDescripcion"].InnerText;
            entity.CodMercado =  node["MercadoDescripcion"].InnerText;
            entity.ISIN =  string.Empty;
            entity.Habilitado =  true;
            return entity;
        }

        private SaldoXMLEntity MapXmlNodeToSaldoXMLEntity(XmlNode node, Guid guid)
        {
            // Validate Fields
            if (node["IdCliente"] == null)
            {
                LogXmlIntegrityError("IdCliente", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["IdEmpresa"] == null)
            {
                LogXmlIntegrityError("IdEmpresa", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["TipoProducto"] == null)
            {
                LogXmlIntegrityError("TipoProducto", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["CodigoProducto"] == null)
            {
                LogXmlIntegrityError("CodigoProducto", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["DescripcionProducto"] == null)
            {
                LogXmlIntegrityError("DescripcionProducto", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["Cantidad"] == null)
            {
                LogXmlIntegrityError("Cantidad", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["Monto"] == null)
            {
                LogXmlIntegrityError("Monto", TipoXmlAProcesar.Clientes, guid);
                return null;
            }
            if (node["Moneda"] == null)
            {
                LogXmlIntegrityError("Moneda", TipoXmlAProcesar.Clientes, guid);
                return null;
            }

            // Map Fields
            var entity = new SaldoXMLEntity();
            entity.CodCliente = node["IdCliente"].InnerText;
            entity.CodEmpresa = node["IdEmpresa"].InnerText;
            entity.TipoProducto = node["TipoProducto"].InnerText;
            entity.CodigoProducto = node["CodigoProducto"].InnerText;
            entity.DescripcionProducto = node["DescripcionProducto"].InnerText;
            entity.Cantidad = node["Cantidad"].InnerText;
            entity.Precio = node["Precio"].InnerText;
            entity.Monto = node["Monto"].InnerText;
            entity.Moneda = node["Moneda"].InnerText;
            return entity;
        }

        private void LogXmlIntegrityError(string campo, TipoXmlAProcesar tipo, Guid guid)
        {
            LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, IdLogCodigoAccion = (byte)LogCodigoAccion.ProcesadoXMLConError, Descripcion = "Importar: " + tipo + $".Msg: El campo {campo} no se encuentra en el archivo XML", IdUsuario = MAEUserSession.Instancia.IdUsuario });
        }

        private void SendXmlToDAL(object entities, TipoXmlAProcesar tipo)
        {
            List<SqlParameter> lista;
            using (var ts = new TransactionScope())
            {
                switch (tipo)
                {
                    case TipoXmlAProcesar.Clientes:
                        var clientes = entities as List<ClienteXMLEntity>;

                        foreach (ClienteXMLEntity node in clientes)
                        {
                            lista = new List<SqlParameter>();
                            lista.Add(SqlServerHelper.GetParam("@NroDocumento", node.NroDocumento));
                            lista.Add(SqlServerHelper.GetParam("@NombrePersona", node.NombrePersona));
                            lista.Add(SqlServerHelper.GetParam("@NroCliente", node.NroCliente));
                            lista.Add(SqlServerHelper.GetParam("@TipoPersona", (int)TipoPersonas.CLIENTE));
                            lista.Add(SqlServerHelper.GetParam("@IdPersoneriaJuridica", (byte)PersoneriaJuridica.PERSONA_FISICA));
                            lista.Add(SqlServerHelper.GetParam("@NroIdentificacionTributaria", node.NroIdentificacionTributaria));
                            lista.Add(SqlServerHelper.GetParam("@CodEmpresa", node.CodEmpresa));
                            lista.Add(SqlServerHelper.GetParam("@Telefono", node.Telefono));
                            PersonasDAL.ProcessFromXml(lista);
                        }
                        break;
                    case TipoXmlAProcesar.Productos:
                        var productos = entities as List<ProductoXMLEntity>;
                        foreach (ProductoXMLEntity node in productos)
                        {
                            lista = new List<SqlParameter>();
                            lista.Add(SqlServerHelper.GetParam("@Codigo", node.Codigo));
                            lista.Add(SqlServerHelper.GetParam("@Descripcion", node.Descripcion));
                            lista.Add(SqlServerHelper.GetParam("@CodMoneda", node.CodMoneda));
                            lista.Add(SqlServerHelper.GetParam("@CodMercado", node.CodMercado));
                            lista.Add(SqlServerHelper.GetParam("@ISIN", node.ISIN));
                            lista.Add(SqlServerHelper.GetParam("@Habilitado", node.Habilitado));
                            ProductosDAL.ProcessFromXml(lista);

                        }
                        break;
                    case TipoXmlAProcesar.Saldos:
                        var saldos = entities as List<SaldoXMLEntity>;
                        foreach (SaldoXMLEntity node in saldos)
                        {
                            lista = new List<SqlParameter>();
                            lista.Add(SqlServerHelper.GetParam("@CodCliente", node.CodCliente));
                            lista.Add(SqlServerHelper.GetParam("@CodEmpresa", node.CodEmpresa));
                            lista.Add(SqlServerHelper.GetParam("@TipoProducto", node.TipoProducto));
                            lista.Add(SqlServerHelper.GetParam("@CodigoProducto", node.CodigoProducto));
                            lista.Add(SqlServerHelper.GetParam("@DescripcionProducto", node.DescripcionProducto));
                            lista.Add(SqlServerHelper.GetParam("@Cantidad", node.Cantidad));
                            lista.Add(SqlServerHelper.GetParam("@Precio", node.Precio));
                            lista.Add(SqlServerHelper.GetParam("@Monto", node.Monto));
                            lista.Add(SqlServerHelper.GetParam("@Moneda", node.Moneda));
                            SaldosDAL.ProcessFromXml(lista);
                        }
                        break;
                    default:
                        break;
                }

                ts.Complete();

            }
        }

        #endregion

    }

    public class ClienteXMLEntity
    {
        public string NroDocumento { get; set; }
        public string NombrePersona { get; set; }
        public string NroCliente { get; set; }
        public int TipoPersona { get; set; }
        public byte IdPersoneriaJuridica { get; set; }
        public string NroIdentificacionTributaria { get; set; }
        public string CodEmpresa { get; set; }
        public string Telefono { get; set; }
    }

    public class ProductoXMLEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string CodMoneda { get; set; }
        public string CodMercado { get; set; }
        public string ISIN { get; set; }
        public bool Habilitado { get; set; }
    }

    public class SaldoXMLEntity
    {
        public string CodCliente { get; set; }
        public string CodEmpresa { get; set; }
        public string TipoProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string Monto { get; set; }
        public string Moneda { get; set; }
    }
}

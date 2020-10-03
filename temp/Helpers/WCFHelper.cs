using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace M4Trader.ordenes.server.Helpers
{

    public  class WCFHelper
    {
        #region class json Mapper
        private class JsonMapper : WebContentTypeMapper
        {
            public override WebContentFormat GetMessageFormatForContentType(string contentType)
            {

                return WebContentFormat.Raw;

            }
        } 
        #endregion

        private const int TwoGigaBytes = 2147483647;
        
        public static string GetServiceUrl(ConfiguracionSistemaURLsEnumDestino destino)
        {
            switch (destino)
            {
                case ConfiguracionSistemaURLsEnumDestino.Mobile:
                    return OrdenesApplication.Instance.ContextoAplicacion.Urls.Find(x => x.TipoUrl == ConfiguracionSistemaURLsEnumDestino.Mobile).Url;
                case ConfiguracionSistemaURLsEnumDestino.Swift:
                    return OrdenesApplication.Instance.ContextoAplicacion.Urls.Find(x => x.TipoUrl == ConfiguracionSistemaURLsEnumDestino.Swift).Url;
                case ConfiguracionSistemaURLsEnumDestino.OrdenesFIX:
                    return OrdenesApplication.Instance.ContextoAplicacion.Urls.Find(x => x.TipoUrl == ConfiguracionSistemaURLsEnumDestino.OrdenesFIX).Url;
                case ConfiguracionSistemaURLsEnumDestino.OrdenesFIXTcp:
                    return OrdenesApplication.Instance.ContextoAplicacion.Urls.Find(x => x.TipoUrl == ConfiguracionSistemaURLsEnumDestino.OrdenesFIXTcp).Url;
                case ConfiguracionSistemaURLsEnumDestino.DoubleAuthentication:
                    return OrdenesApplication.Instance.ContextoAplicacion.Urls.Find(x => x.TipoUrl == ConfiguracionSistemaURLsEnumDestino.DoubleAuthentication).Url;
                case ConfiguracionSistemaURLsEnumDestino.NotificacionesDMAFIX:
                    return OrdenesApplication.Instance.ContextoAplicacion.Urls.Find(x => x.TipoUrl == ConfiguracionSistemaURLsEnumDestino.NotificacionesDMAFIX).Url;
                case ConfiguracionSistemaURLsEnumDestino.ChatService:
                    return OrdenesApplication.Instance.ContextoAplicacion.Urls.Find(x => x.TipoUrl == ConfiguracionSistemaURLsEnumDestino.ChatService).Url;
                default:
                    return "no valido";
            }

        }

        public static WebHttpBinding CreateWebHttpBinding(string uri)
        {
            WebHttpBinding webHttpBinding = new WebHttpBinding();

            if (uri.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                webHttpBinding.Security.Mode = WebHttpSecurityMode.Transport;
            }
            else
            {
                webHttpBinding.Security.Mode = WebHttpSecurityMode.None;
            }

            webHttpBinding.OpenTimeout = new TimeSpan(0, 1, 0);
            webHttpBinding.CloseTimeout = new TimeSpan(0, 1, 0);
            webHttpBinding.SendTimeout = new TimeSpan(0, 5, 0);
            webHttpBinding.ReceiveTimeout = new TimeSpan(0, 5, 0);

            webHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            webHttpBinding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
            webHttpBinding.Security.Transport.Realm = string.Empty;
            webHttpBinding.ReaderQuotas.MaxStringContentLength = TwoGigaBytes;
            webHttpBinding.ReaderQuotas.MaxArrayLength = TwoGigaBytes;
            webHttpBinding.MaxBufferSize = TwoGigaBytes;
            webHttpBinding.MaxReceivedMessageSize = TwoGigaBytes;
            webHttpBinding.MaxBufferPoolSize = TwoGigaBytes;

            return webHttpBinding;
        }


        private static ChannelFactory<T> CreateChannelFactory<T>(ConfiguracionSistemaURLsEnumDestino destino)
        {
            string uri = WCFHelper.GetServiceUrl(destino);
            EndpointAddress endpointAddress = new EndpointAddress(uri);
            ChannelFactory<T> channelFactory;

            if (uri.StartsWith("net.pipe", StringComparison.OrdinalIgnoreCase))
            {
                NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                channelFactory = new ChannelFactory<T>();
                channelFactory.Endpoint.Binding = binding;
                channelFactory.Endpoint.Address = endpointAddress;
            }
            else if (uri.StartsWith("net.tcp", StringComparison.OrdinalIgnoreCase))
            {
                NetTcpBinding binding = new NetTcpBinding
                {
                    MaxReceivedMessageSize = TwoGigaBytes,
                    MaxBufferPoolSize = TwoGigaBytes,
                    MaxBufferSize = TwoGigaBytes,
                };
                binding.Security.Mode = SecurityMode.None;
                channelFactory = new ChannelFactory<T>();
                channelFactory.Endpoint.Binding = binding;
                channelFactory.Endpoint.Address = endpointAddress;
            }
            else
            {
                WebHttpBinding webHttpBinding = WCFHelper.CreateWebHttpBinding(uri);
                channelFactory = new ChannelFactory<T>();
                channelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
                channelFactory.Endpoint.Binding = webHttpBinding;
                channelFactory.Endpoint.Address = endpointAddress;
            }
            return channelFactory;
        }

        public static void ExecuteService<S>(ConfiguracionSistemaURLsEnumDestino destino, Action<S> methodName)
        {
            ChannelFactory<S> client = WCFHelper.CreateChannelFactory<S>(destino);
            client.Open();
            S service = client.CreateChannel();
            using (OperationContextScope ocs = new OperationContextScope((IContextChannel)service))
            {
                try
                {
                    methodName(service);
                }

                finally
                {
                    try
                    {
                        ((IClientChannel)service).Close();
                    }
                    catch (CommunicationException ce)
                    {
                        throw new MAECommunicationException("Error de comunicación", ce);
                    }
                    catch (TimeoutException)
                    {
                        // Ignore Timeouts
                    }
                }
            }
        }

        public static O ExecuteService<S, O>(ConfiguracionSistemaURLsEnumDestino destino, Func<S, O> methodName)
        {
            ChannelFactory<S> client = WCFHelper.CreateChannelFactory<S>(destino);
            client.Open();
            S service = client.CreateChannel();

            using (new OperationContextScope((IContextChannel)service))
            {
                try
                {
                    return methodName(service);
                }
                catch (CommunicationException ce)
                {
                    throw new M4TraderApplicationException("Error de comunicación", ce);
                }
                finally
                {
                    try
                    {
                        ((IClientChannel)service).Close();
                    }
                    catch (CommunicationException)
                    {
                        // Ignore various exceptions regarding the Channel's current state
                    }
                    catch (TimeoutException)
                    {
                        // Ignore Timeouts
                    }
                }
            }
        } 

    }
}

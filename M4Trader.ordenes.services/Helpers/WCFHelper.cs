using M4Trader.ordenes.services.CQRSFramework.CQRS;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.services.Services.helpers
{

    public class WCFHelper
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

        public static string GetServiceUrl(string destino)
        {
            switch (destino)
            {
                case "MobileCMD":
                    return ConfigurationManager.AppSettings["urlServices"] + "OrdenesApiQueryService.svc/Rest";
                case "MobileQRY":
                    return ConfigurationManager.AppSettings["urlServices"] + "OrdenesApiQueryService.svc/Rest";
                case "CommandExtranet":
                    return ConfigurationManager.AppSettings["urlServices"] + "CommandExtranetService.svc/Rest";
                case "OrdenesFIX":
                    return "";
                default:
                    return "";
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


        private static ChannelFactory<T> CreateChannelFactory<T>(string destino)
        {
            try
            {
                string uri = WCFHelper.GetServiceUrl(destino);
                EndpointAddress endpointAddress = new EndpointAddress(uri);
                WebHttpBinding webHttpBinding = WCFHelper.CreateWebHttpBinding(uri);

                ChannelFactory<T> channelFactory = new ChannelFactory<T>();
                channelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
                channelFactory.Endpoint.Binding = webHttpBinding;
                channelFactory.Endpoint.Address = endpointAddress;

                return channelFactory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static ChannelFactory<T> CreateChannelFactoryJsonMapper<T>(string destino)
        {
            try
            {
                string uri = WCFHelper.GetServiceUrl(destino);
                if (uri == "")
                    uri = destino;
                EndpointAddress endpointAddress = new EndpointAddress(uri);
                WebHttpBinding webHttpBinding = WCFHelper.CreateWebHttpBinding(uri);

                ChannelFactory<T> channelFactory = new ChannelFactory<T>();
                channelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
                channelFactory.Endpoint.Binding = webHttpBinding;
                channelFactory.Endpoint.Address = endpointAddress;

                return channelFactory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ExecuteServiceLocal<S>(string destino, string securitytokenid, Func<S, string> methodName) 
        {
            ChannelFactory<S> client = WCFHelper.CreateChannelFactoryJsonMapper<S>(destino);
            client.Open();
            S service = client.CreateChannel();
            using (new OperationContextScope((IContextChannel)service))
            {
                try
                {
                    WebOperationContext.Current.OutgoingRequest.Headers.Add("securitytokenid", securitytokenid);
                    string stream = methodName(service); 
                    return stream;
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

        public static T DeserializarCommand<T>(string stream)
        {
            CommandResult commandResult = JsonConvert.DeserializeObject<CommandResult>(stream);
            if (commandResult.Status == "EX0000" && commandResult.Data != null)
            {
                var jsonSettings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
                };
                return JsonConvert.DeserializeObject<T>(commandResult.Data.ToString(), jsonSettings);
            }
            else
                return default(T);
        }

        public static T Deserializar<T>(string stream)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
            };
            return JsonConvert.DeserializeObject<T>(stream, jsonSettings);
        }

        public static string ExecuteServiceQuery<S>(string destino, Func<S, string> methodName)
        {
            ChannelFactory<S> client = WCFHelper.CreateChannelFactoryJsonMapper<S>(destino);
            client.Open();
            S service = client.CreateChannel();

            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string securitytokenid = headers["securitytokenid"];

            using (new OperationContextScope((IContextChannel)service))
            {
                try
                {
                    WebOperationContext.Current.OutgoingRequest.Headers.Add("securitytokenid", securitytokenid);
                    string stream = methodName(service);

                    return stream;

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

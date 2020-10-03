using M4Trader.ordenes.services.CQRSFramework.CQRS;
using M4Trader.ordenes.services.Entities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.services.Helpers
{
    public class ApiWCFHelper : IWCFHelper
    {
        private const int TwoGigaBytes = 2147483647;
        private static string URL = "";

        public ApiWCFHelper()
        {
            URL = ConfigurationManager.AppSettings["urlServices"];
        }

        public string GetServiceUrl(ServiciosEnum destino)
        {
            switch (destino)
            {
                case ServiciosEnum.MobileCMD:
                    return URL + "OrdenesApiCommandService.svc/Rest";
                case ServiciosEnum.MobileQRY:
                    return URL + "OrdenesApiQueryService.svc/Rest";
                case ServiciosEnum.OrdenesFIX:
                    return "";
                case ServiciosEnum.Graph:
                    return URL + "OrdenesGDService.svc/Rest";
                case ServiciosEnum.CommandExtranet:
                    return URL + "CommandExtranetService.svc/Rest";
                default:
                    return "";
            }

        }

        private WebHttpBinding CreateBinding(string uri)
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

        private ChannelFactory<T> CreateChannelFactory<T>(ServiciosEnum destino)
        {
            try
            {
                string uri = GetServiceUrl(destino);
                EndpointAddress endpointAddress = new EndpointAddress(uri);

                ChannelFactory<T> channelFactory = new ChannelFactory<T>();
                WebHttpBinding webHttpBinding = CreateBinding(uri);

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

        private ChannelFactory<T> CreateChannelFactoryJsonMapper<T>(ServiciosEnum destino)
        {
            try
            {
                string uri = GetServiceUrl(destino);
                EndpointAddress endpointAddress = new EndpointAddress(uri);

                ChannelFactory<T> channelFactory = new ChannelFactory<T>();
                WebHttpBinding webHttpBinding = CreateBinding(uri);

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

        public T DeserializarCommand<T>(string stream)
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


        public string ExecuteQueryService<S>(ServiciosEnum destino, Func<S, string> methodName)
        {
            ChannelFactory<S> client = CreateChannelFactoryJsonMapper<S>(destino);
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


        public O ExecuteService<S, O>(ServiciosEnum destino, string securitytokenid, Func<S, string> methodName)
        {
            ChannelFactory<S> client = CreateChannelFactory<S>(destino);
            client.Open();
            S service = client.CreateChannel();

            using (new OperationContextScope((IContextChannel)service))
            {
                try
                {
                    WebOperationContext.Current.OutgoingRequest.Headers.Add("securitytokenid", securitytokenid);
                    string stream = methodName(service);

                    var commandResult = JsonConvert.DeserializeObject<CommandResult>(stream);

                    if (commandResult.Status == "EX0000" && commandResult.Data != null)
                    {
                        if (commandResult.Data.ToString().ToLower() == "ok")
                        {
                            return default(O);
                        }
                        else
                            return JsonConvert.DeserializeObject<O>(commandResult.Data.ToString());
                    }
                    else
                    {
                        string[] s = JsonConvert.DeserializeObject<string[]>(commandResult.Data.ToString());
                        throw new FaultException<ServiceFault>(new ServiceFault(s[1]), new FaultReason(s[1]));
                    }

                }
                catch (FaultException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw new FaultException<ServiceFault>(new ServiceFault("Servicios No Disponibles"), new FaultReason("Servicios No Disponibles"));
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

        /*public O ExecuteService<S, O>(string destino, Func<S, O> methodName, string securitytokenid)
        {
            ChannelFactory<S> client = CreateChannelFactory<S>(destino);
            client.Open();
            S service = client.CreateChannel();

            using (new OperationContextScope((IContextChannel)service))
            {
                try
                {
                    WebOperationContext.Current.OutgoingRequest.Headers.Add("securitytokenid", securitytokenid);
                    return methodName(service);
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

        */


        public QueryResult ExecuteQueryServiceApiDMA<S>(ServiciosEnum destino, Func<S, string> methodName, string securitytokenid)
        {
            ChannelFactory<S> client = CreateChannelFactoryJsonMapper<S>(destino);
            client.Open();
            S service = client.CreateChannel();

            using (new OperationContextScope((IContextChannel)service))
            {
                try
                {
                    WebOperationContext.Current.OutgoingRequest.Headers.Add("securitytokenid", securitytokenid);
                    string stream = methodName(service);
                    QueryResult queryResult = JsonConvert.DeserializeObject<QueryResult>(stream);
                    return queryResult;
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

        public string GetSecurityTokenIdFromHeader()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            return headers["securitytokenid"];
        }
    }
}
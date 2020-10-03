using M4Trader.ordenes.services.CQRSFramework.CQRS;
using M4Trader.ordenes.services.Entities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.services.Helpers
{
    public class WCFTcpHelper : IWCFHelper
    {
        private const int TwoGigaBytes = 2147483647;
        private static string URL = "";

        public WCFTcpHelper()
        {
            URL = ConfigurationManager.AppSettings["urlServices"];
        }

        public string GetServiceUrl(ServiciosEnum destino)
        {
            switch (destino)
            {
                case ServiciosEnum.MobileCMD:
                    return URL + "OrdenesApiCommandService.svc/nettcp";
                case ServiciosEnum.MobileQRY:
                    return URL + "OrdenesApiQueryService.svc/nettcp";
                case ServiciosEnum.OrdenesFIX:
                    return "";
                case ServiciosEnum.Graph:
                    return URL + "OrdenesGDService.svc/nettcp";
                case ServiciosEnum.CommandExtranet:
                    return URL + "CommandExtranetService.svc/nettcp";
                default:
                    return "";
            }

        }

        private NetTcpBinding CreateBinding(string uri)
        {
            NetTcpBinding binding = new NetTcpBinding
            {
                MaxReceivedMessageSize = TwoGigaBytes,
                MaxBufferPoolSize = TwoGigaBytes,
                MaxBufferSize = TwoGigaBytes,
            };
            binding.Security.Mode = SecurityMode.None;
            return binding;
        }

        private ChannelFactory<T> CreateChannelFactory<T>(ServiciosEnum destino)
        {
            try
            {
                string uri = GetServiceUrl(destino);
                EndpointAddress endpointAddress = new EndpointAddress(uri);

                ChannelFactory<T> channelFactory = new ChannelFactory<T>();
                NetTcpBinding binding = CreateBinding(uri);

                channelFactory.Endpoint.Binding = binding;
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
                NetTcpBinding webHttpBinding = CreateBinding(uri);
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


                    MessageHeader<string> mhg = new MessageHeader<string>(securitytokenid);
                    var untyped = mhg.GetUntypedHeader("securitytokenid", "ns");

                    OperationContext.Current.OutgoingMessageHeaders.Add(untyped);

                    
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

        //public string GetSecurityTokenIdFromHeader()
        //{
        //    var opContext = OperationContext.Current; // If this is null, is this code in an async block? If so, extract it before the async call.

        //    var rq = opContext.RequestContext;

        //    var headers = rq.RequestMessage.Headers;

        //    int headerIndex = headers.FindHeader("securitytokenid", string.Empty);
        //    var clientString = (headerIndex < 0) ? "UNKNOWN" : headers.GetHeader<string>(headerIndex).ToString();
        //    return clientString;
        //}

        //public O ExecuteService<S, O>(string destino, Func<S, O> methodName, string securitytokenid)
        public O ExecuteService<S, O>(ServiciosEnum destino, string securitytokenid, Func<S, string> methodName)
        {
            ChannelFactory<S> client = CreateChannelFactory<S>(destino);
            client.Open();
            S service = client.CreateChannel();

            using (new OperationContextScope((IContextChannel)service))
            {
                try
                {
                    MessageHeader<string> mhg = new MessageHeader<string>(securitytokenid);
                    var untyped = mhg.GetUntypedHeader("securitytokenid", "ns");

                    OperationContext.Current.OutgoingMessageHeaders.Add(untyped);


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



        

        public QueryResult ExecuteQueryServiceApiDMA<S>(ServiciosEnum destino, Func<S, string> methodName, string securitytokenid)
        {
            ChannelFactory<S> client = CreateChannelFactoryJsonMapper<S>(destino);
            client.Open();
            S service = client.CreateChannel();

            using (new OperationContextScope((IContextChannel)service))
            {
                try
                {
                    MessageHeader<string> mhg = new MessageHeader<string>(securitytokenid);
                    var untyped = mhg.GetUntypedHeader("securitytokenid", "ns");

                    OperationContext.Current.OutgoingMessageHeaders.Add(untyped);

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
    }
}
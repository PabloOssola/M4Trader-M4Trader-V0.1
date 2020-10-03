using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;

namespace M4Trader.ordenes.services.Services
{
    public class CommandExtranetServiceFactory : ServiceHostFactory
    {

        private const int TwoGigaBytes = 2147483647;

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost serviceHost = base.CreateServiceHost(serviceType, baseAddresses);
            this.AddBindingForRest(serviceHost, baseAddresses[0]);

            if (serviceHost.Description.Behaviors.Any(b => b is ServiceDebugBehavior))
            {
                ServiceDebugBehavior debugBehavior = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
                debugBehavior.IncludeExceptionDetailInFaults = true;
            }
            return serviceHost;
        }

    
        private void AddBindingForRest(ServiceHost serviceHost, Uri url)
        {
            WebHttpBinding binding = new WebHttpBinding();
            binding.CrossDomainScriptAccessEnabled = true;
            binding.MaxReceivedMessageSize = TwoGigaBytes;
            binding.MaxBufferPoolSize = TwoGigaBytes;
            binding.MaxBufferSize = TwoGigaBytes;
            binding.Security.Mode = WebHttpSecurityMode.Transport;
            
            ServiceEndpoint serviceEndpoint = serviceHost.AddServiceEndpoint(typeof(ICommandExtranetService), binding, "/Rest");

            WebHttpBehavior webhttp = new WebHttpBehavior();
            serviceEndpoint.Behaviors.Add(webhttp);
            webhttp.HelpEnabled = true;

            if (!serviceHost.Description.Behaviors.Any(b => b is ServiceMetadataBehavior))
            {
                var metadata = new ServiceMetadataBehavior();
                metadata.HttpGetEnabled = true;
                metadata.HttpsGetEnabled = true;

                serviceHost.Description.Behaviors.Add(metadata);
            }
            else
            {
                foreach (var b in serviceHost.Description.Behaviors)
                {
                    if (b is ServiceMetadataBehavior)
                    {
                        ((ServiceMetadataBehavior)b).HttpsGetEnabled = true;
                        ((ServiceMetadataBehavior)b).HttpGetEnabled = true;
                    }
                }
            }
        }
    }
}

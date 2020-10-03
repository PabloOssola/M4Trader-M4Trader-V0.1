using M4Trader.ordenes.server.ApplicationServices;
using Mae.Ordenes.Framework;
using System.Collections.Generic;

namespace M4Trader.ordenes.api.Helpers
{
    public static class HelperInitializeServices
    {
        public static void Inicializar(bool withWS)
        {
            List<IApplicationServiceStarter> services = new List<IApplicationServiceStarter>();
            //services.Add(new LoggingServiceStarter(new ApiLoggingConfiguration()));
            services.Add(new EventHelperServiceStarter()); 
            services.Add(new NotificacionesServiceStarter());
            //if (withWS)
            //{
            //    services.Add(new WSServicesConfiguration());
            //}
            OrdenesApplication.StartApplication(services, RolesIngresoAplicacion.API, new AESEncryptor(), new SodiumEncryptor());
            OrdenesApplication.Instance.StartAllServices();
        }
    }
}
using M4Trader.ordenes.api.Helpers;
using System;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Routing;

namespace M4Trader.ordenes.api
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        { 
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
               (object sen, X509Certificate cert, X509Chain chain, SslPolicyErrors sslPolicyErrors) =>
               {
                   string dominioValido = "";// ConfigurationManager.AppSettings["dominioValido"];
                   return cert.Subject.ToLower().Contains(dominioValido) || ((System.Net.HttpWebRequest)(sen)).Address.DnsSafeHost.ToLower().Contains(dominioValido);
               };

            string path = Environment.GetEnvironmentVariable("PATH");
            string binDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin");
            Environment.SetEnvironmentVariable("PATH", path + ";" + binDir);

            IniciarAplicacion();

            //RouteTable.Routes.MapHubs("~/Hubs", new Microsoft.AspNet.SignalR.HubConfiguration() { EnableJSONP = true });
        }

        private void IniciarAplicacion()
        {
            //LT..Instance.Init();
            HelperInitializeServices.Inicializar(false);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE, GET, OPTIONS");

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept,SecurityTokenId, Agencia, X-Requested-With");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
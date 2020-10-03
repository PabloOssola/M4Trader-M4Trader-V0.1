using M4Trader.ordenes.server.Caching;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;

namespace MAE.Clearing.BusinessComponentLayer.Helpers
{

    public static class Utils
    {

        public static string GetIpAddress()
        {
            string ip = null;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var item in host.AddressList)
            {
                if (item.AddressFamily != AddressFamily.InterNetworkV6)
                {
                    ip = item.ToString();
                    break;
                }

            }
            return ip;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static void EnviarMail(string from, string To, string subject, string body) 
        {

            var fromAddress = new MailAddress(from, "From Name");
            var toAddress = new MailAddress(To, "To Name");
            string fromPassword = CachingManager.Instance.GetConfiguracionSeguridad().ContraseniaCasilla;

            var smtp = new SmtpClient
            {
                Host = CachingManager.Instance.GetConfiguracionSeguridad().HostSmtp,
                Port = CachingManager.Instance.GetConfiguracionSeguridad().PortSmtp.Value,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

    }
}

using System.Net;
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

    }
}

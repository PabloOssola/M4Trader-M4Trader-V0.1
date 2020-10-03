using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace M4Trader.TwoFAGateway.VU.NetFramework
{
    public enum DeployMechanism
    {
        sendQROffMail
    }

    public partial class TwoFAGateway_VU 
    {
        private readonly Uri environment;

        private HttpWebRequest createRequest(string nombreAccion)
        {
            var actionUri = new Uri(environment, $"{nombreAccion}.php");

            var request = (HttpWebRequest)HttpWebRequest.Create(actionUri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            return request;
        }

        private static string cargarParametros(Dictionary<string, string> valores)
        {
            string postData = string.Empty;

            foreach (string key in valores.Keys)
            {
                postData += string.Format($"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(valores[key])}&");
            }
            postData.TrimEnd('&');
            return postData;
        }

        private static (string, string) leerResponse(HttpWebRequest request, string postData)
        {
            using (var bodyStream = request.GetRequestStream())
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                bodyStream.Write(byteArray, 0, byteArray.Length);
                bodyStream.Flush();
                bodyStream.Close();
            }

            var response = request.GetResponse();

            using (var bodyStream = response.GetResponseStream())
            {
                var readStream = (TextReader)new StreamReader(bodyStream, Encoding.UTF8);
                var result = readStream.ReadLine();

                readStream.Close();

                var resultParts = result.Split(':');
                var resultCode = resultParts[0].Trim();
                var resultText = resultParts[1].Trim();

                if ("201" != resultCode)
                {
                    throw new TwoFAGatewayException(resultCode, resultText);
                }

                return (resultCode, resultText);

            }
        }
    }
}

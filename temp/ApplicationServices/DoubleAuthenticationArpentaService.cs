using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class DoubleAuthenticationArpentaService : IDoubleAuthenticationService
    {
        private Dictionary<Guid, ResponseDoubleAuthentication> tokens = new Dictionary<Guid, ResponseDoubleAuthentication>();

        public ResponseDoubleAuthentication GetToken(Guid tokenGuid, string telefono, string url)
        {
            ResponseDoubleAuthentication response = new ResponseDoubleAuthentication();
            try
            {
                if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(telefono))
                {
                    response.IsOk = false;
                    response.Id = "";
                    response.Error = "url or params are required";
                    //tokens.Add(tokenGuid, response);

                    return response;
                }

                if (ValidaTelefono(telefono))
                {
                    string html = string.Empty;
                    string urlDestino = url + telefono;

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@urlDestino);
                    using (var webResponse = (HttpWebResponse)request.GetResponse())

                    using (Stream stream = webResponse.GetResponseStream())

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
                    response = JsonConvert.DeserializeObject<ResponseDoubleAuthentication>(html);
                    response.IsOk = true;
                }
                else
                {
                    response.IsOk = false;
                    response.Id = telefono;
                    response.Error = "Bad Format Telephone";
                }
            }
            catch (UriFormatException ex)
            {
                response.Id = telefono;
                response.IsOk = false;
                response.Error = ex.Message;
            }
            catch (WebException ex)
            {
                HttpWebResponse errorResponse = (HttpWebResponse)ex.Response;
                response.Id = telefono;
                response.IsOk = false;
                response.Error = errorResponse.StatusDescription;
            }
            catch (Exception ex)
            {
                response.Id = telefono;
                response.IsOk = false;
                response.Error = ex.Message;
            }

            
            tokens.Add(tokenGuid, response);

            return response;
        }


        private bool ValidaTelefono(string telefono)
        {
            bool response = false;

            response = (telefono.Length == 10);

            return response;
        }

        public bool ValidateToken(Guid tokenGuid, string username, string tokenInput)
        {
            if (tokens.ContainsKey(tokenGuid))
            {
                return tokens[tokenGuid].Code == tokenInput;
            }

            return false;
        }
    }
}

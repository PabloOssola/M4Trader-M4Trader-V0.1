using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class DoubleAuthenticationDummyService : IDoubleAuthenticationService
    {
        private Dictionary<Guid, ResponseDoubleAuthentication> tokens = new Dictionary<Guid, ResponseDoubleAuthentication>();

        public ResponseDoubleAuthentication GetToken(Guid tokenGuid, string telefono, string url)
        {
            ResponseDoubleAuthentication response = new ResponseDoubleAuthentication();
            try
            {
                response.Code = "qwerty";
                response.Error = null;
                response.Id = telefono;
                response.IsOk = true;
            }
            catch (UriFormatException ex)
            {
                response.Id = telefono;
                response.IsOk = false;
                response.Error = ex.Message;
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
      

        public bool ValidateToken(Guid tokenGuid, string username, string token)
        {
            ResponseDoubleAuthentication value;
            tokens.TryGetValue(tokenGuid, out value);
            return value.Code == token;
        }
    }
}
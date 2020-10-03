using Mae.TwoFAGateway.VU.NetFramework;
using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class DoubleAuthenticationVUService : IDoubleAuthenticationService
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

        public bool ValidateToken(Guid guid, string username, string token)
        {
            try
            {
                const string URL = @"https://vuas5.cloud.vusecurity.com/vuserver/connector/tokens/totp/";
                var gatewayVU = new TwoFAGateway_VU(new Uri(URL));

                if (gatewayVU.validarOTP(idUsuario: username, cupon: token))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (BlockedFactorException)
            {
                // OTP bloqueado por re-intentos, debe desbloquaer para continuar
                return false;
            }
          
        }
    }
}
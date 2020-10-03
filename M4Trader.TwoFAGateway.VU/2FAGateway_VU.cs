using System;
using System.Collections.Generic;
using System.Net;

namespace M4Trader.TwoFAGateway.VU.NetFramework
{
    public partial class TwoFAGateway_VU : I2FAGateway
    {
        public TwoFAGateway_VU(Uri environment)
        {
            this.environment = environment;
        }

        public void desbloquearUsuario(string idUsuario)
        {
            HttpWebRequest request = createRequest("unlock");

            var valores = new Dictionary<string, string>();
            valores.Add("username", idUsuario);

            var postData = cargarParametros(valores);

            leerResponse(request, postData);
        }

        public void registrarUsuario(string idUsuario, string correo, string passcode)
        {
            HttpWebRequest request = createRequest("registration");

            var valores = new Dictionary<string, string>();
            valores.Add("username", idUsuario);
            valores.Add("email", correo);
            valores.Add("passcode", passcode);
            valores.Add("deploymentMechanism", nameof(DeployMechanism.sendQROffMail));
            var postData = cargarParametros(valores);
            leerResponse(request, postData);

        }

        public bool validarOTP(string idUsuario, string cupon)
        {
            HttpWebRequest request = createRequest("login");

            var valores = new Dictionary<string, string>();
            valores.Add("username", idUsuario);
            valores.Add("otp", cupon);

            var postData = cargarParametros(valores);

            var (resultCode, resultText) = leerResponse(request, postData);

            switch(resultCode)
            {
                case "201":
                    return true;
                case "952":
                    return false;
                case "503":
                    throw new BlockedFactorException(resultCode, resultText);
                default:
                    throw new TwoFAGatewayException(resultCode, resultText);
            }
        }

        public void eliminarUsuario(string idUsuario)
        {
            HttpWebRequest request = createRequest("delete");

            var valores = new Dictionary<string, string>();
            valores.Add("username", idUsuario);

            var postData = cargarParametros(valores);

            leerResponse(request, postData);
        }
    }
}

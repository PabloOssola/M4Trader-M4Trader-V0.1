using M4Trader.TwoFAGateway.VU.NetFramework;

namespace M4Trader.TwoFAGateway
{
    public class TwoFAGatewayMock : I2FAGateway
    {
        public bool CuponValido { get; set; }
        public bool ErrorDesbloqueo { get; set; }
        public bool ErrorRegistrar { get; set; }
        public bool ErrorEliminar { get; set; }

        public TwoFAGatewayMock()
        {
        }

        public void registrarUsuario(string idUsuario, string correo, string passcode)
        {
            if(ErrorRegistrar)
            {
                throw new TwoFAGatewayException("-1", "error al registrar (mock)");
            }
        }

        public bool validarOTP(string idUsuario, string cupon)
        {
            return CuponValido; 
        }

        public void desbloquearUsuario(string idUsuario)
        {
            if (ErrorDesbloqueo)
            {
                throw new TwoFAGatewayException("-1", "error al desbloquear (mock)");
            }
        }

        public void eliminarUsuario(string idUsuario)
        {
            if (ErrorEliminar)
            {
                throw new TwoFAGatewayException("-1", "error al eliminar (mock)");
            }
        }
    }
}

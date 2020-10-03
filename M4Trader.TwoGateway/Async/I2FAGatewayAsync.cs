using System.Threading.Tasks;

namespace M4Trader.TwoFAGateway
{
    public interface I2FAGatewayAsync
    {
        Task registrarUsuarioAsync(string idUsuario, string correo, string passcode);
        bool validarOTPAsync(string cupon);
        void desbloquearUsuarioAsync(string idUsuario);
    }
}

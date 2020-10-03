namespace M4Trader.TwoFAGateway
{
    public interface I2FAGateway
    {
        void registrarUsuario(string idUsuario, string correo, string passcode);
        bool validarOTP(string idUsuario, string cupon);
        void desbloquearUsuario(string idUsuario);
        void eliminarUsuario(string idUsuario);
    }
}

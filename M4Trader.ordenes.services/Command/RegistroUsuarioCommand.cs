namespace M4Trader.ordenes.services.Command
{
    public class RegistroUsuarioCommand
    {
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RolesUsuario { get; set; }
    }
}
namespace M4Trader.ordenes.services.Command
{
    public class ChangePasswordCommand
    {
        public string UserName { get; set; }
        
        public string PasswordAnterior { get; set; }
        public string PasswordNueva { get; set; }
        public string NuevaVerificacion { get; set; }
    }
}
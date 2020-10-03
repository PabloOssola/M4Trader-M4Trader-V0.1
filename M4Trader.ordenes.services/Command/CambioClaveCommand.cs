namespace M4Trader.ordenes.services.Command
{
    public class CambioClaveCommand
    {
        public int IdUsuario { get; set; } 
        public string Newpassword { get; set; } 
        public string ConfirmPassword { get; set; } 
        public string PreviousPass { get; set; } 
        public string UltimaActualizacion { get; set; }
    }
}
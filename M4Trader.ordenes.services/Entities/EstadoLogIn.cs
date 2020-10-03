namespace M4Trader.ordenes.services.Entities
{
    public class EstadoLogIn
    {
        public string Codigo
        {
            get;
            set;
        }

        public TipoEstado TipoEstado
        {
            get;
            set;
        }

        public string Descripcion
        {
            get;
            set;
        }
    }

    public enum TipoEstado
    {
        INFORMATION = 1,
        WARNING = 2,
        ERROR = 3
    }
}
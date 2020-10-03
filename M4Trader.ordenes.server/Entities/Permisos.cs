namespace M4Trader.ordenes.server.Entities
{
    public enum TipoAutorizacion
    {
        SIN_PERMISOS = 0,
        CON_PERMISOS,
        CON_DOBLE_CONTROL
    }

    public class AutorizationType
    {
        public TipoAutorizacion tipoAutorizacion
        {
            get;
            set;
        }
    }

    public class Permiso
    {
        protected bool _administrasistema;

        public int IdUsuario
        {
            get;
            set;
        }

        public short IdAccion
        {
            get;
            set;
        }

        public int Permisos
        {
            get;
            set;
        }
    }
}

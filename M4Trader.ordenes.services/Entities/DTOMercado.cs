namespace M4Trader.ordenes.services.Entities
{
    public class DTOMercado
    {
        public byte IdMercado { get; set; }
        
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public bool EsInterno { get; set; }

        public bool ProductoHabilitadoDefecto { get; set; }
    }
}
 

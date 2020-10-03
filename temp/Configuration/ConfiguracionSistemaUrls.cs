using M4Trader.ordenes.server.Helpers;

namespace M4Trader.ordenes.server.Configuration
{
    public class ConfiguracionSistemaUrls
    {
        public byte IdConfiguracionSistemaUrls { get; set; }
        public short IdConfiguracionSistema { get; set; }
        public string Password { get; set; }
        public string Usuario { get; set; }
        public ConfiguracionSistemaURLsEnumDestino TipoUrl { get; set; }
        public string Url { get; set; }
        public string Parametros { get; set; }
    }
}

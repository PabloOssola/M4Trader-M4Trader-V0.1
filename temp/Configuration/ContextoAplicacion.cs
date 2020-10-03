using System.Collections.Generic;

namespace M4Trader.ordenes.server.Configuration
{
    public class ContextoAplicacion
    {
        public byte IdConfiguracionSistema { get; set; }
        public bool OcultarErroresBaseDeDatos { get; set; }
        public string PathSalida { get; set; }
        public int TiempoLogSQL { get; set; }
        public bool PermiteProcesamientoParalelo { get; set; }
        public bool EnviaNotificaciones { get; set; }
        public string AbsoluteServicesURL { get; set; }
        public bool EnviarAgentCode { get; set; }
        public int ApiServicePort { get; set; }
        public string JwtSecretKey { get; set; }
        public string JwtAudienceToken { get; set; }
        public string JwtIssuerToken { get; set; }
        public byte MaxOperationRows { get; set; }
        public byte MinOperationRows { get; set; }
        public string PathDirectorioVirtual { get; internal set; }

        public List<ConfiguracionSistemaUrls> Urls { get; set; }
    }
}

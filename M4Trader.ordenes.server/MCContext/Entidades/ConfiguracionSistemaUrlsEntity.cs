using M4Trader.ordenes.server.MCContext.ContextAudit.Configuracion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("ConfiguracionSistemaUrls", Schema = "orden_owner")]
    public class ConfiguracionSistemaUrlsEntity : IUnTrackable
    {
        [Key]
        public byte IdConfiguracionSistemaUrls { get; set; }

        [ForeignKey("ConfiguracionSistema")] 
        public byte IdConfiguracionSistema { get; set; } 

        public string Url { get; set; }

        public string TipoUrl { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public string Parametros { get; set; }

    }
}


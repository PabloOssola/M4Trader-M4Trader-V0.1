using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.ConfiguracionSistema)]
    [Table("ConfiguracionSistema", Schema = "shared_owner")]
    public class ConfiguracionSistemaEntity
    {
        public ConfiguracionSistemaEntity()
        {
            ConfiguracionSistemaUrls = new List<ConfiguracionSistemaUrlsEntity>();
        }

        [Key]//[DatabaseGenerated(DatabaseGeneratedOption.Computed)] 
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
        public virtual ICollection<ConfiguracionSistemaUrlsEntity> ConfiguracionSistemaUrls { get; set; }
    }
}
 

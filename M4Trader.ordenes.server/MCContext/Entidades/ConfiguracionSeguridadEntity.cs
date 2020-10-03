using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.ConfiguracionSeguridad)]
    [Table("ConfiguracionSeguridad", Schema = "shared_owner")]
    public class ConfiguracionSeguridadEntity
    {
        
        [Key]
        public byte IdConfiguracionSeguridad { get; set; }

        [Column("TimeOutInicialSesion")]
        public int TimeOutInicialSesion { get; set; }

        [Column("TimeOutExtensionSesion")]
        public int TimeOutExtensionSesion { get; set; }

        [Column("CantidadIntentosMaximo")]
        public byte CantidadIntentosMaximo { get; set; }

        [Column("MaximoDiasInactividad")]
        public byte MaximoDiasInactividad { get; set; }

        [Column("DiasCambioPassword")]
        public byte DiasCambioPassword { get; set; }

        [Column("CantidadPasswordsHistoricas")]
        public byte CantidadPasswordsHistoricas { get; set; }

        [Column("ConsideraMinimoLargoPassword")]
        public bool ConsideraMinimoLargoPassword { get; set; }

        [Column("CantidadMinimoLargoPassword")]
        public byte CantidadMinimoLargoPassword { get; set; }

        [Column("ConsideraCantidadCaracteres")]
        public bool ConsideraCantidadCaracteres { get; set; }

        [Column("CantidadAlfabeticosPassword")]
        public byte CantidadAlfabeticosPassword { get; set; }

        [Column("CantidadNumericosPassword")]
        public byte CantidadNumericosPassword { get; set; }

        [Column("CantidadMinusculasPassword")]
        public byte CantidadMinusculasPassword { get; set; }

        [Column("CantidadSimbolosPassword")]
        public byte CantidadSimbolosPassword { get; set; }

        [Column("ConsideraMaximaCantCaracteresConsecutivos")]
        public bool ConsideraMaximaCantCaracteresConsecutivos { get; set; }

        [Column("CantidadMaximaCaracteresConsecutivos")]
        public byte CantidadMaximaCaracteresConsecutivos { get; set; }
        [Column("CantidadMayusculasPassword")]
        public byte CantidadMayusculasPassword { get; set; }
        [Column("DobleAutenticacion")]
        public string DobleAutenticacion { get; set; }
        [Column("ContraseniaCasilla")]
        public string ContraseniaCasilla { get; set; }
        [Column("HostSmtp")]
        public string HostSmtp { get; set; }
        [Column("PortSmtp")]
        public int? PortSmtp { get; set; }
        [Column("PermiteEnviarMail")]
        public bool PermiteEnviarMail { get; set; }
        [NotMapped]
        [SkipTracking]
        public bool TieneDobleFactor { get { return !string.IsNullOrEmpty(DobleAutenticacion); } }
    }
}


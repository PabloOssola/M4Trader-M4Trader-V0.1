using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.Sesiones)]
    [Table("Sesiones", Schema = "shared_owner")]
    public class SesionEntity
    {
        [Key]
        public Guid IdSesion { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("Ip")]
        public string Ip { get; set; }

        [Column("FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [Column("FechaFinalizacion")]
        public DateTime FechaFinalizacion { get; set; }

        [Column("BajaLogica")]
        public bool BajaLogica { get; set; }

        [Column("UltimaActualizacion")]
        [Timestamp]
        public byte[] UltimaActualizacion { get; set; }

        [Column("IdAplicacion")]
        public byte IdAplicacion { get; set; }

        [Column("idPersona")]
        public int IdPersona { get; set; }

        [SkipTracking]
        [NotMapped]
        public bool modifiedOrNew { get; set; }


        [SkipTracking]
        [NotMapped]
        public MAEUserSession MaeUserSession { get; set; }

        [SkipTracking]
        [NotMapped]
        public string Global { get; set; }

        [SkipTracking]
        [NotMapped]
        public string PrivateKey { get; set; }

        [SkipTracking]
        [NotMapped]
        public string PublicKey { get; set; }

        [SkipTracking]
        [NotMapped]
        public bool FinalizadaPorLogout { get; set; }

        [Column("ClientSecret")]
        public string ClientSecret { get; set; }

        [Column("ClientPublic")]
        public string ClientPublic { get; set; }

        [Column("ServerSecret")]
        public string ServerSecret { get; set; }

        [Column("ServerPublic")]
        public string ServerPublic { get; set; }
        [Column("Nonce")]
        public string Nonce { get; set; }
        [Column("jsAllowedCommands")]
        public string jsAllowedCommands { get; set; }
        [Column("jsPermisosUsuario")]
        public string jsPermisosUsuario { get; set; }
        [Column("ConfiguracionRegional")]
        public string ConfiguracionRegional { get; internal set; }
        [NotMapped]
        public Dictionary<string, string> JavascriptAllowedCommands { get; set; }
        [NotMapped]
        public Dictionary<string, bool> PermisosUsuario { get; set; }        
        [NotMapped]
        public Dictionary<string, Type> AllowedCommands { get; set; }
    }
}

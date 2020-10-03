using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.Usuarios)]
    [Table("Usuarios", Schema = "shared_owner")]
    public class UsuarioEntity
    {
        public UsuarioEntity()
        {
            RolUsuarioItems = new List<RolUsuarioEntity>();
        }

        [Key]
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("Pass")]
        public string Pass { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Expiracion")]
        public DateTime? Expiracion { get; set; }
        
        public DateTime? FechaBaja { get; set; }

        [Column("CantidadIntentos")]
        public int? CantidadIntentos { get; set; }

        [Column("Bloqueado")]
        public bool Bloqueado { get; set; }

        [Column("Proceso")]
        public bool Proceso { get; set; }
        
        public bool BajaLogica { get; set; }

        [Column("ResetPassword")]
        public bool ResetPassword { get; set; }

        [Timestamp]
        public byte[] UltimaActualizacion { get; set; }

        [Column("UltimaModificacionPassword")]
        public DateTime? UltimaModificacionPassword { get; set; }

        [Column("UltimoLoginExitoso")]
        public DateTime? UltimoLoginExitoso { get; set; }

        [Column("NoControlarInactividad")]
        public bool NoControlarInactividad { get; set; }

        [ForeignKey("Parties")]
        [Column("IdPersona")]
        public int? IdPersona { get; set; }

        [Column("LoginRealizado")]
        public bool LoginRealizado { get; set; }

        [Column("FechaReactivacion")]
        public DateTime? FechaReactivacion { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("ConfiguracionRegional")]
        public string ConfiguracionRegional { get; set; }
        public virtual ICollection<RolUsuarioEntity> RolUsuarioItems { get; set; }

        public virtual UsuariosLimitesEntity Limites { get; set; }

        public virtual ICollection<PortfolioUsuarioEntity> Portfolio { get; set; }

        [NotMapped]
        public string Agencia { get; set; }
    }
}


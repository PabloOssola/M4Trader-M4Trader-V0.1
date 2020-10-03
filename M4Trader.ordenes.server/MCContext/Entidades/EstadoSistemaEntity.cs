using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.EstadoSistema)]
    [Table("EstadoSistema", Schema = "shared_owner")]
    public class EstadoSistemaEntity
    {
        [Key]//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("IdEstadoSistema")]
        public int IdEstadoSistema { get; set; }

        [Column("FechaApertura")]
        public DateTime FechaApertura { get; set; }

        [Column("FechaCierre")]
        public DateTime? FechaCierre { get; set; }

        [Column("FechaSistema")]
        public DateTime FechaSistema { get; set; }

        [Column("IdUsuarioApertura")]
        public int IdUsuarioApertura { get; set; }

        [Column("IdUsuarioCierre")]
        public int? IdUsuarioCierre { get; set; }

        [Column("BajaLogica")]
        public bool BajaLogica { get; set; }

        [Timestamp]
        public byte[] UltimaActualizacion { get; set; }

        public bool EstadoAbierto { get; set; }

        public bool EjecucionValidacion { get; set; }

    }

    public enum TipoEstadoActualSistema
    {
        /// <summary>
        /// 
        /// </summary>
        NONE_TIPOESTADOACTUALSISTEMA = 0,
        /// <summary>
        /// Sistema actulamente abierto
        /// </summary>
        ABIERTO = 1,
        /// <summary>
        /// Sistema actualmente cerrado
        /// </summary>
        CERRADO = 2
    }
    /// <summary>
    /// 
    /// </summary>
    public enum TipoEstadoSistema
    {
        /// <summary>
        /// Ultimo estado del sistema
        /// </summary>
        ULTIMO = 0,
        /// <summary>
        /// Ultimo estado del sistema abierto
        /// </summary>
        ULTIMO_ABIERTO = 1,
        /// <summary>
        /// Ultimo estado del sistema cerrado
        /// </summary>
        ULTIMO_CERRADO = 2
    }
}

using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.Accion)]
    [Table("EstadoOrden", Schema = "orden_owner")]
    public class EstadosOrdenEntity
    {
        [Key]//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("IdEstadoOrden")]
        public int IdEstadoOrden { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

    }
}

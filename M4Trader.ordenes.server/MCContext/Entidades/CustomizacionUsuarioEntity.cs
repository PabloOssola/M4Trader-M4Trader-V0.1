using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.CustomizacionUsuario)]
    [Table("CustomizacionUsuario", Schema = "shared_owner")]
    public class CustomizacionUsuarioEntity
    {
        [Key]//[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("IdCustomizacionUsuario")]
        public int IdCustomizacionUsuario { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("Codigo")]
        public string Codigo { get; set; }

        [Column("Valor")]
        public string Valor { get; set; }


    }
}
 

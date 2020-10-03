using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("UsuariosAdministradorParties", Schema = "shared_owner")]
    public class UsuariosAdminitradorPartiesEntity
    {
        [Key]
        [Column("IdAdministradorParty")]
        public int IdAdministradorParty { get; set; }

        [ForeignKey("Parties")]
        [Column("IdAdministrador")]
        public int IdAdministrador { get; set; }

        [ForeignKey("Parties")]
        [Column("IdParty")]
        public int IdParty { get; set; }
    }
}


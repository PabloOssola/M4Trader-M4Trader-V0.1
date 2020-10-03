using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("PartiesHierarchy", Schema = "shared_owner")]
    public class PartyHierarchyEntity
    {
        [Key]
        [Column("IdPartiesHierarchy")]
        public int IdPartyHierarchy { get; set; }

        [ForeignKey("Parties")]
        [Column("IdPartyFather")]
        public int IdPartyFather { get; set; }

        [ForeignKey("Parties")]
        [Column("IdPartySon")]
        public int IdPartyHijo { get; set; } 

        public PartyEntity Party { get; set; }
    }
}


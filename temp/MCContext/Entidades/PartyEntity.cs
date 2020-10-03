using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [TrackChanges(AuditoriaClase.Personas)]
    [Table("Parties", Schema = "shared_owner")]
    public class PartyEntity
    {
        public PartyEntity()
        {
            PartyItems = new List<PartyHierarchyEntity>();
        }

        [Key]
        [Column("IdParty")]
        public int IdParty { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public string MarketCustomerNumber { get; set; }
        [Column("PartyType")]
        public byte IdPartyType { get; set; }
        public byte IdLegalPersonality { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string Phone { get; set; }
        public bool BajaLogica { get; set; }
        public string AgentCode { get; set; }
        public virtual ICollection<PartyHierarchyEntity> PartyItems { get; set; }
    }
}
 

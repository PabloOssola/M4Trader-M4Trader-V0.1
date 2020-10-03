using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public abstract class PersonaCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        abstract public override object ExecuteCommand(InCourseRequest inCourseRequest);

        abstract public override void Validate();

        
        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        protected List<int> GetParents(string Parents)
        {
            List<int> col = new List<int>();
            if (!string.IsNullOrEmpty(Parents))
            {
                foreach (var parent in Parents.Split(','))
                {
                    col.Add(int.Parse(parent));
                }
            }
            return col;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Personas;
            }
        }

        [DataMember]
        public int r_id { get; set; }

        [DataMember]
        public byte IdPartyType { get; set; }

        [DataMember]
        public string MarketCustomerNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string DocumentNumber { get; set; }

        [DataMember]
        public byte IdLegalPersonality { get; set; }

        [DataMember]
        public string TaxIdentificationNumber { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Parties { get; set; }

        public string Message { get; set; }
    }
}
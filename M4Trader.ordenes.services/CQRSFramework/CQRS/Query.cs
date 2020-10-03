using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.CQRSFramework.CQRS
{
    public enum QueryType
    {
        Grid,
        Combos,
        Data,
        FullRecord,
        FullByEntity,
        Message
    }


    [DataContract]
    public class Query
    {
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public string Message
        {
            get;
            set;
        }

        [DataMember]
        public List<Parameter> Filters
        {
            get;
            set;
        }

        [DataMember]
        public string Type
        {
            get;
            set;
        }

        [DataMember]
        public List<Parameter> Options
        {
            get;
            set;
        }

        [DataMember]
        public Notificacion Data { get; set; }

        [DataMember]
        public bool IsMobile { get; set; } = false;

        [DataMember]
        public string SecurityTokenId { get; set; }
    }

    [DataContract]
    public class Parameter
    {
        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public object Value { get; set; }
    }
}

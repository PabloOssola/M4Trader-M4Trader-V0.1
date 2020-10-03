using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.CQRSFramework.CQRS
{
    [DataContract]
    public class QueryPagingResult : QueryResult
    {
        [DataMember]
        public int draw { get; set; }

        [DataMember]
        public int recordsTotal { get; set; }

        [DataMember]
        public int recordsFiltered { get; set; }

    }
}

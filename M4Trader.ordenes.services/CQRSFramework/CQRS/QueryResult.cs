using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.CQRSFramework.CQRS
{
    [DataContract]
    public class QueryResult
    {

        [DataMember]
        public object[] Data
        {
            get;
            set;
        }

        [DataMember]
        public string[] ColumnNames
        {
            get;
            set;
        }

        [DataMember]
        public IDictionary<string, object> MetaData
        {
            get;
            set;
        }

        [DataMember]
        public string Status
        {
            get;
            set;
        }

        [DataMember]
        public Guid RequestId
        {
            get;
            set;
        }
    }

}

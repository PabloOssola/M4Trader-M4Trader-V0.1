using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.services.Entities
{
    public class Responsechart
    {
        public string Response
        {
            get; set;
        }

        public int Type
        {
            get
            { return 100; }
        }

        public bool Aggregated
        {
            get { return false; }
        }

        public List<Data> Data { get; set; }
        public long TimeTo { get; set; }
        public long TimeFrom { get; set; }
        public bool FirstValueInArray { get { return true; } }
        public ConversionType ConversionType { get; set; }

        public RateLimit RateLimit
        {
            get; set;
        }
        public bool HasWarning
        {
            get { return false; }
        }
    }

    public class RateLimit { }
    public class ConversionType
    {
        public string type { get { return "force_direct"; } }
        public string conversionSymbol { get { return ""; } }
    }

    public class Data
    {
        public long time { get; set; }
        public decimal? close { get; set; }
        public decimal? high { get; set; }
        public decimal? low { get; set; }
        public decimal? open { get; set; }
        public decimal volumefrom { get; set; }
        public decimal volumeto { get; set; }
    }
}

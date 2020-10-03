using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.services.Entities
{


    public class DTOMessage
    {
        public int IdUser { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public DateTime Date { get; set; }
    }
}

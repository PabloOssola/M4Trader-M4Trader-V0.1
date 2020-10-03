using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M4TraderWebApp.Entities
{
    public class DTONewMessage
    {
        public int IdUser { get; set; }
        public string Message { get; set; }
        public string Type{ get; set; }
        public string SubType { get; set; }
        public DateTime Date { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.services.Entities.ComplementoDMA
{
    public class SendTokenRequestDto
    {
        /// <summary>
        /// Username of logged user
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// IP of the user's application
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// GuidToken associated to logged user
        /// </summary>
        public Guid GuidToken { get; set; }
    }

}

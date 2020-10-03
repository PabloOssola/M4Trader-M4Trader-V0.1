using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// Dto for user login
    /// </summary>
    public class M4Trader
    {
        /// <summary>
        ///  User
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
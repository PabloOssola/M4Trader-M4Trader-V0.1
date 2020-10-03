using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// TickerDto
    /// </summary>
    public class TickerDto
    {
        /// <summary>
        /// Ticker
        /// </summary>
        public string Ticker { get; set; }

        public string Currency { get; set; }
    }
}
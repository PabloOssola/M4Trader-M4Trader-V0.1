using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// MarketDataStatusDto
    /// </summary>
    public class UpdateMarketDataResponseDto
    {
        /// <summary>
        /// Response
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Information
        /// </summary>
        public string Information { get; set; }
    }
}
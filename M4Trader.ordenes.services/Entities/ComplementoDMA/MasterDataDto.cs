using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// MasterDataDto
    /// </summary>
    public class MasterDataDto
    {
        /// <summary>
        /// Tickers
        /// </summary>
        public List<TickerDto> Tickers { get; set; }
        /// <summary>
        /// SettlementTypes
        /// </summary>
        public List<string> SettlementTypes { get; set; }
        /// <summary>
        /// Currency
        /// </summary>
        public List<string> Currency { get; set; }
    }
}
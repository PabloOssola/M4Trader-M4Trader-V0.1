using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// MarketDataDto
    /// </summary>
    public class UpdateMarketDataDto
    {
        /// <summary>
        /// Price
        /// </summary>
        public string Ticker { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// PercentageVar
        /// </summary>
        public decimal PercentageVar { get; set; }
        /// <summary>
        /// APrice
        /// </summary>
        public decimal APrice { get; set; }
        /// <summary>
        /// BestPurchaseAmount
        /// </summary>
        public decimal BestPurchaseAmount { get; set; }
        /// <summary>
        /// BestPurchasePrice
        /// </summary>
        public decimal BestPurchasePrice { get; set; }
        /// <summary>
        /// BestSaleAmount
        /// </summary>
        public decimal BestSaleAmount { get; set; }
        /// <summary>
        /// BestSalePrice
        /// </summary>
        public decimal BestSalePrice { get; set; }
    }
}
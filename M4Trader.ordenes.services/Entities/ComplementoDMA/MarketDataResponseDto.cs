using System.Collections.Generic;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// MarketDataResponseDto
    /// </summary>
    public class MarketDataResponseDto
    {
        /// <summary>
        /// Ticker
        /// </summary>
        public string Ticker { get; set; }
        /// <summary>
        /// Plazo
        /// </summary>
        public string Plazo { get; set; }
        /// <summary>
        /// Moneda
        /// </summary>
        public string Moneda { get; set; }
        /// <summary>
        /// ClosingPrice
        /// </summary>
        public decimal ClosingPrice { get; set; }
        /// <summary>
        /// OpeningPrice
        /// </summary>
        public decimal OpeningPrice { get; set; }
        /// <summary>
        /// TradingHighPrice
        /// </summary>
        public decimal TradingHighPrice { get; set; }
        /// <summary>
        /// TradingLowPrice
        /// </summary>
        public decimal TradingLowPrice { get; set; }
        /// <summary>
        /// TradeVolume
        /// </summary>
        public decimal TradeVolume { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Offers
        /// </summary>
        public List<OfferDto> Offers { get; set; }
        /// <summary>
        /// EquivalentRate
        /// </summary>
        public decimal EquivalentRate { get; set; }
    }
}
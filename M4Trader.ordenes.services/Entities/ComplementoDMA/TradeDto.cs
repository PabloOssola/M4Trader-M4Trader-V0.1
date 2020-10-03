using System;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// Dto for Trade
    /// </summary>
    public class TradeDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Row
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// Ticker
        /// </summary>
        public string Ticker { get; set; }
        /// <summary>
        /// SettementType
        /// </summary>
        public string SettementType { get; set; }
        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// UnitPrice
        /// </summary>
        public float UnitPrice { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Total
        /// </summary>
        public float Total { get; set; }
        /// <summary>
        /// Side
        /// </summary>
        public string Side { get; set; }
        /// <summary>
        /// Action
        /// </summary>
        public int Action { get; set; }

        public int? NroOrdenInterno { get; set; }

        public string Timestamp { get; set; }
    }
}
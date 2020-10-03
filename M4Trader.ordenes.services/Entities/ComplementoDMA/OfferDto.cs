namespace M4Trader.ordenes.services.Entities
{
    public class OfferDto
    {
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// BuySell
        /// </summary>
        public string BuySell { get; set; }
        /// <summary>
        /// NroPosition
        /// </summary>
        public byte NroPosition { get; set; }
        /// <summary>
        /// SpotRate
        /// </summary>
        public decimal? SpotRate { get; set; }
        /// <summary>
        /// NroOffers
        /// </summary>
        public int NroOffers { get; set; }
    }
}
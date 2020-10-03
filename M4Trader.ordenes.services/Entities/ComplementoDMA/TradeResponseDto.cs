namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// TradeResponseDto
    /// </summary>
    public class TradeResponseDto
    {
        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// OrdenNumber
        /// </summary>
        public string OrdenNumber { get; set; }
        /// <summary>
        /// OperationNumber
        /// </summary>
        public string OperationNumber { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// Trade
        /// </summary>
        public TradeDto Trade { get; set; }
        /// <summary>
        /// Success
        /// </summary>
        /// 
        public int NroOrdenInterno { get; set; }
        public bool Success { get; set; }
        public string Timestamp { get; set; } 
    }

    /// <summary>
    /// Order status
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Sent
        /// </summary>
        Sent,
        /// <summary>
        /// Accepted
        /// </summary>
        Accepted,
        /// <summary>
        /// Rejected
        /// </summary>
        Rejected,
        /// <summary>
        /// ExecutedPartial
        /// </summary>
        ExecutedPartial,
        /// <summary>
        /// Executed
        /// </summary>
        Executed
    }

    /// <summary>
    /// Action
    /// </summary>
    public enum Action
    {
        /// <summary>
        /// Sent
        /// </summary>
        Sent,
        /// <summary>
        /// Cancel
        /// </summary>
        Cancel
    }
}
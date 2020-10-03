namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// Dto for Operation Status
    /// </summary>
    public class OperationStatusDto
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
        /// Success
        /// </summary>
        public bool Success { get; set; }

        public int NroOrdenInterno { get; set; }
        public string Timestamp { get; set; }
    }
}
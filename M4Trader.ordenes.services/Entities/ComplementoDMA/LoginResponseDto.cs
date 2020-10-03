using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// LoginResponseDto
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// Successful
        /// </summary>
        public bool Successful { get; set; }
        /// <summary>
        /// Information
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// ApiToken
        /// </summary>
        public string ApiToken { get; set; }
        /// <summary>
        /// MAEToken
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// MinOperations
        /// </summary>
        public int MinOperations { get; set; }
        /// <summary>
        /// MaxOperations
        /// </summary>
        public int MaxOperations { get; set; }
        /// <summary>
        /// RequiredSecondFactor
        /// </summary>
        public bool RequiredSecondFactor { get; set; }
        /// <summary>
        /// TotalMultiplier
        /// </summary>
        public int TotalMultiplier { get; set; }
        
        public string Username { get; set; }
        public string NombreAliq { get; set; }
        public Guid? TokenGuid { get; set; }

    }
}
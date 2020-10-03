using System;
using Newtonsoft.Json;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// LoginMaeResponseDto
    /// </summary>
    public class LoginMaeResponseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Data")]
        public virtual LoginMaeDataDto Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("MetaData")]
        public virtual string MetaData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("RequestId")]
        public virtual Guid? RequestId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Status")]
        public virtual string Status { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginMaeResponseDto()
        {
            Data = new LoginMaeDataDto();
        }
    }
}
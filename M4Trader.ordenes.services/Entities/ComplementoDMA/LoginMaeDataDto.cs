using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace M4Trader.ordenes.services.Entities
{
    /// <summary>
    /// LoginMaeDataDto
    /// </summary>
    public class LoginMaeDataDto
    {
        [JsonProperty("UserName")]
        public virtual string Username { get; set; }
        [JsonProperty("NombreAliq")]
        public virtual string NombreAliq { get; set; }
        [JsonProperty("TipoPersona")]
        public virtual string PersonType { get; set; }
        [JsonProperty("EstadoSistema")]
        public virtual string SystemStatus { get; set; }
        [JsonProperty("NombrePersona")]
        public virtual string PersonName { get; set; }
        [JsonProperty("NeedNewPassword")]
        public virtual bool NeedNewPassword { get; set; }
        [JsonProperty("SessionId")]
        public virtual string SessionId { get; set; }
        [JsonProperty("Message")]
        public virtual string Message { get; set; }
        [JsonProperty("Ok")]
        public virtual bool Ok { get; set; }
        [JsonProperty("FechaSistema")]
        public virtual DateTime? SystemDate { get; set; }
        [JsonProperty("DobleAutenticacion")]
        public virtual bool SecondAuth { get; set; }
        [JsonProperty("TokenGuid")]
        public virtual Guid? TokenGuid { get; set; }
        [JsonProperty("EndDateSession")]
        public virtual DateTime? EndDateSession { get; set; }
        [JsonIgnore]
        public Dictionary<string, string> JavaScriptAllowedCommand { get; set; }
    }
}
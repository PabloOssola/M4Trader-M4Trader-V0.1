using System;
using System.Xml.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [Serializable]
	public class MAEUserSessionLogin
    {
        public int IdPersona { get; set; }
        public byte IdTipoPersona { get; set; }
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string TipoPersona { get; set; }
        public string EstadoSistema { get; set; }
        public string NombrePersona { get; set; }
        public bool NeedNewPassword { get; set; }
        public string SessionId { get; set; }
        public string Message { get; set; }
        public bool Ok { get; set; }
        public DateTime FechaSistema { get; set; }
        public string Global { get; set; }
        public bool DobleAutenticacion { get; set; }
        public string Password { get; set; }
        public string TokenGuid { get;  set; }
    }
}


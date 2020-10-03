using System;
using System.Collections.Generic;


namespace M4Trader.ordenes.server.Entities
{
    [Serializable]
	public class M4TraderUserSessionLogin
    {
        public string UserName { get; set; }
        public string TipoPersona { get; set; }
        public string EstadoSistema { get; set; }
        public string NombrePersona { get; set; }
        public bool NeedNewPassword { get; set; }
        public string SessionId { get; set; }
        public int IdUsuario { get; set; }
        public byte IdTipoPersona { get; set; }

        public string Message { get; set; }
        public bool Ok { get; set; }
        public DateTime FechaSistema { get; set; }

        public bool DobleAutenticacion { get; set; }
        public DateTime FechaFinalizacionSesion { get; set; }
        public string TokenGuid { get; set; }
        public Dictionary<string, string> JavascriptAllowedCommands { get; set; }
        public Dictionary<string, bool> PermisosUsuario { get; set; }

        public bool LoginRealizado { get; set; }
    }
}


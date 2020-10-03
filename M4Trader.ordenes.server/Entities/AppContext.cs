using M4Trader.ordenes.server.MCContext.Entidades;
using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.server.Entities
{
    public class OrdenesAppContext
    {
        public string UserName { get; set; }
        public string TipoParticipante { get; set; }
        public string SecurityTokenId { get; set; }
        public string WebUrlName { get; set; }
        public string MaeAppName { get; set; }
        public EstadoSistemaEntity EstadoSistema { get; set; }
        public DateTime FechaDelSistema { get; set; }
        public string FormatoFechaCorta { get; set; }
        public string FormatoFechaCortaMoment { get; set; }
        public string FormatoFechaHora { get; set; }
        public string Global { get; set; }
        public string PublicKey { get; set; }
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public int IdTipoPersona { get; set; }

        public string ClientSecret { get; set; }
        public string ServerPublic { get; set; }
        public string Nonce { get; set; }
        public string CodigoPortfolio { get; set; }
        public Dictionary<string,string> JavascriptAllowedCommands { get; set; }
        public Dictionary<string, bool> PermisosUsuario { get; set; }        
        public string LanguageTag { get; set; }

        public bool LoginRealizado { get; set; }
    }
}

using M4Trader.ordenes.services.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace M4Trader.ordenes.services.Entities
{
    [Serializable]
	public class MAEUserSession
	{
		public MAEUserSession()
		{
		}

        [ThreadStatic]
        private static MAEUserSession _instancia;

        public static void CargarInstancia(MAEUserSession instancia)
        {
            _instancia = instancia;
            if (_instancia?.IdTipoPersona == 0)
            {
                _instancia.IdTipoPersona = 1;//MarketDataHelper.CacheManager.GetPartyById(_instancia.IdPersona).IdPartyType;
            }
        }
        
        public static MAEUserSession Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    throw new Exception("La sesion de usuario no se encuentra cargada.");
                }
                return _instancia;
            }
        }
        public static bool InstanciaCargada { get { return _instancia != null; } }
        public string ID { get; set; }

        public Guid InternalId { get; set; }

        [XmlIgnore]
        public Guid? InCourseRequest { get; set; }
		public int IdUsuario { get; set; }
		public string Ip { get; set; }
		public DateTime FechaInicio { get ; set; }
		public DateTime FechaFinalizacion { get; set; }
		public byte IdAplicacion { get; set; }
		public Byte[] UltimaActualizacion { get; set; }
        public int IdPersona { get; set; }
        public byte IdTipoPersona { get; set; }
        public EstadoLogIn EstadoLogIn { get; set; }
        public int? IdEmpresa { get; set; }

        public bool LoginRealizado { get; set; }


        [XmlIgnore]
		public bool esValida
		{
			get
            {
                if ((this.IdUsuario > 0) && (this.FechaInicio > DateTime.MinValue))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
		}

        public string EstadoSistema { get; set; }
        public string UserName { get; set; }

        public string Global { get; set; }

        public string PublicKey { get; set; }

        public string Dispositivo { get; set; }

        //public RSAParameters PrivateKey { get; set; }
        public string PrivateKey { get; set; }

        public string ConfiguracionRegional { get; set; }

        public string ClientSecret { get; set; }
        public string ClientPublic { get; set; }
        public string ServerSecret { get; set; }
        public string ServerPublic { get; set; }
        public string Nonce { get; set; }
        public Dictionary<string, string> MenuDic { get; set; }
        [JsonIgnoreAttribute]
        public Dictionary<string, Type> AllowedCommands { get; set; }

        public Dictionary<string, string> JavascriptAllowedCommands { get; set; }
        public Dictionary<string, bool> PermisosUsuario { get; set; }

        public static void BorrarInstancia()
        {
            _instancia = null;
        }
    }
}


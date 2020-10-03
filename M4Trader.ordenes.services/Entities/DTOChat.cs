using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.services.Entities
{
    public class DTOChat
    {
        public string Mensaje { get; set; }
        public int IdChat { get; set; }
    }

    public class DTONuevoChat
    {
        public int IdChat { get; set; }

        public string Nombre { get; set; }

        public int IdOwner { get; set; }

        public DateTime Fecha { get; set; }

        public List<DTOUsuario> Participantes { get; set; }
    }

    public class DTONuevoMensajeChat
    {
        public int IdChat { get; set; }
        public int IdChatMensaje { get; set; }

        public string Mensaje { get; set; }
        public string Target { get; set; }

        public bool EsGrupo { get; set; }

        public int IdUsuarioOrigen { get; set; }

        public string UsernameOrigen { get; set; }

        public DateTime Fecha { get; set; }

        public List<DTOUsuario> Participantes { get; set; }
    }
}

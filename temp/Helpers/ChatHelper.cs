using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server.Helpers
{
    public delegate void ChatHandle(string chat);

    public static class ChatHelper
    {

        public static void PersistirMensaje()
        {
            //ChatDAL.PersistirMensaje();
        }

        public static void PublicarMensajes(DTOChat chat)
        {
            WCFHelper.ExecuteService<IChatService>(ConfiguracionSistemaURLsEnumDestino.ChatService, i => i.EnviarMensaje(chat));
        }

        public static int InsertarMensaje(int idChat, int origen, string mensaje)
        {
            return ChatDAL.InsertarMensaje(idChat, origen, mensaje);
        }

        public static void InformarNuevoGrupo(ChatEntity chat, string usuarios, int idOwner)
        {
            //agrego el owner a participantes
            usuarios += "," + idOwner.ToString();
            DTONuevoChat nuevoChat = new DTONuevoChat()
            {
                IdChat = chat.IdChat,
                Nombre = chat.Nombre,
                Participantes = usuarios.Split(',').Select(x => new DTOUsuario() { IdUsuario = int.Parse(x) }).ToList(),
                IdOwner = idOwner,
                Fecha = chat.Fecha

            };
            WCFHelper.ExecuteService<IChatService>(ConfiguracionSistemaURLsEnumDestino.ChatService, i => i.InformarNuevoGrupo(nuevoChat));
        }

        public static void InformarNuevoMensaje(int idChat, string mensaje, int idUsuarioOrigen, int idChatMensaje)
        {
            List<DTOUsuario> participantes;
            ChatEntity chat;
            string nombreChat;
            using (OrdenesContext mc = new OrdenesContext())
            {
                participantes = (from p in mc.ChatUsuarios where p.IdChat == idChat select new DTOUsuario() { IdUsuario = p.IdUsuario }).ToList();
                chat = (from c in mc.Chats where c.IdChat == idChat select c).FirstOrDefault();
                if (chat.EsGrupo)
                {
                    nombreChat = chat.Nombre;
                } else
                {
                    //Si no es grupo, en participantes solo hay 2 usuarios, porque es chat individual. Como busco la contraparte, pongo que sea distinto a idUsuarioOrigen
                    int idContraparte = participantes.Find(x => x.IdUsuario != idUsuarioOrigen).IdUsuario;
                    nombreChat = (from u in mc.Usuario where u.IdUsuario == idContraparte select u).FirstOrDefault().Username;
                }
                 

            }
            DTONuevoMensajeChat nuevoMensajeChat = new DTONuevoMensajeChat()
            {
                IdChat = idChat,
                Mensaje = mensaje,
                Target = nombreChat,
                Participantes = participantes,
                Fecha = DateTime.Now,
                EsGrupo = chat.EsGrupo,
                IdUsuarioOrigen = idUsuarioOrigen,
                UsernameOrigen = MAEUserSession.Instancia.UserName,
                IdChatMensaje = idChatMensaje
            };
            WCFHelper.ExecuteService<IChatService>(ConfiguracionSistemaURLsEnumDestino.ChatService, i => i.InformarNuevoMensaje(nuevoMensajeChat));
        }

        public static int CrearChat(string nombre, bool esGrupo)
        {
            return ChatDAL.CrearChat(nombre, esGrupo);
        }
    }
}

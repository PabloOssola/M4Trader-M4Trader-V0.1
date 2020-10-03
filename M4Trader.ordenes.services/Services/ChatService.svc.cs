using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;
using M4Trader.ordenes.Services.Helpers;
using System.ServiceModel;

namespace M4Trader.ordenes.services.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        public void EnviarMensaje(DTOChat chat)
        {
            ChatMessageHelper.PublicarMensajes(chat);
        }

        public void InformarNuevoGrupo(DTONuevoChat nuevoChat)
        {
            ChatMessageHelper.InformarNuevoGrupo(nuevoChat);
        }

        public void InformarNuevoMensaje(DTONuevoMensajeChat nuevoMensajeChat)
        {
            ChatMessageHelper.InformarNuevoMensaje(nuevoMensajeChat);
        }
    }
}

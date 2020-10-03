using M4TraderWebApp.Entities;
using M4TraderWebApp.Helpers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace M4TraderWebApp.Hubs
{
    public class MessageHub : Hub
    {
        public static Dictionary<int, string> usuariosConectados = new Dictionary<int, string>();
        static bool inicializar = false;

        public MessageHub()
        {
            if (!inicializar)
            {
                MessageHelper.NewMessageHandleEvent += NewMessageHandleEvent;
                inicializar = true;
                
            }
        }

        public override Task OnConnectedAsync()
        {
            var travel = new  { };
            
            return base.OnConnectedAsync();
        }

        public static void RemoveConnection(string id)
        {
            foreach (var item in usuariosConectados)
            {
                if (item.Value == id)
                {
                    usuariosConectados.Remove(item.Key);
                    return;
                }
            }
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            RemoveConnection(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }


        public void Notify( int id)
        {
            try
            {
                string idHub = Context.ConnectionId;
                if (usuariosConectados.TryGetValue(id, out idHub))
                {
                    usuariosConectados.Remove(id);
                }
                usuariosConectados.Add(id, Context.ConnectionId);
            }
            catch
            {
            }
        }

        public async Task SendMessage(string message, string type, string subtye)
        {
            await Clients.All.SendAsync("test", new { type ="See", message = message } );
        }

        public  void NewMessageHandleEvent(DTONewMessage mensaje, IHubContext<MessageHub> hubContext)
        {
            string IdHub;
            if (usuariosConectados.TryGetValue(mensaje.IdUser, out IdHub))
            {

                hubContext.Clients.Client(IdHub).SendAsync("NewMessage", mensaje);
            }
            //TaskNewMessageHandleEventAsync(mensaje);
        }

        public async Task TaskNewMessageHandleEventAsync(DTONewMessage mensaje, IHubContext<MessageHub> hubContext)
        {



            //var hub = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            //Context.

            string IdHub;
            if (usuariosConectados.TryGetValue(mensaje.IdUser, out IdHub))
            {

                await hubContext.Clients.Client(IdHub).SendAsync("NewMessage", mensaje);
            }

        }

    }
}

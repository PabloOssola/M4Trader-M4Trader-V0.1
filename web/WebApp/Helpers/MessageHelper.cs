using M4TraderWebApp.Entities;
using M4TraderWebApp.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M4TraderWebApp.Helpers
{
    public delegate void NewMessageHandle(DTONewMessage dto, IHubContext<MessageHub> context);

    public static class MessageHelper
    {


        #region NewMessageHandle

        public static void OnNewMessageHandle(DTONewMessage dto, IHubContext<MessageHub> context)
        {
            _onNewMessageHandler?.Invoke(dto, context);
        }

        private static NewMessageHandle _onNewMessageHandler;

        public static event NewMessageHandle NewMessageHandleEvent
        {
            add
            {
                if (_onNewMessageHandler == null || !VerificarSiExiste(value))
                    _onNewMessageHandler += value;
            }
            remove
            {
                _onNewMessageHandler -= value;
            }
        }

        public static bool VerificarSiExiste(NewMessageHandle val)
        {
            var subscriptos = _onNewMessageHandler.GetInvocationList();
            foreach (var item in subscriptos)
            {
                var s = item.Method.DeclaringType.FullName + "." + item.Method.Name;
                var ss = val.Method.DeclaringType.FullName + "." + val.Method.Name;

                if (s.Equals(ss, StringComparison.Ordinal))
                    return true;
            }
            return false;
        }
        #endregion
    }
}

using M4Trader.ordenes.services.Entities;
using System;

namespace M4Trader.ordenes.Services.Helpers
{
    public delegate void ChatHandle(DTOChat chat);
    public delegate void NewChatHandle(DTONuevoChat chat);
    public delegate void NewChatMessageHandle(DTONuevoMensajeChat nuevoMensaje);

    public static class ChatMessageHelper
    {
        #region ChatHandle
        private static ChatHandle _onChatHandler;

        public static event ChatHandle ChatHandleEvent
        {
            add
            {
                if (_onChatHandler == null || !VerificarSiExiste(value))
                    _onChatHandler += value;
            }
            remove
            {
                _onChatHandler -= value;
            }
        }

        public static bool VerificarSiExiste(ChatHandle val)
        {
            var subscriptos = _onChatHandler.GetInvocationList();
            foreach (var item in subscriptos)
            {
                var s = item.Method.DeclaringType.FullName + "." + item.Method.Name;
                var ss = val.Method.DeclaringType.FullName + "." + val.Method.Name;

                if (s.Equals(ss, StringComparison.Ordinal))
                    return true;
            }
            return false;
        }


        public static void OnChatHandle(DTOChat chat)
        {
            _onChatHandler?.Invoke(chat);
        }

        public static void PublicarMensajes(DTOChat chat)
        {
            OnChatHandle(chat);
        }
        #endregion


        #region NewChatHandle
        private static NewChatHandle _onNewChatHandler;

        public static event NewChatHandle NewChatHandleEvent
        {
            add
            {
                if (_onNewChatHandler == null || !VerificarSiExiste(value))
                    _onNewChatHandler += value;
            }
            remove
            {
                _onNewChatHandler -= value;
            }
        }

        public static bool VerificarSiExiste(NewChatHandle val)
        {
            var subscriptos = _onChatHandler.GetInvocationList();
            foreach (var item in subscriptos)
            {
                var s = item.Method.DeclaringType.FullName + "." + item.Method.Name;
                var ss = val.Method.DeclaringType.FullName + "." + val.Method.Name;

                if (s.Equals(ss, StringComparison.Ordinal))
                    return true;
            }
            return false;
        }

        public static void OnNewChatHandle(DTONuevoChat nuevoChat)
        {
            _onNewChatHandler?.Invoke(nuevoChat);
        }

        public static void InformarNuevoGrupo(DTONuevoChat nuevoChat)
        {
            _onNewChatHandler(nuevoChat);
        }
        #endregion


        #region NewChatMessageHandle
        private static NewChatMessageHandle _onNewChatMessageHandler;

        public static event NewChatMessageHandle NewChatMessageHandleEvent
        {
            add
            {
                if (_onNewChatMessageHandler == null || !VerificarSiExiste(value))
                    _onNewChatMessageHandler += value;
            }
            remove
            {
                _onNewChatMessageHandler -= value;
            }
        }

        public static bool VerificarSiExiste(NewChatMessageHandle val)
        {
            var subscriptos = _onChatHandler.GetInvocationList();
            foreach (var item in subscriptos)
            {
                var s = item.Method.DeclaringType.FullName + "." + item.Method.Name;
                var ss = val.Method.DeclaringType.FullName + "." + val.Method.Name;

                if (s.Equals(ss, StringComparison.Ordinal))
                    return true;
            }
            return false;
        }

        public static void OnNewChatMessageHandle(DTONuevoMensajeChat nuevoMensajeChat)
        {
            _onNewChatMessageHandler?.Invoke(nuevoMensajeChat);
        }

        public static void InformarNuevoMensaje(DTONuevoMensajeChat nuevoMensajeChat)
        {
            OnNewChatMessageHandle(nuevoMensajeChat);
        }
        #endregion

    }
}

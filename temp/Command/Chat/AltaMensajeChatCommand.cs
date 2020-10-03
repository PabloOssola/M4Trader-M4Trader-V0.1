using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("AltaMnsjChtCmnd", (int)IdAccion.Chat, TipoAplicacion.DMA)]
    public class AltaMensajeChatCommand : ABMContextCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {

            IdChatMensaje = ChatHelper.InsertarMensaje(IdChat, IdUsuarioOrigen, Mensaje);
            return null;

        }

        public override void ExecuteAfterSuccess()
        {
            ChatHelper.InformarNuevoMensaje(IdChat, Mensaje, IdUsuarioOrigen, IdChatMensaje);
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }

        public override void Validate()
        {

        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Chat;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }


        [DataMember]
        public int IdChat { get; set; }

        [DataMember]
        public int IdUsuarioOrigen { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        public int IdChatMensaje { get; set; }


    }
}
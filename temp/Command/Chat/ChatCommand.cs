using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("ChatCommand", (int)IdAccion.Chat,TipoAplicacion.DMA)]
    public class ChatCommand : ABMContextCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            ChatHelper.PersistirMensaje();
            ChatHelper.PublicarMensajes(new DTOChat() { IdChat = 1, Mensaje ="Nuevo mensaje" });
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = true, Message = "Mensaje" });

        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }


        public override bool RefrescarCache
        {
            get
            {
                return true;
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

    }
}
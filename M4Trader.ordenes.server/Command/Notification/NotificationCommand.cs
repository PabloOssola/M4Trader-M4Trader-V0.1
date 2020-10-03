using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server
{
    [CommandType("NotificationCommand", (int)IdAccion.Notificacion, TipoAplicacion.API)]
    public class NotificationCommand : ABMContextCommand
    {


        public override bool RefrescarCache => throw new NotImplementedException();

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Notificacion;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {


            MessageHelper.InformarNuevoMensaje(IdUsuario, this.Type, SubType, Message, Date.Value);

            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { });
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string SubType { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
    }
}

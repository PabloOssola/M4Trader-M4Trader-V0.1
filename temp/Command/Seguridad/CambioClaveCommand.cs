using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.server.Helpers;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("CamClaCom", (int)IdAccion.CambioClave, TipoAplicacion.WEBEXTERNA)]
    public class CambioClaveCommand : ABMCommand
    {
        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            UserHelper.ChangePassword(IdUsuario, PreviousPass, Newpassword, ConfirmPassword);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = true, Message = "Cambio de clave exitoso!" });
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.CambioClave;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.EJECUCION;
            }
        }

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string Newpassword { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public string PreviousPass { get; set; }
        [DataMember]
        public string UltimaActualizacion { get; set; }
    }
}
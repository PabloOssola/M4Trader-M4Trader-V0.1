using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.mvc
{
    [DataContract]
    public class ChangePasswordCommand : ABMContextCommand
    {
        public override bool needTransactionalBevahiour()
        {
            return false;
        }


        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            UserHelper.ChangePassword(MAEUserSession.Instancia.IdUsuario, PasswordAnterior, PasswordNueva, NuevaVerificacion);

            return ExecutionResult.ReturnInmediately(new { OK = "OK" });
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
        public string UserName { get; set; }
        [DataMember]
        public string PasswordAnterior { get; set; }
        [DataMember]
        public string PasswordNueva { get; set; }
        [DataMember]
        public string NuevaVerificacion { get; set; }
        [DataMember]
        public string UserHostAddress { get; set; }

        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }
    }

}

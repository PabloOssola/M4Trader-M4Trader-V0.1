using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using System.Runtime.Serialization;
using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server
{
    [DataContract] 
    [CommandType("ChanPassCom", (int)IdAccion.CambioClave, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.DMA, TipoAplicacion.API)]
    public class ChangePasswordCommand : ABMContextCommand
    {
        public override bool needTransactionalBevahiour()
        {
            return false;
        }


        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            int IdUsuario = CachingManager.Instance.GetUsuarioByUsername(UserName).IdUsuario;
            UserHelper.ChangePassword(IdUsuario, PasswordAnterior, PasswordNueva, NuevaVerificacion);

            return ExecutionResult.ReturnInmediately("OK");
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

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }
    }

}

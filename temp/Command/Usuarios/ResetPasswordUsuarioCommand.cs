using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using System.Linq;
using System.Runtime.Serialization;
using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server
{
    [CommandType("ResetPassUsrCom", (int)IdAccion.Usuarios, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.ORDENES, TipoAplicacion.DMA)]
    public class ResetPasswordUsuarioCommand : UsuarioCommand
    {

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.Usuario where d.IdUsuario == IdUsuario select d);
            MCContext.Entidades.UsuarioEntity usuario = entidad.FirstOrDefault();
            UserHelper.ResetPassword(usuario, Password, ConfirmPassword);
            CachingManager.Instance.ClearUser(usuario.Username);
            string mensaje = "IdUsuario: " + IdUsuario;
            SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.ResetPass, mensaje, (byte)TipoAplicacion.ORDENES);
            return null;
        }


        public override void Validate()
        {
            valida = (Password == ConfirmPassword);

            if (!valida)
            {
                throw fe;
            }

        }
        
        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }

        [DataMember]
        public int IdUsuario { get; set; }
    }
}
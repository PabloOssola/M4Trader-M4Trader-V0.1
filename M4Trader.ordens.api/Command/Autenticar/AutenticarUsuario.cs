using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using MAE.Clearing.BusinessComponentLayer.Helpers;
using System;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.api
{
    [DataContract(Name = "AutenticarUsuario")]
    public class AutenticarUsuario : ABMContextCommand
    {
        public override void Validate()
        {

            #region Requerido
            ValidateString(NombreUsuario, "NombreUsuario", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(Password, "Password", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);

            #endregion
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            string response = string.Empty;
            if (valida)
            {
                InfoCliente infoCliente = new InfoCliente(Utils.GetIpAddress(), inCourseRequest.Origen);
                UsuarioEntity usuarioEntity = new UsuarioEntity()
                {
                    Username = NombreUsuario,
                    Pass = Password
                };
                M4TraderUserSessionLogin userSession = LoginHelper.Login(NombreUsuario, Password, infoCliente, TipoAplicacion.API);
                if (userSession.Ok && userSession.DobleAutenticacion == false)
                    response = MAEUserSession.Instancia.ID;
                else if(userSession.Ok && userSession.DobleAutenticacion == true)
                {
                    TwoFactorAuthenticator autenticador = new TwoFactorAuthenticator();
                    //var setupInfo = autenticador.GenerateSetupCode("M4Trader",
                    //userSession.TokenGuid,
                    //"ALSKDMASKLDMKALDKSA", 300, 300);
                }
                else
                    response = userSession.Message;
            } 
             
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(response);
        }


        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Login;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.EJECUCION;
            }
        }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public string Password { get; set; }

    }
}
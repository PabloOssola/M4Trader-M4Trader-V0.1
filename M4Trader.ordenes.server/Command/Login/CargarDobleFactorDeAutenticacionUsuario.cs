using Google.Authenticator;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using MAE.Clearing.BusinessComponentLayer.Helpers;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract(Name = "CargarDobleFactorDeAutenticacionUsuario")]
    public class CargarDobleFactorDeAutenticacionUsuario : ABMContextCommand
    {
        public override void Validate()
        {

            #region Requerido
            ValidateString(NombreUsuario, "NombreUsuario", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(Password, "Password", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(M4TraderPin, "Totem", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            #endregion
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            string response = string.Empty;
            if (valida)
            { 
                UsuarioEntity usuarioEntity = new UsuarioEntity()
                {
                    Username = NombreUsuario,
                    Pass = Password
                };
                 
                TwoFactorAuthenticator twoFA = new TwoFactorAuthenticator();
                string userUniqueKey = NombreUsuario + "qaz123";

                bool isValid = twoFA.ValidateTwoFactorPIN(userUniqueKey, M4TraderPin);

                if (isValid)
                {
                    InfoCliente infoCliente = new InfoCliente(Utils.GetIpAddress(), inCourseRequest.Origen);
                    M4TraderUserSessionLogin userSession = LoginHelper.Login2FA(NombreUsuario, Password, infoCliente, TipoAplicacion.API, isValid);
                    
                }
                    //response = "Is Valod";  
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
        [DataMember]
        public string M4TraderPin { get; set; }

    }
}
using Google.Authenticator;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract(Name = "ObtenerDobleFactorDeAutenticacionUsuario")]
    public class ObtenerDobleFactorDeAutenticacionUsuario : ABMContextCommand
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
                UsuarioEntity usuarioEntity = new UsuarioEntity()
                {
                    Username = NombreUsuario,
                    Pass = Password
                };
                 
                TwoFactorAuthenticator twoFA = new TwoFactorAuthenticator();
                string userUniqueKey = NombreUsuario + "qaz123"; 
                var totem = twoFA.GenerateSetupCode("Por favor Ingrese Valor de token", NombreUsuario, userUniqueKey, false, 300);
                response = totem.ManualEntryKey;
              
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
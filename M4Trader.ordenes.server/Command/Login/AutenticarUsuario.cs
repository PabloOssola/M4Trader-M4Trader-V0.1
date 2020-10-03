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

namespace M4Trader.ordenes.server
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
            TravelLogin response = new TravelLogin();
            if (valida)
            {
                InfoCliente infoCliente = new InfoCliente(Utils.GetIpAddress(), inCourseRequest.Origen);
                UsuarioEntity usuarioEntity = new UsuarioEntity()
                {
                    Username = NombreUsuario,
                    Pass = Password,
                    Agencia = inCourseRequest.Agencia
                };
                M4TraderUserSessionLogin userSession = LoginHelper.Login(NombreUsuario, Password, infoCliente, TipoAplicacion.API, usuarioEntity.Agencia);
                if (userSession.Ok && !userSession.DobleAutenticacion)
                {
                    response.Token = MAEUserSession.Instancia.ID;
                    response.IdUsuario = userSession.IdUsuario;
                    response.IdTipoPersona = userSession.IdTipoPersona;
                    response.TipoPersona = userSession.TipoPersona;
                    response.Status = 1;

                }               
                else if (userSession.DobleAutenticacion)
                {
                    response.Message =  "Ingrese nuevo control ";
                    response.Status = 2;
                }
                else
                {
                    response.Message = userSession.Message;
                    response.Status = 3;
                }
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


    public class TravelLogin
    {
        public int Status  { get; set; }//1 OK, 2 Docle factor, 3 error con mensaje
        public string Message { get; set; }
        public string Token { get; set; }
        public int IdUsuario { get; set; }
        public byte IdTipoPersona { get; set; }
        public string TipoPersona { get; set; }

    }
}
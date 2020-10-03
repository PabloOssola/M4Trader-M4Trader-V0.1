using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("GetUserSes", (int)IdAccion.GetUserSession, TipoAplicacion.API)]

    public class GetUserSession : ABMCommand
    {
        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        { 
            MAEUserSession usuarioSession = SessionHelper.GetSesionExistente(inCourseRequest.SecurityTokenId);
            
            M4TraderUserSessionLogin userSessionLogin = new M4TraderUserSessionLogin()
            {
                SessionId = usuarioSession.ID,
                UserName = usuarioSession.UserName,
                EstadoSistema = usuarioSession.EstadoSistema,
                TipoPersona = UserHelper.getNombreTipoPersona(usuarioSession.IdTipoPersona),
                NombrePersona = UserHelper.GetNombrePersona(usuarioSession.IdPersona),
                FechaSistema = CachingManager.Instance.GetFechaSistema().FechaSistema,
                FechaFinalizacionSesion = usuarioSession.FechaFinalizacion,
                JavascriptAllowedCommands = usuarioSession.JavascriptAllowedCommands,
                PermisosUsuario = usuarioSession.PermisosUsuario

            };
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(userSessionLogin);
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.GetUserSession;
            }
        }


        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        [DataMember]
        public string sessionId { get; set; }


    }
}
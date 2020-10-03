using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.CQRS.Security.Authorization;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Exceptions;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;

namespace M4Trader.ordenes.server.Helpers
{

    public static class SecurityHelper
    {
        public static TipoAutorizacion AuthorizeAccion(int idUsuario, short idAccion, TipoPermiso permisoRequerido)
        {
            Permiso _permiso = GetByIDPermisos(idUsuario, idAccion);
            AccionEntity accion = CachingManager.Instance.GetAccionById(idAccion);

            if (_permiso != null & accion != null)
            {
                if (((int)permisoRequerido & _permiso.Permisos & accion.HabilitarPermisos) == (int)permisoRequerido)
                {
                    // INFORMATION OK
                    return TipoAutorizacion.CON_PERMISOS;
                }
            }
            return TipoAutorizacion.SIN_PERMISOS;
        }

        private static Permiso GetByIDPermisos(int idUsuario, short idAccion)
        {
            var permiso = CachingManager.Instance.GetByIdPermisos(idUsuario, idAccion);
            if (permiso == null)
            {
                string mensaje = string.Empty;
                AccionEntity accion = CachingManager.Instance.GetAccionById(idAccion);
                if (accion == null)
                {
                    mensaje = string.Format(CodeMensajes.GetDescripcionMensaje(CodeMensajes.ERR_ACCION_NO_EXISTE), idAccion);
                    throw new M4TraderApplicationException(CodeMensajes.ERR_ACCION_NO_EXISTE, mensaje);
                }
                mensaje = string.Format(CodeMensajes.GetDescripcionMensaje(CodeMensajes.ERR_SINPERMISOS), accion.Descripcion, accion.Descripcion);
                throw new M4TraderApplicationException(CodeMensajes.ERR_SINPERMISOS, mensaje);
            }
            VerificarPermiso(ref permiso);
            return permiso;
        }

        public static void VerificarPermiso(ref Permiso permiso)
        {
            try
            {
                var sistema = CachingManager.Instance.GetFechaSistema();

                if ((!sistema.EstadoAbierto)
                    && (permiso.IdAccion != (short)IdAccion.AbrirSistema)
                    && (permiso.IdAccion != (short)IdAccion.AnularCierreSistema)
                    && (permiso.IdAccion != (short)IdAccion.EstadoSistema))
                {
                    if (permiso.Permisos >= (int)TipoPermiso.CONSULTA)
                        permiso.Permisos = (int)TipoPermiso.CONSULTA;

                } 
            }
            catch
            {
                permiso.Permisos = (int)TipoPermiso.CONSULTA;
            }
        }

        public static void ensureAuthorized(Command command, InCourseRequest inCourseRequest)
        {
            SessionHelper.GetSesionExistente(inCourseRequest.SecurityTokenId);
            MAEUserSession.Instancia.InCourseRequest = inCourseRequest.Id;
            Authorization.Authorize(command, MAEUserSession.Instancia.IdUsuario);
        }

        public static void ensureAuthorized(string store, InCourseRequest inCourseRequest)
        {
            SessionHelper.GetSesionExistente(inCourseRequest.SecurityTokenId);
            MAEUserSession.Instancia.InCourseRequest = inCourseRequest.Id;
            Authorization.AuthorizeQuery(store, MAEUserSession.Instancia.IdUsuario, 1);
        }

        public static void ensureAuthorized(Query query, InCourseRequest inCourseRequest)
        {
            SessionHelper.GetSesionExistente(inCourseRequest.SecurityTokenId);
            MAEUserSession.Instancia.InCourseRequest = inCourseRequest.Id;
            Authorization.AuthorizeQuery(query.Name, MAEUserSession.Instancia.IdUsuario, 1);
        }

        public static void ensureAuthenticated(InCourseRequest inCourseRequest)
        {
            SessionHelper.GetSesionExistente(inCourseRequest.SecurityTokenId);
            MAEUserSession.Instancia.InCourseRequest = inCourseRequest.Id;
        }

        public static void ensureAuthorized(IdAccion idaccion, Guid sessionId, InCourseRequest request)
        {
            SessionHelper.GetSesionExistente(sessionId);
            MAEUserSession.Instancia.InCourseRequest = request.Id;
            Authorization.AuthorizeAccion(idaccion, MAEUserSession.Instancia.IdUsuario, TipoPermiso.CONSULTA);
        }

    }
}
using M4Trader.ordenes.server.CQRSFramework.CQRS.Security.Authorization.Exceptions;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using System;

namespace M4Trader.ordenes.server.CQRSFramework.CQRS.Security.Authorization
{

    public class Authorization
    {

        public static void Authorize(Command command, int idUsuario)
        {
            var keyArray = new KeyArray();
            short idAccion = Convert.ToInt16(command.GetIdAccion);
            var tpAuth = CachingManager.Instance.GetAutorizacion(idUsuario, idAccion, (TipoPermiso)command.GetIdPermiso).tipoAutorizacion;

            if (tpAuth == TipoAutorizacion.CON_PERMISOS || tpAuth == TipoAutorizacion.CON_DOBLE_CONTROL)
                return;

            AccionEntity accion = CachingManager.Instance.GetAccionById(idAccion);

            keyArray.Codigo = CodigosMensajes.FE_ERROR_FALTA_PERMISOS;
            if (accion != null)
            {
                keyArray.Parametros.Add(accion.Descripcion);
            }
            else
            {
                keyArray.Parametros.Add(string.Format("Acción {0} no encontrada", idAccion));
            }
            var fe = new AuthorizationException(001);
            fe.DataValidations.Add(keyArray);
            throw fe;
        }

        public static void AuthorizeQuery(string query, int idUsuario, int tipo_permiso)
        {
            bool sinPermisos = false;
            // hasta que no se carguen todas las grillas tiene el try/catch
            var keyArray = new KeyArray();
            QRYIdAccion? idAccion = null;
            try
            {
                idAccion = (QRYIdAccion)Enum.Parse(typeof(QRYIdAccion), query.ToUpper());
            }
            catch 
            {
                sinPermisos = true;
            }

            if (!sinPermisos)
            {
                var tpAuth = CachingManager.Instance.GetAutorizacion(idUsuario, (short)idAccion.Value.GetHashCode(), (TipoPermiso)tipo_permiso).tipoAutorizacion;

                if (tpAuth == TipoAutorizacion.CON_PERMISOS || tpAuth == TipoAutorizacion.CON_DOBLE_CONTROL)
                    return;

                keyArray.Codigo = CodigosMensajes.FE_ERROR_FALTA_PERMISOS;
                AccionEntity accion = CachingManager.Instance.GetAccionById((short)idAccion.Value);

                if (accion != null)
                {
                    keyArray.Parametros.Add(accion.Descripcion);
                }
                else
                {
                    keyArray.Parametros.Add(string.Format("Acción {0} no encontrada", idAccion.Value));
                }
            }
            else
            {
                keyArray.Parametros.Add(string.Format("No se encontró el QueryName {0}", query));
            }
            keyArray.Codigo = CodigosMensajes.FE_ERROR_FALTA_PERMISOS;

            var fe = new AuthorizationException(001);
            fe.DataValidations.Add(keyArray);
            throw fe;
        }

        internal static void AuthorizeAccion(IdAccion idAccion, int idUsuario, TipoPermiso eJECUCION)
        {
            var keyArray = new KeyArray();
            var tpAuth = CachingManager.Instance.GetAutorizacion(idUsuario, (short)idAccion, eJECUCION).tipoAutorizacion;

            if (tpAuth == TipoAutorizacion.CON_PERMISOS || tpAuth == TipoAutorizacion.CON_DOBLE_CONTROL)
                return;

            AccionEntity accion = CachingManager.Instance.GetAccionById((short)idAccion);

            keyArray.Codigo = CodigosMensajes.FE_ERROR_FALTA_PERMISOS;
            if (accion != null)
            {
                keyArray.Parametros.Add(accion.Descripcion);
            }
            else
            {
                keyArray.Parametros.Add(string.Format("Acción {0} no encontrada", idAccion));
            }
            var fe = new AuthorizationException(001);
            fe.DataValidations.Add(keyArray);
            throw fe;
        }
    }
}   
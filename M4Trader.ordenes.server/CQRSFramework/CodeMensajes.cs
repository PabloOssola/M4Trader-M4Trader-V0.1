using System.Globalization;
using M4Trader.ordenes.server.DataAccess;

namespace M4Trader.ordenes.server.CQRSFramework
{
    public class CodeMensajes
    {
        public const string ERR_AUTHENTICATEUSUARIO = "E100006";
        public const string ERR_USUARIOBLOQUEADO = "E100008";
        public const string ERR_CUENTA_EXPIRADA = "E100011";
        public const string ERR_ALCANZO_MAXIMO_INTENTOS = "E100012";
        public const string ERR_SIN_PERMISO_ACCESO = "E100802";
        public const string ERR_SINPERMISOS = "E100014";
        public const string ERR_EXPIRO_SESION = "E100015";
        public const string ERR_COMANDO_NO_PERMITIDO = "E100016";
        public const string ERR_CLAVES_VERIFICACION = "E100020";
        public const string ERR_CLAVE_VERIFICACION_CARACTERES = "E100021";
        public const string ERR_CLAVE_EXISTE_HISTORICA = "E100022";
        public const string ERR_SET_LOGINEXITOSO_USUARIO = "E100060";
        public const string ERR_CUENTA_EXPIRADA_INACTIVA = "E100061";
        public const string ERR_PASSWORD_INCORRECTA = "E100062";
        public const string ERR_CLAVENOUSERNAME = "E100132";
        public const string ERR_CLAVEALFABETICOSNUMERICOS = "E100133";
        public const string ERR_CLAVECANTIDADALFABETICOS = "E100134";
        public const string ERR_CLAVECANTIDADNUMERICOS = "E100135";
        public const string ERR_CLAVECANTIDADCARACTERESCONSECUTIVOS = "E100136";
        public const string ERR_CLAVESINCAMBIOS = "E100139";
        public const string ERR_CLAVECANTIDADMINUSCULAS = "E100553";
        public const string ERR_CLAVECANTIDADMAYUSCULAS = "E100554";
        public const string ERR_CLAVECANTIDADSIMBOLOS = "E100555";
        public const string ERR_ACCION_NO_EXISTE = "E100557";
        public const string ERR_USUARIO_NO_HABILITADO_AGENCIA = "E100558";

        public const string WAR_CAMBIAR_CLAVE_ACCESO = "W100002";

        public const string INF_OK = "I100000";
        public const string INF_INICIO_SESION = "I100002";
        public const string INF_CLAVE_MODIFICA = "I100004";
        public const string INF_CIERRE_SESION = "I100010";

   
        public CodeMensajes()
        {
        }

        public static string GetDescripcionMensaje(string codeError)
        {
            return MensajesDAL.ObtenerMensajeByCodigo(codeError);
        }
    }
}


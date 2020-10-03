using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class ActualizaConfiguracionSeguridadCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.ConfiguracionSeguridad where d.IdConfiguracionSeguridad == IdConfiguracionSeguridad select d);

            ValidateExiste(entidad.Count(), IdConfiguracionSeguridad, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            ConfiguracionSeguridadEntity request = entidad.FirstOrDefault();

            request.TimeOutInicialSesion = TimeOutInicialSesion;

            request.TimeOutExtensionSesion = TimeOutExtensionSesion;

            request.CantidadIntentosMaximo = CantidadIntentosMaximo;

            request.MaximoDiasInactividad = MaximoDiasInactividad;

            request.DiasCambioPassword = DiasCambioPassword;

            request.CantidadPasswordsHistoricas = CantidadPasswordsHistoricas;

            request.ConsideraMinimoLargoPassword = ConsideraMinimoLargoPassword;

            request.CantidadMinimoLargoPassword = ConsideraMinimoLargoPassword ? CantidadMinimoLargoPassword : (byte)0;

            request.ConsideraMaximaCantCaracteresConsecutivos = ConsideraMaximaCantCaracteresConsecutivos;

            request.CantidadMaximaCaracteresConsecutivos = ConsideraMaximaCantCaracteresConsecutivos ? CantidadMaximaCaracteresConsecutivos : (byte)0;

            request.ConsideraCantidadCaracteres = ConsideraCantidadCaracteres;

            request.CantidadAlfabeticosPassword = ConsideraCantidadCaracteres ? CantidadAlfabeticosPassword : (byte)0;

            request.CantidadNumericosPassword = ConsideraCantidadCaracteres ? CantidadNumericosPassword : (byte)0;

            request.CantidadMinusculasPassword = ConsideraCantidadCaracteres ? CantidadMinusculasPassword : (byte)0;

            request.CantidadSimbolosPassword = ConsideraCantidadCaracteres ? CantidadSimbolosPassword : (byte)0;

            request.CantidadMayusculasPassword = ConsideraCantidadCaracteres ? CantidadMayusculasPassword : (byte)0;

            request.DobleAutenticacion = DobleAutenticacion;


            return true;
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "ConfiguracionSeguridad";
            #region Requerido
            ValidateInt(TimeOutExtensionSesion, "Timeout Extensión Sesión", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateInt(TimeOutInicialSesion, "Timeout Inicial", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            #endregion Requerido

            #region validaciones de checkboxes
            if (ConsideraMaximaCantCaracteresConsecutivos)
            {
                ValidateByte(CantidadMaximaCaracteresConsecutivos, "Cant Max Caracteres Consecutivos", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            }

            if (ConsideraMinimoLargoPassword)
            {
                ValidateByte(CantidadMinimoLargoPassword, "Cantidad Mínimo Largo Password", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            }
            #endregion validaciones de checkboxes
            if (!valida)
            {
                throw fe;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.ConfiguracionSeguridad;
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
        public short IdConfiguracionSeguridad { get; set; }
        
        [DataMember]
        public int TimeOutInicialSesion { get; set; }

        [DataMember]
        public int TimeOutExtensionSesion { get; set; }

        [DataMember]
        public byte CantidadIntentosMaximo { get; set; }

        [DataMember]
        public byte MaximoDiasInactividad { get; set; }

        [DataMember]
        public byte DiasCambioPassword { get; set; }

        [DataMember]
        public byte CantidadPasswordsHistoricas { get; set; }

        [DataMember]
        public bool ConsideraMinimoLargoPassword { get; set; }

        [DataMember]
        public byte CantidadMinimoLargoPassword { get; set; }

        [DataMember]
        public bool ConsideraCantidadCaracteres { get; set; }

        [DataMember]
        public byte CantidadAlfabeticosPassword { get; set; }

        [DataMember]
        public byte CantidadNumericosPassword { get; set; }

        [DataMember]
        public byte CantidadMinusculasPassword { get; set; }

        [DataMember]
        public byte CantidadSimbolosPassword { get; set; }

        [DataMember]
        public bool ConsideraMaximaCantCaracteresConsecutivos { get; set; }

        [DataMember]
        public byte CantidadMaximaCaracteresConsecutivos { get; set; }

        [DataMember]
        public byte CantidadMayusculasPassword { get; set; }

        [DataMember]
        public string DobleAutenticacion { get; set; }
    }
}
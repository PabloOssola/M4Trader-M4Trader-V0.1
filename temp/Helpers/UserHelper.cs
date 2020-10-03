using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server.Helpers
{
    internal enum TipoValidacionPassword
    {
        Reset = 1,
        Create = 2,
        Change = 3
    }

    public static class UserHelper
    {
        public static string getNombreTipoPersona(byte idTipoPersona)
        {
            switch (idTipoPersona)
            {
                case 0: return "ANONIMO";
                case 3: return "CLIENTE";
                case 5: return "CUSTODIO";
                case 6: return "LIQUIDADOR";
                case 7: return "NEGOCIADOR";
                case 8: return "ADMFCE";
                case 9: return "ADMUSERS";
                default: return "";
            }
        }

        public static UsuarioEntity GetByIDUsuarios(int idUsuario)
        {
            return CachingManager.Instance.GetByIdUsuario(idUsuario);
        }

        public static void ValidaUsuarioActivo(int cantidadDias, UsuarioEntity usuario)
        {
            if (usuario.NoControlarInactividad || !usuario.UltimoLoginExitoso.HasValue)
            {
                return;
            }
            if (cantidadDias == 0)
                return;
            if (MAEDateTimeTools.DateTimeAdd(usuario.UltimoLoginExitoso.Value, cantidadDias, "d").Date >= DateTime.Now.Date)
                return;
            BlockUsuarios(usuario.IdUsuario, (byte)LogCodigoAccion.UsuarioBloqueadoPorTiempoInactividad);
            AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CUENTA_EXPIRADA_INACTIVA, false);
        }

        public static void BlockUsuarios(int idUsuario, byte codigoAccionSeguridad)
        {
            using (OrdenesContext context = new OrdenesContext())
            {
                UsuarioEntity usuario = (from d in context.Usuario
                                         where d.BajaLogica == false
                                         && d.IdUsuario == idUsuario
                                         select d).FirstOrDefault();
                usuario.Bloqueado = true;
                context.SaveChanges();
            }
        }

        public static string GetNombrePersona(int idPersona)
        {
            using (OrdenesContext context = new OrdenesContext())
            {
                PartyEntity persona = (from d in context.Persona
                                       where d.IdParty == idPersona
                                       select d).FirstOrDefault();

                return (persona == null) ? "" : persona.Name;
            }
        }

        public static PartyEntity GetPersona(int idPersona)
        {
            using (OrdenesContext context = new OrdenesContext())
            {
                PartyEntity persona = (from d in context.Persona
                                       where d.IdParty == idPersona
                                       select d).FirstOrDefault();

                return (persona == null) ? null : persona;
            }
        }
        #region Password
        public static void ChangePassword(int IdUsuario, string anterior, string nueva, string nuevaVerificacion)
        {
            var usuario = CachingManager.Instance.GetByIdUsuario(IdUsuario);
            CachingManager.Instance.ClearUser(IdUsuario);
            ValidaPassword(usuario, anterior, nueva, nuevaVerificacion, TipoValidacionPassword.Change);
            ChangeClave(IdUsuario, MAETools.HashMD5(anterior), MAETools.HashMD5(nueva), DateTime.Now);
        }

        public static void ResetPassword(UsuarioEntity usuario, string nueva, string nuevaVerificacion)
        {
            CachingManager.Instance.ClearUser(usuario.IdUsuario);
            ValidaConfiguracionPassword(nueva, nuevaVerificacion, usuario, TipoValidacionPassword.Reset);
            var _beSeteos = CachingManager.Instance.GetConfiguracionSeguridad();
            DateTime ultimaModificacionPass = DateTime.Now.AddDays(-(_beSeteos.DiasCambioPassword + 1));
            ChangeClave(usuario.IdUsuario, usuario.Pass, MAETools.HashMD5(nueva), ultimaModificacionPass, true);
        }

        private static void ValidaPassword(UsuarioEntity usuario, string vieja, string nueva, string validacion, TipoValidacionPassword Tipo)
        {
            string vieja_md5 = string.Empty;

            // Descifro solo en el casos de un changeclave (sino nunca llega como parametro)
            if (Tipo == TipoValidacionPassword.Change)
            {
                if (string.IsNullOrEmpty(vieja))
                {
                    AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_PASSWORD_INCORRECTA, false);
                }
                vieja_md5 = MAETools.HashMD5(vieja);
            }

            if ((Tipo == TipoValidacionPassword.Change) && (vieja_md5 != usuario.Pass))
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_PASSWORD_INCORRECTA, false);

            if ((Tipo == TipoValidacionPassword.Change) && (vieja == nueva))
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVESINCAMBIOS, false);

            ValidaConfiguracionPassword(nueva, validacion, usuario, Tipo);
        }

        private static void ValidaConfiguracionPassword(string nueva, string validacion, UsuarioEntity usuario, TipoValidacionPassword Tipo)
        {
            var configuracionSeguridad = CachingManager.Instance.GetConfiguracionSeguridad();
            int _caracteresnumericos = 0;
            int _caracteresalfabeticos = 0;

            char _caracter_a_evaluar = char.MinValue;
            int _cantidadcaracterrepetido = 0;
            int _maxcantidadcaracteresconsecutivos = 0;

            int _cantidadcaracteresminusculas = 0;
            int _cantidadcaracteresmayusculas = 0;
            int _cantidadcaracteressimbolos = 0;

            if ((string.IsNullOrEmpty(nueva)) && (string.IsNullOrEmpty(validacion)))
            {
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_PASSWORD_INCORRECTA, false);
            }
            // Que la nueva pass coincida con la validacion
            if (nueva != validacion)
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVES_VERIFICACION, false);

            // Valida que la nueva passw no sea el username
            if (usuario.Username == nueva)
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVENOUSERNAME, false);

            // Valida que la nueva passw contenga solo numeros o caracteres alfabeticos
            foreach (char chr in nueva)
            {

                if ((!Char.IsLetterOrDigit(chr)) && (!MAETools.IsSymbol(chr)))
                    AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVEALFABETICOSNUMERICOS, false);

                // Calcula cantidad de numericos y alfabeticos
                if (Char.IsDigit(chr))
                {
                    _caracteresnumericos = _caracteresnumericos + 1;
                }
                else
                {
                    if (MAETools.IsSymbol(chr)) _cantidadcaracteressimbolos = _cantidadcaracteressimbolos + 1;
                    else
                    {
                        _caracteresalfabeticos = _caracteresalfabeticos + 1;
                        if (Char.IsLower(chr)) _cantidadcaracteresminusculas = _cantidadcaracteresminusculas + 1;
                        else _cantidadcaracteresmayusculas = _cantidadcaracteresmayusculas + 1;
                    }
                }

                // Calcula la maxima cantidad de caracteres que se repite el char
                if (_caracter_a_evaluar == chr)
                {
                    _cantidadcaracterrepetido = _cantidadcaracterrepetido + 1;
                }
                else
                {
                    _caracter_a_evaluar = chr;
                    _cantidadcaracterrepetido = 0;
                }

                if (_maxcantidadcaracteresconsecutivos < _cantidadcaracterrepetido)
                {
                    _maxcantidadcaracteresconsecutivos = _cantidadcaracterrepetido;
                }
            }

            if (configuracionSeguridad.ConsideraCantidadCaracteres)
            {
                if (_caracteresnumericos < configuracionSeguridad.CantidadNumericosPassword)
                    AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVECANTIDADNUMERICOS, false, configuracionSeguridad.CantidadNumericosPassword);
                if (_caracteresalfabeticos < configuracionSeguridad.CantidadAlfabeticosPassword)
                    AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVECANTIDADALFABETICOS, false, configuracionSeguridad.CantidadAlfabeticosPassword);
                if (_cantidadcaracteresminusculas < configuracionSeguridad.CantidadMinusculasPassword)
                    AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVECANTIDADMINUSCULAS, false, configuracionSeguridad.CantidadMinusculasPassword);
                if (_cantidadcaracteresmayusculas < configuracionSeguridad.CantidadMayusculasPassword)
                    AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVECANTIDADMAYUSCULAS, false, configuracionSeguridad.CantidadMayusculasPassword);
                if (_cantidadcaracteressimbolos < configuracionSeguridad.CantidadSimbolosPassword)
                    AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVECANTIDADSIMBOLOS, false, configuracionSeguridad.CantidadSimbolosPassword);
            }

            if (configuracionSeguridad.ConsideraMinimoLargoPassword && configuracionSeguridad.CantidadMinimoLargoPassword > nueva.Length)
            {
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVE_VERIFICACION_CARACTERES, false, configuracionSeguridad.CantidadMinimoLargoPassword);
            }

            if (configuracionSeguridad.ConsideraMaximaCantCaracteresConsecutivos && (configuracionSeguridad.CantidadMaximaCaracteresConsecutivos < _maxcantidadcaracteresconsecutivos + 1))
            {
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVECANTIDADCARACTERESCONSECUTIVOS, false, (configuracionSeguridad.CantidadMaximaCaracteresConsecutivos + 1));
            }

            if ((Tipo != TipoValidacionPassword.Reset) && (ExistsClaveHistorica(usuario.IdUsuario, configuracionSeguridad.CantidadPasswordsHistoricas, MAETools.HashMD5(nueva))))
                AdministradorControlErrores.EnviarExcepcion(CodeMensajes.ERR_CLAVE_EXISTE_HISTORICA, false, configuracionSeguridad.CantidadPasswordsHistoricas);
        }

        public static void CreateHistoricoPassword(int IdUsuario, string pass)
        {
            using (OrdenesContext context = new OrdenesContext())
            {
                HistoricoPasswordEntity hpe = new HistoricoPasswordEntity();
                hpe.Pass = pass;
                hpe.Fecha = DateTime.Now;
                hpe.IdUsuario = IdUsuario;
                context.Add(hpe);
                context.SaveChanges();
            }
        }

        public static void ChangeClave(int usuario, string anterior, string nueva, DateTime date, bool resetPass = false)
        {
            using (OrdenesContext context = new OrdenesContext())
            {
                UsuarioEntity user = (from d in context.Usuario
                                      where d.IdUsuario == usuario
                                      select d).FirstOrDefault();
                user.Pass = nueva;
                user.UltimaModificacionPassword = date;
                user.UltimoLoginExitoso = DateTime.Now;
                user.ResetPassword = resetPass ? true : false;

                HistoricoPasswordEntity hpe = new HistoricoPasswordEntity();
                hpe.Pass = nueva;
                hpe.Fecha = DateTime.Now;
                hpe.IdUsuario = user.IdUsuario;
                context.Add(hpe);

                context.SaveChanges();
            }
            //SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.ModificaClave, null);
        }
        #endregion


        public static bool ExistsClaveHistorica(int idUsuario, long cantidadHistoricas, string clave)
        {
            bool _result = false;

            /*** Martin Modificado 20/sept/2004
             *** No se valida en caso de no tener seteada la cantidad maxima de password historica **/
            if (cantidadHistoricas > 0)
            {
                using (OrdenesContext context = new OrdenesContext())
                {
                    List<HistoricoPasswordEntity> beCollHistoricoPassword = (from d in context.HistoricoPass
                                                                             where d.IdUsuario == idUsuario
                                                                             select d).OrderByDescending(x => x.IdHistoricoPassword).ToList();

                    if (beCollHistoricoPassword.Count > 0)
                    {
                        for (int i = 0; i <= cantidadHistoricas; i++)
                        {
                            if (i == beCollHistoricoPassword.Count) break;

                            if ((clave) == beCollHistoricoPassword[i].Pass)
                            {
                                _result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return _result;
        }

        public static string EliminarUsuario(int idUsuario)
        {
            UsuariosDAL.EliminarUsuario(idUsuario);
            return "Baja del usuario exitosa:";
        }

        public static string ActualizarUsuario(int idUsuario, string nombre, decimal limiteOferta, decimal limiteOperacion, bool bloqueado)
        {
            UsuariosDAL.ActualizarUsuario(idUsuario, nombre, limiteOferta, limiteOperacion, bloqueado);
            return "Actualización del usuario exitosa:";
        }

        public static string CrearUsuario(int idParty, int idUsuario, string nombre, decimal limiteOferta, decimal limiteOperacion, bool bloqueado)
        {
            UsuariosDAL.CrearUsuario(idParty, idUsuario, nombre, limiteOferta, limiteOperacion, bloqueado);
            return "Creación del usuario exitosa:";
        }

    }
}

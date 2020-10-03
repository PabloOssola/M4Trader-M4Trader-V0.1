using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace M4Trader.ordenes.server.CQRSFramework.ABM
{
    [DataContract]
    public abstract class ABMCommand : Command
    {
        protected FunctionalException fe;
        protected KeyArray keyArray;
        protected bool valida;

        public abstract ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest);

        public override void PreProcess()
        {
            valida = true;
            fe = new FunctionalException();
        }

        public ABMCommand()
        {

        }

        public ABMCommand(string singularEntityName, string pluralEntityName)
        {
        }

        public override void Validate()
        {

        }

        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            //try
            //{
                var result = new ExecutionResult();
                if (needTransactionalBevahiour())
                {
                    TransactionOptions opciones = new TransactionOptions();
                    opciones.IsolationLevel = IsolationLevel.ReadCommitted;
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, opciones))
                    {
                        result = this.ExecuteCommand(inCourseRequest);
                        scope.Complete();
                    }
                }
                else
                    result = this.ExecuteCommand(inCourseRequest);


                return result;
            //} catch (Exception e)
            //{
            //    throw new M4TraderApplicationException("Error desconocido. Contáctese con atención a usuarios.");
            //}
        }


        protected byte[] GetUltimaActualizacion(string UltimaActualizacion)
        {
            String[] tempAry = UltimaActualizacion.Split('-');
            byte[] decBytes = new byte[tempAry.Length];
            for (int i = 0; i < tempAry.Length; i++)
                decBytes[i] = Convert.ToByte(tempAry[i], 16);

            return decBytes;
        }

        protected void ValidateInt(int Dato, string Campo, string Codigo, string NombreEntidad)
        {
            if (Dato == 0)
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        //GEQ = Greater than or equal to
        protected void ValidateAGEQBInt(int DatoA, int DatoB, string Campo, string Codigo, string NombreEntidad)
        {
            if (DatoB >  DatoA)
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        protected void ValidateDecimal(decimal Dato, string Campo, string Codigo, string NombreEntidad)
        {
            if (Dato == 0)
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        protected void ValidateLong(long Dato, string Campo, string Codigo, string NombreEntidad)
        {
            if (Dato == 0)
            {
                //Codigo requerido
                keyArray = new KeyArray
                {
                    Codigo = Codigo
                };
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        protected void ValidateByte(byte Dato, string Campo, string Codigo, string NombreEntidad)
        {
            if (Dato == 0)
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        protected void ValidateShort(short Dato, string Campo, string Codigo, string NombreEntidad)
        {
            if (Dato == 0)
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        protected void ValidateString(string Dato, string Campo, string Codigo, string NombreEntidad)
        {
            if (string.IsNullOrEmpty(Dato))
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo);
                if (fe == null)
                {
                    fe = new FunctionalException();
                }
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        protected void sendCustomError(string Campo, string Codigo, string NombreEntidad)
        {
            keyArray = new KeyArray();
            keyArray.Codigo = Codigo;
            keyArray.Parametros.Add(NombreEntidad);
            keyArray.Parametros.Add(Campo);
            if (fe == null)
            {
                fe = new FunctionalException();
            }
            fe.DataValidations.Add(keyArray);
            valida = false;
        }

        protected void ValidateStringLength(string Dato, string Campo, int largo, string Codigo, string NombreEntidad)
        {
            if (string.IsNullOrEmpty(Dato) || Dato.Length != largo)
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo);
                keyArray.Parametros.Add(largo.ToString());
                keyArray.Parametros.Add(Dato);
                if (fe == null)
                {
                    fe = new FunctionalException();
                }
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        protected byte? ToNull(byte value)
        {
            if (value == 0)
                return null;
            else return (byte)value;
        }

        protected short? ToNull(short value)
        {
            if (value == 0)
                return null;
            else return (short)value;
        }

        protected int? ToNull(int value)
        {
            if (value == 0)
                return null;
            else return (int)value;
        }

        protected long? ToNull(long value)
        {
            if (value == 0)
                return null;
            else return (long)value;
        }

        protected byte FromNull(byte? value)
        {
            if (value == null)
                return 0;
            else return (byte)value;
        }

        protected short FromNull(short? value)
        {
            if (value == null)
                return 0;
            else return (short)value;
        }

        protected int FromNull(int? value)
        {
            if (value == null)
                return 0;
            else return (int)value;
        }

        protected long FromNull(long? value)
        {
            if (value == null)
                return 0;
            else return (long)value;
        }

        protected decimal FromNull(decimal? value)
        {
            if (value == null)
                return 0;
            else return (decimal)value;
        }

        protected DateTime FromNull(DateTime? value)
        {
            if (value == null)
                return DateTime.MinValue;
            else return (DateTime)value;
        }



        public Response ProcesamientoGenerica<T>(Func<T, string> accionAEjecutar, List<T> entidad)
        {
            if (OrdenesApplication.Instance.ContextoAplicacion.PermiteProcesamientoParalelo)
                return ProcesamientoGenericaParalelo(accionAEjecutar, entidad);
            else
                return ProcesamientoGenericaSimple(accionAEjecutar, entidad);
        }

        private Response ProcesamientoGenericaParalelo<T>(Func<T, string> accionAEjecutar, List<T> entidad)
        {
            Response resultado = new Response();
            resultado.Resultado = eResult.Ok;
            ConcurrentBag<string> resultadosOk = new ConcurrentBag<string>();
            ConcurrentBag<string> resultadosError = new ConcurrentBag<string>();

            MAEUserSession sesion = MAEUserSession.Instancia;

            Parallel.ForEach(entidad, item =>
            {
                MAEUserSession.CargarInstancia(sesion);
                try
                {
                    resultadosOk.Add(accionAEjecutar(item));
                }
                catch (MAEConcurrencyException ex)
                {
                    resultado.Resultado = eResult.Error;
                    resultadosError.Add(ex.Message);
                }

                catch (M4TraderApplicationException ex)
                {
                    bool teniaCol = false;
                    if (ex.Oks != null && ex.Oks.Count > 0)
                    {
                        teniaCol = true;
                        ex.Oks.ForEach(x => resultadosOk.Add(x));
                        resultado.Resultado = eResult.Ok;
                    }
                    if (ex.Errores != null && ex.Errores.Count > 0)
                    {
                        ex.Errores.ForEach(x => resultadosError.Add(x));
                        if (teniaCol)
                        {
                            resultado.Resultado = eResult.Warning;
                        }
                        else
                        {
                            resultado.Resultado = eResult.Error;
                        }
                        teniaCol = true;
                    }
                    if (!teniaCol)
                    {
                        resultadosError.Add(ex.Message);
                        resultado.Resultado = eResult.Error;
                    }
                }
                catch (MAESqlException ex)
                {
                    resultadosError.Add(ex.Message);
                    resultado.Resultado = eResult.Error;
                }
            });

            resultado.SetResponse(resultadosOk, resultadosError, entidad);

            return resultado;
        }

        private Response ProcesamientoGenericaSimple<T>(Func<T, string> accionAEjecutar, List<T> entidad)
        {
            Response resultado = new Response();
            resultado.Resultado = eResult.Ok;
            ConcurrentBag<string> resultadosOk = new ConcurrentBag<string>();
            ConcurrentBag<string> resultadosError = new ConcurrentBag<string>();

            foreach (var item in entidad)
            {
                try
                {
                    resultadosOk.Add(accionAEjecutar(item));
                }
                catch (M4TraderApplicationException ex)
                {
                    bool teniaCol = false;
                    if (ex.Oks != null && ex.Oks.Count > 0)
                    {
                        teniaCol = true;
                        ex.Oks.ForEach(x => resultadosOk.Add(x));
                        resultado.Resultado = eResult.Ok;
                    }
                    if (ex.Errores != null && ex.Errores.Count > 0)
                    {
                        ex.Errores.ForEach(x => resultadosError.Add(x));
                        if (teniaCol)
                        {
                            resultado.Resultado = eResult.Warning;
                        }
                        else
                        {
                            resultado.Resultado = eResult.Error;
                        }
                        teniaCol = true;
                    }
                    if (!teniaCol)
                    {
                        resultadosError.Add(ex.Message);
                        resultado.Resultado = eResult.Error;
                    }
                }
                catch (MAESqlException ex)
                {
                    resultadosError.Add(ex.Message);
                    resultado.Resultado = eResult.Error;
                }
            };

            resultado.SetResponse(resultadosOk, resultadosError, entidad);

            return resultado;
        }

        public class Response
        {
            public eResult Resultado { get; set; }

            public string[] MensajeOk { get; set; }

            public string[] MensajeError { get; set; }

            public object Detalle { get; set; }

            public void SetResponse(ConcurrentBag<string> resultadosOk, ConcurrentBag<string> resultadosError, object Objdetalle)
            {
                MensajeOk = resultadosOk.ToArray();
                MensajeError = resultadosError.ToArray();
                Resultado = (MensajeError.Length > 0 && MensajeOk.Length > 0) ? eResult.Warning : (MensajeError.Length == 0 && MensajeOk.Length > 0) ? eResult.Ok : (MensajeError.Length > 0 && MensajeOk.Length == 0) ? eResult.Error : eResult.Info;
                Detalle = Objdetalle;
            }
        }


        public enum eResult
        {
            Ok,
            Error,
            Info,
            Warning
        }
    }
}

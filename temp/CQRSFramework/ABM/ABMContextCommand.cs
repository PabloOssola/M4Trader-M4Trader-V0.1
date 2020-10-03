using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using MAE.Clearing.BusinessComponentLayer.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace M4Trader.ordenes.server.CQRSFramework.ABM
{

    [DataContract]
    public abstract class ABMContextCommand : Command
    {
        protected OrdenesContext context = null;
        protected FunctionalException fe;
        protected KeyArray keyArray;
        protected string NombreEntidad;
        protected bool valida;

        public abstract bool RefrescarCache { get; }
        public override void PreProcess()
        {
            context = new OrdenesContext();
            valida = true;
            fe = new FunctionalException();
        }

        public override void Validate()
        {
        }

        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            object result = null;
            try
            {
                if (needTransactionalBevahiour())
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        result = this.ExecuteCommand(inCourseRequest);
                        this.context.SaveChanges();
                        scope.Complete();
                    }
                }
                else
                {
                    result = this.ExecuteCommand(inCourseRequest);
                    this.context.SaveChanges();
                }


                if (RefrescarCache)
                    CachingManager.Instance.RefreshAll();

                if (result == null)
                    return ExecutionResult.ReturnInmediatelyAndQueueOthers("OK");
                else if (result is ExecutionResult)
                    return (ExecutionResult)result;
                else
                    return ExecutionResult.ReturnInmediatelyAndQueueOthers(result);
            }
            catch (Exception ex)
            {
                if (ex.Message == "EX_UltimaActualizacion")
                {
                    keyArray = new KeyArray();
                    keyArray.Codigo = CodigosMensajes.FE_CAMBIO_ULTIMA_ACTUALIZACION;
                    keyArray.Parametros.Add(NombreEntidad);
                    fe.DataValidations.Add(keyArray);
                    valida = false;
                    throw fe;
                }
                else
                    throw;
            }
            finally
            {
                //this.context.Dispose();
            }
        }

        public override void Dispose()
        {
            if (this.context != null)
                this.context.Dispose();
        }

        public virtual object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            return null;
        }

        protected void AgregarAlContextoParaAlta(object request)
        {
            context.Add(request);
        }


        protected byte[] GetUltimaActualizacion(string ultimaActualizacion)
        {
            String[] tempAry = ultimaActualizacion.Split('-');
            byte[] decBytes = new byte[tempAry.Length];
            for (int i = 0; i < tempAry.Length; i++)
                decBytes[i] = Convert.ToByte(tempAry[i], 16);

            return decBytes;
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

        protected void ValidateFechaMenorIgual(DateTime? Fecha1, DateTime? Fecha2, string Campo1, string Campo2, string Codigo)
        {
            if (Fecha1.HasValue && Fecha2.HasValue && Fecha1.Value > Fecha2.Value)
            {
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo1);
                keyArray.Parametros.Add(Campo2);
                keyArray.Parametros.Add(Fecha1.Value.ToString());
                keyArray.Parametros.Add(Fecha2.Value.ToString());
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        protected void ValidateInt(int Dato, string Campo, string Codigo)
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
        protected void ValidateLong(long Dato, string Campo, string Codigo)
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

        protected void ValidateByte(byte Dato, string Campo, string Codigo)
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

        protected void ValidateShort(short Dato, string Campo, string Codigo)
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

        protected void ValidateString(string Dato, string Campo, string Codigo)
        {
            if (string.IsNullOrEmpty(Dato))
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

        protected void ValidateDateTime(DateTime Dato, string Campo, string Codigo)
        {
            if (Dato.Equals(DateTime.MinValue))
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

        protected void ValidateEquality(string dato, string dato2, string Campo, string Codigo)
        {
            if (!string.IsNullOrEmpty(dato) && !string.IsNullOrEmpty(dato2) && !dato.Equals(dato2))
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

        protected void ValidateEmail(string email, string Campo, string Codigo)
        {
            if (!Utils.IsValidEmail(email))
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

        protected void ValidateExiste(int Cantidad, byte id, string Codigo)
        {
            if (Cantidad <= 0)
            {
                fe = new FunctionalException();
                KeyArray keyArray;
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(id.ToString());
                fe.DataValidations.Add(keyArray);
                throw fe;
            }
        }
        protected void ValidateExiste(int Cantidad, int id, string Codigo)
        {
            if (Cantidad <= 0)
            {
                fe = new FunctionalException();
                KeyArray keyArray;
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(id.ToString());
                fe.DataValidations.Add(keyArray);
                throw fe;
            }
        }

        protected void ValidateExiste(int Cantidad, string id, string Codigo)
        {
            if (Cantidad <= 0)
            {
                fe = new FunctionalException();
                KeyArray keyArray;
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(id);
                fe.DataValidations.Add(keyArray);
                throw fe;
            }
        }

        public void ValidateMaxPortfolio<T>(IQueryable<T> objContext, string obj, string nombre, string Codigo)
        {
            if (objContext.Count() > 25)
            {
                //CodigoServicio duplicado
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(nombre);
                keyArray.Parametros.Add(obj);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        public void ValidateUnicidad<T>(IQueryable<T> objContext, string obj, string nombre, string Codigo)
        {
            if (objContext.Count() > 0)
            {
                //CodigoServicio duplicado
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(nombre);
                keyArray.Parametros.Add(obj);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        public void ValidateUnicidad<T>(IQueryable<T> objContext, string nombre, string valor, string nombre2, string valor2, string Codigo)
        {
            if (objContext.Count() > 0)
            {
                //CodigoServicio duplicado
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(nombre);
                keyArray.Parametros.Add(valor);
                keyArray.Parametros.Add(nombre2);
                keyArray.Parametros.Add(valor2);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        public void ValidateUnicidad<T>(IQueryable<T> objContext, string Codigo)
        {
            if (objContext.Count() > 0)
            {
                //CodigoServicio duplicado
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        public void ValidateUnicidad<T>(IQueryable<T> objContext, string[] obj, string[] nombre, string Codigo)
        {
            if (objContext.Count() > 0)
            {
                //CodigoServicio duplicado
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                for (var i = 0; i < obj.Length; i++) {
                    keyArray.Parametros.Add(nombre[i]);
                    keyArray.Parametros.Add(obj[i]);
                }
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        public void ValidateSiAEntoncesB(object objA, string nombreCampoA, object objB, string nombreCampoB, string Codigo)
        {
            if (objA != null && objB == null)
            {
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(objA.ToString());
                keyArray.Parametros.Add(nombreCampoA);
                keyArray.Parametros.Add(nombreCampoB);

                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }

        public void validarIgualdad(object objA, object objB, string nombreEntidad, string Codigo)
        {
            if (!objA.Equals(objB))
            {
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(nombreEntidad);

                fe.DataValidations.Add(keyArray);
                valida = false;
            }
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
                catch (M4TraderApplicationException ex)
                {
                    resultadosError.Add(ex.Message);
                    resultado.Resultado = eResult.Error;
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
                    resultadosError.Add(ex.Message);
                    resultado.Resultado = eResult.Error;
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
                MensajeError =  resultadosError.ToArray();
                Resultado = (MensajeError.Length > 0 && MensajeOk.Length > 0) ? eResult.Warning : (MensajeError.Length == 0 && MensajeOk.Length > 0) ? eResult.Ok : (MensajeError.Length > 0 && MensajeOk.Length == 0) ? eResult.Error : eResult.Info;
                Detalle = Objdetalle;
            }

            public void SetResponseError(string mensajeError, object Objdetalle)
            {
                ConcurrentBag<string> resultadosOk = new ConcurrentBag<string>();
                ConcurrentBag<string> resultadosError = new ConcurrentBag<string>();

                resultadosError.Add(mensajeError);
                

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

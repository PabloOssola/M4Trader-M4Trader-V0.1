using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.server.Services;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace M4Trader.ordenes.server.Helpers
{
    public enum EstadoOrden
    {
        Ingresada = 1,
        Cancelar = 2,
        Expirada = 3,
        Confirmada = 4,
        Aplicada = 5,
        AplicadaParcial = 6,
        RechazoMercado = 7,
        EnMercado = 8,
        Bloqueada = 9
    }

    public enum TipoVigencia
    {
        NoAplica = 1,
        DiasHabiles = 2,
        Horas = 3
    }

    public static class OrdenHelper
    {
        private const string CONST_ERROR_TIMESTAMP = "La orden ha sido modificada por otro usuario de su institución.\n Por favor actualice los datos y reintente en 5 segundos nuevamente.";

        #region EstadosOrdenes
        public static void InsertarOrden(OrdenEntity orden)
        {
            OrdenesDAL.InsertarOrden(orden);
        }

        public static void ActualizarOrden(OrdenEntity orden)
        {
            OrdenesDAL.ActualizarOrden(orden);
        }

        public static void CancelarOrden(OrdenEntity orden, byte[] timeStamp)
        {
            CheckConcurrenciaOrden(orden, timeStamp);
            ValidarEstadoPrevioCancelar(orden);
            orden.IdEstado = (int)EstadoOrden.Cancelar;
            OrdenesDAL.CancelarOrden(orden);
            ProductoEntity producto = CachingManager.Instance.GetProductoById(orden.IdProducto);
            if (producto.IdTipoProducto == (byte)TiposProducto.FACTURAS)
            {
                ProductosDAL.EliminarPortfolioComposicion(producto.IdProducto);
            }
        }

        public static void AltaOrdenDMA(OrdenEntity orden)
        {
            orden.IdPersona = MAEUserSession.Instancia.IdPersona;

            //si es cliente en IDPersona va el padre, y en IdEnNombre de va el propio
            //en el resto, en idPersona va la persona del user logueado, y nada en IdEnNombreDe
            if (MAEUserSession.Instancia.IdTipoPersona == (byte)TipoPersona.CLIENTE)
            {
                orden.IdEnNombreDe = orden.IdPersona;
                orden.IdPersona = CachingManager.Instance.GetPadreByIdHijo(orden.IdPersona).IdParty;
            }

            InsertarOrden(orden);
            /*generar bitacora*/
            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.CrearOrden, "Creación de la orden Nro:" + orden.NumeroOrdenInterno, (EstadoOrden)orden.IdEstado, null, (SourceEnum)orden.IdSourceApplication));

            int IdParaAutoConfirmacion = orden.IdEnNombreDe == null ? orden.IdPersona : (int)orden.IdEnNombreDe;
            PartyEntity persona = CachingManager.Instance.GetPersonaById(IdParaAutoConfirmacion);
            orden.AutoConfirmar = !CachingManager.Instance.GetConfirmacionManual(orden.IdProducto, persona.IdParty, (byte)orden.IdSourceApplication);


            if (orden.AutoConfirmar)
            {
                try
                {
                    orden.IdEstado = (int)EstadoOrden.Confirmada;
                    ConfirmarOrden(orden, (SourceEnum)orden.IdSourceApplication, orden.Timestamp);
                }
                catch (M4TraderApplicationException m)
                {
                    throw new MAEFixApplicationException(m.Message)
                    {
                        IdOrden = orden.IdOrden,
                        NumeroOrdenInterno = orden.NumeroOrdenInterno,
                        Timestamp = BitConverter.ToString(orden.Timestamp, 0)
                    };
                }
            }
        }

        public static bool CheckOrdenActivaEnMercadoByIdProducto(int idProducto)
        {
            return OrdenesDAL.CheckOrdenActivaEnMercadoByIdProducto(idProducto);
        }



        //public static void AltaOrdenPortfolio(OrdenEntity orden)
        //{
        //    orden.IdPersona = MAEUserSession.Instancia.IdPersona;

        //    //si es cliente en IDPersona va el padre, y en IdEnNombre de va el propio
        //    //en el resto, en idPersona va la persona del user logueado, y nada en IdEnNombreDe
        //    if (MAEUserSession.Instancia.IdTipoPersona == (byte)TipoPersona.CLIENTE)
        //    {
        //        orden.IdEnNombreDe = orden.IdPersona;
        //        orden.IdPersona = CachingManager.Instance.GetPadreByIdHijo(orden.IdPersona).IdParty;
        //    }

        //    InsertarOrden(orden);
        //    /*generar bitacora*/
        //    LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.CrearOrden, "Creación de la orden Nro:" + orden.NumeroOrdenInterno, (EstadoOrden)orden.IdEstado, null, (SourceEnum)orden.IdSourceApplication));
        //}

        //public static void ConfirmarOrdenPortfolio(OrdenEntity orden) { 
        //    int IdParaAutoConfirmacion = orden.IdEnNombreDe == null ? orden.IdPersona : (int)orden.IdEnNombreDe;
        //    PartyEntity persona = CachingManager.Instance.GetPersonaById(IdParaAutoConfirmacion);
        //    orden.AutoConfirmar = !CachingManager.Instance.GetConfirmacionManual(orden.IdProducto, persona.IdParty, (byte)orden.IdSourceApplication);


        //    if (orden.AutoConfirmar)
        //    {
        //        try
        //        {
        //            orden.IdEstado = (int)EstadoOrden.Confirmada;
        //            ConfirmarOrden(orden, (SourceEnum)orden.IdSourceApplication, orden.Timestamp);
        //        }
        //        catch (M4TraderApplicationException m)
        //        {
        //            throw new MAEFixApplicationException(m.Message)
        //            {
        //                IdOrden = orden.IdOrden,
        //                NumeroOrdenInterno = orden.NumeroOrdenInterno,
        //                Timestamp = BitConverter.ToString(orden.Timestamp, 0)
        //            };
        //        }
        //    }
        //}


        public static void NotificarDesAsociacionProductoPortfolio(int idProducto, string commandName, string key)
        {
            NotificacionPortfolioProducto noti = new NotificacionPortfolioProducto();
            noti.idProducto = idProducto;
            noti.CommandName = commandName;
            noti.key = key;
            noti.IdTipoNotificacion = (byte)TiposNotificaciones.DesAsociacionProductoPortfolio;
            EventHelperService.Instance.EnQueueMessage(noti);
        }

        public static void NotificarAsociacionProductoPortfolio(ProductoEntity producto, decimal? valorizacion, string key, string personas, int idEmpresa, DTOPortfolio portfolio, byte idMercado)
        {
            NotificacionPortfolioProducto noti = new NotificacionPortfolioProducto();
            noti.idProducto = producto.IdProducto;
            noti.IdMoneda = producto.IdMoneda;
            noti.Moneda = CachingManager.Instance.GetMonedaById(producto.IdMoneda).Descripcion;
            noti.key = key;
            ProductoPorMercadoEntity ppm = CachingManager.Instance.GetProductoPorMercadoByProductoYMercado(idMercado, producto.IdProducto);
            noti.PrecioReferencia = ppm.PrecioReferencia;
            noti.PrecioCierre = ppm.PrecioCierre;
            noti.CodigoProducto = producto.Codigo;
            noti.DescripcionProducto = producto.Descripcion;
            noti.CommandName = "AltaPortfolioEmpresaComposicionCommand";
            noti.IdTipoNotificacion = (byte)TiposNotificaciones.AsociacionProductoPortfolio;
            noti.Valorizacion = valorizacion;
            noti.Codigo = portfolio.Codigo;
            noti.Nombre = portfolio.Nombre;
            noti.Rueda = producto.Rueda;
            noti.PorDefecto = true;
            noti.Personas = personas;
            noti.IdEmpresa = idEmpresa;
            EventHelperService.Instance.EnQueueMessage(noti);
        }
        #endregion

        public static string AltaOrden(OrdenEntity orden)
        {
            /*Actualizar Orden*/
            InsertarOrden(orden);
            /*generar bitacora*/
            SourceEnum source = (SourceEnum)orden.IdSourceApplication;
            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.CrearOrden, "Creación de la orden Nro:" + orden.NumeroOrdenInterno, (EstadoOrden)orden.IdEstado, null, source));

            int IdParaAutoConfirmacion = orden.IdEnNombreDe == null ? orden.IdPersona : (int)orden.IdEnNombreDe;
            PartyEntity persona = CachingManager.Instance.GetPersonaById(IdParaAutoConfirmacion);

            orden.AutoConfirmar = !CachingManager.Instance.GetConfirmacionManual(orden.IdProducto, persona.IdParty, (byte)orden.IdSourceApplication);
            if (orden.AutoConfirmar)
            {
                orden.IdEstado = (int)EstadoOrden.Confirmada;
                OrdenHelper.ConfirmarOrden(orden, source, orden.Timestamp);
            }
            return "Alta Exitosa Orden Nro: " + orden.NumeroOrdenInterno;
        }

        public static int GetRemanentes(int idOrden)
        {
            return OrdenesDAL.GetRemanentes(idOrden);
        }

        public static void InsertarOrdenOperacion(OrdenOperacionEntity request, OrdenEntity ordenOriginal, byte[] timestamp, byte? idEstado)
        {
            CheckConcurrenciaOrden(ordenOriginal, timestamp);
            OrdenesDAL.InsertarOrdenOperacion(request, idEstado, string.Empty);
        }

        public static void CheckConcurrenciaOrden(OrdenEntity orden, byte[] timeStamp)
        {
            if (Convert.ToBase64String(orden.Timestamp) != Convert.ToBase64String(timeStamp))
            {
                throw new M4TraderApplicationException(CodigosMensajes.FE_CAMBIO_ULTIMA_ACTUALIZACION, CONST_ERROR_TIMESTAMP);
            }
        }

        public static string ConfirmarOrden(OrdenEntity orden, SourceEnum source, byte[] timeStamp)
        {
            if (!orden.AutoConfirmar)
            {
                CheckConcurrenciaOrden(orden, timeStamp);
            }
            ValidarEstadoPrevioConfirmar(orden);
            FixOrdenEntity fixOrden;
            FixOrdenesResponseEntity resultado = new FixOrdenesResponseEntity();
            fixOrden = PrepararOrdenEnviarMercado(orden, FixTipoAccionEnum.New);

            FixOrdenesEntity ords = new FixOrdenesEntity
            {
                Accion = FixAccionEnum.ALTA_ORDEN
            };
            ords.Ordenes.Add(fixOrden);
            string errorException = string.Empty;
            Exception e1 = null;
            try
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(MAEUserSession.Instancia.InCourseRequest.Value, MAEUserSession.Instancia.IdUsuario) { Fecha = DateTime.Now, Descripcion = "Inicio de llamada a EnviarOrdenesAlMercado", Exception = null, RequestId = MAEUserSession.Instancia.InCourseRequest, IdLogCodigoAccion = (byte)LogCodigoAccion.ConfirmarOrden });
                resultado = WCFHelper.ExecuteService<IOrdenService, FixOrdenesResponseEntity>(ConfiguracionSistemaURLsEnumDestino.OrdenesFIX, i => i.EnviarOrdenesAlMercado(ords));
            }
            catch (Exception e)
            {
                resultado.RespuestaOk = false;
                resultado.DescripcionError = "Error en la comunicación con FIX";
                errorException = e.Message;
                e1 = e;
            }
            if (resultado.RespuestaOk)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(MAEUserSession.Instancia.InCourseRequest.Value, MAEUserSession.Instancia.IdUsuario) { Fecha = DateTime.Now, Descripcion = "Llamada a EnviarOrdenesAlMercado exitosa", Exception = null, RequestId = MAEUserSession.Instancia.InCourseRequest, IdLogCodigoAccion = (byte)LogCodigoAccion.ConfirmarOrden });
                orden.IdEstado = (int)EstadoOrden.Confirmada;
                DateTime? SettlementDate = null;
                if (orden.Plazo.HasValue)
                {
                    SettlementDate = (byte)orden.Plazo == (byte)PlazoOrdenEnum.Futuro ? orden.FechaLiquidacion : null;
                }
                OrdenesDAL.CambioEstadoOrden(orden.IdOrden, orden.IdEstado, orden.NumeroOrdenMercado, null, orden.OperoPorTasa, orden.PrecioVinculado, orden.PrecioLimite, orden.Valorizacion, SettlementDate); //Confirmada
                LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.ConfirmarOrden, "Envio de orden Nro.:" + orden.NumeroOrdenInterno + " al Mercado:" + fixOrden.Mercado, (EstadoOrden)orden.IdEstado, null, source));
                return "Se envio al mercado la orden Nro.:" + orden.NumeroOrdenInterno.ToString();
            }
            else
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(MAEUserSession.Instancia.InCourseRequest.Value, MAEUserSession.Instancia.IdUsuario) { Fecha = DateTime.Now, Descripcion = resultado.DescripcionError + ": " + errorException, Exception = e1, RequestId = MAEUserSession.Instancia.InCourseRequest, IdLogCodigoAccion = (byte)LogCodigoAccion.ConfirmarOrden });
                string respuesta = "Surgio un error en la transaccion. Por favor, consulte con su administrador. Envio de orden Nro.:" + orden.NumeroOrdenInterno;
                LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.ErrorAlEnviarAlMercado, "Envio de orden Nro.:" + orden.NumeroOrdenInterno + " al Mercado:" + fixOrden.Mercado, (EstadoOrden)orden.IdEstado, null, source));

                throw new M4TraderApplicationException(respuesta);
            }
        }

        public static void ActualizarOrdenes()
        {
            List<OrdenEntity> ordenes = OrdenesDAL.ObtenerOrdenesPendientes();
            List<OrdenEntity> pendientes = ordenes.FindAll(x => x.IdEstado == (byte)EstadoOrden.Ingresada
                                                        || x.IdEstado == (byte)EstadoOrden.Confirmada
                                                        || x.IdEstado == (byte)EstadoOrden.EnMercado
                                                        || x.IdEstado == (byte)EstadoOrden.AplicadaParcial);
            FixOrdenesResponseEntity resultado = new FixOrdenesResponseEntity();
            Exception e1 = new Exception();
            foreach (OrdenEntity orden in pendientes)
            {
                try
                {
                    FixOrdenEntity fixOrden = ActualizarOrdenMercado(orden, FixTipoAccionEnum.Change);

                    FixOrdenesEntity ords = new FixOrdenesEntity
                    {
                        Accion = FixAccionEnum.REPORTE_ESTADO
                    };
                    ords.Ordenes.Add(fixOrden);
                    resultado = WCFHelper.ExecuteService<IOrdenService, FixOrdenesResponseEntity>(ConfiguracionSistemaURLsEnumDestino.OrdenesFIX, i => i.EnviarOrdenesAlMercado(ords));
                }
                catch (Exception e)
                {
                    resultado.RespuestaOk = false;
                    resultado.DescripcionError = "Error en la comunicación con FIX";
                    e1 = e;
                }
            }

        }

        public static bool ObtenerOrdenOperacionByProducto(int idProducto)
        {
            List<OrdenOperacionEntity> ordenes = OrdenesDAL.ObtenerOrdenesOperacionByProducto(idProducto);
            if (ordenes.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //public static void CambiarEstadoOrden(OrdenEntity orden)
        //{
        //    OrdenesDAL.CambioEstadoOrden(orden.IdOrden, orden.IdEstado, orden.NumeroOrdenMercado, orden.EquivalentRate, orden.OperoPorTasa, orden.PrecioVinculado, orden.PrecioLimite, orden.Valorizacion, orden.FechaLiquidacion);
        //}

        public static string CancelarOrden(OrdenEntity orden, byte IdMotivo, SourceEnum source, byte[] timestamp)
        {
            orden.IdMotivoBaja = IdMotivo;
            /*Actualizar Orden*/
            CancelarOrden(orden, timestamp);

            /*generar bitacora*/
            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.ModificaOrden, "Cancelación de orden Nro: " + orden.NumeroOrdenInterno, (EstadoOrden)orden.IdEstado, IdMotivo, source));

            return "Cancelacion Exitosa Orden Numero:" + orden.NumeroOrdenInterno;
        }

        public static string CancelarOrdenMercado(OrdenEntity orden, byte IdMotivo, SourceEnum source, byte[] timestamp)
        {
            FixOrdenesResponseEntity resultado;

            FixOrdenEntity fixOrden = CancelarOrdenMercado(orden, FixTipoAccionEnum.Delete);

            FixOrdenesEntity ords = new FixOrdenesEntity
            {
                Ordenes = new List<FixOrdenEntity>(),
                Accion = FixAccionEnum.CANCELAR_ORDEN
            };

            ords.Ordenes.Add(fixOrden);
            resultado = WCFHelper.ExecuteService<IOrdenService, FixOrdenesResponseEntity>(ConfiguracionSistemaURLsEnumDestino.OrdenesFIX, i => i.EnviarOrdenesAlMercado(ords));

            if (resultado.RespuestaOk)
            {
                //*Actualizar Orden*/
                orden.IdMotivoBaja = IdMotivo;
                DateTime? SettlementDate = null;
                if (orden.Plazo.HasValue)
                {
                    SettlementDate = (byte)orden.Plazo == (byte)PlazoOrdenEnum.Futuro ? orden.FechaLiquidacion : null;
                }
                OrdenesDAL.CambioEstadoOrden(orden.IdOrden, orden.IdEstado, orden.NumeroOrdenMercado, null, orden.OperoPorTasa, orden.PrecioVinculado, orden.PrecioLimite, orden.Valorizacion, SettlementDate);
                ProductoEntity producto = CachingManager.Instance.GetProductoById(orden.IdProducto);
                if (producto.IdTipoProducto == (byte)TiposProducto.FACTURAS)
                {
                    ProductosDAL.EliminarPortfolioComposicion(producto.IdProducto);
                }
                LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.EnviarCancelacionMercado, "Envio de cancelación de la orden Nro.:" + orden.NumeroOrdenInterno + " al Mercado: " + fixOrden.Mercado, (EstadoOrden)orden.IdEstado, IdMotivo, source));

                return "Se envio al mercado la cancelacion de la Orden Nro:" + orden.NumeroOrdenInterno;
            }
            else
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(MAEUserSession.Instancia.InCourseRequest.Value, MAEUserSession.Instancia.IdUsuario) { Fecha = DateTime.Now, Descripcion = resultado.DescripcionError, Exception = null, RequestId = MAEUserSession.Instancia.InCourseRequest, IdLogCodigoAccion = (byte)LogCodigoAccion.EnviarCancelacionMercado });

                string respuesta = "Surgio un error en la transaccion. Por favor, consulte con su administrador. RequestID: " + MAEUserSession.Instancia.InCourseRequest;
                throw new M4TraderApplicationException(respuesta);
            }
        }


        public static string ActualizarOrden(OrdenEntity orden, int r_id, SourceEnum source, byte[] timeStamp)
        {
            ValidarEstadoPrevioModificar(orden);
            CheckConcurrenciaOrden(orden, timeStamp);
            ActualizarOrden(orden);

            /*generar bitacora*/
            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(r_id, LogCodigoAccion.ModificaOrden, "Se realizo modificacion de orden Nro: " + orden.NumeroOrdenInterno, (EstadoOrden)orden.IdEstado, null, source));

            return "Actualizacion Exitosa Orden Nro:" + orden.NumeroOrdenInterno;
        }

        public static string ActualizarOrdenMercado(OrdenEntity orden, int r_id, SourceEnum source, byte[] timeStamp)
        {
            FixOrdenesResponseEntity resultado;
            ValidarEstadoPrevioModificar(orden);
            CheckConcurrenciaOrden(orden, timeStamp);
            FixOrdenEntity fixOrden = ActualizarOrdenMercado(orden, FixTipoAccionEnum.Change);

            FixOrdenesEntity ords = new FixOrdenesEntity
            {
                Accion = FixAccionEnum.MODIFICAR_ORDEN
            };
            ords.Ordenes.Add(fixOrden);
            resultado = WCFHelper.ExecuteService<IOrdenService, FixOrdenesResponseEntity>(ConfiguracionSistemaURLsEnumDestino.OrdenesFIX, i => i.EnviarOrdenesAlMercado(ords));

            if (resultado.RespuestaOk)
            {
                /*generar bitacora*/
                LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(r_id, LogCodigoAccion.EnviarModificacionMercado, "Envio de modificacion de la orden Nro: " + orden.NumeroOrdenInterno + " en el Mercado: " + fixOrden.Mercado, (EstadoOrden)orden.IdEstado, null, source));

                return "Se envio al mercado la actualizacion de la Orden Nro:" + orden.NumeroOrdenInterno;
            }
            else
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(MAEUserSession.Instancia.InCourseRequest.Value, MAEUserSession.Instancia.IdUsuario) { Fecha = DateTime.Now, Descripcion = resultado.DescripcionError, Exception = null, RequestId = MAEUserSession.Instancia.InCourseRequest, IdLogCodigoAccion = (byte)LogCodigoAccion.EnviarModificacionMercado });

                string respuesta = "Surgio un error en la transaccion. Por favor, consulte con su administrador. RequestID: " + MAEUserSession.Instancia.InCourseRequest;
                throw new M4TraderApplicationException(respuesta);
            }
        }

        public static FixOrdenEntity PrepararOrdenEnviarMercado(OrdenEntity orden, FixTipoAccionEnum accion)
        {
            FixOrdenEntity response;

            PartyEntity persona = CachingManager.Instance.GetPersonaById(orden.IdPersona);
            MercadoEntity mercado = CachingManager.Instance.GetMercadoById(orden.IdMercado);
            MonedaEntity moneda = CachingManager.Instance.GetMonedaById(orden.IdMoneda);
            ProductoEntity producto = CachingManager.Instance.GetProductoById(orden.IdProducto);
            TipoOrdenEntity tipoOrden = CachingManager.Instance.GetTipoOrdenById(orden.IdTipoOrden);
            PartyEntity personaEnNombreDe = null;
            if (orden.IdEnNombreDe.HasValue)
            {
                personaEnNombreDe = CachingManager.Instance.GetPersonaById(orden.IdEnNombreDe.Value);
            }
            if (string.IsNullOrEmpty(orden.Rueda) && CachingManager.Instance.GetProductoById(orden.IdProducto) != null)
            {
                orden.Rueda = CachingManager.Instance.GetProductoById(orden.IdProducto).Rueda;
            }
            response = FixOrdenHelper.FixOrden_AccionIngresar(orden, accion, persona, mercado, producto, moneda, tipoOrden, personaEnNombreDe);

            return response;
        }

        public static FixOrdenEntity ActualizarOrdenMercado(OrdenEntity orden, FixTipoAccionEnum accion)
        {
            FixOrdenEntity response;

            PartyEntity persona = CachingManager.Instance.GetPersonaById(orden.IdPersona);
            MercadoEntity mercado = CachingManager.Instance.GetMercadoById(orden.IdMercado);
            MonedaEntity moneda = CachingManager.Instance.GetMonedaById(orden.IdMoneda);
            ProductoEntity producto = CachingManager.Instance.GetProductoById(orden.IdProducto);
            response = FixOrdenHelper.FixOrden_AccionActualizar(orden, accion, persona, mercado, producto, moneda);

            return response;
        }

        public static FixOrdenEntity CancelarOrdenMercado(OrdenEntity orden, FixTipoAccionEnum accion)
        {
            FixOrdenEntity response;

            PartyEntity persona = CachingManager.Instance.GetPersonaById(orden.IdPersona);
            MercadoEntity mercado = CachingManager.Instance.GetMercadoById(orden.IdMercado);
            MonedaEntity moneda = CachingManager.Instance.GetMonedaById(orden.IdMoneda);
            ProductoEntity producto = CachingManager.Instance.GetProductoById(orden.IdProducto);
            response = FixOrdenHelper.FixOrden_AccionCancelar(orden, accion, persona, mercado, producto, moneda);

            return response;
        }

        public static string ReRegistrarse(string mercado)
        {
            FixOrdenesResponseEntity resultado;
            resultado = WCFHelper.ExecuteService<IOrdenService, FixOrdenesResponseEntity>(ConfiguracionSistemaURLsEnumDestino.OrdenesFIX, i => i.ReRegistrarse(mercado));

            if (resultado.RespuestaOk)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(MAEUserSession.Instancia.InCourseRequest.Value, MAEUserSession.Instancia.IdUsuario) { Fecha = DateTime.Now, IdLogCodigoAccion = (byte)LogCodigoAccion.ReRegistrarse, Descripcion = "Re Registrar Security List en el Mercado: " + mercado, Exception = null });

                return "Se envio solicitud de re registrarse al mercado";
            }
            else
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(MAEUserSession.Instancia.InCourseRequest.Value, MAEUserSession.Instancia.IdUsuario) { Fecha = DateTime.Now, IdLogCodigoAccion = (byte)LogCodigoAccion.ReRegistrarse, Descripcion = resultado.DescripcionError, Exception = null });

                string respuesta = "Surgio un error en el envio solicitud de re registrarse al mercado. RequestID: " + MAEUserSession.Instancia.InCourseRequest;
                throw new M4TraderApplicationException(respuesta);
            }
        }

        public static OrdenEntity ObtenerOrdenbyID(int IdOrden)
        {
            OrdenEntity orden = OrdenesDAL.ObtenerOrdenbyID(IdOrden);

            return orden;
        }

        public static OrdenEntity ObtenerOrdenbyNumeroOrdenInterno(int NumeroOrdenInterno)
        {
            return OrdenesDAL.ObtenerOrdenbyNumeroOrdenInterno(NumeroOrdenInterno);
        }

        public static List<LogAuditoriaOrdenEntity> ObtenerLogAuditoriaOrden(int IdOrden, int IdUsuario, int pageNumber, int pageSize)
        {
            List<LogAuditoriaOrdenEntity> respuesta = OrdenesDAL.ObtenerLogAuditoriaOrden(IdOrden, IdUsuario);

            return respuesta;
        }

        public static List<OrdenIngresadaEntity> ObtenerOrdenesByEstadoID(int estadoId)
        {
            return OrdenesDAL.ObtenerOrdenesByEstadoID(estadoId);
        }

        public static List<OrdenIngresadaEntity> ObtenerOrdenesByEstadoIDForApi(int estadoId)
        {
            var ordenes = OrdenesDAL.ObtenerOrdenesByEstadoID(estadoId);

            // Modifica el estado de las ordenes a bloqueadas.
            foreach (var orden in ordenes)
            {
                orden.IdEstado = (byte)EstadoOrden.Bloqueada;
                OrdenesDAL.CambioEstadoOrden(orden.OrderID, orden.IdEstado, string.Empty, null, false, null, null, null);
                LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.OrderID, LogCodigoAccion.BloqueoOrden, "Bloqueo orden Nro.:" + orden.OrderNumber + " proveniente desde Webservice externo", (EstadoOrden)orden.IdEstado, null, SourceEnum.Api));
            }

            return ordenes;
        }

        public static OrdenEntity DesbloquearOrden(int idOrden, SourceEnum source, byte[] timeStamp = null)
        {
            OrdenEntity orden = OrdenesDAL.ObtenerOrdenbyID(idOrden);
            if (orden == null || orden.IdOrden < 0)
            {
                throw new M4TraderApplicationException("Orden inexistente");
            }
            if (timeStamp != null)
            {
                CheckConcurrenciaOrden(orden, timeStamp);
            }

            if (orden.IdEstado != (byte)EstadoOrden.Bloqueada)
            {
                throw new M4TraderApplicationException("La orden debe de encontrarse en estado Bloqueada");
            }
            orden.IdEstado = (byte)EstadoOrden.Ingresada;
            DateTime? SettlementDate = null;
            if (orden.Plazo.HasValue)
            {
                SettlementDate = (byte)orden.Plazo == (byte)PlazoOrdenEnum.Futuro ? orden.FechaLiquidacion : null;
            }
            OrdenesDAL.CambioEstadoOrden(orden.IdOrden, orden.IdEstado, orden.NumeroOrdenMercado, orden.EquivalentRate, orden.OperoPorTasa, orden.PrecioVinculado, orden.PrecioLimite, orden.Valorizacion, SettlementDate);

            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.DesbloqueoOrden, "Desbloqueo de orden Nro.:" + orden.NumeroOrdenInterno, (EstadoOrden)orden.IdEstado, null, source));

            return orden;
        }


        #region "Validacion Estados"
        public static void ValidarEstadoPrevioCancelar(OrdenEntity orden)
        {
            if (orden != null)
            {
                int IdEstadoOrden = orden.IdEstado;

                List<EstadoOrden> _estadosValidos = new List<EstadoOrden>
                {
                    EstadoOrden.Ingresada,
                    EstadoOrden.EnMercado,
                    EstadoOrden.AplicadaParcial,
                    EstadoOrden.Confirmada
                };

                if (!_estadosValidos.Contains((EstadoOrden)IdEstadoOrden))
                {
                    FunctionalException fe = new FunctionalException();
                    KeyArray keyArray = new KeyArray
                    {
                        Codigo = CodigosMensajes.FE_ESTADO_ORDEN_NO_VALIDO
                    };

                    keyArray.Parametros.Add(orden.NumeroOrdenInterno.ToString());
                    keyArray.Parametros.Add(EstadoOrden.Ingresada.ToString() + ", " + EstadoOrden.EnMercado.ToString() + ", " + EstadoOrden.AplicadaParcial.ToString());

                    fe.DataValidations.Add(keyArray);
                    throw fe;
                }
            }
        }

        public static void ValidarEstadoPrevioModificar(OrdenEntity orden)
        {
            if (orden != null)
            {
                int IdEstadoOrden = orden.IdEstado;
                List<EstadoOrden> _estadosValidos = new List<EstadoOrden>
                {
                    EstadoOrden.Ingresada,
                    EstadoOrden.EnMercado,
                    //EstadoOrden.RechazoMercado,
                    EstadoOrden.AplicadaParcial
                };

                if (!_estadosValidos.Contains((EstadoOrden)IdEstadoOrden))
                {
                    FunctionalException fe = new FunctionalException();
                    KeyArray keyArray = new KeyArray
                    {
                        Codigo = CodigosMensajes.FE_ESTADO_ORDEN_NO_VALIDO
                    };

                    keyArray.Parametros.Add(orden.NumeroOrdenInterno.ToString());
                    keyArray.Parametros.Add(EstadoOrden.Ingresada.ToString() + ", " + EstadoOrden.EnMercado.ToString() + ", " + EstadoOrden.AplicadaParcial.ToString());

                    fe.DataValidations.Add(keyArray);
                    throw fe;
                }
            }
        }

        public static void ValidarEstadoPrevioConfirmar(OrdenEntity orden)
        {
            if (orden != null)
            {
                int IdEstadoOrden = orden.IdEstado;
                List<EstadoOrden> _estadosValidos = new List<EstadoOrden>
                {
                    EstadoOrden.Ingresada,
                    EstadoOrden.Confirmada,
                    EstadoOrden.RechazoMercado
                };

                if (!_estadosValidos.Contains((EstadoOrden)IdEstadoOrden))
                {
                    FunctionalException fe = new FunctionalException();
                    KeyArray keyArray = new KeyArray
                    {
                        Codigo = CodigosMensajes.FE_ESTADO_ORDEN_NO_VALIDO
                    };

                    keyArray.Parametros.Add(orden.NumeroOrdenInterno.ToString());
                    keyArray.Parametros.Add(EstadoOrden.Ingresada.ToString() + ", " + EstadoOrden.Confirmada.ToString());

                    fe.DataValidations.Add(keyArray);
                    throw fe;
                }
            }
        }

        #endregion

        #region Orden Service
        public static void RecibirGarantiasRespuesta(FixGarantiasEntity garantia, Guid guid)
        {
            if (garantia != null)
            {
                NotificacionGarantias noti = new NotificacionGarantias
                {
                    CommandName = "CollateralReport"
                };
                CollateralReport(garantia, guid);
                noti.id = garantia.IdCollateralReport;
                noti.ClearingHouse = garantia.ClearingHouse;
                noti.Dador = garantia.Dador;
                noti.Receptor = garantia.Receptor;
                noti.ConsumedAmount = garantia.ConsumedAmount;
                noti.ConsumedChips = garantia.ConsumedChips;
                noti.Moneda = garantia.Moneda;
                noti.TotalAmount = garantia.TotalAmount;
                noti.IdTipoNotificacion = (byte)TiposNotificaciones.CollateralReport;
                EventHelperService.Instance.EnQueueMessage(noti);
            }
        }

        public static void RecibirTradeCaptureReportRespuesta(FixTradeCaptureReportInfo tradeCaptureReport, Guid guid)
        {
            if (tradeCaptureReport != null)
            {
                NotificacionGarantias noti = new NotificacionGarantias
                {
                    CommandName = "TradeCaptureReport"
                };
                TradeCaptureReport(tradeCaptureReport, guid);
                //TODO: cargar los datos necesarios para la notificacion
                noti.IdTipoNotificacion = (byte)TiposNotificaciones.TradeCaptureReport;
                //EventHelperService.Instance.EnQueueMessage(noti);
            }
        }

        public static void RecibirHeartBeat()
        {
            NotificacionHeartBeat noti = new NotificacionHeartBeat
            {
                MarketData = false
            };
            noti.IdTipoNotificacion = (byte)TiposNotificaciones.HeartBeat;
            EventHelperService.Instance.EnQueueMessage(noti);
        }

        public static void RecibirOrdenRespuesta(FixOrdenRespuestaEntity ordenMercado, OrdenEntity ordenInterna, Guid guid)
        {
            if (ordenMercado.NumeroOrdenLocal != string.Empty)
            {
                ordenInterna = ObtenerOrdenbyID(Convert.ToInt32(ordenMercado.NumeroOrdenLocal));

                if (ordenInterna != null)
                {
                    byte estadoActual = ordenInterna.IdEstado;
                    ordenInterna.NumeroOrdenMercado = ordenMercado.NumeroOrdenMercado;
                    ordenInterna.Valorizacion = ordenMercado.Valorizacion;
                    ordenInterna.OperoPorTasa = ordenMercado.OperoPorTasa == null ? false : true;

                    switch ((FixTipoEstadoOrdenEnum)ordenMercado.Estado)
                    {
                        case FixTipoEstadoOrdenEnum.New:
                            ordenInterna.IdEstado = (int)EstadoOrden.EnMercado;
                            break;
                        case FixTipoEstadoOrdenEnum.PartiallyFilled:
                            ordenInterna.IdEstado = (int)EstadoOrden.AplicadaParcial;
                            break;
                        case FixTipoEstadoOrdenEnum.Filled:
                            ordenInterna.IdEstado = (int)EstadoOrden.Aplicada;
                            break;
                        case FixTipoEstadoOrdenEnum.Canceled:
                            ordenInterna.IdEstado = (int)EstadoOrden.Cancelar;
                            break;
                        case FixTipoEstadoOrdenEnum.Rejected:
                            ordenInterna.IdEstado = (int)EstadoOrden.RechazoMercado;
                            break;
                        default:
                            break;
                    }


                    switch (ordenMercado.TipoEjecucion)
                    {
                        case FixTipoEjecucionOrdenEnum.New:
                        case FixTipoEjecucionOrdenEnum.Trade:
                            OrdenActivaMercado(ordenMercado, ordenInterna);
                            break;
                        case FixTipoEjecucionOrdenEnum.Replaced:
                            OrdenReemplazarMercado(ordenMercado, ordenInterna);
                            break;
                        case FixTipoEjecucionOrdenEnum.Canceled:
                            OrdenCancelarMercado(ordenMercado, ordenInterna, estadoActual);
                            break;
                        case FixTipoEjecucionOrdenEnum.Rejected:
                            OrdenRechazoMercado(ordenMercado, ordenInterna, estadoActual);
                            break;
                        case FixTipoEjecucionOrdenEnum.OrderStatus:
                            ActualizarPorOrderStatus(ordenMercado, ordenInterna, estadoActual);
                            break;
                        default:
                            LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(MAEUserSession.Instancia.InCourseRequest.Value, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "TipoEjecucion invalido: " + ordenMercado.TipoEjecucion.ToString(), Exception = null, IdLogCodigoAccion = (byte)LogCodigoAccion.AccionIncorrecta });
                            break;
                    }
                }
            }
        }

        private static void ActualizarPorOrderStatus(FixOrdenRespuestaEntity ordenMercado, OrdenEntity ordenInterna, byte estadoActual)
        {
            //switch ((FixTipoEstadoOrdenEnum)ordenMercado.Estado)
            //{
            //    case FixTipoEstadoOrdenEnum.New:
            //    case FixTipoEstadoOrdenEnum.PartiallyFilled:
            //    case FixTipoEstadoOrdenEnum.Filled:
            //        OrdenActivaMercado(ordenMercado, ordenInterna, noti);
            //        break;
            //    case FixTipoEstadoOrdenEnum.Canceled:
            //        OrdenCancelarMercado(ordenMercado, ordenInterna, estadoActual, noti);
            //        break;
            //    case FixTipoEstadoOrdenEnum.Rejected:
            //        OrdenRechazoMercado(ordenMercado, ordenInterna, estadoActual, noti);
            //        break;
            //    default:
            //        break;
            //}
        }

        private static void CollateralReport(FixGarantiasEntity garantia, Guid guid)
        {
            OrdenOperacionEntity ordenOperacion = new OrdenOperacionEntity();
            string accionRealizada = "Se recibio el reporte de garantias de id: " + garantia.IdCollateralReport + " en el  mercado: " + garantia.Mercado.ToString();
            DTOMercado mercado = CachingManager.Instance.GetMercadoByCode(garantia.Mercado.ToString());
            if (mercado == null || mercado.IdMercado <= 0)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "Mercado inexistente: " + garantia.Mercado.ToString(), Exception = null, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado });
                return;
            }
            DTOMoneda moneda = CachingManager.Instance.GetMonedaByISOCode(garantia.Moneda.ToString());
            if (moneda == null || moneda.IdMoneda <= 0)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario) { Fecha = DateTime.Now, Descripcion = "Moneda inexistente: " + garantia.Moneda.ToString(), Exception = null, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado });
                return;
            }
            GarantiasDAL.InsertarCollateralReport(garantia, moneda.IdMoneda);
        }

        private static void TradeCaptureReport(FixTradeCaptureReportInfo tradeCaptureReport, Guid guid)
        {
            OperacionHistoricoEntity operacionHistorico = ConvertToOperacionHistorico(tradeCaptureReport, guid, OrdenesApplication.Instance.SessionUsuarioProceso.IdUsuario);
            if (operacionHistorico == null)
            {
                return;
            }
            OperacionesHistoricasDAL.InsertarOperacionHistorica(operacionHistorico);
            //TODO: hacer elmetodo de insercion
            //GarantiasDAL.InsertarTradeCaptureReport(tradeCaptureReport, moneda.IdMoneda);
        }

        private static OperacionHistoricoEntity ConvertToOperacionHistorico(FixTradeCaptureReportInfo tradeCaptureReport, Guid guid, int idUsuarioConectado)
        {
            OperacionHistoricoEntity operacionHistorico = new OperacionHistoricoEntity();
            DTOMercado mercado = CachingManager.Instance.GetMercadoByCode(tradeCaptureReport.Market.ToString());
            if (mercado == null || mercado.IdMercado <= 0)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, idUsuarioConectado) { Fecha = DateTime.Now, Descripcion = "Mercado inexistente: " + tradeCaptureReport.Market.ToString(), Exception = null, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado });
                return null;
            }
            operacionHistorico.IdMercado = mercado.IdMercado;
            DTOMoneda moneda = CachingManager.Instance.GetMonedaByISOCode(tradeCaptureReport.Moneda.Value.ToString());
            if (moneda == null || moneda.IdMoneda <= 0)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, idUsuarioConectado) { Fecha = DateTime.Now, Descripcion = "Moneda inexistente: " + tradeCaptureReport.Moneda.ToString(), Exception = null, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado });
            }
            else
            {
                operacionHistorico.IdMoneda = moneda.IdMoneda;
            }
            ProductoEntity producto = CachingManager.Instance.GetProductoByCodigoAndIdMoneda(tradeCaptureReport.Producto, moneda.IdMoneda, tradeCaptureReport.Rueda);
            if (producto == null || producto.IdProducto <= 0)
            {
                LoggingHelper.Instance.AgregarLog(new LogProcesoEntity(guid, idUsuarioConectado) { Fecha = DateTime.Now, Descripcion = "Producto inexistente: " + tradeCaptureReport.Producto, Exception = null, IdLogCodigoAccion = (byte)LogCodigoAccion.RecibirRespuestaMercado });
                return null;
            }
            operacionHistorico.IdProducto = producto.IdProducto;
            operacionHistorico.FechaLiquidacion = tradeCaptureReport.FechaLiquidacion;
            operacionHistorico.Rueda = tradeCaptureReport.Rueda;
            operacionHistorico.TradeReportID = tradeCaptureReport.TradeReportID;
            operacionHistorico.IdPlazo = tradeCaptureReport.TipoPlazoLiquidacionOrden.HasValue ? (byte)tradeCaptureReport.TipoPlazoLiquidacionOrden : (byte?)null;
            operacionHistorico.PrecioTasa = tradeCaptureReport.Precio;
            operacionHistorico.Cantidad = tradeCaptureReport.Cantidad;
            operacionHistorico.EsAlta = tradeCaptureReport.EsAlta;
            operacionHistorico.OperoPorTasa = tradeCaptureReport.OperaPorTasa;
            operacionHistorico.Fecha = tradeCaptureReport.TradeDate;
            operacionHistorico.ProductoNombreLargo = tradeCaptureReport.ProductoNombreLargo;
            operacionHistorico.LastSpotRate = tradeCaptureReport.LastSpotRate;

            operacionHistorico.ReferencePrice = tradeCaptureReport.ReferencePrice;
            operacionHistorico.Valorizacion = tradeCaptureReport.Valorizacion;
            operacionHistorico.PartyComprador = tradeCaptureReport.Participantes.Find(x => x.Side == '1').Codigo;
            operacionHistorico.PartyVendedor = tradeCaptureReport.Participantes.Find(x => x.Side == '2').Codigo;
            operacionHistorico.MensajeTextoPlano = tradeCaptureReport.MensajeTextoPlano;
            return operacionHistorico;
        }

        private static void OrdenActivaMercado(FixOrdenRespuestaEntity ordenMercado, OrdenEntity ordenInterna)
        {
            ProductoEntity producto = CachingManager.Instance.GetProductoById(ordenInterna.IdProducto);
            OrdenOperacionEntity ordenOperacion = new OrdenOperacionEntity();
            string accionRealizada = "Se ingreso la orden Nro: " + ordenInterna.NumeroOrdenInterno + " en el  mercado: " + ordenMercado.Mercado;

            if (ordenInterna.IdEstado == (int)EstadoOrden.RechazoMercado && !string.IsNullOrEmpty(ordenMercado.RechazoTexto))
            {
                accionRealizada = "El mercado: " + ordenMercado.Mercado + " rechazo el ingreso. Motivos:" + ordenMercado.RechazoTexto;
            }

            decimal cantidadOferta = 0;
            decimal cantidadOperacion = 0;
            if (ordenMercado.NumeroOrdenMercado != null && ordenMercado.CantidadEjecutada > 0)
            {
                ordenOperacion.Precio = ordenMercado.PrecioMercado;
                ordenOperacion.Cantidad = ordenMercado.CantidadEjecutada;
                ordenOperacion.IdOrden = Convert.ToInt32(ordenMercado.NumeroOrdenLocal);
                ordenOperacion.NroOperacionMercado = ordenMercado.NroOperacionMercado;
                ordenOperacion.SpotRate = ordenMercado.SpotRate;
                ordenOperacion.OperoPorTasa = ordenMercado.OperoPorTasa == null ? false : (bool)ordenMercado.OperoPorTasa;
                ordenOperacion.PrecioVinculado = ordenMercado.PrecioVinculado;
                ordenOperacion.Valorizacion = ordenMercado.Valorizacion;
                OrdenesDAL.InsertarOrdenOperacion(ordenOperacion, ordenInterna.IdEstado, ordenInterna.NumeroOrdenMercado);
                //Al agredir la oferta, y pasar a ser operacion, se resta lo consumido en limiteOfertas y se suma en limiteoperaciones
                cantidadOferta = -(decimal)ordenOperacion.Precio * ordenOperacion.Cantidad;
                cantidadOperacion = -cantidadOferta;
                if (producto.IdTipoProducto == (byte)TiposProducto.FACTURAS)
                {
                    ProductosDAL.EliminarProducto(producto.IdProducto);
                }
            }
            else
            {
                DateTime? SettlementDate = null;
                if (ordenInterna.Plazo.HasValue)
                {
                    SettlementDate = (byte)ordenInterna.Plazo == (byte)PlazoOrdenEnum.Futuro ? ordenInterna.FechaLiquidacion : null;
                }
                bool operoTasa = ordenOperacion.OperoPorTasa = ordenMercado.OperoPorTasa == null ? false : (bool)ordenMercado.OperoPorTasa;
                OrdenesDAL.CambioEstadoOrden(ordenInterna.IdOrden, ordenInterna.IdEstado, ordenInterna.NumeroOrdenMercado, ordenMercado.SpotRate, operoTasa, ordenMercado.PrecioVinculado, (ordenMercado.PrecioOrden > 0) ? ordenMercado.PrecioOrden : (decimal?)null, ordenMercado.Valorizacion, SettlementDate);
                if (producto.IdTipoProducto == 7 && ordenMercado.TipoEjecucion == FixTipoEjecucionOrdenEnum.New && ordenMercado.Estado != FixEstadoOrdenEnum.Rejected)
                {
                    PortfolioHelper.HabilitarPortfoliosProductosFCE(producto.IdProducto);
                }
                if (ordenMercado.Estado == FixEstadoOrdenEnum.New)
                {
                    //Al crear la oferta, y llegar al mercado, se baja la cantidad en limiteOfertas 
                    cantidadOferta = (decimal)ordenMercado.PrecioOrden * ordenMercado.Cantidad;
                }
            }
            ActualizarLimitesUsuario(MAEUserSession.Instancia.IdUsuario, cantidadOferta, cantidadOperacion);
            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(ordenInterna.IdOrden, LogCodigoAccion.RecibirRespuestaMercado, accionRealizada, (EstadoOrden)ordenInterna.IdEstado, null));
            NotificarOrdenActivaMercado(ordenMercado, ordenInterna, producto);
        }

        private static void ActualizarLimitesUsuario(int idUsuario, decimal cantidadOferta, decimal cantidadOperacion)
        {
            UsuariosLimitesDiariosEntity limiteDiario;
            using (OrdenesContext context = new OrdenesContext())
            {
                limiteDiario = (from d in context.UsuariosLimitesDiarios
                                where d.IdUsuario == idUsuario
                                && d.Fecha.Date == DateTime.Now.Date
                                select d
                                ).FirstOrDefault();
                if (limiteDiario == null)
                {
                    limiteDiario = (from d in context.UsuariosLimites
                                    where d.IdUsuario == idUsuario
                                    select new UsuariosLimitesDiariosEntity()
                                    {
                                        IdUsuario = idUsuario,
                                        ConsumidoOferta = 0,
                                        ConsumidoOperacion = 0,
                                        Fecha = DateTime.Now
                                    }
                                ).FirstOrDefault();
                    context.Add(limiteDiario);
                }
                limiteDiario.ConsumidoOferta += cantidadOferta;
                limiteDiario.ConsumidoOperacion += cantidadOperacion;
                context.SaveChanges();
            }
        }


        private static void NotificarOrdenActivaMercado(FixOrdenRespuestaEntity ordenMercado, OrdenEntity ordenInterna, ProductoEntity productoEntity)
        {
            NotificacionOrden noti = new NotificacionOrden();
            noti.IdParty = ordenInterna.IdPersona;
            noti.CommandName = ordenMercado.TipoEjecucion.ToString();
            noti.id = ordenInterna.IdOrden;
            noti.IdMoneda = ordenInterna.IdMoneda;
            noti.key = ordenInterna.GetProductKey();
            noti.IdTipoProducto = productoEntity.IdTipoProducto;
            noti.symbol = productoEntity.Descripcion;
            noti.symbo_name = productoEntity.Descripcion;
            noti.tradeType = 0;
            noti.volume = ordenMercado.Cantidad;
            noti.remainingVolume = ordenMercado.CantidadRemanente;
            noti.executedVolume = ordenMercado.CantidadEjecutada;
            noti.side = ordenInterna.CompraVenta == "C" ? 2 : 1;
            //noti.openTime = 20;
            noti.openPrice = 10;
            noti.price = ordenInterna.PrecioLimite;
            noti.margin = 123;
            noti.nominalValue = 1;
            noti.openOrigin = 1;
            noti.isNew = true; //Metadata
            noti.isRun = false; //Metadata
            noti.delete = false;
            //noti.total = noti.price * noti.executedVolume;
            noti.date = DateTime.Now;
            noti.marketPrice = ordenMercado.PrecioMercado;
            noti.orderId2 = ordenInterna.NumeroOrdenMercado;
            noti.contrato = productoEntity.CantidadContrato;
            noti.idProducto = ordenInterna.IdProducto;
            noti.IdTipoNotificacion = (ordenMercado.Estado == FixEstadoOrdenEnum.Rejected || ordenMercado.Estado == FixEstadoOrdenEnum.Canceled) ? (byte)TiposNotificaciones.OrdenRechazoMercado : (byte)TiposNotificaciones.OrdenActivaMercado;
            noti.comment = ordenMercado.RechazoTexto;
            noti.sequenceNumber = ordenMercado.NroOperacionMercado;
            noti.pareja = ordenInterna.IdOrdenDeReferencia;
            noti.EquivalentRate = ordenMercado.SpotRate;
            noti.OperoPorTasa = ordenMercado.OperoPorTasa == null ? false : (bool)ordenMercado.OperoPorTasa;
            noti.PrecioVinculado = ordenMercado.PrecioVinculado;
            noti.Valorizacion = ordenInterna.Valorizacion;
            noti.Timestamp = BitConverter.ToString((byte[])ordenInterna.Timestamp, 0);
            noti.espuja = false;
            EventHelperService.Instance.EnQueueMessage(noti);
        }


        private static void OrdenReemplazarMercado(FixOrdenRespuestaEntity ordenMercado, OrdenEntity ordenInterna)
        {
            string accionRealizada = "El mercado: " + ordenMercado.Mercado + " acepto la modificacion de la orden Nro.: " + ordenInterna.NumeroOrdenInterno;
            ordenInterna.Cantidad = ordenMercado.Cantidad;
            ordenInterna.PrecioLimite = ordenMercado.PrecioOrden;

            ActualizarOrden(ordenInterna);

            /*generar bitacora*/
            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(ordenInterna.IdOrden, LogCodigoAccion.RecibirRespuestaMercado, accionRealizada, (EstadoOrden)ordenInterna.IdEstado, null));
            NotificarOrdenReemplazarMercado(ordenMercado, ordenInterna);
        }

        private static void NotificarOrdenReemplazarMercado(FixOrdenRespuestaEntity ordenMercado, OrdenEntity ordenInterna)
        {
            NotificacionOrden noti = new NotificacionOrden();
            noti.IdParty = ordenInterna.IdPersona;
            noti.CommandName = ordenMercado.TipoEjecucion.ToString();
            noti.id = ordenInterna.IdOrden;
            noti.orderId2 = ordenInterna.NumeroOrdenMercado;
            noti.Valorizacion = ordenInterna.Valorizacion;
            noti.volume = ordenInterna.Cantidad - ordenInterna.Ejecutadas;
            noti.price = (decimal)ordenInterna.PrecioLimite;
            noti.IdTipoNotificacion = (byte)TiposNotificaciones.OrdenReemplazarMercado;
            EventHelperService.Instance.EnQueueMessage(noti);
        }

        private static void OrdenCancelarMercado(FixOrdenRespuestaEntity ordenMercado, OrdenEntity ordenInterna, byte estadoActual)
        {
            string accionRealizada = "";
            byte estadofinal = 0;
            decimal cantidadOferta = 0;
            ProductoEntity producto = CachingManager.Instance.GetProductoById(ordenInterna.IdProducto);
            if (producto.IdTipoProducto == (byte)TiposProducto.FACTURAS)
            {
                PortfolioHelper.DesHabilitarPortfoliosProductosFCE(producto.IdProducto);
                //string key = ordenInterna.IdProducto.ToString() + "_" + ordenInterna.IdMercado + "_" + ordenInterna.IdMoneda + "_" + ordenInterna.Plazo + "_" + ordenInterna.Rueda;
                //NotificarDesAsociacionProductoPortfolio(producto.IdProducto, "OrdenCancelarMercado",key);
            }
            if (estadoActual == (int)EstadoOrden.AplicadaParcial)
            {
                accionRealizada = "El mercado: " + ordenMercado.Mercado + " acepto la cancelación parcial de la orden Nro.: " + ordenInterna.NumeroOrdenInterno;
                DateTime? SettlementDate = null;
                if (ordenInterna.Plazo.HasValue)
                {
                    SettlementDate = (byte)ordenInterna.Plazo == (byte)PlazoOrdenEnum.Futuro ? ordenInterna.FechaLiquidacion : null;
                }
                OrdenesDAL.CambioEstadoOrden(ordenInterna.IdOrden, (int)EstadoOrden.Aplicada, ordenInterna.NumeroOrdenMercado, null, ordenInterna.OperoPorTasa, ordenInterna.PrecioVinculado, ordenInterna.PrecioLimite, ordenInterna.Valorizacion);
                estadofinal = (int)EstadoOrden.Aplicada;
                cantidadOferta = (ordenInterna.Cantidad - ordenInterna.Ejecutadas) * (decimal)ordenInterna.PrecioLimite;
            }
            else
            {
                estadofinal = ordenInterna.IdEstado;
                accionRealizada = "El mercado: " + ordenMercado.Mercado + " acepto la cancelación de la orden Nro.: " + ordenInterna.NumeroOrdenInterno;
                OrdenesDAL.CambioEstadoOrden(ordenInterna.IdOrden, ordenInterna.IdEstado, ordenInterna.NumeroOrdenMercado, null, ordenInterna.OperoPorTasa, ordenInterna.PrecioVinculado, ordenInterna.PrecioLimite, ordenInterna.Valorizacion);
                cantidadOferta = ordenInterna.Cantidad * (decimal)ordenInterna.PrecioLimite;
            }
            //Se asigna nuevamente la parte de ofertas desafectadas. Va el menos porque en la tabla es ConsumidoOferta
            ActualizarLimitesUsuario(MAEUserSession.Instancia.IdUsuario, -cantidadOferta, 0);
            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(ordenInterna.IdOrden, LogCodigoAccion.RecibirRespuestaMercado, accionRealizada, (EstadoOrden)estadofinal, null));
            NotificarOrdenCancelarMercado(ordenInterna, producto);
        }

        private static void NotificarOrdenCancelarMercado(OrdenEntity ordenInterna, ProductoEntity producto)
        {
            NotificacionOrden noti = new NotificacionOrden();
            string key = ordenInterna.GetProductKey();
            noti.key = key;
            noti.IdMercado = ordenInterna.IdMercado;
            noti.Mercado = CachingManager.Instance.GetMercadoById(noti.IdMercado).Codigo;
            ProductoPorMercadoEntity ppm = CachingManager.Instance.GetProductoPorMercadoByProductoYMercado(ordenInterna.IdMercado, ordenInterna.IdProducto);
            noti.PrecioReferencia = ppm.PrecioReferencia;
            noti.IdTipoProducto = producto.IdTipoProducto;
            noti.IdParty = ordenInterna.IdPersona;
            noti.CommandName = "NotificarOrdenCancelarMercado";
            noti.id = ordenInterna.IdOrden;
            noti.orderId2 = ordenInterna.NumeroOrdenMercado;
            noti.Valorizacion = ordenInterna.Valorizacion;
            noti.Rueda = ordenInterna.Rueda;
            noti.comment = "Orden Cancelada por el usuario.";
            noti.IdTipoNotificacion = (byte)TiposNotificaciones.OrdenCancelarMercado;
            EventHelperService.Instance.EnQueueMessage(noti);
        }

        private static void OrdenRechazoMercado(FixOrdenRespuestaEntity ordenMercado, OrdenEntity ordenInterna, byte estadoActual)
        {
            string accionRealizada = "El mercado: " + ordenMercado.Mercado + " rechazo accion sobre la orden Nro.: " + ordenInterna.NumeroOrdenInterno;
            if (ordenInterna.IdEstado == (int)EstadoOrden.RechazoMercado && !string.IsNullOrEmpty(ordenMercado.RechazoTexto))
            {
                accionRealizada = accionRealizada + ". Razon de rechazo: " + ordenMercado.RechazoTexto;
            }
            if (estadoActual == (int)EstadoOrden.Ingresada || estadoActual == (int)EstadoOrden.Confirmada)
            {
                OrdenesDAL.CambioEstadoOrden(ordenInterna.IdOrden, ordenInterna.IdEstado, ordenInterna.NumeroOrdenMercado, null, ordenInterna.OperoPorTasa, ordenInterna.PrecioVinculado, ordenInterna.PrecioLimite, ordenInterna.Valorizacion);
            }

            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(ordenInterna.IdOrden, LogCodigoAccion.RecibirRespuestaMercado, accionRealizada, (EstadoOrden)ordenInterna.IdEstado, null));
            NotificarOrdenRechazoMercado(ordenMercado, ordenInterna, estadoActual);
        }

        public static void NotificarOrdenRechazoMercado(FixOrdenRespuestaEntity ordenMercado, OrdenEntity ordenInterna, byte estadoActual)
        {
            NotificacionOrden noti = new NotificacionOrden();
            noti.IdParty = ordenInterna.IdPersona;
            noti.CommandName = TiposNotificaciones.OrdenRechazoMercado.ToString();
            noti.IdTipoNotificacion = (byte)TiposNotificaciones.OrdenRechazoMercado;
            noti.id = ordenInterna.IdOrden;
            noti.orderId2 = ordenInterna.NumeroOrdenMercado;
            noti.Estado = estadoActual;
            noti.comment = ordenMercado.RechazoTexto;
            noti.price = ordenInterna.PrecioLimite;
            noti.volume = ordenMercado.Cantidad;
            EventHelperService.Instance.EnQueueMessage(noti);
        }

        public static void InformarMercadoEstado(byte TipoEstado, string NombreCommando)
        {
            NotificacionEstadoSistema noti = new NotificacionEstadoSistema
            {
                IdTipoNotificacion = (byte)TiposNotificaciones.EstadoSistema,
                EstadoSistema = TipoEstado == (byte)TipoEstadoSistema.ULTIMO_ABIERTO ? "Abierto" : "Cerrado",
                CommandName = NombreCommando
            };
            EventHelperService.Instance.EnQueueMessage(noti);
        }

        public static string DeleteRejectedOrder(int idOrden)
        {
            OrdenEntity orden = OrdenesDAL.ObtenerOrdenbyID(idOrden);
            if (orden == null || orden.IdOrden < 0)
            {
                throw new M4TraderApplicationException("Orden inexistente");
            }

            if (orden.IdEstado != (byte)EstadoOrden.Cancelar && orden.IdEstado != (byte)EstadoOrden.RechazoMercado)
            {
                throw new M4TraderApplicationException("La orden debe de encontrarse en estado Cancelada");
            }

            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.BloqueoOrden, "Baja lógica orden Nro.:" + orden.NumeroOrdenInterno, (EstadoOrden)orden.IdEstado, null));

            OrdenesDAL.DeleteRejectedOrder(idOrden);
            return "Cancelacion Exitosa Orden Numero:" + orden.IdOrden;
        }

        public static string DeleteOpenOrder(int idOrden)
        {
            OrdenEntity orden = OrdenesDAL.ObtenerOrdenbyID(idOrden);
            if (orden == null || orden.IdOrden < 0)
            {
                throw new M4TraderApplicationException("Orden inexistente");
            }

            if (orden.IdEstado != (byte)EstadoOrden.Cancelar && orden.IdEstado != (byte)EstadoOrden.RechazoMercado)
            {
                throw new M4TraderApplicationException("La orden debe de encontrarse en estado Cancelada");
            }

            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(orden.IdOrden, LogCodigoAccion.BloqueoOrden, "Baja lógica orden Nro.:" + orden.NumeroOrdenInterno, (EstadoOrden)orden.IdEstado, null));

            OrdenesDAL.DeleteOpenOrder(idOrden);
            return "Cancelacion Exitosa Orden Numero:" + orden.IdOrden;
        }
        #endregion

    }
}

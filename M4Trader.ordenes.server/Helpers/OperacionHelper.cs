using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.CQRSFramework.Transactions;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server.Helpers
{


    public static class OperacionHelper
    {

        public static string ConcertarOperacion(OperacionEntity operacion)
        {
            List<MovimientosSaldos> movimientosSaldo = new List<MovimientosSaldos>();

            LimitesPorPersonaEntity limiteComprador = new LimitesPorPersonaEntity();
            LimitesPorPersonaEntity limiteVendedor = new LimitesPorPersonaEntity();

            ValidarRestriccionesDeOperacion(operacion, ref limiteComprador, ref limiteVendedor);
            
            //Generar movimiento Saldo
            movimientosSaldo = TransaccionesHelper.CrearMovimimientosSaldos(operacion);

            movimientosSaldo.AddRange(TransaccionesHelper.CrearMovimimientosComisiones(operacion));

            //ValidoSaldos
            ValidarSaldos(movimientosSaldo.Where(x => x.IdTipoMovimiento == TipoMovimientos.MonedaDebito).ToList());
            
            //Insertar operacion y movimientos e impacto en saldos
            using (ReadCommittedTransactionScope ts = new ReadCommittedTransactionScope())
            {
                MovimientosSaldos movDebitoComprador = movimientosSaldo.Where(x => x.IdTipoMovimiento == TipoMovimientos.MonedaDebito && x.IdPersona == operacion.IdPersonaComprador).FirstOrDefault();
                MovimientosSaldos movDebitoVendedor = movimientosSaldo.Where(x => x.IdTipoMovimiento == TipoMovimientos.MonedaDebito && x.IdPersona == operacion.IdPersonaVendedor).FirstOrDefault();

                byte[] ultimaactualizacionsaldocomprador = SaldosDAL.ObtenerUltimaActualizacionSaldo(movDebitoComprador.IdMoneda, movDebitoComprador.IdPersona);
                byte[] ultimaactualizacionsaldovendedor = SaldosDAL.ObtenerUltimaActualizacionSaldo(movDebitoVendedor.IdMoneda, movDebitoVendedor.IdPersona);

                CheckConcurrenciaSaldo(ultimaactualizacionsaldocomprador, operacion.CompraVenta == "C" ? operacion.TimestampSaldoComprador : operacion.TimestampSaldoVendedor);
                CheckConcurrenciaSaldo(ultimaactualizacionsaldovendedor, operacion.CompraVenta == "C" ? operacion.TimestampSaldoVendedor : operacion.TimestampSaldoComprador);
                
                OperacionesDAL.CrearOperacion(operacion);
                movimientosSaldo = movimientosSaldo.Select(c => { c.IdPropietario = operacion.IdOperacion; return c; }).ToList();
                SaldosDAL.GenerarMovimientos(movimientosSaldo);
                SaldosDAL.ActualizarSaldos(movimientosSaldo);
                
                if(limiteComprador != null)
                    OperacionesDAL.CrearRestricciones(operacion, limiteComprador);

                if (limiteComprador != null)
                    OperacionesDAL.CrearRestricciones(operacion, limiteVendedor);

                ts.Complete();
            }


            NotificacionesEntity noti = new NotificacionesEntity();
            noti.Fecha = DateTime.Now;
            noti.IdDestinatario = operacion.IdPersonaComprador;
            noti.IdTipoNotificacion = (byte)TipoNotificacionesMensajeria.Successfully;
            noti.IdSubTipoNotificacion = (byte)SubTipoNotificacionesMensajeria.OperacionRealizada;
            noti.Leido = false;
            noti.Mensaje = string.Format( "Se registro la operación {0} de forma satisfactoaria e impacto en Saldos ", operacion.NroOperacion);
            NotificacionesHelperService.Instance.EnQueueMessage(noti);


            LoggingHelper.Instance.AgregarLog(new LogBitacoraOperacionEntity(operacion.IdOperacion, LogCodigoAccion.CrearOperacion, "Creación de la Operacion Nro:" + operacion.NroOperacion));
            MessageHelper.InformarNuevoMensaje(operacion.IdPersonaComprador, TipoNotificacionesMensajeria.Successfully.ToString(), SubTipoNotificacionesMensajeria.OperacionRealizada.ToString(), "Se registro la operación de forma satisfactoaria e impacto en Saldos: " + operacion.NroOperacion, DateTime.Now);
            return "Se registro la operación de forma satisfactoaria e impacto en Saldos: " + operacion.NroOperacion;
        }

        public static void CheckConcurrenciaSaldo(byte[] ultimaactualizacionsaldo, byte[] timeStamp)
        {
            if (Convert.ToBase64String(ultimaactualizacionsaldo) != Convert.ToBase64String(timeStamp))
            {
                throw new M4TraderApplicationException(CodigosMensajes.FE_CAMBIO_ULTIMA_ACTUALIZACION, "El Saldo fue modificado por otra transacción en este momento, por favor espere unos instantes");
            }
        }


        public static void ValidarRestriccionesDeOperacion(OperacionEntity operacion, ref LimitesPorPersonaEntity limiteComprador, ref LimitesPorPersonaEntity limiteVendedor)
        {
            //Buscar reglas de limites.
            limiteComprador = CachingManager.Instance.GetUsuariosLimiteByIdUsuario(operacion.IdPersonaComprador, "C");
            limiteVendedor = CachingManager.Instance.GetUsuariosLimiteByIdUsuario(operacion.IdPersonaVendedor, "V");

            if (limiteComprador == null && limiteVendedor == null)
                return;

            //Verifica que los usr no esten bloqueados
            if (limiteComprador != null)
            {
                ValidarUsrBloqueado(operacion.IdPersonaComprador, operacion.FechaOperacion, "C");
                //ValidarTopes
                ValidarTopes(operacion.Cantidad, limiteComprador);
            }

            if (limiteVendedor != null)
            {
                ValidarUsrBloqueado(operacion.IdPersonaVendedor, operacion.FechaOperacion, "V");
                //ValidarTopes
                ValidarTopes(operacion.Cantidad, limiteVendedor);
            }                
        }

        public static void ValidarUsrBloqueado(int idPersona, DateTime fechaOperacion, string bloqueoParaTipoOperacion)
        {
            bool estaBloqueado = CachingManager.Instance.UsuarioBloqueadoParaOperar(idPersona, fechaOperacion, bloqueoParaTipoOperacion);
            if(estaBloqueado)
                throw new M4TraderApplicationException(CodigosMensajes.FE_USUARIO_BLOQUEADO_PARA_OPERAR, "Error el usr que se encuenta" + bloqueoParaTipoOperacion == "C" ? " Comprando " : " Vendiendo " + " se encuentra bloqueado para operar por limites establecidos");

        }

        public static void ValidarTopes(decimal cantidad, LimitesPorPersonaEntity limite)
        {
            if(cantidad > limite.Tope)
                throw new M4TraderApplicationException(CodigosMensajes.FE_USUARIO_BLOQUEADO_PARA_OPERAR, "Error el usr supero el monto establecido por el limite :" + limite.Tope.ToString());

            decimal cantidadoperado = OperacionesDAL.ObtenerCantidadOperda(limite);
            if (cantidadoperado + cantidad > limite.Tope)
            {
                throw new M4TraderApplicationException(CodigosMensajes.FE_USUARIO_BLOQUEADO_PARA_OPERAR, string.Format("El usr esta operando por un total de {0} pero ya opero por {1}, con lo cual solo puede realizar una operación por un monto de {2} o inferior ", (cantidadoperado + cantidad).ToString(), cantidadoperado.ToString(), (limite.Tope - (cantidadoperado + cantidad)).ToString()));
            }
        }

        public static string ImpactarEnSaldosHistoricos(DateTime fechaSistema)
        {
            SaldosDAL.ImpactarEnSaldosHistoricos(fechaSistema);
            return "Se impactaron todas las operaciones del día Saldos Históricos: ";
        }

        public static void ValidarSaldos(List<MovimientosSaldos> movimimientoSaldo)
        {
            decimal importeSaldo = 0;
            foreach (MovimientosSaldos m in movimimientoSaldo)
            {

                importeSaldo = SaldosDAL.ObtenerImporteSaldo(m.IdPersona, m.IdMoneda);
                if(m.Importe > importeSaldo)
                    throw new M4TraderApplicationException(CodigosMensajes.FE_CAMBIO_ULTIMA_ACTUALIZACION, "Error saldo insuficiente para realizar la operación");                           
            }              
        }

        public static void ValidarTopes(OperacionEntity operacion)
        {
            //decimal importeSaldo = 0;
            
            //UsuariosLimitesDiariosEntity
            //    importeSaldo = SaldosDAL.ObtenerImporteSaldo(m.IdPersona, m.IdMoneda);
            //    if (m.Importe > importeSaldo)
            //        throw new M4TraderApplicationException(CodigosMensajes.FE_CAMBIO_ULTIMA_ACTUALIZACION, "Error saldo insuficiente para realizar la operación");
              
        }
        

    } 
}

using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.CQRSFramework.Transactions;
using M4Trader.ordenes.services.Entities;
using MAE.Clearing.BusinessComponentLayer.Helpers;
using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.server.Helpers
{
    public static class NovedadDeTransferenciaHelper
    {

        public static string AltaNovedadDeTransferenciaHelper(NovedadTransferenciaEntity novedadTransferencia)
        {
            MovimientosSaldos m = new MovimientosSaldos();
            m = TransaccionesHelper.CrearMovimientoDeDeposito(novedadTransferencia);

            using (ReadCommittedTransactionScope ts = new ReadCommittedTransactionScope())
            {                
                NovedadesTransferenciaDeFondosDAL.CrearNovedadTransferencia(novedadTransferencia);
                List<MovimientosSaldos> l = new List<MovimientosSaldos>();
                l.Add(m);
                SaldosDAL.AgregarDepositoPendiente(novedadTransferencia);
                if (novedadTransferencia.EsDepositoEnAgencia)
                {
                    SaldosDAL.ActualizarSaldos(l);
                } 

                m.IdPropietario = novedadTransferencia.IdNovedadTransferenciaFondo;
                SaldosDAL.GenerarMovimientos(l);
                ts.Complete();
            }

            NotificacionesEntity noti = new NotificacionesEntity();
            noti.Fecha = DateTime.Now;
            noti.IdDestinatario = novedadTransferencia.IdPersonaDestino;
            noti.IdTipoNotificacion = (byte)TipoNotificacionesMensajeria.Successfully;
            noti.IdSubTipoNotificacion = (byte)SubTipoNotificacionesMensajeria.DepositoRealizado;
            noti.Leido = false;
            noti.Mensaje = "";//string. 
            NotificacionesHelperService.Instance.EnQueueMessage(noti);

            MessageHelper.InformarNuevoMensaje(noti.IdDestinatario, TipoNotificacionesMensajeria.Successfully.ToString(), SubTipoNotificacionesMensajeria.DepositoRealizado.ToString(), noti.Mensaje, noti.Fecha);
            int idpersonadestino = CachingManager.Instance.GetPersonaByCBU(novedadTransferencia.CBUDestino).IdParty; 
            string mensaje = string.Format("Se registro la novedad de transferencia de forma satisfactoaria espere que la agencia valide la misma. CBU Origen {0}, CBU Destino {1}, Importe {2}", novedadTransferencia.CBUOrigen, novedadTransferencia.CBUDestino, novedadTransferencia.Importe);
            
            if(CachingManager.Instance.GetConfiguracionSeguridad().PermiteEnviarMail)
                Utils.EnviarMail(CachingManager.Instance.GetAllUsuarios().Find(x => x.IdPersona == idpersonadestino).Email, CachingManager.Instance.GetAllUsuarios().Find(x => x.IdPersona == m.IdPersona).Email, "Novedad de transferencia", mensaje);

            return mensaje;
        }

        public static string TransferirFondosAUsuario(NovedadTransferenciaEntity novedadTransferencia)
        {
            return "";
        }

        public static string AcreditacionNovedadDeTransferenciaHelper(int IdNovedadDeTrasferencia)
        {

            List<MovimientosSaldos> movimientossaldos = SaldosDAL.ObtenerMovimientosSaldoByIdPropietario(IdNovedadDeTrasferencia);
            List<MovimientosSaldos> l = new List<MovimientosSaldos>();
            
            l.AddRange(movimientossaldos);

            using (ReadCommittedTransactionScope ts = new ReadCommittedTransactionScope())
            {
                foreach(MovimientosSaldos m in movimientossaldos)
                    SaldosDAL.ActualizarEstado((int)TipoEstadoMovimiento.aprobada, m.IdMovimiento);
                SaldosDAL.ActualizarSaldos(l);
            }

            string mensaje = string.Format("Se acredito el movimiento de forma satisfactoaria espere");
            if (CachingManager.Instance.GetConfiguracionSeguridad().PermiteEnviarMail)
                Utils.EnviarMail(CachingManager.Instance.GetAllUsuarios().Find(x => x.IdPersona == movimientossaldos[0].IdPersona).Email, CachingManager.Instance.GetAllUsuarios().Find(x => x.IdPersona == movimientossaldos[0].IdPersona).Email, "Acreditacion de transferencia", mensaje);

            return mensaje;
        }

        public static List<NovedadTransferenciaEntity> ConsultaNovedadDeTransferencia(int IdPersona, DateTime? fechaDesde, DateTime? fechaHasta, byte? idMoneda, int? idEstado, string receptor, string orden)
        {
            return NovedadesTransferenciaDeFondosDAL.ConsultaNovedades(IdPersona, fechaDesde, fechaHasta, idMoneda, idEstado, receptor, orden);
        }

        public static int ObtenerEstadoNovedad(int idnovedad)
        {
            return NovedadesTransferenciaDeFondosDAL.ObtenerEstadoNovedad(idnovedad);             
        }
        

        public static string BajaNovedadDeTransferenciaHelper(int idNovedad)
        {
            //NovedadesTransferenciaDeFondosDAL.CrearNovedadTransferencia(novedadTransferencia);
            return string.Format("Se registro la baja de la novedad de transferencia de forma satisfactoaria");
        }
        

    } 
}

using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;

namespace M4Trader.ordenes.server.Helpers
{


    public static class TransaccionesHelper
    {

        public static List<MovimientosSaldos> CrearMovimimientosSaldos(OperacionEntity operacion)
        {

            List<MovimientosSaldos> movimimientoSaldos = new List<MovimientosSaldos>();
            
            movimimientoSaldos.AddRange(CrearMovimientosCreditos(operacion, operacion.CompraVenta == "C"));
            movimimientoSaldos.AddRange(CrearMovimientosDebitos(operacion, operacion.CompraVenta == "C"));
            
            LoggingHelper.Instance.AgregarLog(new LogBitacoraOperacionEntity(operacion.IdOperacion, LogCodigoAccion.CrearMovimientoSaldo, "Se crean los movimientos de la operacion Nro:" + operacion.NroOperacion));

            return movimimientoSaldos;

        }

        public static List<MovimientosSaldos> CrearMovimimientosComisiones(OperacionEntity operacion)
        {

            List<MovimientosSaldos> movimimientoSaldos = new List<MovimientosSaldos>();

            //movimimientoSaldos.AddRange(CrearMovimientosCreditos(operacion, operacion.CompraVenta == "C"));
            //movimimientoSaldos.AddRange(CrearMovimientosDebitos(operacion, operacion.CompraVenta == "C"));

            //LoggingHelper.Instance.AgregarLog(new LogBitacoraOperacionEntity(operacion.IdOperacion, LogCodigoAccion.CrearMovimientoSaldo, "Se crean los movimientos de la operacion Nro:" + operacion.NroOperacion));

            return movimimientoSaldos;

        }
        
        public static MovimientosSaldos CrearMovimientoDeDeposito(NovedadTransferenciaEntity novedad)
        {
            MovimientosSaldos movimiento = new MovimientosSaldos();
            movimiento = CrearMovimientosDesdeUnDeposito(novedad);
            return movimiento;
        }

        private static List<MovimientosSaldos> CrearMovimientosCreditos(OperacionEntity operacion, bool esCompra)
        {
            List<MovimientosSaldos> movimientoSaldos = new List<MovimientosSaldos>();

            MovimientosSaldos movCredito = new MovimientosSaldos();
            if (esCompra)
            {
                movCredito.IdTipoMovimiento = ObtenerTipoMovimiento(true);
                movCredito.IdMoneda = operacion.IdMonedaCompra;
                movCredito.IdPersona = operacion.IdPersonaComprador;
                movCredito.Importe = operacion.Cantidad;
                movCredito.ImpactoEnSaldo = false;
                movCredito.IdEstado = (int)TipoEstadoMovimiento.aprobada;
                movimientoSaldos.Add(movCredito);

                movCredito = new MovimientosSaldos();
                movCredito.IdTipoMovimiento = ObtenerTipoMovimiento(true);
                movCredito.IdMoneda = operacion.IdMonedaVenta;
                movCredito.IdPersona = operacion.IdPersonaVendedor;
                movCredito.Importe = operacion.Monto;
                movCredito.ImpactoEnSaldo = false;
                movCredito.IdEstado = (int)TipoEstadoMovimiento.aprobada;
                movimientoSaldos.Add(movCredito);
            }
            else
            {  
                movCredito.IdTipoMovimiento = ObtenerTipoMovimiento(true);
                movCredito.IdMoneda = operacion.IdMonedaCompra;
                movCredito.IdPersona = operacion.IdPersonaVendedor;
                movCredito.Importe = operacion.Monto;
                movCredito.ImpactoEnSaldo = false;
                movCredito.IdEstado = (int)TipoEstadoMovimiento.aprobada;
                movimientoSaldos.Add(movCredito);

                movCredito = new MovimientosSaldos();
                movCredito.IdTipoMovimiento = ObtenerTipoMovimiento(true);
                movCredito.IdMoneda = operacion.IdMonedaVenta;
                movCredito.IdPersona = operacion.IdPersonaComprador;
                movCredito.Importe = operacion.Cantidad;
                movCredito.ImpactoEnSaldo = false;
                movCredito.IdEstado = (int)TipoEstadoMovimiento.aprobada;
                movimientoSaldos.Add(movCredito);
            }
            return movimientoSaldos;
        }

        private static List<MovimientosSaldos> CrearMovimientosDebitos(OperacionEntity operacion, bool esCompra)
        {
            List<MovimientosSaldos> movimientoSaldos = new List<MovimientosSaldos>();
             
            MovimientosSaldos movDebito = new MovimientosSaldos(); 
            if (esCompra)
            {  
                movDebito.IdTipoMovimiento = ObtenerTipoMovimiento(false);
                movDebito.IdMoneda = operacion.IdMonedaVenta;
                movDebito.IdPersona = operacion.IdPersonaComprador;
                movDebito.Importe = operacion.Monto;
                movDebito.ImpactoEnSaldo = false;
                movDebito.IdEstado = (int)TipoEstadoMovimiento.aprobada;
                movimientoSaldos.Add(movDebito);

                movDebito = new MovimientosSaldos();
                movDebito.IdTipoMovimiento = ObtenerTipoMovimiento(false);
                movDebito.IdMoneda = operacion.IdMonedaCompra;
                movDebito.IdPersona = operacion.IdPersonaVendedor;
                movDebito.Importe = operacion.Cantidad;
                movDebito.ImpactoEnSaldo = false;
                movDebito.IdEstado = (int)TipoEstadoMovimiento.aprobada;
                movimientoSaldos.Add(movDebito);
            }
            else
            {
                movDebito.IdTipoMovimiento = ObtenerTipoMovimiento(false);
                movDebito.IdMoneda = operacion.IdMonedaVenta;
                movDebito.IdPersona = operacion.IdPersonaVendedor;
                movDebito.Importe = operacion.Cantidad;
                movDebito.ImpactoEnSaldo = false;
                movDebito.IdEstado = (int)TipoEstadoMovimiento.aprobada;
                movimientoSaldos.Add(movDebito);

                movDebito = new MovimientosSaldos();
                movDebito.IdTipoMovimiento = ObtenerTipoMovimiento(false);
                movDebito.IdMoneda = operacion.IdMonedaCompra;
                movDebito.IdPersona = operacion.IdPersonaComprador;
                movDebito.Importe = operacion.Monto;
                movDebito.ImpactoEnSaldo = false;
                movDebito.IdEstado = (int)TipoEstadoMovimiento.aprobada;
                movimientoSaldos.Add(movDebito);

            }
            return movimientoSaldos;
        }

        private static MovimientosSaldos CrearMovimientosDesdeUnDeposito(NovedadTransferenciaEntity n)
        {
            MovimientosSaldos movCredito = new MovimientosSaldos();
            movCredito.IdTipoMovimiento = TipoMovimientos.DepositoDeTransferencia;
            movCredito.IdMoneda = n.IdMoneda;
            movCredito.IdPersona = n.IdPersona;
            movCredito.Importe = n.Importe;
            movCredito.ImpactoEnSaldo = false;
            movCredito.IdEstado = n.EsDepositoEnAgencia ? (int)TipoEstadoMovimiento.aprobada : (int)TipoEstadoMovimiento.pendiente;
            return movCredito;
        }

        private static TipoMovimientos ObtenerTipoMovimiento(bool esCredito)
        {
            return esCredito ? TipoMovimientos.MonedaCredito : TipoMovimientos.MonedaDebito; 
        }
    }

}

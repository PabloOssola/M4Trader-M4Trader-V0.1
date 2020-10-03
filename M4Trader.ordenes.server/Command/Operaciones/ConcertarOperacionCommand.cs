using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class ConcertarOperacionCommand : ABMCommand
    {

        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            List<OperacionEntity> OperacionesGeneradas = new List<OperacionEntity>();

            foreach (Operacion o in operaciones)
            {
                OperacionEntity oe = new OperacionEntity();

                oe.NroOperacion = DateTime.Now.ToString("yyMMddHHmmss");
                oe.CompraVenta = o.CompraOVenta;
                oe.IdPersonaComprador = oe.CompraVenta == "C" ? MAEUserSession.Instancia.IdPersona : CachingManager.Instance.GetPadreByIdHijo(MAEUserSession.Instancia.IdPersona).IdParty;
                oe.IdPersonaVendedor = oe.CompraVenta == "C" ?  CachingManager.Instance.GetPadreByIdHijo(MAEUserSession.Instancia.IdPersona).IdParty : MAEUserSession.Instancia.IdPersona;
                oe.Cantidad = o.Cantidad;
                oe.Precio = PizarrasDAL.ObtenerPrecioActual(CachingManager.Instance.GetMonedaByCodigoISO(o.CodigoMonedaISO).IdMoneda, oe.CompraVenta);
                oe.Monto = o.Cantidad * oe.Precio;
                oe.FechaOperacion = DateTime.Now;
                oe.IdMonedaCompra = oe.CompraVenta == "C" ? CachingManager.Instance.GetMonedaByCodigoISO(o.CodigoMonedaISO).IdMoneda : CachingManager.Instance.GetAllMonedas().Find(x => x.EsMonedaNacional == true).IdMoneda;
                oe.IdMonedaVenta = oe.CompraVenta == "C" ? CachingManager.Instance.GetAllMonedas().Find(x => x.EsMonedaNacional == true).IdMoneda : CachingManager.Instance.GetMonedaByCodigoISO(o.CodigoMonedaISO).IdMoneda;
                
                oe.TimestampSaldoComprador = SaldosDAL.ObtenerUltimaActualizacionSaldo(oe.IdMonedaVenta, oe.CompraVenta == "C" ? oe.IdPersonaComprador : oe.IdPersonaVendedor);
                oe.TimestampSaldoVendedor = SaldosDAL.ObtenerUltimaActualizacionSaldo(oe.IdMonedaCompra, oe.CompraVenta == "C" ? oe.IdPersonaVendedor : oe.IdPersonaComprador);// GetUltimaActualizacion(o.TimestampSaldoVendedor);

                OperacionesGeneradas.Add(oe);
            }


            return ExecutionResult.ReturnInmediatelyAndQueueOthers(ProcesamientoGenerica(ConcertarOperacion, OperacionesGeneradas));
        }


        private string ConcertarOperacion(OperacionEntity operacion)
        {
            return OperacionHelper.ConcertarOperacion(operacion);
        }
        

        public override bool needTransactionalBevahiour()
        {
            return false;
        }


        public override void Validate()
        {
            string NombreEntidad = "Concertar Operaciones";

            ValidateEstadoSistema(CachingManager.Instance.GetFechaSistema().EstadoAbierto, "Estado del sistema cerrado, no se puede operar", NombreEntidad, "EstadoSistemaCerrar");
             
            if (!valida)
            {
                throw fe;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Operaciones;
            }
        }


        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.EJECUCION;
            }
        }

        [DataMember]
        public List<Operacion> operaciones { get; set; }
    }
     
    public class Operacion
    { 
        public string NroCliente { get; set; }
        public string CompraOVenta { get; set; }
        public string CodigoMonedaISO { get; set; } 
        public decimal Cantidad { get; set; } 
    }
}
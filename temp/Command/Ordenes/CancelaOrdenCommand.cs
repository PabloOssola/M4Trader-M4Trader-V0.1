using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("CancOrdCom",(int)IdAccion.Ordenes, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA)]
    public class CancelaOrdenCommand : ABMCommand
    {

        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(ProcesamientoGenerica(DistribuirPorEstado, Ordenes));
        }

        private string DistribuirPorEstado(Order order)
        {
            OrdenEntity orden = null;
            if (Source == SourceEnum.Api)
            {
                orden = OrdenHelper.DesbloquearOrden(order.IdOrden, Source);
            }
            else
            {
                orden = OrdenHelper.ObtenerOrdenbyID(order.IdOrden);
            }
            switch (orden.IdEstado)
            {
                case (int)EstadoOrden.Ingresada:
                case (int)EstadoOrden.Confirmada:
                    return CancelarOrden(orden, GetUltimaActualizacion(order.Timestamp));
                case (int)EstadoOrden.EnMercado:
                case (int)EstadoOrden.Aplicada:
                case (int)EstadoOrden.AplicadaParcial:
                    return CancelarOrdenMercado(orden, GetUltimaActualizacion(order.Timestamp));
                default:
                    throw new M4TraderApplicationException("Estado no Valido para la orden Nro: " + orden.NumeroOrdenInterno);
            }
        }


        private string CancelarOrden(OrdenEntity orden, byte[] timeStamp)
        {
            return OrdenHelper.CancelarOrden(orden, IdMotivo, SourceEnum.Web, timeStamp);
        }

        private string CancelarOrdenMercado(OrdenEntity orden, byte[] timeStamp)
        {

            return OrdenHelper.CancelarOrdenMercado(orden, IdMotivo, SourceEnum.Web, timeStamp);
        }



        public override bool needTransactionalBevahiour()
        {
            return false;
        }


        public override void Validate()
        {
            string NombreEntidad = "Ordenes";

            #region Requerido
            ValidateInt(Convert.ToInt32(IdMotivo), "Motivo", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO, NombreEntidad);
            #endregion Requerido


            if (!valida)
            {
                throw fe;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Ordenes;
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
        public List<Order> Ordenes { get; set; }

        [DataMember]
        public byte IdMotivo { get; set; }

        [DataMember]
        public string Observaciones { get; set; }

        [DataMember]
        public SourceEnum Source { get; set; }

    }

    public class Order
    {

        public int IdOrden { get; set; }
        public string Observaciones { get; set; }

        public string Timestamp { get; set; }
        public string NumeroOrdenMercado { get; set; }
        public int NumeroOrdenInterno { get; set; }
    }
}
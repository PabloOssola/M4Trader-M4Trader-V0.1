using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class SICancelaOrdenCommand : ABMCommand
    {
        List<OrdenEntity> ordenes;

        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            Response resultado = new Response();
            ordenes = new List<OrdenEntity>();
            OrdenEntity orden = OrdenHelper.DesbloquearOrden(IdOrden, Source);
            ordenes.Add(orden);
            resultado = ProcesamientoGenerica(DistribuirPorEstado, ordenes);
            LoggingHelper.Instance.AgregarLog(new LogCommandApiEntity("SICancelaOrdenCommand", "CMD-API", inCourseRequest.Id, resultado));
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
        }

        private string DistribuirPorEstado(OrdenEntity order)
        {
            var orden = OrdenHelper.ObtenerOrdenbyID(order.IdOrden);
            switch (orden.IdEstado)
            {
                case (int)EstadoOrden.Ingresada:
                    return CancelarOrden(orden, order.Timestamp);
                case (int)EstadoOrden.EnMercado:
                case (int)EstadoOrden.Aplicada:
                    //case (int)EstadoOrden.AplicadaParcial:
                    return CancelarOrdenMercado(orden, order.Timestamp);
                default:
                    return "Estado no Valido para la orden Nro: " + orden.NumeroOrdenInterno;
            }
        }


        private string CancelarOrden(OrdenEntity orden, byte[] timeStamp)
        {
            orden.IdOrden = IdOrden;
            return OrdenHelper.CancelarOrden(orden, IdMotivo, SourceEnum.Web, timeStamp);
        }

        private string CancelarOrdenMercado(OrdenEntity orden, byte[] timeStamp)
        {
            orden.IdOrden = IdOrden;
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
        public int IdOrden { get; set; }

        [DataMember]
        public byte IdMotivo { get { return (byte)MotivoBajaEnum.CanceladoSistemaExterno; } }

        [DataMember]
        public string Observaciones { get; set; }

        [DataMember]
        public SourceEnum Source { get { return SourceEnum.Api; } }

    }
}
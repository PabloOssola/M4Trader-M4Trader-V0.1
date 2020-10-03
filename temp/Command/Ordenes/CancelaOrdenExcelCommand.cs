using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("CancOrdExcelCom", (int)IdAccion.OrdenesExcel, TipoAplicacion.COMPLEMENTODMA)]
    public class CancelaOrdenExcelCommand : CancelaOrdenCommand
    {

        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            ResponseGenerico resultado = new ResponseGenerico();
            resultado.Resultado = (byte)eResult.Ok;
            string id = DistribuirPorEstado(Ordenes[0]);
            resultado.Detalle = JsonConvert.SerializeObject(Ordenes[0]);            
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
        }

        private string DistribuirPorEstado(Order order)
        {
            OrdenEntity orden = null;
            if (Source == SourceEnum.Api)
            {
                orden = OrdenHelper.DesbloquearOrden(order.IdOrden, Source);
            }
            if (Source == SourceEnum.ComplementoDMA)
            {
                orden = OrdenHelper.ObtenerOrdenbyNumeroOrdenInterno(order.IdOrden);
                order.NumeroOrdenMercado = orden.NumeroOrdenMercado;
                order.NumeroOrdenInterno = orden.NumeroOrdenInterno;
            }
            else
            {
                orden = OrdenHelper.ObtenerOrdenbyID(order.IdOrden);
            }
            switch (orden.IdEstado)
            {
                case (int)EstadoOrden.Ingresada:
                    return CancelarOrden(orden, GetUltimaActualizacion(order.Timestamp));
                case (int)EstadoOrden.EnMercado:
                case (int)EstadoOrden.Aplicada:
                    //case (int)EstadoOrden.AplicadaParcial:
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
            return base.needTransactionalBevahiour();
        }

       
        public override void Validate()
        {
            base.Validate();
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.OrdenesExcel;
            }
        }


        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }

    } 
}
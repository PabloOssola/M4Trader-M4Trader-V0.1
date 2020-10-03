using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("DelRejOrdDMACom", (int)IdAccion.Ordenes, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA)]
    public class DeleteRejectedOrderDMACommand : ABMCommand
    {

        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(ProcesamientoGenerica(DeleteRejectedOrder, Ordenes));
        }

        private string DeleteRejectedOrder(Order order)
        {
            try
            {
                return OrdenHelper.DeleteRejectedOrder(order.IdOrden);
            }
            catch (Exception e)
            {
                throw new M4TraderApplicationException(e.Message + " No se pudo eliminar la orden: " + order.IdOrden);
            }
        }


        public override bool needTransactionalBevahiour()
        {
            return false;
        }


        public override void Validate()
        {
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
        public SourceEnum Source { get; set; }

    }
}
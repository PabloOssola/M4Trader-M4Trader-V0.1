using System.Runtime.Serialization;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.server.Helpers;
using System.Collections.Generic;


namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("ConOrdCom", (int)IdAccion.Ordenes, TipoAplicacion.WEBEXTERNA)]

    public class ConfirmaOrdenCommand: ABMCommand
    {        
        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            //if (Source == 0)
            //    Source = SourceEnum.Mobile;

            return ExecutionResult.ReturnInmediatelyAndQueueOthers(ProcesamientoGenerica(ConfimarOrden, Ordenes));
        }


        private string ConfimarOrden(Order order)
        {
            OrdenEntity orden = OrdenHelper.DesbloquearOrden(order.IdOrden, Source);
            orden.IdEstado = (int)EstadoOrden.Confirmada;
            return OrdenHelper.ConfirmarOrden(orden, Source, GetUltimaActualizacion(order.Timestamp));
        }


        public override bool needTransactionalBevahiour()
        {
            return false;
        }

       
        public override void Validate()
        {
                
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

        public SourceEnum  Source { get; set; }
    }
}
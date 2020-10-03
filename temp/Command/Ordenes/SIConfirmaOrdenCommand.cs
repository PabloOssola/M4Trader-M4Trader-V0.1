using System.Runtime.Serialization;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.Helpers;
using System.Collections.Generic;
using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class SIConfirmaOrdenCommand : ABMCommand
    {
        List<OrdenEntity> ordenes;

        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {

            Response resultado = new Response();
            OrdenEntity orden = new OrdenEntity();
            ordenes = new List<OrdenEntity>();

            ordenes.Add(OrdenHelper.ObtenerOrdenbyID(IdOrden));

            resultado = ProcesamientoGenerica<OrdenEntity>(ConfimarOrden, ordenes);

            LoggingHelper.Instance.AgregarLog(new LogCommandApiEntity("SIConfirmaOrdenCommand", "CMD-API", inCourseRequest.Id, resultado));


            return ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
        }


        private string ConfimarOrden(OrdenEntity orden)
        {
            OrdenHelper.DesbloquearOrden(orden.IdOrden, Source);
            orden.IdEstado = (int)EstadoOrden.Confirmada;
            ordenes.Add(orden);

            return OrdenHelper.ConfirmarOrden(orden, Source, orden.Timestamp);
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
        public int IdOrden { get; set; }


        [DataMember]
        public string Observaciones { get; set; }

        public SourceEnum Source { get { return SourceEnum.Api; } }
    }
}
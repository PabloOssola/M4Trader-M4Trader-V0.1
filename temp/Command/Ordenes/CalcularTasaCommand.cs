using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("CalcularTasaCommand", (int)IdAccion.Ordenes, TipoAplicacion.DMA)]

    public class CalcularTasaCommand : ABMCommand
    {
        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            decimal tasa = 10;
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = true, tasa });
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
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
        public decimal? Precio { get; set; }
    }
}
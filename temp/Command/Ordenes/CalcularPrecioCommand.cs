using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("CalcularPrecioCommand", (int)IdAccion.Ordenes, TipoAplicacion.DMA)]

    public class CalcularPrecioCommand : ABMCommand
    {
        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            decimal precio = 1000000;
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = true, precio });
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
        public decimal? Tasa { get; set; }
    }
}
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{ 
    [CommandType("MarWatCom", (int)IdAccion.CachingManager, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.API)]

    public class MarketWatchCommand : Command
    {

        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            List<PrecioHubModel> result = MarketWatchDAL.PreciosYOfertas(idUsuario, idPortfolio);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(result);
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.CachingManager;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        [DataMember]
        public short r_id { get; set; }
        [DataMember]
        public int idUsuario { get; set; }
        [DataMember]
        public int idPortfolio { get; set; }
    }
}
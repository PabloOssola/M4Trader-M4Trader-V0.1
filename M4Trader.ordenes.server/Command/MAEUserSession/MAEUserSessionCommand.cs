using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{

    [CommandType("UsrSesCom", (int)IdAccion.CachingManager, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.API)]

    public class MAEUserSessionCommand : Command
    {
        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            MAEUserSession result = SessionHelper.GetSesionExistente(SecurityTokenId, (byte)TipoAplicacion.API);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(result);
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
        public string SecurityTokenId { get; set; }

    }
}
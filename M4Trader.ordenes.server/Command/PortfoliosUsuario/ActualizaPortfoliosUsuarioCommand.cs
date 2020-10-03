using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("ActualizaPortfoliosUsuarioCommand", (int)IdAccion.PortfoliosUsuario, TipoAplicacion.WEBEXTERNA)]
    public class ActualizaPortfoliosUsuarioCommand : Command
    {
        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            PortfolioHelper.SetearPorDefecto(r_id, MAEUserSession.Instancia.IdUsuario);

            return ExecutionResult.ReturnInmediatelyAndQueueOthers(null);
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.PortfoliosUsuario;
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
        public short r_id { get; set; }
        
    }
}
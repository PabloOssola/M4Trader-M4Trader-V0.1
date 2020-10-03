using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server
{
    public class GetPermisosProductosCommand : Command
    {
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(CachingManager.Instance.GetProductoByCodigoMonedaDefaultAndRueda(codigoProducto, idMercado, Rueda));
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

        public string codigoProducto { get; set; }
        public byte idMercado { get; set; }
        public string Rueda { get; set; }
    }
}
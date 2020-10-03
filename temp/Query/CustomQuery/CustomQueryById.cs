using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.CQRSFramework.Interfaces;
using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.mvc
{
    public abstract class CustomQueryById : ICustomQuery
    {

        public object Execute(Query query)
        {
            object result = null;
            try
            {
                using (var ctx = new OrdenesContext())
                {
                    var requestId = query.Filters[0].Value;
                    result = this.GetById(ctx, requestId);
                }
            }
            catch
            {
                //TODO: Loguear
                throw new FunctionalException((int)CommandStatus.EF_ERROR_GENERIC);
            }
            return result;
        }

        protected abstract object GetById(OrdenesContext ctx, object requestId);
    }

    
}
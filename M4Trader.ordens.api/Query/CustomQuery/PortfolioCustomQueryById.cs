using System;
using System.Linq;
using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.mvc
{
    public class PortfolioCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            short idPortfolio = Convert.ToSByte(requestId);
            return (from d in ctx.Portfolios where d.IdPortfolio == idPortfolio select d).FirstOrDefault();
        }
    }
}
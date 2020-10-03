using M4Trader.ordenes.server.MCContext;
using System;
using System.Linq;

namespace M4Trader.ordenes.mvc
{
    public class MercadoCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            byte idMercado = Convert.ToByte(requestId);
            return (from d in ctx.Mercado where d.IdMercado == idMercado select d).FirstOrDefault();
        }
    }
}
using System;
using System.Linq; 
using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.mvc
{
    public class MonedaCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            byte IdMoneda = Convert.ToByte(requestId);
            return (from d in ctx.Moneda where d.IdMoneda == IdMoneda select d).FirstOrDefault();

        }
    }
}
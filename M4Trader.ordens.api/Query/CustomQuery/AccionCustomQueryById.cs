using System;
using System.Linq; 
using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.mvc
{
    public class AccionCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            short idAccion = Convert.ToInt16(requestId);
            return (from d in ctx.Acciones where d.IdAccion == idAccion select d).FirstOrDefault();
        }
    }
}
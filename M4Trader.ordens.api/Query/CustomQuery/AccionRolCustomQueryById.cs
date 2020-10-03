using System;
using System.Linq; 
using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.mvc
{
    public class AccionRolCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            short idAccionRol = Convert.ToInt16(requestId);
            return (from d in ctx.AccionRol where d.IdAccionRol == idAccionRol select d).FirstOrDefault();
        }
    }
}
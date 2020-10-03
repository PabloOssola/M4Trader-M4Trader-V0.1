using System;
using System.Linq; 
using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.mvc
{
    public class RolCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            short IdRol = (short)Convert.ToInt32(requestId);
            return (from d in ctx.Rol where d.IdRol == IdRol select d).FirstOrDefault();
        }
    }
}
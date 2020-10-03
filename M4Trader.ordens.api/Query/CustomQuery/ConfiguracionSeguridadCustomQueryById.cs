using System;
using System.Linq; 
using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.mvc
{
    public class ConfiguracionSeguridadCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            short IdConfiguracionSeguridad = (short)Convert.ToInt32(requestId);
            return (from d in ctx.ConfiguracionSeguridad where d.IdConfiguracionSeguridad == IdConfiguracionSeguridad select d).FirstOrDefault();
        }
    }
}
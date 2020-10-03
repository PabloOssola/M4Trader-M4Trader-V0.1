using M4Trader.ordenes.server.MCContext;
using System;
using System.Linq;

namespace M4Trader.ordenes.mvc
{
    public class ConfiguracionSistemaCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            int idConfiguracionSistema = Convert.ToInt32(requestId);
            return (from d in ctx.ConfiguracionSistema where d.IdConfiguracionSistema == idConfiguracionSistema select d).FirstOrDefault();

        }
    }
}
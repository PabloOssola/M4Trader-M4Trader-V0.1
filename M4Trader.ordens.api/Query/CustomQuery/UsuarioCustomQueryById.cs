using System;
using System.Linq; 
using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.mvc
{
    public class UsuarioCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            short IdUsuario = (short)Convert.ToInt32(requestId);
            return (from d in ctx.Usuario where d.IdUsuario == IdUsuario select d).FirstOrDefault();
        }
    }
}
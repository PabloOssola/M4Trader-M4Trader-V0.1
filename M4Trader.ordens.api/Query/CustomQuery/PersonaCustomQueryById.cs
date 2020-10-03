using System;
using System.Linq;
using M4Trader.ordenes.server.MCContext;

namespace M4Trader.ordenes.mvc
{
    public class PersonaCustomQueryById : CustomQueryById
    {
        protected override object GetById(OrdenesContext ctx, object requestId)
        {
            int idPersona = Convert.ToInt32(requestId);
            return (from d in ctx.Persona where d.IdParty == idPersona select d).FirstOrDefault();

        }
    }
}
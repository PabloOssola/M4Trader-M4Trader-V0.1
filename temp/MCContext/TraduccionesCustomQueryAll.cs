using M4Trader.ordenes.server.MCContext.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server.MCContext
{

    public class MensajesCustomQueryAll
    {
        public List<MensajesLiteralesEntity> Execute(string idioma)
        {
            List<MensajesLiteralesEntity> mensajes;
            using (var context = new OrdenesContext())
            {
                mensajes = (from d in context.MensajesLiterales where d.Idioma == idioma select d).ToList();
            }
            return mensajes;
        }
    }
}
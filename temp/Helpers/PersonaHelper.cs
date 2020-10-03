using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades;

namespace M4Trader.ordenes.server.Helpers
{
    public static class PersonaHelper
    {
        public static PartyEntity ObtenerPersonabyId(int idPersona)
        {
            return PersonasDAL.ObtenerPersonabyId(idPersona);
        }
    }
}

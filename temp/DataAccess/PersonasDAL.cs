using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace M4Trader.ordenes.server.DataAccess
{
    public class PersonasDAL
    {
        public static string AprobarPersonasNovedades(int idNovedad, int idUsuarioAprobador)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@idNovedad", idNovedad));
            lista.Add(SqlServerHelper.GetParam("@idUsuarioAprobador", idUsuarioAprobador));
            SqlParameter p = SqlServerHelper.GetParamStringOuput("@CodigoRespuesta");
            lista.Add(p);

            SqlServerHelper.ExecuteNonQuery("orden_owner.aprobar_personanovedad", lista);
            return (string)p.Value;
        }
        public static void RechazarPersonasNovedades(int idNovedad, int idUsuarioAprobador, byte idMotivoRechazoNovedades)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@idNovedad", idNovedad));
            lista.Add(SqlServerHelper.GetParam("@idUsuarioAprobador", idUsuarioAprobador));
            lista.Add(SqlServerHelper.GetParam("@idMotivoRechazoNovedades", idMotivoRechazoNovedades));

            SqlServerHelper.ExecuteNonQuery("orden_owner.rechazar_personanovedad", lista);
        }

        public static PartyEntity ObtenerPersonabyId(int idPersona)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@idPersona", idPersona));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.PER_ObtenerPersonaByID", lista))
            {
                return reader.DataReaderMapToEntity<PartyEntity>();
            }
        }

        public static void ProcessFromXml(List<SqlParameter> lista)
        {
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[XML_PERSONAS_PROCESSING]", lista);

        }
    }
}

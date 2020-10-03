using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.server.MCContext.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class SessionDAL
    {

        public static SesionEntity GetSessionById(Guid idSesion)
        {
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(SqlServerHelper.GetParam("@idsesion", idSesion));

            using (var reader = SqlServerHelper.ExecuteReader("shared_owner.SESSION_GETBYID", lstParams))
            {
                return reader.DataReaderMapToEntity<SesionEntity>();
            }
        }
    }
}

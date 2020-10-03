using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.server.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class SecurityDAL
    {

        public static List<Permiso> GetAllPermisos(int idusuario)
        {
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(SqlServerHelper.GetParam("@idusuario", idusuario));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.SEG_GETALLPERMISOSBYUSUARIO", lstParams))
            {
                return reader.DataReaderMapToList<Permiso>();
            }
        }
    }
}

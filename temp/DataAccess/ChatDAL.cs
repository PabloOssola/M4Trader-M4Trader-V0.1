using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class ChatDAL
    {
        public static int CrearChat(string nombre, bool esGrupo)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@Nombre", nombre));
            lista.Add(SqlServerHelper.GetParam("@EsGrupo", esGrupo));
            SqlParameter p1 = SqlServerHelper.GetParamStringOuput("@IdChat");
            lista.Add(p1);


            SqlServerHelper.ExecuteNonQuery("orden_owner.CHAT_INSERTARCHAT", lista);
            return int.Parse(p1.Value.ToString());
        }

        public static int InsertarMensaje(int idChat, int origen, string mensaje)
        {
            {
                List<SqlParameter> lista = new List<SqlParameter>();
                lista.Add(SqlServerHelper.GetParam("@IdChat", idChat));
                lista.Add(SqlServerHelper.GetParam("@IdUsuarioOrigen", origen));
                lista.Add(SqlServerHelper.GetParam("@Mensaje", mensaje));
                //TODO sacar este hardcodeo para cuando esten los otros tipos de mensajes.
                lista.Add(SqlServerHelper.GetParam("@IdTipoMensaje", 1));
                SqlParameter p1 = SqlServerHelper.GetParamStringOuput("@IdChatMensaje");
                lista.Add(p1);
                SqlServerHelper.ExecuteNonQuery("orden_owner.CHAT_INSERTARMENSAJECHAT", lista);
                return int.Parse(p1.Value.ToString());
            }
        }
    }
}

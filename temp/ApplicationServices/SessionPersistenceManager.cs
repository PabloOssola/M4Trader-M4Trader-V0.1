using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace M4Trader.ordenes.server.ApplicationServices
{
    public class SessionPersistenceManager //: ISession<SesionEntity>
    {
        private ConcurrentDictionary<Guid, SesionEntity> sesiones = new ConcurrentDictionary<Guid, SesionEntity>();
        
        public void AddOrUpdate(SesionEntity sesion)
        {
            if (sesion.modifiedOrNew)
            {
                this.sesiones.AddOrUpdate(sesion.IdSesion, sesion, (k, v) => sesion);
            }
        }

        public void DeleteSession(Guid idSesion)
        {
            SesionEntity sesion = null;
            this.sesiones.TryRemove(idSesion, out sesion);
        }

        public SesionEntity GetSessionById(Guid idSesion)
        {
            SesionEntity sesion = null;
            this.sesiones.TryGetValue(idSesion, out sesion);
            if (sesion == null)
            {
                sesion = SessionDAL.GetSessionById(idSesion);
                sesion.JavascriptAllowedCommands = sesion.jsAllowedCommands.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Split(',').ToDictionary(item => item.Split(':')[0], item => item.Split(':')[1]);
                sesion.PermisosUsuario = sesion.jsPermisosUsuario.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Split(',').ToDictionary(item => item.Split(':')[0], item => Boolean.Parse(item.Split(':')[1]));
            }
            return sesion;
        }

        public void Persistir()
        {
            if (sesiones.Count == 0)
                return;

            foreach (var s in sesiones)
            {
                if (s.Value.modifiedOrNew)
                {
                    Insertar(s.Value);
                    s.Value.modifiedOrNew = false;
                    if (s.Value.FechaFinalizacion < DateTime.Now)
                    {
                        SesionEntity se;
                        sesiones.TryRemove(s.Key, out se);
                    }
                }
            }
        }

        private void Insertar(SesionEntity sesion)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdSesion", sesion.IdSesion.ToString()));
            lista.Add(SqlServerHelper.GetParam("@IdUsuario", sesion.IdUsuario));
            lista.Add(SqlServerHelper.GetParam("@Ip", sesion.Ip));
            lista.Add(SqlServerHelper.GetParam("@FechaInicio", sesion.FechaInicio));
            lista.Add(SqlServerHelper.GetParam("@FechaFinalizacion", sesion.FechaFinalizacion));
            lista.Add(SqlServerHelper.GetParam("@BajaLogica", sesion.BajaLogica));
            lista.Add(SqlServerHelper.GetParam("@IdAplicacion", sesion.IdAplicacion));
            lista.Add(SqlServerHelper.GetParam("@IdPersona", sesion.IdPersona));
            lista.Add(SqlServerHelper.GetParam("@ClientPublic", sesion.ClientPublic));
            lista.Add(SqlServerHelper.GetParam("@ClientSecret", sesion.ClientSecret));
            lista.Add(SqlServerHelper.GetParam("@ServerPublic", sesion.ServerPublic));
            lista.Add(SqlServerHelper.GetParam("@ServerSecret", sesion.ServerSecret));
            var kvs = sesion.JavascriptAllowedCommands.Select(kvp => string.Format("\"{0}\":\"{1}\"", kvp.Key, kvp.Value));
            string jsAllowedCommands = string.Concat("{", string.Join(",", kvs), "}");
            lista.Add(SqlServerHelper.GetParam("@JsAllowedCommands", jsAllowedCommands));
            if (sesion.PermisosUsuario != null)
            {
                var kvsPermUsuario = sesion.PermisosUsuario.Select(kvp => string.Format("\"{0}\":\"{1}\"", kvp.Key, kvp.Value));
                string permUser = string.Concat("{", string.Join(",", kvsPermUsuario), "}");
                lista.Add(SqlServerHelper.GetParam("@PermisosUsuario", permUser));
            }
            lista.Add(SqlServerHelper.GetParam("@Nonce", sesion.Nonce));
            lista.Add(SqlServerHelper.GetParam("@ConfiguracionRegional", sesion.ConfiguracionRegional));
            SqlServerHelper.ExecuteNonQuery("shared_owner.SESSION_INSERT", lista);
        }
    }
}

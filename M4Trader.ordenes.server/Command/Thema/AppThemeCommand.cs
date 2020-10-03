using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;
using System.Data.Entity;

using System.Linq;
using System.ServiceModel;

namespace M4Trader.ordenes.server
{
    [CommandType("AppThemeCom", (int)IdAccion.CachingManager,  TipoAplicacion.API)]
    public class AppThemeCommand : ABMContextCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            if (!string.IsNullOrEmpty(NombreUsuario))
            {
                usuario = Caching.CachingManager.Instance.GetUsuarioByUsername(NombreUsuario);
            }

            return ExecutionResult.ReturnInmediatelyAndQueueOthers(GetTheme(usuario.IdUsuario));
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.CachingManager;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        [DataMember]
        public string NombreUsuario { get; set; }

        public ThemeEntity GetTheme(int idusuario)
        {

            string keyCache = "THEME_" + idusuario;
            ThemeEntity Theme = CacheLayer.Get<ThemeEntity>(keyCache);

            if (Theme == null)
            {
                using (OrdenesContext dbContext = new OrdenesContext())
                {
                    Theme =
                        (from d in dbContext.Theme where d.IdUsuario == idusuario select d).FirstOrDefault();
                }
                if (Theme != null)
                {
                    CacheLayer.Add<ThemeEntity>(Theme, keyCache);
                }
            }

            return Theme;
        }
    }
}
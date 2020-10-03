using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using System.Runtime.Serialization;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.server.Helpers;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("RefCachCom", (int)IdAccion.RefrescarCacheCommand, TipoAplicacion.ORDENES, TipoAplicacion.DMA, TipoAplicacion.API)]
    public class RefrescarCacheCommand : ABMContextCommand
    {
        public RefrescarCacheCommand(string singularEntityName, string pluralEntityName)
        {

        }

        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            CachingManager.Instance.RefreshAll();
            OrdenesApplication.Instance.RefreshConfiguracionSistema();
            
            return null;
        }


        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {

        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.EstadoSistema;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

    }
}
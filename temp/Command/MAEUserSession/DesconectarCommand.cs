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

    [CommandType("DesConCom", (int)IdAccion.CachingManager, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.API)]
    public class DesconectarCommand : ABMContextCommand
    {
        public DesconectarCommand()
        {

        }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            CachingManager.Instance.RefreshAll();
            OrdenesApplication.Instance.RefreshConfiguracionSistema(false);
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

    }
}
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.server.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class DesconectarRabbitMQCommand : ABMContextCommand
    {
        
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
           
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            //RabbitMQService.Instance.Desconectar();

            return null;
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
        
        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }
    }
}
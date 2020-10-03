using M4Trader.ordenes.services.Entities;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.services.Services
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        [WebInvoke(Method = "POST")]
        void EnviarMensaje(DTOChat chat);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        void InformarNuevoGrupo(DTONuevoChat nuevoChat);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        void InformarNuevoMensaje(DTONuevoMensajeChat nuevoMensajeChat);
    }
}

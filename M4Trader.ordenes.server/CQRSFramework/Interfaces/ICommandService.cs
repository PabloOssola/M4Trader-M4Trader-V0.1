using M4Trader.ordenes.services.Command;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.server.CQRSFramework.Interfaces
{
    [ServiceContract]
    public interface ICommandService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string c(Commande Commnade);
    }
}

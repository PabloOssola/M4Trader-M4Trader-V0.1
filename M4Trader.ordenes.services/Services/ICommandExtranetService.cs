using M4Trader.ordenes.services.Command;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.services.Services
{
    [ServiceContract]
    public interface ICommandExtranetService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string c(JSCommand command);
    }
}

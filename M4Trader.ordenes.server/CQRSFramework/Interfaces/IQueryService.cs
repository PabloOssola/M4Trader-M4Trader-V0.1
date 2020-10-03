using M4Trader.ordenes.server.CQRSFramework.CQRS;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.server.CQRSFramework.Interfaces
{
    [ServiceContract]
    public interface IQueryService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string e(Querye Querye);
    }

}

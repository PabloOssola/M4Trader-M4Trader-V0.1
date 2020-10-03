using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.server.Services
{
    [ServiceContract]
    public interface IOrdenService
    {
        [OperationContract]
        [WebInvoke(Method = "POST")]
        void RecibirOrdenRespuesta(FixOrdenRespuestaEntity orden);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        void RecibirGarantiasRespuesta(FixGarantiasEntity garantia);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        void RecibirTradeCaptureReportRespuesta(FixTradeCaptureReportInfo tradeCaptureReport);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        void RecibirHeartBeat();

        [OperationContract]
        [WebInvoke(Method = "POST")]
        FixOrdenesResponseEntity EnviarOrdenesAlMercado(FixOrdenesEntity ordenes);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        FixOrdenesResponseEntity ReRegistrarse(string mercado);
    }
}

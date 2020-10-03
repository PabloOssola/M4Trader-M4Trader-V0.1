using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Interfaces;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;

namespace M4Trader.ordenes.mvc
{
    public class OperacionStatusCustomQueryById : ICustomQuery
    {
        public object Execute(Query query)
        {
            CustomQueryReturn cqr = new CustomQueryReturn();
            OperationStatusDto operationStatusDto = new OperationStatusDto();
            if (query.Filters.Find(x => x.Key == "ordenNumber").Value != null)
            {
                string ordenNumber = query.Filters.Find(x => x.Key == "ordenNumber").Value.ToString();
                operationStatusDto = OrdenesDAL.ObtenerEtadoOperacion(ordenNumber);
            }
            cqr.Data = new object[1]; 
            cqr.Data[0] = operationStatusDto;
            cqr.TotalRows = 1;

            return cqr;
        }
    }

}
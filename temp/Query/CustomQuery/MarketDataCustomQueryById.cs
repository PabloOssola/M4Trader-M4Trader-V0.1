using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Interfaces;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;

namespace M4Trader.ordenes.mvc
{
    public class MarketDataCustomQueryById : ICustomQuery
    {
        public object Execute(Query query)
        {
            var datos = SqlServerHelper.RunFullRecordListDictionary("orden_owner.EXCEL_MARKETDATA", query.Filters);
            CustomQueryReturn cqr = new CustomQueryReturn();

            MarketDataResponseDto marketDataResponseDto = new MarketDataResponseDto();
            marketDataResponseDto.Offers = new List<OfferDto>();
            List<OfferDto> offers = new List<OfferDto>();
            int totalrows = 0;
            for (int i = 0; i < datos.Count; i++)
            {
                totalrows++;
                object value = null;
                if (i == 0)
                {
                    datos[i].TryGetValue("ClosingPrice", out value);
                    marketDataResponseDto.ClosingPrice = (decimal)value;
                    datos[i].TryGetValue("OpeningPrice", out value);
                    marketDataResponseDto.OpeningPrice = (decimal)value;
                    datos[i].TryGetValue("Quantity", out value);
                    marketDataResponseDto.Quantity = (decimal)value;
                    datos[i].TryGetValue("TradeVolume", out value);
                    marketDataResponseDto.TradeVolume = (decimal)value;
                    datos[i].TryGetValue("HighPrice", out value);
                    marketDataResponseDto.TradingHighPrice = (decimal)value;
                    datos[i].TryGetValue("LowPrice", out value);
                    marketDataResponseDto.TradingLowPrice = (decimal)value;
                    datos[i].TryGetValue("Codigo", out value);
                    marketDataResponseDto.Ticker = value.ToString();
                    datos[i].TryGetValue("EquivalentRate", out value);
                    marketDataResponseDto.EquivalentRate = (decimal)value;
                }
                OfferDto offer = new OfferDto();
               
                datos[i].TryGetValue("CompraVenta", out value);
                offer.BuySell = value.ToString();

                datos[i].TryGetValue("NumeroPosicion", out value);
                offer.NroPosition = (byte)value;

                datos[i].TryGetValue("NumeroDeOfertas", out value);
                offer.NroOffers = (byte)value;

                if (offer.BuySell == "C")
                {
                    datos[i].TryGetValue("PrecioCompra", out value);
                    offer.Price = (decimal)value;
                    datos[i].TryGetValue("CantidadCompra", out value);
                    offer.Quantity = (decimal)value;
                }
                else
                {
                    datos[i].TryGetValue("PrecioVenta", out value);
                    offer.Price = (decimal)value;
                    datos[i].TryGetValue("CantidadVenta", out value);
                    offer.Quantity = (decimal)value;
                }
                
                marketDataResponseDto.Offers.Add(offer);
            }
            cqr.Data = new object[1]; 
            cqr.Data[0] = marketDataResponseDto;
            cqr.TotalRows = totalrows;

            return cqr;
        }
    }

}
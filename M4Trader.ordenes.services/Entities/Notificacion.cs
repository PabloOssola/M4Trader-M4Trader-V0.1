using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.Entities
{
    public abstract class Notificacion
    {
        public int id { get; set; }
        public string CommandName { get; set; }
        public int IdParty { get; set; }
        public byte IdTipoNotificacion { get; set; }
        public int idProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string CodigoProducto { get; set; }
        public decimal? PrecioReferencia { get; set; }
        public decimal? PrecioCierre { get; set; }
        public decimal? Valorizacion { get; set; }
        public string sequenceNumber { get; set; }
        public string key { get; set; }
        public int IdMoneda { get; set; }
        public string Personas { get; set; }
        public byte IdMercado { get; set; }
        public string Mercado { get; set; }
        public byte IdTipoProducto { get; set; }
        public string Rueda { get; set; }
    }

    public class NotificacionRefrescarCache : Notificacion
    {
        public Dictionary<string, string> NotificacionPropiedades { get; set; }
    }

    public class NotificacionEstadoSistema : Notificacion
    {

        public string EstadoSistema { get; set; }
    }

    public class NotificacionPortfolioProducto : Notificacion
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool PorDefecto { get; set; }        
        public string Moneda { get; set; }
        public int IdEmpresa { get; set; }
    }

    public class NotificacionOrden : Notificacion
    {
        public byte IdTipoNotificacionOriginal { get; set; }

        public string symbolKey { get; set; }//: Codigo Producto

        public byte positionId { get; set; }//: numero posicom

        public string orderId2 { get; set; }//: Ide Mercado

        public string symbol { get; set; }//: Codigo Producto

        public int side { get; set; }//: bid or ask,

        public int tradeType { get; set; }//: 0,

        public decimal volume { get; set; }//: item.volume,

        public DateTime openTime { get; set; }//: fecga concertacion,

        public decimal openPrice { get; set; }//: item.openPrice,
        public DateTime expiryDate { get; set; }//: null,
        public decimal marketPrice { get; set; }//: item.marketPrice,
        public decimal margin { get; set; }//: 1,
        public decimal nominalValue { get; set; }//: item.nominalValue,
        public decimal marketValue { get; set; }//: 1,
        public decimal netProfitPercent { get; set; }//: 1,
        public decimal commission { get; set; }//: 1,
        public decimal closeCommission { get; set; }//: 1,
        public decimal storage { get; set; }//: 1,
        public decimal totalProfit { get; set; }//: diff,
        public decimal profit { get; set; }//: profit,
        public string comment { get; set; }//: 1,
        public decimal openOrigin { get; set; }//: "1",
        public decimal? price { get; set; }//: item.price,
        public int? pareja { get; set; }//: Id interno de la contraparte,
        public decimal? total { get; set; }//: item.total,
        public DateTime date { get; set; }//: fecha concertacion
        public byte Estado { get; set; }
        public decimal? EquivalentRate { get; set; }//: TasaEquivalente,
        public bool isNew { get; set; }
        public bool isRun { get; set; }
        public bool delete { get; set; }
        public string symbo_name { get; set; }
        public decimal contrato { get; set; }
        public string Timestamp { get; set; }
        public decimal remainingVolume { get; set; }
        public bool OperoPorTasa { get; set; }
        public decimal? PrecioVinculado { get; set; }
        public decimal executedVolume { get; set; }
        public bool espuja { get; set; }
    }
}

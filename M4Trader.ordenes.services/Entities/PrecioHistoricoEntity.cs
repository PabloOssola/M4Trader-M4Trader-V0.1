using System;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.Entities
{
    [DataContract(Name = "PrecioEntity", Namespace = "http://schemas.datacontract.org/2004/07/M4Trader.ordenes.server.MCContext.Entidades")]
    public class PrecioHistoricoEntity
    {
        public long IdPrecioHistorico { get; set; }
        public int IdProducto { get; set; }
        public byte IdMercado { get; set; }
        public byte IdMoneda { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; } 
    }
}
 

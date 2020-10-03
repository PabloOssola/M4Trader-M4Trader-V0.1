using M4Trader.ordenes.services.Entities;
using System;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract(Name = "FixOrdenEntity", Namespace = "http://schemas.datacontract.org/2004/07/M4Trader.fix.client.interfaces.Entities")]
    public class FixOrdenEntity
    {
        [DataMember]
        public int NumeroOrdenLocal { get; set; }
        [DataMember]
        public string Mercado { get; set; }
        [DataMember]
        public string Producto { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public decimal Cantidad { get; set; }
        [DataMember]
        public decimal CantidadMinima { get; set; }
        [DataMember]
        public DateTime FechaTransaccion { get; set; }
        [DataMember]
        public FixTipoEntradaEnum? TipoOferta { get; set; }
        [DataMember]
        public FixTipoAccionEnum? Accion { get; set; }
        [DataMember]
        public MonedasEnum? Moneda { get; set; }
        [DataMember]
        public string Rueda { get; set; }
        [DataMember]
        public FixTipoOrdenEnum? TipoOrden { get; set; }
        [DataMember]
        public FixSideOrdenEnum Side { get; set; }
        [DataMember]
        public PlazoOrdenEnum? TipoPlazoLiquidacionOrden { get; set; }
        [DataMember]
        public DateTime? FechaLiquidacion { get; set; }
        [DataMember]
        public string AgenteNegociadorId { get; set; }
        [DataMember]
        public string ClienteId { get; set; }
        [DataMember]
        public string ClienteNro { get; set; }
        [DataMember]
        public FixRolParticipanteEnum? ClienteRol { get; set; }
        [DataMember]
        public DateTime? FechaVencimientoOrden { get; set; }
        [DataMember]
        public FixTipoDuracionOrdenEnum? TipoDuracionOrden { get; set; }
        [DataMember]
        public string NumeroOrdenMercado { get; set; }
        [DataMember]
        public bool OperoPorTasa { get; set; }

    }
}
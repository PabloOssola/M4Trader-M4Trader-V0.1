using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract(Name = "FixOrdenRespuestaEntity", Namespace = "http://schemas.datacontract.org/2004/07/M4Trader.fix.client.interfaces.Entities")]
    public class FixOrdenRespuestaEntity
    {
        [DataMember]
        public string Mercado { get; set; }
        [DataMember]
        public string NumeroReferenciaFix { get; set; }
        [DataMember]
        public string NumeroOrdenLocal { get; set; }
        [DataMember]
        public string NumeroOrdenMercado { get; set; }
        [DataMember]
        public string NroOperacionMercado { get; set; }
        [DataMember]
        public FixEstadoOrdenEnum Estado { get; set; }
        [DataMember]
        public FixTipoEjecucionOrdenEnum TipoEjecucion { get; set; }
        [DataMember]
        public decimal PrecioMercado { get; set; }
        [DataMember]
        public decimal PrecioOrden { get; set; }
        [DataMember]
        public decimal Cantidad { get; set; }
        [DataMember]
        public decimal CantidadEjecutada { get; set; }
        [DataMember]
        public decimal CantidadRemanente { get; set; }
        [DataMember]
        public string RechazoTexto { get; set; }
        [DataMember]
        public int RechazoCodigo { get; set; }
        [DataMember]
        public string MensajeTextoPlano { get; set; }
        [DataMember]
        public decimal? SpotRate { get; set; }
        [DataMember]
        public bool? OperoPorTasa { get; set; }
        [DataMember]
        public decimal? PrecioVinculado { get; set; }
        [DataMember]
        public decimal? Valorizacion { get; set; }
    }
}

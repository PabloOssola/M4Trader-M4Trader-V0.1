using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    //[TrackChanges(AuditoriaClase.NovedadesDeTransferencia)]
    [Table("NovedadesDeTransferencias", Schema = "orden_owner")]
    public class NovedadTransferenciaEntity
    {
        public int IdNovedadTransferenciaFondo { get; set; }
        public string CodigoUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string CBUOrigen { get; set; }
        public string CBUDestino { get; set; }
        public string BancoReceptor { get; set; }
        public byte IdMoneda { get; set; }
        public Decimal Importe { get; set; }
        public string Comentarios { get; set; }
        public byte[] Comprobante { get; set; }
        [NotMapped]
        public int IdPersona { get; set; }
        [NotMapped]
        public int IdPersonaDestino { get; set; }
        public int IdEstado { get; set; }

        [NotMapped]
        public string DescripcionMoneda { get; set; }
        [NotMapped]
        public string Estado { get; set; }
        [NotMapped]
        public string Receptor { get; set; }
        [NotMapped]
        public bool EsDepositoEnAgencia { get; set; }

    }
}


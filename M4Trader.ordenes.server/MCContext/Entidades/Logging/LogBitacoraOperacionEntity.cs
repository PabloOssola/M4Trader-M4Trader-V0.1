using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades.Logging
{

    [Table("LogBitacoraOperacion", Schema = "orden_owner")]
    public class LogBitacoraOperacionEntity
    {
        

        public LogBitacoraOperacionEntity(int idOperacion, LogCodigoAccion codigoAccion, string detalleAccion)
        {
            /*TODO*/
            IdOperacion = idOperacion;
            DetalleAccion = detalleAccion;
            Fecha = DateTime.Now.ToUniversalTime();
            if (MAEUserSession.InstanciaCargada)
            {
                IdUsuario = MAEUserSession.Instancia.IdUsuario;
                RequestId = MAEUserSession.Instancia.InCourseRequest;
            }
            else
            {
                IdUsuario = 1;
            }
            CodigoAccion = (byte)codigoAccion;
        }

        [Key]public int IdLogBitacoraOperacion { get; set; }
        public int IdOperacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public byte CodigoAccion { get; set;}
        public string DetalleAccion { get; set; }
        public Guid? RequestId { get; set; }
    }
}

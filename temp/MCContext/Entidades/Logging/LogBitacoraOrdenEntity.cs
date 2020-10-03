using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades.Logging
{

    [Table("LogBitacoraOrdenes", Schema = "orden_owner")]
    public class LogBitacoraOrdenEntity
    {
        

        public LogBitacoraOrdenEntity(int idOrden, LogCodigoAccion codigoAccion, string detalleAccion, EstadoOrden idEstadoOrden, byte? idMotivoCancelacion, SourceEnum? source = null)
        {
            /*TODO*/
            IdOrden = idOrden;
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
            IdEstadoOrden = (byte)idEstadoOrden;
            if(idMotivoCancelacion.HasValue)
                IdMotivoCancelacion = idMotivoCancelacion.Value;
            IdSourceApplication = (byte?)source;
        }

        [Key]public int IdLogBitacoraOrden { get; set; }
        public int IdOrden { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public byte CodigoAccion { get; set;}
        public string DetalleAccion { get; set; }
        public Guid? RequestId { get; set; }
        public byte IdEstadoOrden { get; set; }
        public byte? IdMotivoCancelacion { get; set; }
        public byte? IdSourceApplication { get; set; }
    }
}

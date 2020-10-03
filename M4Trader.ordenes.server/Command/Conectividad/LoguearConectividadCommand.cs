using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("LogConCom", (int)IdAccion.ConsultasGenerales, TipoAplicacion.DMA)]
    public class LoguearConectividadCommand : ABMContextCommand
    {


        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            ConectividadHelper.InsertarLogConectividad(IdPersona, Fecha, Mensaje);
            return null;
        }

       

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }

        public override void Validate()
        {

        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.ConsultasGenerales;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        //Interfgas de travel
        //        IdPersona,
        //        Fecha,
        //        mensaje

        [DataMember]
        public int IdPersona { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

    }
}
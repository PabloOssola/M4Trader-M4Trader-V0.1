using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract(Name = "ConsultaNovedadesDeTransferencia")]
    public class ConsultaNovedadesDeTransferenciaCommand : ABMContextCommand
    {
        public override void Validate()
        {

            #region Requerido
           
            #endregion
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(ConsultaNovedadesDeTransferencia());
        }

        private List<NovedadTransferenciaEntity> ConsultaNovedadesDeTransferencia()
        {
            MAEUserSession usuarioSession = null;
            if (MAEUserSession.InstanciaCargada)
                usuarioSession = MAEUserSession.Instancia;
            return NovedadDeTransferenciaHelper.ConsultaNovedadDeTransferencia(usuarioSession.IdPersona, FechaDesde, FechaHasta, IdMoneda, IdEstado, Receptor, Orden);
        }



        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.NovedadesDeTransferencia;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        } 
        [DataMember]
        public DateTime? FechaDesde { get; set; }
        [DataMember]
        public DateTime? FechaHasta { get; set; }
        [DataMember]
        public byte? IdMoneda { get; set; }
        [DataMember]
        public int? IdEstado { get; set; }
        [DataMember]
        public string Receptor { get; set; }
        [DataMember]
        public string Orden { get; set; }    
    } 
}
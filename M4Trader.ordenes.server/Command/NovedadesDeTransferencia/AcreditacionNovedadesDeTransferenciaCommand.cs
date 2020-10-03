using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace M4Trader.ordenes.server
{
    [DataContract(Name = "AcreditacionNovedadesDeTransferencia")]
    public class AcreditacionNovedadesDeTransferenciaCommand : ABMContextCommand
    {
        public override void Validate()
        {

            #region Requerido
            

            #endregion
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(AcreditacionNovedadesDeTransferencia(IdNovedadDeTrasferencia));
        }

        private string AcreditacionNovedadesDeTransferencia(int IdNovedadDeTrasferencia)
        {
            return NovedadDeTransferenciaHelper.AcreditacionNovedadDeTransferenciaHelper(IdNovedadDeTrasferencia);
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
                return (int)TipoPermiso.ALTA;
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
        public int IdNovedadDeTrasferencia { get; set; }
         
    }
     
     
}
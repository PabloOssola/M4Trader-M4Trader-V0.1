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

namespace M4Trader.ordenes.server
{
    [DataContract(Name = "BajaNovedadesDeTransferencia")]
    public class BajaNovedadesDeTransferenciaCommand : ABMContextCommand
    {
        public override void Validate()
        {

            #region Requerido 
            if (NovedadDeTransferenciaHelper.ObtenerEstadoNovedad(IdNovedadTransferencia) != 1)
            {
                keyArray = new KeyArray();
                keyArray.Codigo = "NovedadAprobada";
                keyArray.Parametros.Add("BAJANOVEDAD");
                keyArray.Parametros.Add("La novedad ya fue aprobada, por favor verifique o contactese con un administrador");
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
            #endregion
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {           
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(BajaNovedadesDeTransferencia(IdNovedadTransferencia));
        }

        private string BajaNovedadesDeTransferencia(int idNovedad)
        {
            return NovedadDeTransferenciaHelper.BajaNovedadDeTransferenciaHelper(idNovedad);
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
                return (int)TipoPermiso.BAJA;
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
        public int IdNovedadTransferencia { get; set; } 
    }
     
     
}
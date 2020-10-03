using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class ConsultaSaldosCommand : ABMCommand
    {

        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            MAEUserSession usuarioSession = null;
            if (MAEUserSession.InstanciaCargada)
                usuarioSession = MAEUserSession.Instancia; 
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(ConsultaDeSaldos(usuarioSession.IdPersona));
        }


        private List<SaldosDTO> ConsultaDeSaldos(int idPersona)
        {
            return SaldosHelper.ConsultaDeSaldos(idPersona);
        }
        

        public override bool needTransactionalBevahiour()
        {
            return false;
        }


        public override void Validate()
        {
            //string NombreEntidad = "Concertar Operaciones";

            //ValidateEstadoSistema(CachingManager.Instance.GetFechaSistema().EstadoAbierto, "Estado del sistema cerrado, no se puede operar", NombreEntidad, "EstadoSistemaCerrar");

            //if (!valida)
            //{
            //    throw fe;
            //}
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Saldos;
            }
        }


        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public byte IdMoneda { get; set; }
        [DataMember]
        public string orden { get; set; }

    }
      
}
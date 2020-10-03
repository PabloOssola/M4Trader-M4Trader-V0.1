using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using System.Runtime.Serialization;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.server.Helpers;
using System.Collections.Generic;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("ReRegCom", (int)IdAccion.ReRegistrarseSecurityList, TipoAplicacion.ORDENES, TipoAplicacion.DMA, TipoAplicacion.API)]
    public class ReRegistrarseCommand : ABMContextCommand
    {
        List<string> mercados;

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            mercados = new List<string>();
            mercados.Add("MAE");


            Response resultado = ProcesamientoGenerica<string>(ReRegistrarse, mercados);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
        }

        private string ReRegistrarse(string mercado)
        {
            return OrdenHelper.ReRegistrarse(mercado);
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        public override void Validate()
        {

        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.ReRegistrarseSecurityList;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

    }
}
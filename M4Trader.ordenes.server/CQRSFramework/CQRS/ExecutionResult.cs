using System;
using System.Collections.Generic;
using static M4Trader.ordenes.server.CQRSFramework.ABM.ABMCommand;

namespace M4Trader.ordenes.server.CQRSFramework.CQRS
{
    public class ExecutionResult
    {
        public static ExecutionResult ReturnInmediately(object data)
        {
            return new ReturnAndForgetExecutionResult(data);
        }

        public static ExecutionResult ReturnInmediatelyAndQueueOthers(object data)
        {
            return new ReturnAndQueueOthersExecutionResult(data);
        }

        public static ExecutionResult ReturnWithError(string Mensaje, Guid IdRequest)
        {
            Response resultado = new Response();

            List<string> resultadosError = new List<string>();
            resultadosError.Add(Mensaje);
            resultado.MensajeError = resultadosError.ToArray();

            resultado.Resultado = eResult.Error;
            resultado.Detalle = IdRequest;
            return new ReturnAndQueueOthersExecutionResult(resultado);
        }


        public object Data
        {
            get;
            protected set;
        }
    }

    public class ReturnAndForgetExecutionResult : ExecutionResult
    {
        public ReturnAndForgetExecutionResult(object data)
        {
            Data = data;
        }
    }

    public class ReturnAndQueueOthersExecutionResult : ExecutionResult
    {
        public ReturnAndQueueOthersExecutionResult(object data)
        {
            Data = data;
        }
    }
}

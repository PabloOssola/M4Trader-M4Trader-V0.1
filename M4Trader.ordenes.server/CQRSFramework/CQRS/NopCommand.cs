using System.Runtime.Serialization;
using System;
using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server.CQRSFramework.CQRS
{
    [DataContract]
    public class NopCommand : Command
    {
        public override int GetIdAccion
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void PreProcess()
        {
        }


        public override void Validate()
        {
        }

        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            return ExecutionResult.ReturnInmediately("NOP");
        }
    }
}
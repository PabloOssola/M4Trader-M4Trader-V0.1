using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("AltaOrdenExcelCommand",(int)IdAccion.OrdenesExcel, TipoAplicacion.COMPLEMENTODMA)]

    public class AltaOrdenExcelCommand : AltaOrdenCommand
    {
        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            return base.ExecuteCommand(inCourseRequest);
        }
 

        public override bool needTransactionalBevahiour()
        {
            return base.needTransactionalBevahiour();
        }


        public override void Validate()
        {
            base.Validate();            
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.OrdenesExcel;
            }
        }


        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.ALTA;
            }
        }         
    }
}
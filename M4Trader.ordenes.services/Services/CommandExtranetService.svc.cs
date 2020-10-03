using M4Trader.ordenes.services.Command;
using M4Trader.ordenes.services.CQRSFramework.CQRS;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using M4Trader.ordenes.services.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace M4Trader.ordenes.services.Services
{
    public class CommandExtranetService : ICommandExtranetService
    {
        public string c(JSCommand command)
        {
            var r = new CommandResult();
            Dictionary<string, object> metaData = null;
            var inCourseRequest = InCourseRequest.New();
            var re = OperationContext.Current;
            try
            {
                return WCFWrapper.Instance.wcfHelper.ExecuteQueryService<ICommandExtranetService>(ServiciosEnum.CommandExtranet, i => i.c(command));
            }
            catch (M4TraderApplicationException ex)
            {

                r.MetaData = metaData;
                r.Data = new object[2] { inCourseRequest.Id, ex.Message };
                r.Status = "EX0000";
                r.RequestId = inCourseRequest.Id.ToString();
                return JsonConvert.SerializeObject(r);
            }
            catch (Exception ex)
            {

                r.MetaData = metaData;
                r.Data = new object[2] { inCourseRequest.Id, ex.Message }; 
                r.Status = "EX0000";
                r.RequestId = inCourseRequest.Id.ToString();
                return JsonConvert.SerializeObject(r);
            }   
        }

    }
}

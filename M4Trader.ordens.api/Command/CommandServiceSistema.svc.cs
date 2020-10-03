using M4Trader.ordenes.server;
using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.DbC;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.CQRSFramework.Interfaces;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Exceptions;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.CQRSFramework.CQRS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Web;
using static M4Trader.ordenes.server.CQRSFramework.ABM.ABMContextCommand;

namespace M4Trader.ordenes.mvc
{
    public class CommandServiceSistema : ICommandServiceSistema
    {
        public string c(Command command)
        {
            var inCourseRequest = InCourseRequest.New();
            OrdenesApplication ordenesApplication = OrdenesApplication.Instance;
            inCourseRequest.SecurityTokenId = ordenesApplication.GetSecurityTokenIdFromHeader();

            Dictionary<string, object> metaData = null;
            var r = new CommandResult();
            Stopwatch stopWatch = null;
            bool includeServerMetrics = false;
            string commandName = command.GetType().Name;

            try
            {
                var opts = command.Options;
                includeServerMetrics = null != opts && opts.ContainsKey("includeServerMetrics");

                if (includeServerMetrics)
                {
                    stopWatch = Stopwatch.StartNew();
                    metaData = new Dictionary<string, object>(1);
                }
                Type tipoAConsultar = command.GetType();
                if (tipoAConsultar != typeof(RefrescarCacheCommand)
                    && command.GetIdAccion != (int)IdAccion.Login)

                {
                    SecurityHelper.ensureAuthorized(command, inCourseRequest);
                    inCourseRequest.Identity_rid = MAEUserSession.Instancia.IdUsuario;//command.ensureAuthorized(inCourseRequest).Identity_rid;
                }
                //TODO: levantar log despues...
                CommandLog.Start(command, inCourseRequest);

                command.PreProcess();
                command.Validate();

                r.MetaData = metaData;

                r.Data = command.Execute(inCourseRequest).Data;
                r.Status = "EX0000";
                r.MetaData = metaData;
                r.RequestId = inCourseRequest.Id.ToString();

                //TODO: levantar log despues...
                CommandLog.FinishOK(commandName, r, inCourseRequest);

                try { command.ExecuteAfterSuccess(); }
                catch { }
            }
            catch (SessionException sex)
            {
                var cr = new CommandResult();
                Response resultado = new Response();
                resultado.Resultado = eResult.Error;
                resultado.MensajeError[0] = "Sessión Expirada";
                cr.Data = ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
                cr.Status = "SE6666";
                cr.MetaData = metaData;

                CommandLog.FinishWithError(commandName, sex, inCourseRequest);

                r = cr;
            }
            catch (PreConditionNotEnsuredException ex)
            {

                Response resultado = new Response();
                resultado.Resultado = eResult.Error;
                resultado.MensajeError[0] = ex.Message;
                resultado.Detalle = inCourseRequest.Id;
                r.Data = ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
                r.Status = "FE9999";
                r.MetaData = metaData;

                //TODO: levantar log despues...
                CommandLog.FinishWithError(commandName, ex, inCourseRequest);
            }
            catch (FunctionalException fe)
            {
                Response resultado = new Response();
                resultado.Resultado = eResult.Error;
                resultado.MensajeError[0] = fe.Message;
                resultado.Detalle = inCourseRequest.Id;
                r.Data = ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
                r.Status = string.Format("FE{0}", fe.Code.ToString("0000"));
                r.MetaData = metaData;

                //TODO: levantar log despues...
                CommandLog.FinishWithError(commandName, fe, inCourseRequest);
            }
            catch (M4TraderApplicationException maex)
            {
                Response resultado = new Response();
                resultado.Resultado = eResult.Error;
                resultado.MensajeError[0] = maex.Message;
                resultado.Detalle = inCourseRequest.Id;
                r.Data = ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
                r.Status = string.Format("FE{0}", maex.Codigo);
                r.MetaData = metaData;
                CommandLog.FinishWithError(commandName, maex, inCourseRequest);
            }
            catch (MAECommunicationException mce)
            {
                Response resultado = new Response();
                resultado.Resultado = eResult.Error;
                resultado.MensajeError[0] = mce.Message;
                resultado.Detalle = inCourseRequest.Id;
                r.Data = ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
                r.Status = string.Format("FE9999");
                r.MetaData = metaData;
                CommandLog.FinishWithError(commandName, mce, inCourseRequest);
            }
            catch (Exception ex)
            {
                Response resultado = new Response();
                resultado.Resultado = eResult.Error;
                resultado.MensajeError[0] = ex.Message;
                resultado.Detalle = inCourseRequest.Id;
                r.Data = ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
                r.Status = "TE9999";
                r.MetaData = metaData;

                //TODO: levantar log despues...
                CommandLog.FinishWithError(commandName, ex, inCourseRequest);
            }
            finally
            {
                command.Dispose();
                if (includeServerMetrics)
                {
                    r.MetaData.Add("serverMetrics", stopWatch.ElapsedMilliseconds);
                    stopWatch.Reset();
                }
            }


            r.RequestId = inCourseRequest.Id.ToString();
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return JsonConvert.SerializeObject(r);

        }
    }
}

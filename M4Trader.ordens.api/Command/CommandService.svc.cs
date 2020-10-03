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
using M4Trader.ordenes.services.Command;
using M4Trader.ordenes.services.CQRSFramework.CQRS;
using Newtonsoft.Json;
using System;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.mvc
{
    public class CommandService : ICommandService
    {
        public string c(Commande Commnade)
        {
            var r = new CommandResult();
            string commandName = Commnade.d;
            Command command = null;
            //string desencry = null;

           var inCourseRequest = InCourseRequest.New();
            OrdenesApplication ordenesApplication = OrdenesApplication.Instance;
            //inCourseRequest.SecurityTokenId = ordenesApplication.GetSecurityTokenIdFromHeader();
            try
            {
                //SecurityHelper.ensureAuthenticated(inCourseRequest);
                //AESEncryptor encryptor = new AESEncryptor();
                //desencry = encryptor.DesencriptarQuery(Commnade.d, MAEUserSession.Instancia.Global);
                //desencry = desencry.Replace("@s", "M4Trader.ordenes.server").Replace("@a", "M4Trader.ordenes.mvc");

                Commnade.d = Commnade.d.Replace("@s", "M4Trader.ordenes.server").Replace("@a", "M4Trader.ordenes.mvc");


                command = JsonConvert.DeserializeObject<Command>(Commnade.d, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
                });
                commandName = command.GetType().Name;


                var opts = command.Options;
                inCourseRequest.Agencia = ordenesApplication.GetSecurityAgenciaFromHeader();
                if (!(command is RefrescarCacheCommand) && command.GetIdAccion != (int)IdAccion.Login && !(command is M4Trader.ordenes.server.AppLiteralesCommand) && !(command is M4Trader.ordenes.server.AppThemeCommand))
                {
                    inCourseRequest.SecurityTokenId = ordenesApplication.GetSecurityTokenIdFromHeader();
                   
                    SecurityHelper.ensureAuthorized(command, inCourseRequest);
                    inCourseRequest.Identity_rid = MAEUserSession.Instancia.IdUsuario;
                }

                CommandLog.Start(command, inCourseRequest);

                command.PreProcess();
                command.Validate();
                
                r.Data = command.Execute(inCourseRequest).Data;
                r.Status = "EX0000";
                r.RequestId = inCourseRequest.Id.ToString();

                CommandLog.FinishOK(commandName, r, inCourseRequest);
                try { command.ExecuteAfterSuccess(); }
                catch { }
            }
            catch (JsonSerializationException)
            {
                Commnade.d = Commnade.d.Replace("M4Trader.ordenes.mvc", "M4Trader.ordenes.server");

                command = JsonConvert.DeserializeObject<Command>(Commnade.d, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
                });
                commandName = command.GetType().Name;
                var opts = command.Options;

                if (!(command is RefrescarCacheCommand) && command.GetIdAccion != (int)IdAccion.Login && !(command is M4Trader.ordenes.server.AppLiteralesCommand))
                {
                    inCourseRequest.SecurityTokenId = ordenesApplication.GetSecurityTokenIdFromHeader();
                    SecurityHelper.ensureAuthorized(command, inCourseRequest);
                    inCourseRequest.Identity_rid = MAEUserSession.Instancia.IdUsuario;
                }

                CommandLog.Start(command, inCourseRequest);

                command.PreProcess();
                command.Validate();

                r.Data = command.Execute(inCourseRequest).Data;
                r.Status = "EX0000";
                r.RequestId = inCourseRequest.Id.ToString();

                CommandLog.FinishOK(commandName, r, inCourseRequest);
                try { command.ExecuteAfterSuccess(); }
                catch { }
            }
            catch (SessionException sex)
            {
                CommandLog.StartDesencriptado(Commnade.d, inCourseRequest);

                var cr = new CommandResult();
                cr.Data = ExecutionResult.ReturnWithError("Sessión Expirada", inCourseRequest.Id).Data;
                cr.Status = "SE6666";

                CommandLog.FinishWithError(commandName, sex, inCourseRequest);

                r = cr;
            }
            catch (PreConditionNotEnsuredException ex)
            {
                CommandLog.StartDesencriptado(Commnade.d, inCourseRequest);

                r.Data = ExecutionResult.ReturnWithError(ex.Message, inCourseRequest.Id).Data;
                r.Status = "FE9999";

                CommandLog.FinishWithError(commandName, ex, inCourseRequest);
            }
            catch (FunctionalException fe)
            {
                CommandLog.StartDesencriptado(Commnade.d, inCourseRequest);

                r.Data = ExecutionResult.ReturnWithError(fe.Message, inCourseRequest.Id).Data;
                r.Status = string.Format("FE{0}", fe.Code.ToString("0000"));

                CommandLog.FinishWithError(commandName, fe, inCourseRequest);
            }
            catch (M4TraderApplicationException maex)
            {
                CommandLog.StartDesencriptado(Commnade.d, inCourseRequest);

                r.Data = ExecutionResult.ReturnWithError(maex.Message, inCourseRequest.Id).Data;
                r.Status = string.Format("FE{0}", maex.Codigo);
                CommandLog.FinishWithError(commandName, maex, inCourseRequest);
            }
            catch (MAECommunicationException mce)
            {
                CommandLog.StartDesencriptado(Commnade.d, inCourseRequest);

                r.Data = ExecutionResult.ReturnWithError(mce.Message, inCourseRequest.Id).Data;
                r.Status = "FE9999";
                CommandLog.FinishWithError(commandName, mce, inCourseRequest);
            }
            catch (MAEConcurrencyException mce)
            {
                CommandLog.StartDesencriptado(Commnade.d, inCourseRequest);

                r.Data = ExecutionResult.ReturnWithError(mce.Message, inCourseRequest.Id).Data;
                r.Status = "FE00055";
                CommandLog.FinishWithError(commandName, mce, inCourseRequest);
            }
            catch (Exception ex)
            {
                CommandLog.StartDesencriptado(Commnade.d, inCourseRequest);

                r.Data = ExecutionResult.ReturnWithError(ex.Message, inCourseRequest.Id).Data;
                r.Status = "TE9999";

                CommandLog.FinishWithError(commandName, ex, inCourseRequest);
            }

            finally
            {
                if( command != null)
                    command.Dispose();
            }

            r.RequestId = inCourseRequest.Id.ToString();
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return JsonConvert.SerializeObject(r);

        }
    }
}

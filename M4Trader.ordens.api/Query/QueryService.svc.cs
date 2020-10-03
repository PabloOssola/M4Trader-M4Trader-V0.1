using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.CQRSFramework.Interfaces;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.CQRSFramework.CQRS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Web;

namespace M4Trader.ordenes.mvc
{

    public class QueryService : IQueryService
    {
        private Dictionary<string, IExtraFilter> extraFilters = null;
        private Dictionary<string, ICustomQuery> customQueries = null;

        public string e(Querye querye)
        {

            Dictionary<string, object> metaData = null;
            QueryResult qr = null;
            Stopwatch stopWatch = null;

            bool includeServerMetrics = false;
            bool returnColumnNames = false;
            string queryName = querye.d;

            var inCourseRequest = InCourseRequest.New();
            OrdenesApplication ordenesApplication = OrdenesApplication.Instance;
            inCourseRequest.SecurityTokenId = ordenesApplication.GetSecurityTokenIdFromHeader();
            inCourseRequest.Agencia = ordenesApplication.GetSecurityAgenciaFromHeader();

            Query query = null;

            try
            {

                SecurityHelper.ensureAuthenticated(inCourseRequest);
                query = JsonConvert.DeserializeObject<Query>(querye.d, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
                });

                var type = (QueryType)Enum.Parse(typeof(QueryType), query.Type);

                //includeServerMetrics = null != opts && opts.ContainsKey("includeServerMetrics");
                //returnColumnNames = null != opts && opts.ContainsKey("returnColumnNames");

                includeServerMetrics = null != query.Options && query.Options.Exists(x => x.Key.Equals("includeServerMetrics", StringComparison.OrdinalIgnoreCase));
                returnColumnNames = null != query.Options && query.Options.Exists(x => x.Key.Equals("returnColumnNames", StringComparison.OrdinalIgnoreCase));

                if (includeServerMetrics)
                {
                    stopWatch = Stopwatch.StartNew();
                    metaData = new Dictionary<string, object>(1);
                }

                SecurityHelper.ensureAuthorized(query, inCourseRequest);
                queryName = query.Name;
                //query.ensureAuthorized(inCourseRequest);
                //var queryName = query.getDecriptedQueryName();

                //TODO Encender QueryLog.Start para loguear... hay que adaptarlo a Ordenes
                QueryLog.Start(query, inCourseRequest);

                var requireIdentity = query.Options.Find(x => x.Key.Equals("requireIdentityFilter", StringComparison.OrdinalIgnoreCase));
                // Es comun que varias consultas necesiten el usuario que las activa....
                if (requireIdentity != null && Convert.ToBoolean(requireIdentity.Value))
                {
                    //query.Filters.Add("IdUsuario", session.Identity_rid);
                    query.Filters.Add(new Parameter() { Key = "IdUsuario", Value = MAEUserSession.Instancia.IdUsuario });
                }


                if (query.Options.Exists(x => x.Key == "extendToKnownType"))
                {
                    ExtendQueryFilters(query);
                }
                if (queryName.Contains("_CUSTOM_"))
                {
                    qr = new QueryResult();
                    var tName = queryName.Split(new string[] { "_CUSTOM_" }, StringSplitOptions.None)[1] + "CustomQueryById";
                    object result = reflect(query, tName);

                    qr.Data = new object[] { result };
                    qr.Status = "EX0000";
                    qr.MetaData = metaData;
                }
                else
                {
                    switch (type)
                    {
                        case QueryType.Grid:
                            var r = new QueryPagingResult();

                            int totalRows;
                            string[] columnNames;
                            object[] r_grid = null;
                            var draw = 0;
                            //query.Filters.Remove("maxrecord"); //TODO: porque remueves este parametro?
                            if (query.Options.Exists(x => x.Key.Equals("gridAdapter", StringComparison.OrdinalIgnoreCase)))
                            {
                                var result = (CustomQueryReturn)reflect(query, queryName);
                                r_grid = result.Data;
                                totalRows = result.TotalRows;
                            }
                            else
                            {
                                r_grid = SqlServerHelper.RunGrid("orden_owner." + queryName, query.Filters, out columnNames, out totalRows);
                                if (returnColumnNames)
                                    r.ColumnNames = columnNames;
                            }

                            var pageSize = query.Filters.Find(i => i.Key == "pageSize");
                            draw = (pageSize != null) ? Convert.ToInt32(pageSize.Value) : totalRows;

                            r.Data = r_grid;
                            r.Status = "EX0000";
                            r.MetaData = metaData;
                            r.draw = (int)draw;
                            r.recordsTotal = totalRows;
                            r.recordsFiltered = totalRows;//r_grid.Length;

                            qr = r;
                            break;
                        case QueryType.Combos:
                            qr = new QueryResult();
                            DatabaseQueryResult r_combos = null;
                            if (query.Options.Exists(x => x.Key == "filtersAdapter"))
                            {
                                r_combos = (DatabaseQueryResult)reflect(query, queryName);
                            }
                            else
                            {
                                r_combos = SqlServerHelper.RunCombos("orden_owner." + queryName, query.Filters);
                            }
                            qr.Data = r_combos.ResultSets.ToArray();
                            qr.Status = "EX0000";
                            qr.MetaData = metaData;
                            break;
                        case QueryType.Data:
                            qr = new QueryResult();
                            qr.Data = new object[1]; // TODO: FIXME: arreglar para tener mas de un data set
                            qr.Data[0] = SqlServerHelper.RunDictionary("orden_owner." + queryName, query.Filters);
                            qr.Status = "EX0000";
                            qr.MetaData = metaData;
                            break;
                        case QueryType.FullRecord:
                            if (query.Options.Exists(x => x.Key.Equals("gridAdapter", StringComparison.OrdinalIgnoreCase)))
                            {
                                var rqr = new QueryPagingResult();
                                var result = (CustomQueryReturn)reflect(query, queryName);
                                r_grid = result.Data;
                                totalRows = result.TotalRows;
                                draw = totalRows;

                                rqr.Data = r_grid;
                                rqr.Status = "EX0000";
                                rqr.MetaData = metaData;
                                rqr.draw = (int)draw;
                                rqr.recordsTotal = totalRows;
                                rqr.recordsFiltered = totalRows;//r_grid.Length;
                                qr = rqr;
                            }
                            else
                            {
                                qr = new QueryResult();
                                var r_fullrecord = SqlServerHelper.RunFullRecord("orden_owner." + queryName, query.Filters);
                                qr.Data = r_fullrecord.ResultSets.ToArray();
                                qr.Status = "EX0000";
                                qr.MetaData = metaData;
                            }
                            break;
                        case QueryType.FullByEntity:
                            qr = new QueryResult();
                            //TODO ADAPTAR PARA USAR EF...
                            //var r_fullrecord = ReadDatabase.Instance.RunFullRecord("orden_owner." + queryName, query.Filters);
                            //qr.Data = r_fullrecord.ResultSets.ToArray();
                            qr.Status = "EX0000";
                            qr.MetaData = metaData;
                            break;
                    }
                }

                //TODO Encender QueryLog.FinishOK para loguear... adapatar a Ordenes
                QueryLog.FinishOK(query, qr, inCourseRequest);
            }
            catch (SessionException sex)
            {
                qr = new QueryResult();

                qr.Data = new object[2] { inCourseRequest.Id, "Sessión Expirada" };
                qr.Status = "SE6666";
                qr.MetaData = metaData;

                //TODO: levantar log despues...
                QueryLog.FinishWithError(queryName, qr, sex, inCourseRequest);
            }
            catch (FunctionalException fe)
            {
                qr = new QueryResult();

                qr.Data = new object[2] { inCourseRequest.Id, fe.Message };
                qr.Status = string.Format("FE{0}", fe.Code.ToString("0000"));
                qr.MetaData = metaData;

                //TODO: levantar log despues...
                QueryLog.FinishWithError(queryName, qr, fe, inCourseRequest);
            }
            catch (Exception ex)
            {
                qr = new QueryResult();

                qr.Data = new object[2] { inCourseRequest.Id, ex.Message };
                qr.Status = "TE9999";
                qr.MetaData = metaData;

                //TODO: levantar log despues...
                QueryLog.FinishWithError(queryName, qr, ex, inCourseRequest);
            }
            finally
            {
                if (includeServerMetrics)
                {
                    qr.MetaData.Add("serverMetrics", stopWatch.ElapsedMilliseconds); 
                    stopWatch.Reset();
                }
            }

            qr.RequestId = inCourseRequest.Id;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return JsonConvert.SerializeObject(qr);
        }

       
        private object reflect(Query query, string tName)
        {
            if (this.customQueries == null)
            {
                this.customQueries = new Dictionary<string, ICustomQuery>();
                var interfaceCustomQueryType = typeof(ICustomQuery);
                var asm = typeof(QueryService).Assembly;
                var types = asm.GetTypes();
                foreach (Type t in types)
                {
                    if (interfaceCustomQueryType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                    {
                        ICustomQuery classInstance = (ICustomQuery)Activator.CreateInstance(t, null);
                        this.customQueries.Add(t.Name, classInstance);
                    }
                }

                //asm = typeof(CustomQueryById).Assembly;
                //types = asm.GetTypes();
                //foreach (Type t in types)
                //{
                //    if (interfaceCustomQueryType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                //    {
                //        ICustomQuery classInstance = (ICustomQuery)Activator.CreateInstance(t, null);
                //        this.customQueries.Add(t.Name, classInstance);
                //    }
                //}

            }
            if (!this.customQueries.ContainsKey(tName))
                throw new TechnicalException(new Exception("No se encuentra definido el custom query: " + tName));
            return this.customQueries[tName].Execute(query); ;
        }

        private void ExtendQueryFilters(Query query)
        {
            if (this.extraFilters == null)
            {
                this.extraFilters = new Dictionary<string, IExtraFilter>();
                var interfaceExtraFilterType = typeof(IExtraFilter);
                var asm = typeof(QueryService).Assembly;
                var types = asm.GetTypes();
                foreach (Type t in types)
                {
                    if (interfaceExtraFilterType.IsAssignableFrom(t) && !t.IsInterface)
                    {
                        IExtraFilter classInstance = (IExtraFilter)Activator.CreateInstance(t, null);
                        this.extraFilters.Add(t.Name, classInstance);
                    }
                }
            }
            var key = query.Options.Find(x => x.Key == "extendToKnownType").Value.ToString();
            if (!this.extraFilters.ContainsKey(key))
                throw new TechnicalException(new Exception("No se encuentra definido el filtro adicional: " + key));

            this.extraFilters[key].AddExtraFilters(query);
        }

    }
}
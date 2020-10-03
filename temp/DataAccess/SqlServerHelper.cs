using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace M4Trader.ordenes.server.DataAccess
{
    public class SqlServerHelper
    {
        private static string connectionString;
        private static int? commandTimeout;

        static SqlServerHelper()
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                return;
            }
            commandTimeout = 60;
            string tmp = ConfigurationManager.ConnectionStrings["Ordenes"].ConnectionString;
            if (tmp.Contains("|"))
            {
                commandTimeout = int.Parse(tmp.Split('|')[0]) * 60;
                connectionString = tmp.Split('|')[1];
            }
            else
            {
                connectionString = tmp;
            }
        }

        public static bool CheckConnection()
        {
            bool resp = false;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                }
                resp = true;
            }
            catch
            {
                LoggingHelper.Instance.NoHayConexcionConLaBase(connectionString);
            }
            return resp;
        }

        #region Reader
        public static void ExecuteNonQuery(string sp, List<SqlParameter> parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    // Create a command and prepare it for execution
                    using (SqlCommand cmd = GetCommand(conn, sp))
                    {
                        if (parameters != null && parameters.Count > 0)
                            cmd.Parameters.AddRange(parameters.ToArray());
                        int retval = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("ExecuteNonQuery", sp, parameters, e));
                LoggingHelper.HandleException(e);
            }
        }

        public static IDataReader ExecuteReader(string sp, List<SqlParameter> parameters)
        {
            try
            {
                IDataReader dr = null;
                SqlConnection conn = GetConnection();
                {
                    conn.Open();
                    // Create a command and prepare it for execution
                    using (SqlCommand cmd = GetCommand(conn, sp))
                    {
                        cmd.CommandText = sp;
                        if (parameters != null && parameters.Count > 0)
                            cmd.Parameters.AddRange(parameters.ToArray());

                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                }

                return dr;
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("ExecuteReader", sp, parameters, e));
                LoggingHelper.HandleException(e);
                return null;
            }
        }

        public static object ExecuteScalar(string sp, List<SqlParameter> parameters)
        {
            try
            {
                object retval = null;
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    // Create a command and prepare it for execution
                    using (SqlCommand cmd = GetCommand(conn, sp))
                    {
                        cmd.CommandText = sp;
                        if (parameters != null && parameters.Count > 0)
                            cmd.Parameters.AddRange(parameters.ToArray());
                        retval = cmd.ExecuteScalar();
                    }
                }
                return retval;
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("ExecuteScalar", sp, parameters, e));
                LoggingHelper.HandleException(e);
                return null;
            }
        }



        public static object ExecuteScalar(string sp, object parameters)
        {
            object col1 = null;
            try
            {


                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    var cmd = GetCommand(conn, sp);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (cmd)
                    {
                        buildParameters(parameters, cmd);
                        col1 = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                List<Parameter> parametersBuild = new List<Parameter>();
                if (parameters != null && parameters.GetType() != null
                    && parameters.GetType().GetProperties() != null && parameters.GetType().GetProperties().Length > 0)
                {
                    parametersBuild.Add(new Parameter() { Key = parameters.GetType().GetProperties()[0].Name, Value = parameters.GetType().GetProperties()[0].GetValue(parameters) });
                }
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("ExecuteScalar", sp, buildParametrosToLog(parametersBuild), e));
                LoggingHelper.HandleException(e);
            }

            return col1;
        }

        private static List<SqlParameter> buildParametrosToLog(List<Parameter> parameters)
        {
            List<SqlParameter> resp = new List<SqlParameter>();
            if (null == parameters)
            {
                return resp;
            }

            foreach (var kp in parameters)
            {
                var param = new SqlParameter();
                param.ParameterName = kp.Key;
                param.Value = kp.Value;
                param.Direction = ParameterDirection.Input;

                resp.Add(param);
            }

            return resp;
        }

        private static SqlCommand GetCommand(SqlConnection conn, string storedProcedureName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            if (commandTimeout.HasValue)
                cmd.CommandTimeout = commandTimeout.Value;

            cmd.CommandText = storedProcedureName;

            return cmd;
        }

        public static SqlParameter GetParamTimeStampOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Timestamp
            };
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        #endregion

        #region Parameters
        public static SqlParameter GetParam(string param, Guid? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor.Value,
                    SqlDbType = SqlDbType.UniqueIdentifier
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.UniqueIdentifier
                };
            }
        }

        internal static SqlParameter GetParam(string paramName, List<int> valor)
        {
            DataTable t = new DataTable();
            t.Columns.Add("id_r", typeof(int));
            foreach (var id_r in valor)
            {
                t.Rows.Add(id_r);
            }

            return new SqlParameter()
            {
                TypeName = "Int32List",
                ParameterName = paramName,
                Value = t,
                SqlDbType = SqlDbType.Structured
            };
        }

        internal static SqlParameter GetParam(string paramName, List<long> valor)
        {
            DataTable t = new DataTable();
            t.Columns.Add("id_r", typeof(int));
            foreach (var id_r in valor)
            {
                t.Rows.Add(id_r);
            }

            return new SqlParameter()
            {
                TypeName = "Int64List",
                ParameterName = paramName,
                Value = t,
                SqlDbType = SqlDbType.Structured
            };
        }

        public static SqlParameter GetParam(string param, int valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.Int
            };
        }

        public static SqlParameter GetParam(string param, int? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor.Value,
                    SqlDbType = SqlDbType.Int
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.Int
                };
            }
        }

        public static SqlParameter GetParam(string param, decimal valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.Decimal
            };
        }

        public static SqlParameter GetParam(string param, decimal? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor,
                    SqlDbType = SqlDbType.Decimal
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.Decimal
                };
            }
        }

        public static SqlParameter GetParam(string param, DateTime valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.DateTime
            };
        }

        public static SqlParameter GetParam(string param, DateTime? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor,
                    SqlDbType = SqlDbType.DateTime
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.DateTime
                };
            }
        }

        public static SqlParameter GetParamDateTime2(string param, DateTime valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.DateTime2
            };
        }

        public static SqlParameter GetParamSmall(string param, DateTime valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.SmallDateTime
            };
        }
        public static SqlParameter GetParamMinNull(string param, DateTime valor)
        {
            if (valor != DateTime.MinValue)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor,
                    SqlDbType = SqlDbType.DateTime
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.DateTime
                };
            }
        }

        public static SqlParameter GetParamFrom(string param, DateTime? valor)
        {
            SqlParameter p = new SqlParameter(param, SqlDbType.DateTime);
            p.Value = DBNull.Value;
            if (valor != null)
            {
                DateTime begin = new DateTime(valor.Value.Year, valor.Value.Month, valor.Value.Day, 0, 0, 0);
                p.Value = begin;
            }
            return p;
        }

        public static SqlParameter GetParamTo(string param, DateTime? valor)
        {
            SqlParameter p = new SqlParameter(param, SqlDbType.DateTime);
            p.Value = DBNull.Value;
            if (valor != null)
            {
                DateTime begin = new DateTime(valor.Value.Year, valor.Value.Month, valor.Value.Day, 23, 59, 59);
                p.Value = begin;
            }
            return p;
        }

        public static SqlParameter GetParam(string param, bool valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.Bit
            };
        }

        public static SqlParameter GetParam(string param, bool? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor,
                    SqlDbType = SqlDbType.Bit
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.Bit
                };
            }
        }

        public static SqlParameter GetParam(string param, long valor)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Value = valor,
                SqlDbType = SqlDbType.BigInt
            };
        }

        public static SqlParameter GetParam(string param, long? valor)
        {
            if (valor != null)
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = valor,
                    SqlDbType = SqlDbType.BigInt
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = param,
                    Value = DBNull.Value,
                    SqlDbType = SqlDbType.BigInt
                };
            }
        }

        public static SqlParameter GetParam(string param, Byte[] valor)
        {
            SqlParameter p = new SqlParameter(param, SqlDbType.Timestamp);
            p.Value = valor;
            p.Direction = ParameterDirection.Input;
            return p;
        }

        public static SqlParameter GetParam(string param, string valor)
        {
            SqlParameter p = new SqlParameter(param, SqlDbType.VarChar);
            p.Value = DBNull.Value;
            p.Direction = ParameterDirection.Input;
            if (!string.IsNullOrEmpty(valor))
            {
                p.Value = valor;
            }
            return p;
        }


        public static SqlParameter GetParamIntOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Int
            };
        }

        public static SqlParameter GetParamByteOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.TinyInt
            };
        }

        public static SqlParameter GetParamLongOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.BigInt
            };
        }

        public static SqlParameter GetParamStringOuput(string param)
        {
            return new SqlParameter()
            {
                ParameterName = param,
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.VarChar,
                Size = 8000
            };
        }

        public static SqlParameter GetParamReturn()
        {
            return new SqlParameter()
            {
                Direction = ParameterDirection.ReturnValue,
            };
        }

        #endregion

        #region CQRS
        public static Dictionary<string, string> RunDictionary(string storedProcedureName, List<Parameter> parameters)
        {
            try
            {
                var r = new Dictionary<string, string>(100);

                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        var cmd = GetCommand(conn, storedProcedureName);
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (cmd)
                        {

                            buildParameters(parameters, cmd);

                            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    r.Add(dr[0].ToString(), dr[1].ToString());
                                }
                                dr.Close();
                                return r;
                            }
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("RunDictionary", storedProcedureName, buildParametrosToLog(parameters), e));
                LoggingHelper.HandleException(e);
                return null;
            }
        }

        public static DatabaseQueryResult RunCombos(string storedProcedureName, List<Parameter> parameters)
        {
            try
            {
                var r = new DatabaseQueryResult();

                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = GetCommand(conn, storedProcedureName))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            buildParameters(parameters, cmd);

                            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                var resultSetCount = 0;

                                do
                                {
                                    var resultSetData = new ArrayList(100);

                                    while (dr.Read())
                                    {
                                        var row = new ArrayList(dr.FieldCount);

                                        for (var i = 0; i < dr.FieldCount; i++)
                                        {
                                            var colValue = dr[i];

                                            row.Add(colValue);
                                            if (dr[i].GetType().Name.Equals("Byte[]"))
                                                row[i] = BitConverter.ToString((byte[])colValue, 0);
                                        }

                                        resultSetData.Add(row);
                                    }

                                    var rs = new ResultSet(resultSetCount.ToString());
                                    rs.Data = resultSetData;
                                    rs.Columns = getColumnNames(dr);
                                    r.ResultSets.Add(rs);
                                    resultSetCount++;

                                } while (dr.NextResult());

                                return r;
                            }
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("RunCombos", storedProcedureName, buildParametrosToLog(parameters), e));
                LoggingHelper.HandleException(e);
                return null;
            }
        }

        public static object[] RunGrid(string storedProcedureName, List<Parameter> parameters, out string[] columnNames, out int rowCount)
        {
            var r = new ArrayList(100);
            rowCount = 0;
            columnNames = null;
            try
            {

                var totalRows = 0;
                var totalRowsAsField = true;
                string[] colStrings = null;
                var columnNamesCompleted = false;
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (var cmd = GetCommand(conn, storedProcedureName))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            buildParameters(parameters, cmd);

                            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.Read())
                                {
                                    var row = new object[dr.FieldCount];
                                    if (!columnNamesCompleted)
                                        colStrings = new string[dr.FieldCount];
                                    for (var i = 0; i <= dr.FieldCount - 1; i++)
                                    {
                                        var colValue = dr[i];

                                        row[i] = colValue;

                                        if (dr[i].GetType().Name.Equals("Byte[]"))
                                            row[i] = System.BitConverter.ToString((byte[])colValue, 0);

                                        if (!columnNamesCompleted)
                                            colStrings[i] = dr.GetName(i);
                                    }

                                    if (!columnNamesCompleted)
                                    {
                                        totalRowsAsField = dr.HasColumn("TotalRows");
                                        totalRows = (totalRowsAsField) ? Convert.ToInt32(dr["TotalRows"]) : 0;
                                        columnNamesCompleted = true;
                                    }

                                    r.Add(row);
                                }
                                columnNames = colStrings;
                                dr.Close();
                            }
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }

                    rowCount = (totalRowsAsField) ? totalRows : r.Count;

                }
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("RunGrid", storedProcedureName, buildParametrosToLog(parameters), e));
                LoggingHelper.HandleException(e);
                return null;
            }
            return r.ToArray();
        }

        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    prop.SetValue(obj, dr[prop.Name] == DBNull.Value ? null : dr[prop.Name], null);
                }
                list.Add(obj);
            }
            try { dr.Close(); } catch { }
            return list;
        }

        public static List<T> DataReaderMapToListAs400<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        prop.SetValue(obj, dr[prop.Name] == DBNull.Value ? null : dr[prop.Name], null);
                    }
                    catch { }
                }
                list.Add(obj);
            }
            try { dr.Close(); } catch { }
            return list;
        }

        public static List<T> RunFullRecordGeneric<T>(string storedProcedureName, List<Parameter> parameters)
        {
            List<T> list = new List<T>();
            try
            {
                var r = new DatabaseQueryResult();


                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = GetCommand(conn, storedProcedureName))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            buildParameters(parameters, cmd);

                            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                list = DataReaderMapToList<T>(dr);
                            }

                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("RunFullRecordGeneric", storedProcedureName, buildParametrosToLog(parameters), ex));
                LoggingHelper.HandleException(ex);
            }

            return list;
        }

        public static List<T> RunFullRecordGenericForAs400<T>(string storedProcedureName, List<Parameter> parameters)
        {
            List<T> list = new List<T>();
            try
            {
                var r = new DatabaseQueryResult();

                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = GetCommand(conn, storedProcedureName))
                        {
                            cmd.CommandTimeout = 10;
                            cmd.CommandType = CommandType.StoredProcedure;
                            buildParameters(parameters, cmd);

                            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                list = DataReaderMapToListAs400<T>(dr);
                            }

                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("RunFullRecordGeneric", storedProcedureName, buildParametrosToLog(parameters), ex));
                LoggingHelper.HandleException(ex);
            }
            return list;
        }


        public static List<T> RunFullRecordGenericForAs400<T>(string storedProcedureName, List<SqlParameter> parameters)
        {
            List<T> list = new List<T>();
            try
            {
                var r = new DatabaseQueryResult();

                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = GetCommand(conn, storedProcedureName))
                        {
                            cmd.CommandTimeout = 10;
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (parameters != null && parameters.Count > 0)
                                cmd.Parameters.AddRange(parameters.ToArray());

                            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                list = DataReaderMapToListAs400<T>(dr);
                            }

                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("RunFullRecordGeneric", storedProcedureName, parameters, ex));
                LoggingHelper.HandleException(ex);
            }
            return list;
        }
        public static Dictionary<string, object> RunFullRecordDictionary(string storedProcedureName, List<Parameter> parameters)
        {
            var details = new Dictionary<string, object>();
            try
            {
                var r = new DatabaseQueryResult();


                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = GetCommand(conn, storedProcedureName))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            buildParameters(parameters, cmd);

                            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                if (dr.HasRows && dr.Read())
                                {
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        details.Add(dr.GetName(i), dr.IsDBNull(i) ? null : dr.GetValue(i));
                                    }
                                }
                                dr.Close();
                            }

                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("RunFullRecordDictionary", storedProcedureName, buildParametrosToLog(parameters), e));
                LoggingHelper.HandleException(e);
            }
            return details;
        }

        public static List<Dictionary<string, object>> RunFullRecordListDictionary(string storedProcedureName, List<Parameter> parameters)
        {
            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            Dictionary<string, object> details = null;
            try
            {
                var r = new DatabaseQueryResult();


                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = GetCommand(conn, storedProcedureName))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            buildParameters(parameters, cmd);

                            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                while (dr.HasRows && dr.Read())
                                {
                                    details = new Dictionary<string, object>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        details.Add(dr.GetName(i), dr.IsDBNull(i) ? null : dr.GetValue(i));
                                    }
                                    result.Add(details);
                                }
                            }

                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("RunFullRecordDictionary", storedProcedureName, buildParametrosToLog(parameters), e));
                LoggingHelper.HandleException(e);
            }
            return result;
        }

        public static DatabaseQueryResult RunFullRecord(string storedProcedureName, List<Parameter> parameters)
        {
            try
            {
                var r = new DatabaseQueryResult();

                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = GetCommand(conn, storedProcedureName))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            buildParameters(parameters, cmd);

                            using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                var resultSetCount = 0;

                                do
                                {
                                    var resultSetData = new ArrayList(100);

                                    while (dr.Read())
                                    {
                                        var row = new ArrayList(dr.FieldCount);

                                        for (var i = 0; i < dr.FieldCount; i++)
                                        {
                                            var colValue = dr[i];

                                            row.Add(colValue);
                                        }

                                        resultSetData.Add(row);
                                    }

                                    var rs = new ResultSet(resultSetCount.ToString());
                                    rs.Data = resultSetData;
                                    rs.Columns = getColumnNames(dr);
                                    r.ResultSets.Add(rs);
                                    resultSetCount++;

                                } while (dr.NextResult());
                                dr.Close();
                                return r;
                            }
                        }
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("RunFullRecord", storedProcedureName, buildParametrosToLog(parameters), e));
                LoggingHelper.HandleException(e);
                return null;
            }
        }

        private static List<SqlParameter> buildParameters(List<Parameter> parameters)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            if (null == parameters) return sqlParam;

            SqlParameter param = null;
            foreach (var kp in parameters)
            {
                param = GetParam(kp.Key, kp.Value);

                sqlParam.Add(param);
            }

            return sqlParam;
        }

        private static void buildParameters(List<Parameter> parameters, SqlCommand cmd)
        {
            if (null == parameters) return;

            SqlParameter param = null;
            foreach (var kp in parameters)
            {
                param = GetParam(kp.Key, kp.Value);

                cmd.Parameters.Add(param);
            }

        }

        private static SqlParameter GetParam(string key, object valor)
        {

            if (valor != null)
            {
                Type type = valor.GetType();
                bool isNullable = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
                return new SqlParameter()
                {
                    ParameterName = key,
                    Value = valor,//isNullable ? ((Nullable)valor).GetValueOrDefault() : valor,
                    SqlDbType = TypeConvertor.ToSqlDbType(type)
                };
            }
            else
            {
                return new SqlParameter()
                {
                    ParameterName = key,
                    Value = DBNull.Value
                    //SqlDbType = TypeConvertor.ToSqlDbType(type)
                };
            }
        }

        private static void buildParameters(object dto, SqlCommand cmd)
        {
            if (null == dto) return;

            foreach (var p in dto.GetType().GetProperties())
            {
                var param = new SqlParameter();
                param.ParameterName = p.Name;
                param.Value = p.GetValue(dto);
                param.SqlDbType = TypeConvertor.ToSqlDbType(p.PropertyType);
                param.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(param);
            }
        }

        private static string[] getColumnNames(IDataReader dr)
        {
            var count = dr.FieldCount;
            var r = new string[count];

            for (var i = 0; i < count; i++)
            {
                r[i] = dr.GetName(i);
            }

            return r;
        }
        #endregion

        #region GetParameters
        public static DateTime GetDateTime(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetDateTime(i);
            else
                return new DateTime(1 / 1 / 1);
        }

        public static string GetString(IDataReader reader, String fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetString(i);
            else
                return string.Empty;
        }

        public static Decimal GetDecimal(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetDecimal(i);
            else
                return 0;
        }

        public static byte GetByte(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetByte(i);
            else
                return 0;
        }

        public static Int16 GetInt16(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetInt16(i);
            else
                return 0;
        }

        public static Int32 GetInt32(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetInt32(i);
            else
                return 0;
        }

        public static Int64 GetInt64(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetInt64(i);
            else
                return 0;
        }

        public static bool GetBool(IDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(reader.GetOrdinal(fieldName)))
                return reader.GetBoolean(i);
            else
                return false;
        }
        #endregion
    }

    public static class DataRecordExtensions
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}

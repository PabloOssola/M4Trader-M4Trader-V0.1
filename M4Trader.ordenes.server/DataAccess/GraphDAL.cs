using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using M4Trader.ordenes.server.DataAccess.Interfaces;

namespace M4Trader.ordenes.server.DataAccess
{
    public class GraphDAL
    {
        public static Responsechart GetGD(int idProducto, DateTime from, DateTime to, string StoreProcedure)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));
            lista.Add(SqlServerHelper.GetParam("@FechaDesde", from));
            lista.Add(SqlServerHelper.GetParam("@FechaHasta", to));

            Responsechart responseChart = new Responsechart();
            List<Data> Data = new List<Data>();

            using (var reader = SqlServerHelper.ExecuteReader("precios_owner." + StoreProcedure, lista))
            {
                while (reader.Read())
                {
                    if (!(reader as SqlDataReader).HasRows)
                        return null;

                    Data d = new Data();
                    d.close = reader.GetDecimal(7);
                    d.high = reader.GetDecimal(10);
                    d.low = reader.GetDecimal(9);
                    d.open = reader.GetDecimal(8);

                    //Ver si se puede resolver en SQLServer
                    long ticks = reader.GetDateTime(1).ToUniversalTime().Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
                    ticks /= 10000000; //Convert windows ticks to seconds

                    d.time = ticks;
                    d.volumefrom = reader.GetDecimal(6);
                    d.volumeto = reader.GetDecimal(6);

                    Data.Add(d);
                }

                responseChart.RateLimit = new RateLimit();
                if (Data.Count > 0)
                {
                    responseChart.TimeTo = Data.Last().time;
                    responseChart.TimeFrom = Data.First().time; 
                }
                responseChart.Data = Data;
                responseChart.ConversionType = new ConversionType();
                responseChart.Response = "Success";
            }
            return responseChart;
        }

        public static List<GraphMinEntity> GetGDDay20Min(string codigoProducto, string moneda, string plazo, string rueda, string mercado)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@CodigoProducto", codigoProducto));
            lista.Add(SqlServerHelper.GetParam("@Moneda", moneda));
            lista.Add(SqlServerHelper.GetParam("@Plazo", plazo));
            lista.Add(SqlServerHelper.GetParam("@Rueda", rueda));
            lista.Add(SqlServerHelper.GetParam("@Mercado", mercado));

            Responsechart responseChart = new Responsechart();
            List<GraphMinEntity> Data = new List<GraphMinEntity>();

            using (var reader = SqlServerHelper.ExecuteReader("precios_owner.HIS_ObtenerOfertas20Min", lista))
            {
                while (reader.Read())
                {
                    if (!(reader as SqlDataReader).HasRows)
                        return null;

                    GraphMinEntity d = new GraphMinEntity();

                    if (!reader.IsDBNull(0))
                        d.precio_of_c = Math.Round(reader.GetDecimal(0),3);

                    if (!reader.IsDBNull(1))
                        d.precio_of_v = Math.Round(reader.GetDecimal(1), 3);

                    int time = reader.GetInt32(2);

                    int hora = Int32.Parse(time.ToString().Substring(0, 2));
                    int minutos = Int32.Parse(time.ToString().Substring(2, 2));

                    DateTime dateT = DateTime.Today;
                    TimeSpan horaT = new TimeSpan(0, hora, minutos, 0);
                    DateTime combined = dateT.Add(horaT);                   

                    //Ver si se puede resolver en SQLServer
                    long ticks = combined.ToUniversalTime().Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
                    ticks /= 10000000; //Convert windows ticks to seconds

                    d.secuencia = ticks;

                    Data.Add(d);
                }
            }

            return Data;
        }

        public static void InsertarPrecio(PrecioHistoricoEntity precio)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", precio.IdProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMoneda", precio.IdMoneda));
            lista.Add(SqlServerHelper.GetParam("@Precio", precio.Precio));
            lista.Add(SqlServerHelper.GetParam("@Cantidad", precio.Cantidad));

            SqlServerHelper.ExecuteNonQuery("precios_owner.HIS_ActualizarDatos", lista);
        }
    }
}

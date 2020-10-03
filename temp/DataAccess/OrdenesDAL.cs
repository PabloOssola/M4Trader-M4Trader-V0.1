using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class OrdenesDAL
    {
        public static void InsertarOrden(OrdenEntity orden)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@CompraVenta", orden.CompraVenta));
            lista.Add(SqlServerHelper.GetParam("@IdProducto", orden.IdProducto));
            lista.Add(SqlServerHelper.GetParam("@IdMoneda", orden.IdMoneda));
            lista.Add(SqlServerHelper.GetParam("@IdMercado", orden.IdMercado));
            lista.Add(SqlServerHelper.GetParam("@IdPersona", orden.IdPersona));
            lista.Add(SqlServerHelper.GetParam("@IdEnNombreDe", orden.IdEnNombreDe));
            lista.Add(SqlServerHelper.GetParam("@FechaConcertacion", orden.FechaConcertacion));
            lista.Add(SqlServerHelper.GetParam("@Cantidad", orden.Cantidad));
            lista.Add(SqlServerHelper.GetParam("@CantidadMinima", orden.CantidadMinima));
            if (orden.IdUsuario.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@IdUsuario", orden.IdUsuario));
            }
            if (orden.PrecioLimite.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@PrecioLimite", orden.PrecioLimite.Value));
            }
            lista.Add(SqlServerHelper.GetParam("@IdEstado", orden.IdEstado));
            if (orden.IdMotivoBaja.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@IdMotivoBaja", orden.IdMotivoBaja));
            }
            lista.Add(SqlServerHelper.GetParam("@IdTipoVigencia", (int)orden.IdTipoVigencia));
            lista.Add(SqlServerHelper.GetParam("@FechaVencimiento", orden.FechaVencimiento));
            lista.Add(SqlServerHelper.GetParam("@NumeroOrdenMercado", orden.NumeroOrdenMercado));
            if (orden.Plazo.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@Plazo", orden.Plazo));
            }
            lista.Add(SqlServerHelper.GetParam("@IdTipoOrden", orden.IdTipoOrden));
            lista.Add(SqlServerHelper.GetParam("@IdSourceApplication", orden.IdSourceApplication));
            if (orden.IdOrdenDeReferencia.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@IdOrdenDeReferencia", orden.IdOrdenDeReferencia.Value));
            }
            if (orden.EquivalentRate.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@EquivalentRate", orden.EquivalentRate.Value));
            }
            lista.Add(SqlServerHelper.GetParam("@OperoPorTasa", orden.OperoPorTasa));
            if (orden.PrecioVinculado.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@PrecioVinculado", orden.PrecioVinculado));
            }
            if (orden.Tasa.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@Tasa", orden.Tasa));
            }
            SqlParameter p1 = SqlServerHelper.GetParamStringOuput("@IdOrden");
            lista.Add(p1);

            SqlParameter p2 = SqlServerHelper.GetParamStringOuput("@NroOrdenInterno");
            lista.Add(p2);

            SqlParameter p3 = SqlServerHelper.GetParamTimeStampOuput("@timestamp");
            lista.Add(p3);

            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_InsertarOrden", lista);
            orden.IdOrden = int.Parse(p1.Value.ToString());
            orden.NumeroOrdenInterno = int.Parse(p2.Value.ToString());
            orden.Timestamp = (byte[])(p3.Value);
        }

        public static object GetGDDay(int idProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));

            List<DataGraph> Data = new List<DataGraph>();

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.ORD_MonteOperado", lista))
            {
                while (reader.Read())
                {
                    if (!(reader as SqlDataReader).HasRows)
                        return null;
                    //select p.IdProducto, o.CompraVenta, o.FechaConcertacion, hcd.MontoOperado 
                    DataGraph d = new DataGraph();
                    d.IdProducto = reader.GetInt32(0);
                    d.Compraoventa = reader.GetString(1);
                    d.Fechaconcertacion = reader.GetDateTime(2);
                    d.Montooperado = reader.GetDecimal(3);

                    Data.Add(d);
                }
            }
            return Data;
        }

        public static bool CheckOrdenActivaEnMercadoByIdProducto(int idProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter p1 = SqlServerHelper.GetParamStringOuput("@Cantidad");
            lista.Add(p1);
            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));
            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_CheckOrdenActivaEnMercadoByIdProducto", lista);
            return int.Parse(p1.Value.ToString()) > 0;
        }

        public static void ActualizarOrden(OrdenEntity orden)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdOrden", orden.IdOrden));

            lista.Add(SqlServerHelper.GetParam("@PrecioLimite", orden.PrecioLimite));

            lista.Add(SqlServerHelper.GetParam("@Plazo", orden.Plazo));

            //if (SettlementDate != null)
            //{
            //    lista.Add(SqlServerHelper.GetParam("@SettlementDate", orden.FechaLiquidacion));
            //}

            lista.Add(SqlServerHelper.GetParam("@Cantidad", orden.Cantidad));

            lista.Add(SqlServerHelper.GetParam("@IdMercado", orden.IdMercado));

            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_ActualizarOrden", lista);
        }

        public static void CancelarOrden(OrdenEntity orden)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdOrden", orden.IdOrden));
            lista.Add(SqlServerHelper.GetParam("@IdEstado", orden.IdEstado));
            lista.Add(SqlServerHelper.GetParam("@IdMotivoBaja", orden.IdMotivoBaja));

            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_CancelarOrden", lista);
        }

        public static void AnularConfirmarOrden(OrdenEntity orden)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdOrden", orden.IdOrden));
            lista.Add(SqlServerHelper.GetParam("@IdEstado", orden.IdEstado));
            lista.Add(SqlServerHelper.GetParam("@IdMotivoBaja", orden.IdMotivoBaja));

            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_AnularConfirmarOrden", lista);
        }

        public static int GetRemanentes(int idOrden)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter p1 = SqlServerHelper.GetParamStringOuput("@Remanentes");
            lista.Add(p1);
            lista.Add(SqlServerHelper.GetParam("@IdOrden", idOrden));
            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_GetRemanentes", lista);
            return int.Parse(p1.Value.ToString());
        }

        public static void InsertarOrdenOperacion(OrdenOperacionEntity ordenOperacion, byte? idEstado, string numeroOrdenMercado)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdOrden", ordenOperacion.IdOrden));
            lista.Add(SqlServerHelper.GetParam("@NroOperacionMercado", ordenOperacion.NroOperacionMercado));
            lista.Add(SqlServerHelper.GetParam("@NroOperacionBoleto", ordenOperacion.NroOperacionBoleto));
            lista.Add(SqlServerHelper.GetParam("@Precio", ordenOperacion.Precio));
            lista.Add(SqlServerHelper.GetParam("@Cantidad", ordenOperacion.Cantidad));
            lista.Add(SqlServerHelper.GetParam("@OperoPorTasa", ordenOperacion.OperoPorTasa));
            if (ordenOperacion.PrecioVinculado.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@PrecioVinculado", ordenOperacion.PrecioVinculado));
            }
            if (idEstado.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@IdEstado", idEstado));
            }
            if (!string.IsNullOrEmpty(numeroOrdenMercado))
            {
                lista.Add(SqlServerHelper.GetParam("@NumeroOrdenMercado", numeroOrdenMercado));
            }
            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_InsertarOrdenOperacion", lista);
        }

        public static void CambioEstadoOrden(int idOrden, byte idEstado, string numeroOrdenMercado, decimal? equivalentRate, bool operoPorTasa, decimal? precioVinculado, decimal? precioLimite, decimal? Valorizacion, DateTime? SettlementDate = null)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdOrden", idOrden));
            lista.Add(SqlServerHelper.GetParam("@IdEstado", idEstado));
            if (!string.IsNullOrEmpty(numeroOrdenMercado))
            {
                lista.Add(SqlServerHelper.GetParam("@NumeroOrdenMercado", numeroOrdenMercado));
            }
            if (equivalentRate.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@EquivalentRate", equivalentRate));
            }
            lista.Add(SqlServerHelper.GetParam("@OperoPorTasa", operoPorTasa));
            if (precioVinculado.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@PrecioVinculado", precioVinculado));
            }
            if (precioLimite.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@Precio", precioLimite));
            }
            if (Valorizacion.HasValue)
            {
                lista.Add(SqlServerHelper.GetParam("@Valorizacion", Valorizacion));
            }
            if (SettlementDate != null)
            {
                lista.Add(SqlServerHelper.GetParam("@SettlementDate", SettlementDate));
            }
            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_Actualizar_EstadoNroMercado_Orden", lista);
        }

        public static OrdenEntity ObtenerOrdenbyID(int IdOrden)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdOrden", IdOrden));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.[QRY_SCRN_ORDENES_ENTITY_FULL]", lista))
            {
                return reader.DataReaderMapToEntity<OrdenEntity>();
            }
        }

        public static OrdenEntity ObtenerOrdenbyNumeroOrdenInterno(int NumeroOrdenInterno)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@NumeroOrdenInterno", NumeroOrdenInterno));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.ORD_OBTENERORDENBYNUMEROORDENINTERNO", lista))
            {
                return reader.DataReaderMapToEntity<OrdenEntity>();
            }
        }

        public static List<LogAuditoriaOrdenEntity> ObtenerLogAuditoriaOrden(int IdOrden, int IdUsuario)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdOrden", IdOrden));
            lista.Add(SqlServerHelper.GetParam("@IdUsuario", IdUsuario));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.QRY_SCRN_BITACORAORDENES_GRID_MAIN_ALL", lista))
            {
                return reader.DataReaderMapToList<LogAuditoriaOrdenEntity>();
            }

        }

        public static List<OrdenEntity> ObtenerOrdenesPendientes()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdMercado", 1));
            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.DMA_GetPosturasDelDia", lista))
            {
                var items = reader.DataReaderMapToList<OrdenEntity>();
                return items;
            }
        }

        public static List<OrdenOperacionEntity> ObtenerOrdenesOperacionByProducto(int idProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdProducto", idProducto));
            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.ORD_ObtenerOrdenesOperacionByProducto", lista))
            {
                var items = reader.DataReaderMapToList<OrdenOperacionEntity>();
                return items;
            }
        }

        public static List<OrdenIngresadaEntity> ObtenerOrdenesByEstadoID(int estadoId)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdEstado", estadoId));
            lista.Add(SqlServerHelper.GetParam("@Fecha", CachingManager.Instance.GetFechaSistema()?.FechaSistema));
            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.ORD_ORDENESBYESTADOID", lista))
            {
                var items = reader.DataReaderMapToList<OrdenIngresadaEntity>();
                return items;
            }
        }

        public static OperationStatusDto ObtenerEtadoOperacion(string ordenNumber)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@OrdenNumber", ordenNumber));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.EXCEL_GETOPERACIONESTADO", lista))
            {
                return reader.DataReaderMapToEntity<OperationStatusDto>();
            }
        }

        public static void DeleteRejectedOrder(int idOrden)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdOrden", idOrden));
            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_DeleteRejectedOrder", lista);
        }

        public static void DeleteOpenOrder(int idOrden)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@IdOrden", idOrden));
            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_DeleteOpenOrder", lista);
        }
    }

    public class DataGraph
    {
        public int IdProducto { get; set; }
        public decimal Montooperado { get; set; }
        public string Compraoventa { get; set; }
        public DateTime Fechaconcertacion { get; set; }

    }
}

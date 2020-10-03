using M4Trader.ordenes.server.MCContext.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class OperacionesDAL
    {
        public static void CrearOperacion(OperacionEntity operacion)
        {
            List<SqlParameter> lista = new List<SqlParameter>();


            lista.Add(SqlServerHelper.GetParam("@IdPersonaComprador", operacion.IdPersonaComprador));
            lista.Add(SqlServerHelper.GetParam("@IdPersonaVendedor", operacion.IdPersonaVendedor));
            lista.Add(SqlServerHelper.GetParam("@Cantidad", operacion.Cantidad));
            lista.Add(SqlServerHelper.GetParam("@Monto", operacion.Monto));
            lista.Add(SqlServerHelper.GetParam("@Precio", operacion.Precio));
            lista.Add(SqlServerHelper.GetParam("@NroOperacion", operacion.NroOperacion));
            lista.Add(SqlServerHelper.GetParam("@FechaOperacion", operacion.FechaOperacion));
            lista.Add(SqlServerHelper.GetParam("@IdMonedaCompra", operacion.IdMonedaCompra));
            lista.Add(SqlServerHelper.GetParam("@IdMonedaVenta", operacion.IdMonedaVenta)); 
            SqlParameter IdOperacion = SqlServerHelper.GetParamIntOuput("@IdPropietario");
            lista.Add(IdOperacion);

            SqlServerHelper.ExecuteNonQuery("[orden_owner].[OPE_CrearOperacion]", lista);
            operacion.IdOperacion = (int)IdOperacion.Value;
        }


        public static void CrearRestricciones(OperacionEntity operacion, LimitesPorPersonaEntity limite)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
             
            lista.Add(SqlServerHelper.GetParam("@FechaOperacion", operacion.FechaOperacion));
            lista.Add(SqlServerHelper.GetParam("@Tope", limite.Tope));
            lista.Add(SqlServerHelper.GetParam("@TipoOperacion", limite.TipoOperacion));
            lista.Add(SqlServerHelper.GetParam("@IdPersona", limite.IdPersona));
            lista.Add(SqlServerHelper.GetParam("@IdTiempoLimite", limite.IdTiempoLimite));

            SqlServerHelper.ExecuteNonQuery("[orden_owner].[OPE_CrearRestricciones]", lista);
        }

        public static decimal ObtenerCantidadOperda(LimitesPorPersonaEntity limite)
        {
            List<SqlParameter> lista = new List<SqlParameter>();


            lista.Add(SqlServerHelper.GetParam("@IdPersonaComprador", limite.IdPersona));
            lista.Add(SqlServerHelper.GetParam("@IdPersonaVendedor", limite.IdTiempoLimite));
            lista.Add(SqlServerHelper.GetParam("@Cantidad", limite.TipoOperacion));
            SqlParameter TotalOperado = SqlServerHelper.GetParamIntOuput("@TotalOperado");
            lista.Add(TotalOperado);

            SqlServerHelper.ExecuteNonQuery("[orden_owner].[OPE_ObtenerCantidadOperda]", lista);
            return (decimal)TotalOperado.Value;
        }
        

    }
}

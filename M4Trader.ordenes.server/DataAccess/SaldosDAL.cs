using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.server.MCContext.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class SaldosDAL
    {
        public static void CleanSaldos()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[ORD_CleanSaldos]", lista);
        }

        public static decimal ObtenerImporteSaldo(int idPersona, byte idmoneda)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdMoneda", idmoneda));
            lista.Add(SqlServerHelper.GetParam("@IdPersona", idPersona));
            SqlParameter Importe = SqlServerHelper.GetParamDecimalOuput("@Importe");
            lista.Add(Importe); 

            SqlServerHelper.ExecuteNonQuery("[orden_owner].[OPE_GetSaldoByPersonaYMoneda]", lista);
            return (decimal)(Importe.Value);
        }


        public static List<SaldosDTO> ConsultaSaldosByPersona(int idPersona)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdPersona", idPersona));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.SAL_OBTENERSALDOSPORPERSONA", lista))
            {
                return reader.DataReaderMapToList<SaldosDTO>();
            }
        }

        public static MovimientosSaldos ObtenerSaldoByIdMovimiento(int idMovimiento)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@idMovimiento", idMovimiento));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.SAL_OBTENERSALDOSPORID", lista))
            {
                return reader.DataReaderMapToEntity<MovimientosSaldos>();
            }
        }
        


        public static byte[] ObtenerUltimaActualizacionSaldo(byte IdMoneda, int IdPersona)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdMoneda", IdMoneda));
            lista.Add(SqlServerHelper.GetParam("@IdPersona", IdPersona));
            SqlParameter UltimaActualizacion = SqlServerHelper.GetParamTimeStampOuput("@UltimaActualizacion");
            lista.Add(UltimaActualizacion);

            SqlServerHelper.ExecuteNonQuery("[orden_owner].[OPE_ObtenerUltimaActualizacionSaldo]", lista);
            if (!string.IsNullOrEmpty(UltimaActualizacion.Value.ToString()))
                return (byte[])(UltimaActualizacion.Value);
            else
                throw new Exception(string.Format("La persona {0}, no tiene saldos suficientes para realizar la operación con la moneda {1} por favor contactese con un administrador ", CachingManager.Instance.GetPersonaById(IdPersona).Name, CachingManager.Instance.GetMonedaById(IdMoneda).Descripcion));
        }

        public static void GenerarMovimientos(List<MovimientosSaldos> movimimientoSaldos)
        { 
            foreach(MovimientosSaldos m in movimimientoSaldos)
            {
                List<SqlParameter> lista = new List<SqlParameter>();
                lista.Add(SqlServerHelper.GetParam("@IdTipoMovimiento", (int)m.IdTipoMovimiento));
                lista.Add(SqlServerHelper.GetParam("@IdMoneda", m.IdMoneda));
                lista.Add(SqlServerHelper.GetParam("@IdPersona", m.IdPersona));
                lista.Add(SqlServerHelper.GetParam("@Importe", m.Importe));
                lista.Add(SqlServerHelper.GetParam("@IdPropietario", m.IdPropietario));
                lista.Add(SqlServerHelper.GetParam("@ImpactoEnSaldo", false));
                lista.Add(SqlServerHelper.GetParam("@IdEstado", m.IdEstado));


                SqlServerHelper.ExecuteNonQuery("[orden_owner].[OPE_GenerarMovimientosByPersonaYMoneda]", lista);
            }
        }

        public static void ActualizarSaldos(List<MovimientosSaldos> movimimientoSaldos)
        {
            foreach (MovimientosSaldos m in movimimientoSaldos)
            {
                List<SqlParameter> lista = new List<SqlParameter>();

                lista.Add(SqlServerHelper.GetParam("@IdMoneda", m.IdMoneda));
                lista.Add(SqlServerHelper.GetParam("@IdPersona", m.IdPersona));
                lista.Add(SqlServerHelper.GetParam("@Importe", m.Importe));
                lista.Add(SqlServerHelper.GetParam("@IdTipoMovimiento", (int)m.IdTipoMovimiento));
                SqlServerHelper.ExecuteNonQuery("[orden_owner].[OPE_ImpactarEnSaldoByPersonaYMoneda]", lista);
            }
        }

        public static void ActualizarEstado(int idEstado, int idMovimiento)
        { 
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdEstado", idEstado));
            lista.Add(SqlServerHelper.GetParam("@idMovimiento", idMovimiento)); 
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[SAL_ActualizarEstado]", lista);
          
        }
        

        public static void AgregarDepositoPendiente(NovedadTransferenciaEntity n)
        { 
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdMoneda", n.IdMoneda));
            lista.Add(SqlServerHelper.GetParam("@IdPersona", n.IdPersona));
            lista.Add(SqlServerHelper.GetParam("@Importe", n.Importe));
            lista.Add(SqlServerHelper.GetParam("@Cuenta", n.CBUOrigen));
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[Nov_AgregarDespositoEnSaldoByPersonaYMoneda]", lista);
        }

        public static List<MovimientosSaldos> ObtenerMovimientosSaldoByIdPropietario(int idPropietario)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@idPropietario", idPropietario));

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.SAL_OBTENERMOVIMIENTOSSALDOSBYIDPROPIETARIO", lista))
            {
                return reader.DataReaderMapToList<MovimientosSaldos>();
            }
        } 

        public static void ImpactarEnSaldosHistoricos(DateTime fechaSistema)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            lista.Add(SqlServerHelper.GetParam("@FechaSistema", fechaSistema));
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[OPE_ImpactarEnSaldoHistoricosOperacionesDelDia]", lista);
        }


        public static void ProcessFromXml(List<SqlParameter> lista)
        {
            SqlServerHelper.ExecuteNonQuery("[orden_owner].[XML_SALDOS_PROCESSING]", lista);
        }
    }
}

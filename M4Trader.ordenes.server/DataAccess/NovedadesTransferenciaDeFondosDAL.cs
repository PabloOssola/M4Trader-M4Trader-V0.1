using M4Trader.ordenes.server.DataAccess.Interfaces;
using M4Trader.ordenes.server.MCContext.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace M4Trader.ordenes.server.DataAccess
{
    public class NovedadesTransferenciaDeFondosDAL
    {
        public static void CrearNovedadTransferencia(NovedadTransferenciaEntity novedad)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@CodigoUsuario", novedad.CodigoUsuario));
            lista.Add(SqlServerHelper.GetParam("@Fecha", novedad.Fecha));
            lista.Add(SqlServerHelper.GetParam("@CBUOrigen", novedad.CBUOrigen));
            lista.Add(SqlServerHelper.GetParam("@CBUDestino", novedad.CBUDestino));
            lista.Add(SqlServerHelper.GetParam("@BancoReceptor", novedad.BancoReceptor));
            lista.Add(SqlServerHelper.GetParam("@IdMoneda", novedad.IdMoneda));
            lista.Add(SqlServerHelper.GetParam("@Importe", novedad.Importe));
            lista.Add(SqlServerHelper.GetParam("@Comentarios", novedad.Comentarios));
            lista.Add(SqlServerHelper.GetParam("@Comprobante", novedad.Comprobante));


            SqlParameter IdNovedadTransferenciaFondo = SqlServerHelper.GetParamIntOuput("@IdNovedadTransferenciaFondo");
            lista.Add(IdNovedadTransferenciaFondo);

            SqlServerHelper.ExecuteNonQuery("[orden_owner].[NOV_CrearNovedad]", lista);
            novedad.IdNovedadTransferenciaFondo = (int)IdNovedadTransferenciaFondo.Value;
        }

        public static List<NovedadTransferenciaEntity> ConsultaNovedades(int IdPersona, DateTime? fechaDesde, DateTime? fechaHasta, byte? idMoneda, int? idEstado, string receptor, string orden)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdPersona", IdPersona));
            lista.Add(SqlServerHelper.GetParam("@fechaDesde", fechaDesde));
            lista.Add(SqlServerHelper.GetParam("@fechaHasta", fechaHasta));
            lista.Add(SqlServerHelper.GetParam("@idMoneda", idMoneda));
            lista.Add(SqlServerHelper.GetParam("@idEstado", idEstado));
            lista.Add(SqlServerHelper.GetParam("@receptor", receptor));
            lista.Add(SqlServerHelper.GetParam("@orden", orden));   

            using (var reader = SqlServerHelper.ExecuteReader("orden_owner.NOV_OBTENERNOVEDADESDETRANSFERENCIA", lista))
            {
                return reader.DataReaderMapToList<NovedadTransferenciaEntity>();
            }
        }
        

        public static int ObtenerEstadoNovedad(int idNovedad)
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            lista.Add(SqlServerHelper.GetParam("@IdNovedadDeTransferencia", idNovedad)); 

            SqlParameter IdEstado = SqlServerHelper.GetParamIntOuput("@IdEstado");
            lista.Add(IdEstado);

            SqlServerHelper.ExecuteNonQuery("[orden_owner].[NOV_ObtenerEstadoNovedad]", lista);
            return (int)IdEstado.Value;
        }
        

    }
}

using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.CQRSFramework.Transactions;
using System;
using System.Linq;
using System.Transactions;

namespace M4Trader.ordenes.server.Helpers
{
    public static class SistemaHelper
    {
        public static void AbrirElDia(int idUsuario)
        {
            bool cerrarAntes = false;
            //TODO: se lo deshabilito temporalmente porque requiere tener habilitado el servicio MS MSDTC (Distributed Transaction Server)
            //using (ReadCommittedTransactionScope scope = new ReadCommittedTransactionScope(TransactionScopeOption.Required))
            //{
            EstadoSistemaEntity estadoSistema;
            using (OrdenesContext context = new OrdenesContext())
            {
                int idEstadoSistema = context.EstadoSistema.Where(p1 => p1.IdEstadoSistema != 0).Max(r => r.IdEstadoSistema);
                estadoSistema = context.EstadoSistema.Where(p => p.IdEstadoSistema == idEstadoSistema).FirstOrDefault();
                if (estadoSistema.EstadoAbierto)
                {
                    cerrarAntes = true;
                }
                if (!cerrarAntes)
                {
                    CleanOfertas_Precios();
                    CleanLimitesDiarios();
                    //context.OpenConnection();
                    EstadoSistemaEntity request = new EstadoSistemaEntity()
                    {
                        EjecucionValidacion = false,
                        EstadoAbierto = true,
                        FechaCierre = null,
                        IdUsuarioCierre = null,
                        FechaApertura = DateTime.Now,
                        FechaSistema = DateTime.Now,
                        BajaLogica = false,
                        IdUsuarioApertura = idUsuario
                    };
                    context.Add(request);
                    context.SaveChanges();
                    estadoSistema = request;
                }
                else
                {
                    OrdenHelper.ActualizarOrdenes();
                }
            }
            if (!cerrarAntes)
            {
                OrdenHelper.InformarMercadoEstado((byte)TipoEstadoSistema.ULTIMO_ABIERTO, "AbrirSistemaCommand");
                //    scope.Complete();
                //}
            }
            //TODO validar
            else if (estadoSistema.FechaSistema.Date != DateTime.Now.Date)
            {
                CerrarElDiaYAbrirlo(idUsuario);
            }
        }

        public static void CerrarElDiaYAbrirlo(int idUsuario)
        {
            CerrarElDia(idUsuario);
            AbrirElDia(idUsuario);
        }

        public static void CerrarElDia(int idUsuario)
        {
            using (ReadCommittedTransactionScope scope = new ReadCommittedTransactionScope(TransactionScopeOption.Required))
            {
                RechazarOrdenesPorCierreDia();
                using (OrdenesContext context = new OrdenesContext())
                {
                    int idEstadoSistema = context.EstadoSistema.Where(p1 => p1.IdEstadoSistema != 0).Max(r => r.IdEstadoSistema);
                    var entidad = context.EstadoSistema.Where(p => p.IdEstadoSistema == idEstadoSistema).FirstOrDefault();
                    if (entidad != null)
                    {
                        EstadoSistemaEntity request = entidad;
                        request.EjecucionValidacion = true;
                        request.EstadoAbierto = false;
                        request.FechaCierre = DateTime.Now;
                        request.IdUsuarioCierre = idUsuario;
                    }
                    if (!entidad.EstadoAbierto)
                    {
                        //Si el Dia ya estaba cerrado, no lo vuelvo a cerrar
                        context.SaveChanges();
                    }
                }
                OrdenHelper.InformarMercadoEstado((byte)TipoEstadoSistema.ULTIMO_CERRADO, "CerrarSistemaCommand");
                PortfolioHelper.DesAsociarPortfoliosProductosFCE();
                scope.Complete();
            }
        }

        public static void CleanOfertas_Precios()
        {
            SqlServerHelper.ExecuteNonQuery("orden_owner.SIS_LIMPIAR_OFERTAS", null);
            SqlServerHelper.ExecuteNonQuery("orden_owner.SIS_LIMPIAR_ORDENES", null);
            SqlServerHelper.ExecuteReader("orden_owner.SIS_LIMPIAR_PRECIOS", null);
        }

        public static void CleanLimitesDiarios()
        {
            SqlServerHelper.ExecuteNonQuery("shared_owner.SIS_LIMPIAR_LIMITES_DIARIOS", null);
        }

        public static void RechazarOrdenesPorCierreDia()
        {
            SqlServerHelper.ExecuteNonQuery("orden_owner.ORD_RechazarOrdenesPorCierreDia", null);
        }
    }
}

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
                PortfolioHelper.DesAsociarPortfoliosProductosFCE();
                scope.Complete();
            }
        }
          
    }
}

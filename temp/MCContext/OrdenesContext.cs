using M4Trader.ordenes.server.MCContext.ContextAudit;
using M4Trader.ordenes.server.MCContext.ContextAudit.Model;
using M4Trader.ordenes.server.MCContext.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Configuration;

namespace M4Trader.ordenes.server.MCContext
{
    public class OrdenesContext : AuditContext
    {
        private static string ConnectionString { get; set; }
        public int? CommandTimeout { get; set; }

        public OrdenesContext() : base()
        {
            this.CommandTimeout = 60;
            if (string.IsNullOrEmpty(ConnectionString))
            {
                string tmp = ConfigurationManager.ConnectionStrings["Ordenes"].ConnectionString;
                if (tmp.Contains("|"))
                {
                    this.CommandTimeout = int.Parse(tmp.Split('|')[0]) * 60;
                    ConnectionString = tmp.Split('|')[1];
                }
                else
                {
                    ConnectionString = tmp;
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            optionsBuilder.ConfigureWarnings(x => x.Ignore(new Microsoft.Extensions.Logging.EventId[] { RelationalEventId.AmbientTransactionWarning }));

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigureSequence(modelBuilder);

            modelBuilder.Entity<PortfolioUsuarioEntity>()
              .HasOne(e => e.Portfolio);
        }

        private void ConfigureSequence(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>()
              .Property(x => x.IdLogAuditoria)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_LogAuditoria");


            modelBuilder.Entity<AccionEntity>()
              .Property(x => x.IdAccion)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_Acciones");

            modelBuilder.Entity<AccionRolEntity>()
              .Property(x => x.IdAccionRol)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_AccionRol");

            modelBuilder.Entity<ConfiguracionSeguridadEntity>()
              .Property(x => x.IdConfiguracionSeguridad)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_ConfiguracionSeguridad");

            modelBuilder.Entity<ConfiguracionSistemaEntity>()
              .Property(x => x.IdConfiguracionSistema)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_ConfiguracionSistema");

            modelBuilder.Entity<ConfiguracionSistemaUrlsEntity>()
              .Property(x => x.IdConfiguracionSistemaUrls)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_ConfiguracionSistemaUrls");

            modelBuilder.Entity<CustomizacionUsuarioEntity>()
              .Property(x => x.IdCustomizacionUsuario)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_CustomizacionUsuario");

            modelBuilder.Entity<EstadoSistemaEntity>()
              .Property(x => x.IdEstadoSistema)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_EstadoSistema");

            modelBuilder.Entity<HistoricoPasswordEntity>()
              .Property(x => x.IdHistoricoPassword)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_HistoricoPassword");

            modelBuilder.Entity<MercadoEntity>()
              .Property(x => x.IdMercado)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_Mercados");

            modelBuilder.Entity<MonedaEntity>()
              .Property(x => x.IdMoneda)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_Monedas");
            

            modelBuilder.Entity<PartyEntity>()
              .Property(x => x.IdParty)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_Personas");

            modelBuilder.Entity<ProductoEntity>()
              .Property(x => x.IdProducto)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_Productos");

            modelBuilder.Entity<RolEntity>()
              .Property(x => x.IdRol)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_Roles");

            modelBuilder.Entity<RolUsuarioEntity>()
              .Property(x => x.IdRolUsuario)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_RolUsuario");

            modelBuilder.Entity<PartyHierarchyEntity>()
              .Property(x => x.IdPartyHierarchy)
              .HasDefaultValueSql("NEXT VALUE FOR shared_owner.SQ_PartiesHierarchy");

            modelBuilder.Entity<UsuarioEntity>()
              .Property(x => x.IdUsuario)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_Usuarios");

            modelBuilder.Entity<UsuariosAdminitradorPartiesEntity>()
              .Property(x => x.IdAdministradorParty)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_UsuariosAdministradorParties");

            modelBuilder.Entity<UsuariosLimitesEntity>()
              .Property(x => x.IdUsuarioLimite)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_UsuariosLimites");

            modelBuilder.Entity<UsuariosLimitesDiariosEntity>()
              .Property(x => x.IdUsuarioLimiteDiario)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_UsuariosLimitesDiarios");


            modelBuilder.Entity<PortfolioEntity>()
              .Property(x => x.IdPortfolio)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_Portfolios");

            modelBuilder.Entity<PortfolioComposicionEntity>()
              .Property(x => x.IdPortfoliosComposicion)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_PortfoliosComposicion");

            modelBuilder.Entity<PermisosProductosEntity>()
              .Property(x => x.IdPermisosProductos)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_PermisosProductos");

            modelBuilder.Entity<PortfolioUsuarioEntity>()
              .Property(x => x.IdPortfolioUsuario)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_PortfoliosUsuario");

            modelBuilder.Entity<ProductoPorMercadoEntity>()
              .Property(x => x.IdProductoPorMercado)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_ProductosPorMercado");

            modelBuilder.Entity<OrdenOperacionEntity>()
              .Property(x => x.IdOrdenOperacion)
              .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_OrdenOperacion");

            modelBuilder.Entity<ConfirmacionManualEntity>()
            .Property(x => x.IdConfirmacionManual)
            .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_ConfirmacionManual");

            modelBuilder.Entity<ChatUsuarioEntity>()
            .Property(x => x.IdChatUsuario)
            .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_ChatUsuarios");

            modelBuilder.Entity<ChatEntity>()
            .Property(x => x.IdChat)
            .HasDefaultValueSql("NEXT VALUE FOR orden_owner.SQ_Chats");

        }

        public DbSet<ConfirmacionManualEntity> ConfirmacionManual { get; set; }
        public DbSet<AccionEntity> Acciones { get; set; }
        public DbSet<MercadoEntity> Mercado { get; set; }
        public DbSet<MensajesLiteralesEntity> MensajesLiterales { get; set; }
        public DbSet<CustomizacionUsuarioEntity> EstadoPantalla { get; set; }
        public DbSet<PartyEntity> Persona { get; set; }
        public DbSet<ProductoEntity> Producto { get; set; }
        public DbSet<ConfiguracionSistemaEntity> ConfiguracionSistema { get; set; }
        public DbSet<MonedaEntity> Moneda { get; set; }
        public DbSet<RolEntity> Rol { get; set; }
        public DbSet<AccionRolEntity> AccionRol { get; set; }
        public DbSet<RolUsuarioEntity> RolUsuario { get; set; }
        public DbSet<PartyHierarchyEntity> PartyHierarchyEntities { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<UsuariosAdminitradorPartiesEntity> UsuariosAdminitradorParties{ get; set; }
        public DbSet<UsuariosLimitesEntity> UsuariosLimites { get; set; }
        public DbSet<UsuariosLimitesDiariosEntity> UsuariosLimitesDiarios { get; set; }

        public DbSet<EstadoSistemaEntity> EstadoSistema { get; set; }
        public DbSet<ConfiguracionSeguridadEntity> ConfiguracionSeguridad { get; set; }
        public DbSet<HistoricoPasswordEntity> HistoricoPass { get; set; }
        public DbSet<SesionEntity> Sesion { get; set; }
        public DbSet<CustomizacionUsuarioEntity> CustomizacionUsuario { get; set; }
        public DbSet<ConfiguracionSistemaUrlsEntity> ConfiguracionSistemaUrls { get; set; }
        public DbSet<PortfolioEntity> Portfolios { get; set; }
        public DbSet<PortfolioComposicionEntity> PortfoliosComposicion { get; set; }

        public DbSet<PermisosProductosEntity> PermisosProductosEmpresas { get; set; }
        public DbSet<PortfolioUsuarioEntity> PortfoliosUsuario { get; set; }
        public DbSet<TipoOrdenEntity> TiposOrden { get; set; }
        public DbSet<ProductoPorMercadoEntity> ProductosPorMercado { get; set; }
        public DbSet<PlazoEntity> Plazos { get; set; }
        public DbSet<ChatUsuarioEntity> ChatUsuarios { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
    }
}

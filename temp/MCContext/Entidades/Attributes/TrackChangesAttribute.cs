using System;

namespace M4Trader.ordenes.server.MCContext.Entidades.Attributes
{
    /// <summary>
    ///     Enables tracking of Entity tables.
    ///     Place this attribute on a entity class which you want to track for audit.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class TrackChangesAttribute : Attribute
    {
        public TrackChangesAttribute(AuditoriaClase logAuditoriaClase)
        {
            this.LogAuditoriaClase = logAuditoriaClase;
        }
        public AuditoriaClase LogAuditoriaClase { get; set; }
    }

    public enum AuditoriaClase : short
    {
        Accion = 1,
        AccionRol = 2,
        ConfiguracionSeguridad = 3,
        ConfiguracionSistema = 4,
        CustomizacionUsuario = 5,
        EstadoSistema = 6,
        HistoricoPassword = 7,
        MensajesLiterales = 8,
        Mercados = 9,
        Monedas = 10,
        Ordenes = 11,
        Personas = 12,
        Productos = 13,
        Roles = 14,
        RolUsuario = 15,
        Sesiones = 16,
        Usuarios = 17,
        Portfolios = 18,
        PortfoliosComposicion = 19,
        PortfolioUsuario = 20,
        ProductosPorMercado = 23,
        OrdenOperacion = 24,
        OrdenHistorico = 25,
        ConfirmacionManual = 26
    }
}
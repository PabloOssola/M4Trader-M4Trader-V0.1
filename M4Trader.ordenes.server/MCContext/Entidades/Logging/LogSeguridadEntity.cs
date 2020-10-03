using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace M4Trader.ordenes.server.MCContext.Entidades.Logging
{
    public enum LogCodigoAccionSeguridad : byte
    {
        InicioSesion = 120,
        SesionExpirada = 121,
        UsuarioBloqueado = 122,
        ModificaClave = 123,
        InfoOk = 124,
        NoRechazarNovedad = 125,
        CierreSesionExitoso = 126,
        ErrorInicioSesion = 127,
        AprobarParticipanteNovedad = 128,
        RechazarNovedad = 129,
        ErrorAprobarNovedad = 130,
        AprobarNovedad = 131,
        NoAprobarParticipanteNovedad = 132,
        CierreSesionNoExitoso = 133,
        MaximosIntentos = 134,
        Generico = 135,
        AltaUsuario = 136,
        EliminarUser = 137,
        ResetPass = 138,
        ActualizaUser = 139,
        ReactivarUser = 140,
        UsuarioInexistente = 141,
        UsuarioBajaLogica = 142,
        UsuarioDesbloqueadoPorAdmin = 143,
        UsuarioBloqueadoPorAdmin = 144,
        UsuarioBloqueadoPorCtaExpirada = 145,
        UsuarioBloqueadoPorTiempoInactividad = 146,
        SeRechazaInstruccionesDeLiquidacion = 147,
        SeRectificaInstruccionesDeLiquidacion = 148,
        IniciandoServicio = 149,
        ServicioIniciadoCorrectamente = 150,
        ServicioIniciadoConError = 151,
        IniciandoInterface = 152,
        InterfaceSkipped = 153, 
        InterfaceIniciadaCorrectamente = 154,
        InterfaceIniciadaConError = 155,
        DispatchingInterfaceStarts = 156,
        DispatchingInterfaceSucceeded = 157,
        DispatchingInterfaceError = 158,
        ErrorProccessingMarketDataFixMessage = 159,
        AccionIncorrecta = 160,
        ErrorProccessingCollateralReportFixMessage = 161,

        ItemQueueCancelled = 253,
        ItemQueued = 254,
        FinEjecucion = 255,
    }

    [Table("LogSeguridad", Schema = "orden_owner")]
    public class LogSeguridadEntity
    {
        [Key]
        public int IdLogSeguridad { get; set; }

        public byte IdLogCodigoAccion { get; set; }

        public int? IdUsuario { get; set; }
        
        public DateTime Fecha { get; set; }

        public string Origen { get; set; }
        
        public string Descripcion { get; set; }
        
        public Guid? RequestId { get; set; }

        public byte IdAplicacion { get; set; }
    }
}

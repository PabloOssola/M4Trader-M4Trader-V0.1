namespace M4Trader.ordenes.services.Entities
{
    public enum LogCodigoAccion : byte
    {
        CrearOrden = 101,
        EliminarOrden = 102,
        ModificaOrden = 103,
        ConfirmarOrden = 104,
        RecibirRespuestaMercado = 105,
        EnviarModificacionMercado = 106,
        EnviarCancelacionMercado = 107,
        EnviadaAlMercado = 108,
        ErrorAlEnviarAlMercado = 109,
        InicioSesion = 110,
        UsuarioBloqueado = 111,
        MaximosIntentos=112,
        UsuarioInexistente = 113,
        UsuarioBajaLogica=114,
        UsuarioBloqueadoPorCuentaExpirada = 115,
        UsuarioBloqueadoPorTiempoInactividad = 116,
        IniciandoServicio = 117,
        ServicioIniciadoCorrectamente = 118,
        ServicioIniciadoConError = 119,
        ProcesadoXMLCorrectamente = 120,
        ProcesadoXMLConError = 121,
        CierreMercadoInterno = 122,
        BloqueoOrden = 123,
        DesbloqueoOrden = 124,
        SesionExpirada = 125,
        CierreSesionNoExitoso = 126,
        ErrorInicioSesion = 127,
        CierreSesionExitoso = 128,
        AccionIncorrecta = 160, 
        CrearMovimientoSaldo = 162,
        CrearOperacion = 163,
    }
}
 

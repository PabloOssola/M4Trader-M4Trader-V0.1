namespace M4Trader.ordenes.server.MCContext.Entidades
{

    public class MovimientosSaldos
    {
        public int IdMovimiento { get; set; }
        public TipoMovimientos IdTipoMovimiento { get; set; }
        public byte IdMoneda { get; set; }
        public int IdPersona { get; set; }
        public decimal Importe { get; set; }
        public int IdPropietario { get; set; }
        public bool ImpactoEnSaldo { get; set; }
        public int IdEstado { get; set; }

    } 
    public enum TipoMovimientos
    {
        MonedaDebito = 1,
        MonedaCredito = 2,
        DepositoDeTransferencia = 3 
    }

    public enum TipoEstadoMovimiento
    {
        pendiente = 1,
        aprobada = 2
    }
}


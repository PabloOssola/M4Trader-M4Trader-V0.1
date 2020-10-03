namespace M4Trader.ordenes.server.CQRSFramework.CQRS
{
    public class CustomQueryReturn
    {
        public int TotalRows { get; set; }
        public object[] Data { get; set; }
    }
}

using System;


namespace M4Trader.ordenes.server.ApplicationServices
{
    public class ResponseDoubleAuthentication
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public bool IsOk { get; set; }
        public string Error { get; set; }
    }
}

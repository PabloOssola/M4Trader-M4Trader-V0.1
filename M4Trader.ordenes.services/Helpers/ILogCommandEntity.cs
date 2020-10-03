using System;

namespace M4Trader.ordenes.services.Helpers
{
    public interface ILogCommandEntity
    {
        int IdLogCommand { get; set; }
        int? IdUsuario { get; set; }
        string CommandName { get; set; }
        string Codigo { get; set; }
        DateTime StartDatetime { get; set; }
        Guid RequestId { get; set; }
        string Argument { get; set; }
        Guid? IdSesion { get; set; }
        object Data { get; set; }
        string GetSchema();
    }
}

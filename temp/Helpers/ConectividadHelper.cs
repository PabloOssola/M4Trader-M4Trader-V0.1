using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System;

namespace M4Trader.ordenes.server.Helpers
{

    public static class ConectividadHelper
    {
        private static object syncSession = new object();

        

        public static void InsertarLogConectividad(int IdPersona, DateTime Fecha, string Mensaje)
        {
            LogConectividadEntity lse = new LogConectividadEntity
            {
                IdPersona = IdPersona,
                Fecha = Fecha,
                Mensaje = Mensaje
            };
            LoggingService.Instance.AgregarLog(lse);
        }


      
    }
}

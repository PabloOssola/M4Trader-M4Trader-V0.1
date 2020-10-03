using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.CQRSFramework.Transactions;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server.Helpers
{


    public static class SaldosHelper
    {

        public static List<SaldosDTO> ConsultaDeSaldos(int idPersona)
        {
            return SaldosDAL.ConsultaSaldosByPersona(idPersona);                 
        }
         
          
    } 
}

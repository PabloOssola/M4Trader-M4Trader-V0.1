using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.MCContext.Entidades;
using System.Collections.Generic;

namespace M4Trader.ordenes.server.Helpers
{
    public class AdaptardorHelper: XMLBase<SaldoEntity>
    {
        public List<SaldoEntity> ObtenerSaldosbyFiltro(int idUsuario, string tipoProducto, int pageNumber, int maxRecord, string file)
        {
            List<SaldoEntity> respuestaSaldos = new List<SaldoEntity>();
            //List<SaldoEntity> beArray;

            PartyEntity persona = CachingManager.Instance.getPersonaParteByIdUsuarioLogin(idUsuario);
            if (persona != null)
            {
                /*int idEmpresa = persona.IdEmpresa.Value;
                int idCliente = Convert.ToInt32(persona.MarketCustomerNumber);
                beArray = base.ObtenerTodos(file);

                respuestaSaldos = beArray.Where(x => (x.IdCliente == idCliente)
                                                    && (x.IdEmpresa == idEmpresa)
                                                    && (x.TipoProducto.ToUpper() == tipoProducto.ToUpper())
                                                )
                                   .Skip(Convert.ToInt32(pageNumber) - 1).Take(Convert.ToInt32(maxRecord)).ToList();*/
            }

            return respuestaSaldos;

        }
    }
}

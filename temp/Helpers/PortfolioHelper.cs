using System;
using M4Trader.ordenes.server.DataAccess;

namespace M4Trader.ordenes.server.Helpers
{
    public static class PortfolioHelper
    {
        public static void SetearPorDefecto(int idPortfolioUsuario, int IdUsuario)
        {
             PortfolioDAL.SetearPorDefecto(idPortfolioUsuario, IdUsuario);
        }

        public static void DesAsociarProdutoParty(int idProducto)
        {
            PortfolioDAL.DesAsociarProdutoParty(idProducto);
        }

        public static void DesAsociarPortfoliosProductosFCE()
        {
            PortfolioDAL.DesAsociarPortfoliosProductosFCE();
        }

        public static void HabilitarPortfoliosProductosFCE(int idProducto)
        {
            PortfolioDAL.HabilitarPortfoliosProductosFCE(idProducto);
        }

        public static void DesHabilitarPortfoliosProductosFCE(int idProducto)
        {
            PortfolioDAL.DesHabilitarPortfoliosProductosFCE(idProducto);
        }
    }
}

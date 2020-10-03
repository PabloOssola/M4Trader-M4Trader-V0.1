using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Linq;


namespace M4Trader.ordenes.server
{
    [CommandType("EliminaPortfolioComposicionEmpresasCommand", (int)IdAccion.PortfoliosEmpresas, TipoAplicacion.WEBEXTERNA)]
    public class EliminaPortfolioComposicionEmpresasCommand : EliminaPortfolioComposicionCommand
    {
        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.PortfoliosEmpresas;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var request = (from d in context.PortfoliosComposicion where IdPortfoliosComposiciones.Contains(d.IdPortfoliosComposicion) select d).ToList();
            Productos = request.Select(y => y.IdProducto).Distinct().ToList();
            foreach (int IdProducto in Productos)
            {
                PortfolioHelper.DesHabilitarPortfoliosProductosFCE(IdProducto);
                //TODO poner la key que corresponda.
                string key =string.Empty;
                OrdenHelper.NotificarDesAsociacionProductoPortfolio(IdProducto, "EliminaPortfolioComposicionEmpresasCommand",key);
            }
            return null;
        }

        public override void ExecuteAfterSuccess()
        {
            foreach (int IdProducto in Productos)
            {
                PortfolioHelper.DesAsociarProdutoParty(IdProducto);
            }
        }

        List<int> Productos { get; set; }
    }
}
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("EliminaPortfolioCommand", (int)IdAccion.Portfolios, TipoAplicacion.WEBEXTERNA)]
    public class EliminaPortfolioCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {

            foreach (var id in Ids)
            {
                PortfolioEntity request = (from d in context.Portfolios where d.IdPortfolio == id select d).Single();

                // PortfolioComposicion
                var portfolioSComposicion = (from d in context.PortfoliosComposicion where d.IdPortfolio == id select d).ToList(); ;
                context.PortfoliosComposicion.RemoveRange(portfolioSComposicion);


                // PortfolioUsuario
                var portfoliosUsuario = (from d in context.PortfoliosUsuario where d.IdPortfolio == id select d).ToList();
                context.PortfoliosUsuario.RemoveRange(portfoliosUsuario);

                // Portfolio
                context.Remove(request);
            }

            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "Portfolio";

            #region Requerido

            #endregion Requerido

            #region Unicidad

            #endregion Unicidad

            

            if (!valida)
            {
                throw fe;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Portfolios;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.BAJA;
            }
        }

        [DataMember]
        public int[] Ids { get; set; }

    }
}
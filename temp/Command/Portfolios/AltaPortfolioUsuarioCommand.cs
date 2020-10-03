using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("AltaPortfolioUsuarioCommand", (int)IdAccion.Portfolios, TipoAplicacion.WEBEXTERNA)]
    public class AltaPortfolioUsuarioCommand : ABMContextCommand
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
            PortfolioUsuarioEntity request = new PortfolioUsuarioEntity()
            {
                IdPortfolio = IdPortfolio,
                IdUsuario = IdUsuario
            };

            this.AgregarAlContextoParaAlta(request);

            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "PortfolioUsuario";

            #region Requerido


            #endregion Requerido

            #region Unicidad

            var coleccion = (from d in context.PortfoliosUsuario where d.IdPortfolio == IdPortfolio && d.IdUsuario == IdUsuario select d);
            ValidateUnicidad(coleccion, IdPortfolio.ToString(), "Portfolio", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

            var count = (from pu in context.PortfoliosUsuario where pu.IdUsuario == IdUsuario select pu);
            ValidateMaxPortfolio(count, IdUsuario.ToString(), "IdUsuario", CodigosMensajes.FE_ALTA_MAX_AMOUNT_REACHED);

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
                return (int)TipoPermiso.ALTA;
            }
        }

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public short IdPortfolio { get; set; }
    }
}
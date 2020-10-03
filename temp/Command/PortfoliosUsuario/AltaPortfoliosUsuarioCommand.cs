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
    [CommandType("AltaPortfoliosUsuarioCommand", (int)IdAccion.PortfoliosUsuario, TipoAplicacion.WEBEXTERNA)]
    public class AltaPortfoliosUsuarioCommand : ABMContextCommand
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
                IdUsuario = MAEUserSession.Instancia.IdUsuario,
                PorDefecto = PorDefecto
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

            if (PorDefecto)
            {
                var pordefectoUnicidad = (from d in context.PortfoliosUsuario where d.PorDefecto && d.IdUsuario == MAEUserSession.Instancia.IdUsuario select d);
                ValidateUnicidad(pordefectoUnicidad, "PorDefecto", "Por Defecto", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

            }

            var coleccion = (from d in context.PortfoliosUsuario where d.IdPortfolio == IdPortfolio && d.IdUsuario == MAEUserSession.Instancia.IdUsuario select d);
            ValidateUnicidad(coleccion, IdPortfolio.ToString(), "Portfolio", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

            var count = (from pu in context.PortfoliosUsuario where pu.IdUsuario == MAEUserSession.Instancia.IdUsuario select pu);
            ValidateMaxPortfolio(count, MAEUserSession.Instancia.IdUsuario.ToString(), "IdUsuario", CodigosMensajes.FE_ALTA_MAX_AMOUNT_REACHED);

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
                return (int)IdAccion.PortfoliosUsuario;
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
        public short IdPortfolio { get; set; }

        [DataMember]
        public bool PorDefecto { get; set; }
    }
}
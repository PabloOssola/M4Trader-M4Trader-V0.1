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
    [CommandType("AltaPortfolioCommand", (int)IdAccion.Portfolios, TipoAplicacion.WEBEXTERNA)]
    public class AltaPortfolioCommand : ABMContextCommand
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
            IdUsuario = MAEUserSession.Instancia.IdUsuario;
            PortfolioEntity request = new PortfolioEntity()
            {
                EsDeSistema = EsDeSistema,
                Nombre = Nombre,
                Codigo = Codigo
            };

            var portfolioUsuario = new PortfolioUsuarioEntity()
            {
                Portfolio = request,
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
            NombreEntidad = "Portfolio";

            #region Requerido

            ValidateString(Nombre, "Nombre", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(Codigo, "Codigo", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);

            #endregion Requerido

            #region Unicidad

            var coleccion = (from d in context.Portfolios where d.Nombre.Equals(Nombre) select d);
            ValidateUnicidad(coleccion, Nombre, "Nombre", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

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
        public short r_id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public bool EsDeSistema { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }


    }
}
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
    [CommandType("ActualizaPortfolioCommand", (int)IdAccion.Portfolios, TipoAplicacion.WEBEXTERNA)]
    public class ActualizaPortfolioCommand : ABMContextCommand
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
            var entidad = (from d in context.Portfolios where d.IdPortfolio == r_id select d);
            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            PortfolioEntity request = entidad.FirstOrDefault();
            request.Nombre = Nombre;
            request.Codigo = Codigo;
            request.EsDeSistema = EsDeSistema;

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
                return (int)TipoPermiso.MODIFICACION;
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

    }
}
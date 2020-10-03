using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class AltaPortfolioComposicionCommand : ABMContextCommand
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
            var plazos = IdPlazo.Split(',');
            var elements = context.PortfoliosComposicion.Where(x => x.IdPortfolio == IdPortfolio);
            int orden = 0;
            if (elements.Any())
            {
                orden = elements.Max(x => x.Orden);
            }
            foreach (var plazo in plazos)
            {
                var request = new PortfolioComposicionEntity()
                {
                    IdMercado = IdMercado,
                    IdPortfolio = Convert.ToInt16(IdPortfolio),
                    IdProducto = IdProducto,
                    IdPlazo = byte.Parse(plazo),
                    Orden = orden++
                };

                this.AgregarAlContextoParaAlta(request);
            }

            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "PortfolioComposicion";

            #region Requerido

            #endregion Requerido

            #region Unicidad

            var plazos = IdPlazo.Split(',');

            var coleccion = (from d in context.PortfoliosComposicion where d.IdProducto == IdProducto && d.IdMercado == IdMercado && plazos.Contains(d.IdPlazo.ToString()) && d.IdPortfolio == IdPortfolio select d);
            ValidateUnicidad(coleccion, "Producto, Mercado y Plazo", "Producto", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            if (coleccion.Any())
                valida = false;

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
        public int IdPortfolio { get; set; }

        [DataMember]
        public int IdProducto { get; set; }

        [DataMember]
        public byte IdMercado { get; set; }

        [DataMember]
        public string IdPlazo { get; set; }



    }
}
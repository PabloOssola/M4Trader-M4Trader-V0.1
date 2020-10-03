using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("EliminarPortfolioFavoritoCommand", (int)IdAccion.PortfoliosComposicion, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA)]
    public class EliminarPortfolioFavoritoCommand : ABMContextCommand
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
            DTOPortfolio favorito = CachingManager.Instance.GetPortfolioByCodigo("F" + IdUsuario.ToString());
            //byte idPlazo = (byte)CachingManager.Instance.GetAllPlazos().Find(x => x.Descripcion == Plazo).IdPlazo;
            //PortfolioComposicionEntity pc =  CachingManager.Instance.GetPortfolioComposicionByPortfolioAndProducto(favorito.IdPortfolio, IdProducto, idPlazo);
            //if (pc != null)
            //{
            //    context.PortfoliosComposicion.Remove(pc);
            //}

            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = true });
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "PortfoliosEmpresasComposicion";

            #region Requerido

            #endregion Requerido

            #region Unicidad

            portfolio = CachingManager.Instance.GetPortfolioDefaultByIdUsuario(IdUsuario);

            //var coleccion = (from d in context.PortfoliosComposicion where d.IdProducto == IdProducto && d.IdMercado == IdMercado && d.IdPortfolio == portfolio.IdPortfolio select d);
            //ValidateUnicidad(coleccion, "Producto, Mercado y Plazo", "Producto", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            //if (coleccion.Any())
            //  valida = false;

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
                return (int)IdAccion.PortfoliosComposicion;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        [DataMember]
        public int IdPortfolio { get; set; }

        [DataMember]
        public int IdProducto { get; set; }

        [DataMember]
        public string Plazo { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }

        DTOPortfolio portfolio { get; set; }

    }
}

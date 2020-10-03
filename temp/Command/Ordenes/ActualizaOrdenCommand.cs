using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("ActualizaOrdenCommand", (int)IdAccion.Ordenes, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA)]

    public class ActualizaOrdenCommand : ABMCommand
    {
        List<OrdenEntity> ordenes;
        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            Response resultado = new Response();
            OrdenEntity orden = new OrdenEntity();
            ordenes = new List<OrdenEntity>();

            //if (Source == 0)
            //    Source = SourceEnum.Mobile;
            orden = OrdenHelper.ObtenerOrdenbyID(r_id);
            ProductoEntity p = CachingManager.Instance.GetProductoById(orden.IdProducto);
            if (ValidarCambiosModificar(orden))
            {
                orden.IdOrden = r_id;
                orden.Cantidad = Cantidad + orden.Ejecutadas;
                orden.CantidadMinima = OfertaParcial ? CantidadMinima : Cantidad;
                orden.Plazo = PlazoType;

                if(p.IdTipoProducto == (byte)TiposProducto.FACTURAS)
                {
                    orden.OperoPorTasa = true;
                }

                if (PrecioLimite.HasValue)
                    orden.PrecioLimite = PrecioLimite.Value;
                else
                    orden.PrecioLimite = null;

                ordenes.Add(orden);

                switch (orden.IdEstado)
                {
                    case (int)EstadoOrden.Ingresada:
                    case (int)EstadoOrden.Confirmada:
                        resultado = ProcesamientoGenerica<OrdenEntity>(ActualizarOrden, ordenes);
                        break;
                    case (int)EstadoOrden.EnMercado:
                    case (int)EstadoOrden.AplicadaParcial:
                    //case (int)EstadoOrden.RechazoMercado:
                        resultado = ProcesamientoGenerica<OrdenEntity>(ActualizarOrdenMercado, ordenes);
                        break;
                }
            }
            else
            {
                ConcurrentBag<string> resultadosOk = new ConcurrentBag<string>();
                ConcurrentBag<string> resultadosError = new ConcurrentBag<string>();

                resultadosError.Add("No se ingresaron modificaciones para la orden Nro: " + orden.NumeroOrdenInterno);
                resultado.Resultado = eResult.Error;

                resultado.SetResponse(resultadosOk, resultadosError, "Ordenes");
            }
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);

        }

        private string ActualizarOrden(OrdenEntity orden)
        {
            return OrdenHelper.ActualizarOrden(orden, r_id, SourceEnum.Api, orden.Timestamp);
        }

        private string ActualizarOrdenMercado(OrdenEntity orden)
        {
            return OrdenHelper.ActualizarOrdenMercado(orden, r_id, SourceEnum.Api, orden.Timestamp);
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            //NombreEntidad = "Ordenes";

            //#region Requerido
            //ValidateInt(Convert.ToInt32(Cantidad), "Cantidad", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            //#endregion Requerido

            //if (!valida)
            //{
            //    throw fe;
            //}
        }


        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Ordenes;
            }
        }


        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }

        public bool ValidarCambiosModificar(OrdenEntity orden)
        {
            bool valid = true;
            //decimal remanente = OrdenHelper.GetRemanentes(orden.IdOrden);
            //decimal ejecutada = orden.Cantidad - remanente;
            switch (orden.IdEstado)
            {
                case (int)EstadoOrden.Ingresada:
                case (int)EstadoOrden.Confirmada:
                    //case (int)EstadoOrden.RechazoMercado:
                    valid = !(orden.Cantidad == (Cantidad + orden.Ejecutadas) && orden.PrecioLimite == PrecioLimite && orden.Plazo == PlazoType);// && Cantidad > ejecutada;
                    break;
                case (int)EstadoOrden.AplicadaParcial:
                case (int)EstadoOrden.EnMercado:
                    valid = !(orden.Cantidad == (Cantidad + orden.Ejecutadas) && orden.PrecioLimite == PrecioLimite);// && Cantidad > ejecutada;
                    break;
                default:
                    valid = false;
                    break;
            }

            return valid;
        }

        [DataMember]
        public int r_id { get; set; }

        [DataMember]
        public decimal Cantidad { get; set; }

        [DataMember]
        public bool OperoPorTasa { get; set; }

        [DataMember]
        public decimal CantidadMinima { get; set; }
        [DataMember]
        public bool OfertaParcial { get; set; }

        [DataMember]
        public decimal? PrecioLimite { get; set; }

        public string Observaciones { get; set; }

        [DataMember]
        public byte? PlazoType { get; set; }

        [DataMember]
        public byte? StopType { get; set; }

        [DataMember]
        public SourceEnum Source { get; set; }

        [DataMember]
        public string Timestamp { get; set; }
    }
}
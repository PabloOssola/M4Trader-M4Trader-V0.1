using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("CloPosOrdDMACom", (int)IdAccion.Ordenes, TipoAplicacion.DMA)]

    public class ClosePositionOrdenCommandDMA : ABMCommand
    {
        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            OrdenEntity ordenEspejo = OrdenHelper.ObtenerOrdenbyID(IdOrden);
            OrdenEntity orden = CrearOrdenDesdeEspejo(ordenEspejo);
            orden.IdUsuario = MAEUserSession.InstanciaCargada ? (int?)MAEUserSession.Instancia.IdUsuario : null;
            Response resultado = new Response();
            resultado.Resultado = eResult.Ok;
            OrdenHelper.AltaOrdenDMA(orden);
            resultado.Detalle = JsonConvert.SerializeObject(orden);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
        }

        private OrdenEntity CrearOrdenDesdeEspejo(OrdenEntity ordenEspejo)
        {
            OrdenEntity orden = new OrdenEntity();
            orden.CompraVenta = ordenEspejo.CompraVenta == "V" ? "C" : "V";
            orden.IdMercado = ordenEspejo.IdMercado;
            orden.FechaConcertacion = DateTime.Now.ToUniversalTime();
            orden.IdTipoVigencia = ordenEspejo.IdTipoVigencia;
            orden.Cantidad = ordenEspejo.Cantidad;
            orden.PrecioLimite = NuevoPrecioLimite;
            orden.IdEstado = (int)EstadoOrden.Ingresada;
            orden.Plazo = ordenEspejo.Plazo;
            orden.IdSourceApplication = (byte)SourceEnum.DMA;
            orden.IdProducto = ordenEspejo.IdProducto;
            orden.IdMoneda = ordenEspejo.IdMoneda;
            orden.IdTipoOrden = ordenEspejo.IdTipoOrden;
            orden.IdEnNombreDe = ordenEspejo.IdEnNombreDe;
            orden.IdPersona = ordenEspejo.IdPersona;
            orden.IdOrdenDeReferencia = IdOrden;
            return orden;
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

       
        public override void Validate()
        {

            #region Requerido
            ValidateDecimal(NuevoPrecioLimite, "Precio", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO, "Ordenes");
            #endregion Requerido

            if (!valida)
            {
                throw fe;
            }
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
                return (int)TipoPermiso.ALTA;
            }
        }

        [DataMember]
        public int IdOrden { get; set; }
        [DataMember]
        decimal NuevoPrecioLimite { get; set; }
    }
}
using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("AltaOrdenCommand", (int)IdAccion.Ordenes, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA)]

    public class AltaOrdenCommand : ABMCommand
    {
        List<OrdenEntity> ordenes;
        public override ExecutionResult ExecuteCommand(InCourseRequest inCourseRequest)
        {
            if (OrdenHelper.ObtenerOrdenOperacionByProducto(IdProducto.Value))
            {
                throw new M4TraderApplicationException("Ya se cerró una orden para este producto");
            }

            OrdenEntity orden = new OrdenEntity();
            orden.CompraVenta = CompraOVenta;
            orden.FechaConcertacion = DateTime.Now.ToUniversalTime();

            orden.IdMercado = IdMercado;
            ProductoEntity producto = new ProductoEntity();
            if (CodigoProducto != null)
                producto = CachingManager.Instance.GetProductoByCodigoMonedaDefaultAndRueda(CodigoProducto, orden.IdMercado, SegmentMarketId);
            else
                producto = CachingManager.Instance.GetProductoById(IdProducto.Value);
            orden.IdProducto = producto.IdProducto;
            orden.IdMoneda = IdMoneda.HasValue ? IdMoneda.Value : producto.IdMoneda;
            orden.Rueda = SegmentMarketId;
            orden.IdPersona = IdPersona.HasValue ? IdPersona.Value : MAEUserSession.Instancia.IdPersona;
            orden.IdEnNombreDe = IdEnNombreDe;
            orden.Cantidad = Cantidad;
            orden.CantidadMinima = OfertaParcial ? CantidadMinima : Cantidad;
            orden.IdSourceApplication = (byte)Source;
            orden.IdEstado = (int)EstadoOrden.Ingresada;
            orden.OperoPorTasa = OperoPorTasa;
            orden.Tasa = Tasa;
            orden.IdUsuario = MAEUserSession.InstanciaCargada ? (int?)MAEUserSession.Instancia.IdUsuario : null;
            if (!StopType)
            {
                orden.PrecioLimite = PrecioLimite;
            }

            if (CodigoPlazoType == "")
            {
                CodigoPlazoType = "CI";
            }

            orden.Plazo = PlazoType.HasValue ? PlazoType.Value : CachingManager.Instance.GetAllPlazos().Find(x => x.Descripcion == CodigoPlazoType).IdPlazo;
            //if (orden.Plazo == (byte)PlazoOrdenEnum.Futuro)
            //{
            //    orden.FechaLiquidacion = CachingManager.Instance.GetFechaLiquidacionByIdProductoAndPlazo(orden.Plazo, orden.IdProducto).FechaLiquidacion;
            //}
            orden.IdTipoVigencia = IdTipoVigencia.HasValue ? (TipoVigencia)IdTipoVigencia.Value : TipoVigencia.NoAplica;

            if (orden.IdTipoVigencia != TipoVigencia.NoAplica)
            {
                orden.FechaVencimiento = FechaVencimiento;
            }

            if (OrderType == "")
            {
                OrderType = "0";
            }

            if (producto.IdTipoProducto == (byte)TiposProducto.FACTURAS)
            {
                OrderType = "3";
                orden.OperoPorTasa = true;
                orden.Tasa = Tasa;
                orden.CantidadMinima = orden.Cantidad;
            }
            TipoOrdenEntity tipoOrden = CachingManager.Instance.GetTipoOrdenByCodigo(OrderType);

            if (tipoOrden != null)
                orden.IdTipoOrden = tipoOrden.IdTipoOrden;
            ResponseGenerico resultado = new ResponseGenerico();

            ordenes = new List<OrdenEntity>();
            ordenes.Add(orden);

            resultado.Resultado = (byte)eResult.Ok;
            OrdenHelper.AltaOrdenDMA(orden);
            orden.TimestampStr = BitConverter.ToString(orden.Timestamp, 0);
            resultado.Detalle = JsonConvert.SerializeObject(orden);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(resultado);
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        private void ValidateLimits(string Campo, string Codigo, string NombreEntidad)
        {

            UsuariosLimitesDiariosEntity limiteDiario = CachingManager.Instance.GetUsuariosLimiteDiariosByIdUsuario(MAEUserSession.Instancia.IdUsuario);
            UsuariosLimitesEntity limites = CachingManager.Instance.GetUsuariosLimiteByIdUsuario(MAEUserSession.Instancia.IdUsuario);
            decimal consumidoOferta = 0;
            decimal consumidoOperacion = 0;
            if (limiteDiario != null)
            {
                consumidoOferta = limiteDiario.ConsumidoOferta;
                consumidoOperacion = limiteDiario.ConsumidoOperacion;
            }

            if (limites.LimiteOferta < consumidoOferta + (Cantidad * PrecioLimite) || limites.LimiteOperacion < consumidoOperacion + (Cantidad * PrecioLimite))
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(Campo);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
        }


        public override void Validate()
        {

            #region Requerido
            ValidateInt(Convert.ToInt32(Cantidad), "Cantidad", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO, "Ordenes");
            ValidateInt(Convert.ToByte(IdMercado), "IdMercado", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO, "Ordenes");
            if (IdProducto == null && CodigoProducto == null)
            {
                ValidateInt(Convert.ToInt32(IdProducto), "IdProducto", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO, "Ordenes");
            }
            #endregion Requerido

            #region Limites
            ValidateLimits("Limite Oferta", CodigosMensajes.FE_SUPERA_LIMITES_OFERTA, "Ordenes");
            #endregion

            if (OfertaParcial)
            {
                ValidateAGEQBInt(Cantidad, CantidadMinima, "Cantidad", CodigosMensajes.FE_CAMPOA_MAYORQUE_CAMPOB, "Ordenes");
            }

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
        public string CompraOVenta { get; set; }

        [DataMember]
        public byte IdMercado { get; set; }
        [DataMember]
        public Int32? IdProducto { get; set; }
        [DataMember]
        public string CodigoProducto { get; set; }
        [DataMember]
        public byte? IdMoneda { get; set; }
        [DataMember]
        public Int32? IdPersona { get; set; }

        [DataMember]
        public int? IdEnNombreDe { get; set; }

        [DataMember]
        public Int32? IdTipoVigencia { get; set; }
        [DataMember]
        public DateTime? FechaVencimiento { get; set; }

        [DataMember]
        public DateTime? FechaLiquidacion { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public int CantidadMinima { get; set; }

        [DataMember]
        public decimal? PrecioLimite { get; set; }

        public decimal? PrecioReferencia { get; set; }
        [DataMember]
        public string SegmentMarketId { get; set; }

        public DateTime? FechaPrecioReferencia { get; set; }
        public string Observaciones { get; set; }
        public decimal? PrecioFuturo { get; set; }
        [DataMember]
        public decimal? Tasa { get; set; }
        public DateTime? FechaLiquidacionFuturo { get; set; }

        [DataMember]
        public bool OperoPorTasa { get; set; }
        [DataMember]
        public bool OfertaParcial { get; set; }

        [DataMember]
        public byte? PlazoType { get; set; }
        [DataMember]
        public string CodigoPlazoType { get; set; }
        [DataMember]
        public bool StopType { get; set; }
        [DataMember]
        public string OrderType { get; set; }

        [DataMember]
        public SourceEnum Source { get; set; }

    }
}
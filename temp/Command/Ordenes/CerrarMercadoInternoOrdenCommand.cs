using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;
using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.CQRSFramework.Transactions;
using System.Transactions;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class CerrarMercadoInternoOrdenCommand : ABMContextCommand
    {
        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.CierreMercadoInterno;
            }

        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.ALTA;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            OrdenOperacionEntity request = new OrdenOperacionEntity()
            {
                IdOrden = IdOrden,
                Cantidad = Cantidad,
                Precio = Precio,
                NroOperacionMercado = NroOperacionMercado
            };

            // Cambio de Estado
            if (Orden == null)
            {
                Orden = OrdenesDAL.ObtenerOrdenbyID(IdOrden);
            }
            Orden.IdEstado = (Cantidad == Orden?.Cantidad && Remanente == 0) ? (byte)EstadoOrden.Aplicada : (Remanente > 0 && Remanente == Cantidad) ? (byte)EstadoOrden.Aplicada : (byte)EstadoOrden.AplicadaParcial;

            using (ReadCommittedTransactionScope scope = new ReadCommittedTransactionScope(TransactionScopeOption.Required))
            {
                // Insertar OrdenOperacion
                OrdenesDAL.InsertarOrdenOperacion(request, Orden.IdEstado, Orden.NumeroOrdenMercado);

                Orden.IdMercado = CachingManager.Instance.GetAllMercados().FirstOrDefault(x => x.EsInterno).IdMercado;
                OrdenesDAL.ActualizarOrden(Orden);

                scope.Complete();
            }

            LoggingHelper.Instance.AgregarLog(new LogBitacoraOrdenEntity(request.IdOrden, LogCodigoAccion.CierreMercadoInterno, "Cierre de Mercado Interno #:" + request.NroOperacionMercado, (EstadoOrden)Orden.IdEstado, null, SourceEnum.Mobile));

            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {

            Orden = OrdenesDAL.ObtenerOrdenbyID(IdOrden);

            if (Remanente > 0 && Cantidad > Remanente)
            {
                keyArray = new KeyArray();
                keyArray.Codigo = CodigosMensajes.ERR_CANTIDAEXCEDEORDEN;
                keyArray.Parametros.Add(NombreEntidad);
                fe.DataValidations.Add(keyArray);
                valida = false;
                keyArray = new KeyArray();
            }

            if (Orden.IdEstado != (int)EstadoOrden.AplicadaParcial && Orden.IdEstado != (int)EstadoOrden.Ingresada)
            {

                keyArray = new KeyArray();
                keyArray.Codigo = CodigosMensajes.FE_ESTADO_ORDEN_NO_VALIDO;
                keyArray.Parametros.Add(NombreEntidad);
                fe.DataValidations.Add(keyArray);
                valida = false;
                keyArray = new KeyArray();

            }

            var coleccion = (from m in context.Mercado where m.EsInterno select m);
            if (!coleccion.Any())
            {
                keyArray = new KeyArray();
                keyArray.Codigo = CodigosMensajes.FE_NO_EXISTE_MERCADO_INTERNO;
                keyArray.Parametros.Add(NombreEntidad);
                fe.DataValidations.Add(keyArray);
                valida = false;
                keyArray = new KeyArray();
            }


            if (!valida)
            {
                throw fe;
            }
        }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        [DataMember]
        public int IdOrden { get; set; }

        [DataMember]
        public string NroOperacionMercado { get; set; }

        [DataMember]
        public decimal Cantidad { get; set; }

        [DataMember]
        public decimal? Precio { get; set; }

        [DataMember]
        public int Remanente { get; set; }

        public OrdenEntity Orden { get; set; }

        [DataMember]
        public SourceEnum Source { get; set; }


    }
}
using M4Trader.ordenes.services.CQRSFramework.Transactions;
using M4Trader.ordenes.services.Entities;
using System;
using System.Transactions;

namespace M4Trader.ordenes.services.Helpers
{
    public interface ICachingManager
    {
        DTOMoneda GetMonedaByISOCode(string CodigoISO);
        //DTOProducto GetProductoByCodeDefaultCurrencyAndRueda(string producto, byte idMercado, string rueda);
        //DTOProducto GetProductoByCodeIdMonedaAndRueda(string producto, byte idMoneda, string rueda);
        DTOMercado GetMercadoByCode(string Codigo);
        Party GetPartyById(int id);
        void RefreshAll();
    }

    public class Party
    {
        public int IdParty { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public string MarketCustomerNumber { get; set; }
        public byte IdPartyType { get; set; }
        public byte IdLegalPersonality { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string Phone { get; set; }
        public bool BajaLogica { get; set; }
        public string AgentCode { get; set; }
    }

    public class LoggingHelperDummy : ILogueador
    {
        public void AgregarLog<T>(T log)
        {

        }
        public void AgregarCommandLog(string command, object data, InCourseRequest inCourseRequest, string codigo = "CMD")
        {

        }

    }

    public delegate void NewPriceHandle(PrecioEntity precio); 
    public static class MarketDataHelper
    {
        private static NewPriceHandle _onPriceHandler;
         
        public static ILogueador Logger;

        public static event NewPriceHandle NewPriceHandleEvent
        {
            add
            {
                if (_onPriceHandler == null || !VerificarSiExiste(value))
                    _onPriceHandler += value;
            }
            remove
            {
                _onPriceHandler -= value;
            }
        }
          
        public static bool VerificarSiExiste(NewPriceHandle val)
        {
            var subscriptos = _onPriceHandler.GetInvocationList();
            foreach (var item in subscriptos)
            {
                var s = item.Method.DeclaringType.FullName + "." + item.Method.Name;
                var ss = val.Method.DeclaringType.FullName + "." + val.Method.Name;

                if (s.Equals(ss, StringComparison.Ordinal))
                    return true;
            }
            return false;
        } 

        public static void OnNewPriceHandle(PrecioEntity precio)
        {
            _onPriceHandler?.Invoke(precio);
        }
         
         
        public static ICachingManager CacheManager { get; set; }

           
        private static DTOMercado GetIdMercado(string codigoMercado)
        {
            return CacheManager.GetMercadoByCode(codigoMercado.Trim());
        }

         
        public static PrecioHistoricoEntity ConvertPrecioToPreciosHistoricos(PrecioEntity precio, byte idMoneda)
        {
            PrecioHistoricoEntity ordenesPrecio = new PrecioHistoricoEntity();
            ordenesPrecio.Cantidad = precio.Cantidad;
            ordenesPrecio.IdMercado = precio.IdMercado;
            ordenesPrecio.IdProducto = precio.IdProducto;
            ordenesPrecio.IdMoneda = idMoneda;
            ordenesPrecio.Precio = precio.Precio;
            ordenesPrecio.Fecha = precio.Fecha.HasValue ? precio.Fecha.Value : DateTime.Now; 
            return ordenesPrecio;
        }
    }
}

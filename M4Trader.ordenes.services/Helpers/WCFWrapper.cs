using M4Trader.ordenes.services.CQRSFramework.CQRS;
using M4Trader.ordenes.services.Entities;
using System;
using System.Configuration;

namespace M4Trader.ordenes.services.Helpers
{
    public class WCFWrapper
    {

        public IWCFHelper wcfHelper;
        public bool IsTcp;

        #region Singleton

        private WCFWrapper()
        {
            var URL = ConfigurationManager.AppSettings["urlServices"];
            if (URL != null && URL.ToLower().StartsWith("net.tcp"))
            {
                wcfHelper = new WCFTcpHelper();
                IsTcp = true;
            }
            else
            {
                IsTcp = false;
                wcfHelper = new ApiWCFHelper();
            }
        }

        private static volatile WCFWrapper _instance;

        public static WCFWrapper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(WCFWrapper))
                    {
                        if (_instance == null)
                            _instance = new WCFWrapper();
                    }
                }
                return _instance;
            }
        }
        #endregion

        public T DeserializarCommand<T>(string stream)
        {
            return wcfHelper.DeserializarCommand<T>(stream);
        }


        public string ExecuteServiceQuery<S>(ServiciosEnum destino, Func<S, string> methodName)
        {
            return wcfHelper.ExecuteQueryService<S>(destino, methodName);
        }

        public O ExecuteService<S, O>(ServiciosEnum destino, Func<S, string> methodName, string securitytokenid)
        {
            return wcfHelper.ExecuteService<S, O>(destino, securitytokenid, methodName);
        }



        public string ExecuteQueryService<S>(ServiciosEnum destino, Func<S, string> methodName)
        {
            return wcfHelper.ExecuteQueryService<S>(destino, methodName);
        }

        public QueryResult ExecuteQueryServiceApiDMA<S>(ServiciosEnum destino, Func<S, string> methodName, string securitytokenid)
        {
            return wcfHelper.ExecuteQueryServiceApiDMA<S>(destino, methodName, securitytokenid);
        }

    }
}

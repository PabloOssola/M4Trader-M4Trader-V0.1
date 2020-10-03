using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.CQRSFramework.Interfaces;
using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.mvc
{
    public abstract class CustomQueryResulSet : ICustomQuery
    {

        public object Execute(Query query)
        {
            object result = null;
            try
            {

                result = this.GetResults(query);
            }
            catch (Exception)
            {
                //TODO: Loguear
                throw new FunctionalException((int)CommandStatus.EF_ERROR_GENERIC);
            }
            return result;
        }

        protected abstract object GetResults(Query query);



    }

    public static class ExtensionQueryObject
    {
        public static void TryGetValue(this List<Parameter> list, string key, out object result)
        {
            result = null;
            var res = list.Find(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
            if (res != null)
                result = res.Value;
        }

        public static void Add(this List<Parameter> list, string key, object value)
        {
            if (!list.Exists(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase)))
                list.Add(new Parameter() { Key = key, Value = value });
        }
    }


}
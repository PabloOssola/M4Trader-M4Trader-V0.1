
using M4Trader.ordenes.server;
using M4Trader.ordenes.server.Entities;

using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Helpers;
using M4Trader.ordenes.services.Services;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace M4TraderWebApp
{
    public class CachingManager
    {

        const string KEY_LITERALES = "KEY";


        #region FirstOrDefaultton

        private CachingManager()
        {
        }

        private static volatile CachingManager _instance;

        public static CachingManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(CachingManager))
                    {
                        if (_instance == null)
                            _instance = new CachingManager();
                    }
                }
                return _instance;
            }
        }



        #endregion

        #region GetLiterales
        public object GetLiterales(string securitytokenid)
        {
            string keyCache = KEY_LITERALES;
           // object config = CacheLayer.Get<object>(keyCache);

            //if (config == null)
            //{
            AppLiteralesCommand appLiteralesCommand = new AppLiteralesCommand();
            var s = JsonConvert.SerializeObject(appLiteralesCommand, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            M4Trader.ordenes.services.Command.JSCommand command = new M4Trader.ordenes.services.Command.JSCommand();
            string encryptName = string.Empty;
            command.d = s;
            command.k = "AppLitCom";
            command.b = true;
            command.a = (byte)TipoAplicacion.API;

            object data = WCFWrapper.Instance.wcfHelper.ExecuteService<ICommandExtranetService, object>(ServiciosEnum.CommandExtranet, securitytokenid, i => i.c(command));

            //if (data != null)
            //{
            //    CacheLayer.Add<object>(data, keyCache);
            //}
            //

            return data;
        }
        #endregion
    }


    //#region  Clase CacheLayer
    //public class CacheLayer
    //{
    //    static ObjectCache Cache = MemoryCache.Defualt;

    //    public static T Get<T>(string key) where T : class
    //    {
    //        try
    //        {
    //            return (T)Cache[key];
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }

    //    public static object Get(string key)
    //    {
    //        try
    //        {
    //            return Cache[key];
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }

    //    public static void Add<T>(T objectToCache, string key) where T : class
    //    {
    //        Cache.Remove(key);
    //        Cache.Add(key, objectToCache, DateTime.Now.AddHours(1));
    //    }

    //    public static void Add<T>(T objectToCache, string key, DateTime expirationDate) where T : class
    //    {
    //        Cache.Remove(key);
    //        Cache.Add(key, objectToCache, expirationDate);
    //    }

    //    public static void AddObject(object objectToCache, string key)
    //    {
    //        Cache.Remove(key);
    //        Cache.Add(key, objectToCache, DateTime.Now.AddHours(1));
    //    }

    //    public static void Clear(string key)
    //    {
    //        Cache.Remove(key);
    //    }

    //    public static void ClearAll()
    //    {
    //        //Cache = MemoryCache.Default;
    //        List<string> cacheKeys = Cache.Select(kvp => kvp.Key).ToList();
    //        foreach (string cacheKey in cacheKeys)
    //        {
    //            Cache.Remove(cacheKey);
    //        }
    //    }

    //    public static bool Exists(string key)
    //    {
    //        return Cache.Get(key) != null;
    //    }

    //    public static List<string> GetAll()
    //    {
    //        return Cache.Select(keyValuePair => keyValuePair.Key).ToList();
    //    }
    //}
    //#endregion
}

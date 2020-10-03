using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{ 
    [CommandType("CachCom", (int)IdAccion.CachingManager, TipoAplicacion.WEBEXTERNA, TipoAplicacion.MOBILE, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.MOBILE, TipoAplicacion.API)]

    public class CachingCommand : Command
    {
        public override ExecutionResult Execute(InCourseRequest inCourseRequest)
        {
            Type type = typeof(CachingManager);
            MethodInfo info = type.GetMethod(Nombre, BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            object result = null;

            if (info != null)
            {
                ParameterInfo[] param = info.GetParameters();

                if (param.Length == 0)
                {
                    result = type.GetMethod(Nombre).Invoke(CachingManager.Instance, null);
                }
                else
                {
                    result = type.GetMethod(Nombre).Invoke(CachingManager.Instance, Parameters);
                }
            }
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(result);
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.CachingManager;
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
        public short r_id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public object[] Parameters { get; set; }
    }
}
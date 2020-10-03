using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.CQRSFramework.CQRS
{
    public enum CommandStatus
    {
          [StringValue("EX0001")]
          PENDING_DISPATCH,             // Received, pending to validate arguments data and dispatching
          [StringValue("EX9999")]
          OK,                           // Successful execution
          [StringValue("VF0000")]
          VAL_FAIL,                     // Failed because of a failed functional/domain model validation while command arguments validation
          [StringValue("VF0001")]
          FAIL,                         // Failed because of a failed functional/domain model validation while execution command
          [StringValue("TE0001")]
          TECH_ERROR_CMD_NOT_FOUND,     // Technical error Command not found
          [StringValue("TE0002")]
          TECH_ERROR_GENERIC,           // Technical error while executing command
          [StringValue("SEC002")]
          SEC_FAIL_AUTHORIZATION,       // Failed because of denied or not granted security permission
          [StringValue("SEC003")]
          SEC_FAIL_SESSION_EXPIRED,     // Failed because of session expiry reached
          [StringValue("DAT001")]
          COMMIT_ERROR_DUPLICATED_PID,  // Failed because of duplicated PID
          [StringValue("DAT002")]
          COMMIT_ERROR_UNRESOLVED_VERSION_MISMATCH, // Failed because of unresolved some aggregate version mismatch
          [StringValue("EF001")]
          EF_ERROR_GENERIC
    }

    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class Command
    {
        private static object syncRoot = new object();

        static IEnumerable<Type> knownTypes = null;

        public static IEnumerable<Type> GetKnownTypes()
        {
            if (knownTypes != null)
                return knownTypes;
            //System.Threading.Thread.Sleep(20000);
            lock (syncRoot)
            {
                Type[] exportedTypes = null;
                Type asmType = null;
                Assembly asm = null;

                var r = new List<Type>();
                var typeCommand = typeof(Command);

                asmType = Type.GetType("M4Trader.ordenes.server.LoginCommand, M4Trader.ordenes.server");

                /*if (OrdenesApplication.Instance.Commands.Any(d => d == TipoAplicacion.ORDENES))
                {
                    asmType = Type.GetType("M4Trader.ordenes.server.UsuarioCommand, Mae.ordenes.MVC");
                    */
                    if (asmType != null)
                    {
                        asm = asmType.Assembly;
                        exportedTypes = asm.GetExportedTypes();
                        {
                            foreach (var t in exportedTypes)
                            {
                                if (typeCommand.IsAssignableFrom(t))
                                {
                                    r.Add(t);
                                }
                            }
                        }
                    }
                /*}
                if (OrdenesApplication.Instance.Commands.Any(d => d == TipoAplicacion.MOBILE))
                {
                    asmType = Type.GetType("Mae.ordenes.Mobile.MAEUserSessionCommand, Mae.ordenes.Mobile");
                    if (asmType != null)
                    {
                        asm = asmType.Assembly;
                        exportedTypes = asm.GetExportedTypes();
                        {
                            foreach (var t in exportedTypes)
                            {
                                if (typeCommand.IsAssignableFrom(t))
                                {
                                    r.Add(t);
                                }
                            }
                        }
                    }
                }

                if (OrdenesApplication.Instance.Commands.Any(d => d == TipoAplicacion.API))
                {
                    asmType = Type.GetType("Mae.Clear.api.AutenticaCommand, Mae.ordenes.api");*/
                    if (asmType != null)
                    {
                        asm = asmType.Assembly;
                        exportedTypes = asm.GetExportedTypes();
                        {
                            foreach (var t in exportedTypes)
                            {
                                if (typeCommand.IsAssignableFrom(t))
                                {
                                    r.Add(t);
                                }
                            }
                        }
                    }
                //}
                knownTypes = r;
            }
            
            return knownTypes;
        }

        public virtual void PreProcess() { }
        public virtual void Validate() { }
        public abstract int GetIdAccion { get; }
        public abstract int GetIdPermiso { get; }
        public abstract ExecutionResult Execute(InCourseRequest inCourseRequest);
        public virtual void ExecuteAfterSuccess()
        {

        }

        internal void Prepare()
        {
            autoTrimStrings();
        }

        public virtual void Dispose()
        {
        }

        public abstract bool needTransactionalBevahiour();

        // TODO: extender a string[] params ...
        protected void autoTrimStrings()
        {
            foreach (var f in GetType().GetProperties())
            {
                if (f.PropertyType == typeof(String))
                {
                    f.SetValue(this, ((string)f.GetValue(this)).Trim());
                }
            }
        }

        [DataMember]
        public Dictionary<string, object> Options
        {
            get;
            set;
        }

        [DataMember]
        public string Origen
        {
            get;
            set;
        }

    }
}

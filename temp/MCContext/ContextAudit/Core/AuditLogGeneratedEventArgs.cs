using M4Trader.ordenes.server.MCContext.ContextAudit.Model;
using System;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Core
{
    public class AuditLogGeneratedEventArgs : System.EventArgs
    {
        public AuditLogGeneratedEventArgs(AuditLog log, object entity)
        {
            Log = log;
            Entity = entity;
        }

        public AuditLog Log { get; internal set; }

        public object Entity { get; internal set; }

        [Obsolete("Please use `SkipSavingLog` property instead.")]
        public bool SkipSaving
        {
            get { return SkipSavingLog; }
            set { SkipSavingLog = value; }
        }

        public bool SkipSavingLog { get; set; }

        public dynamic Metadata { get; internal set; }
    }
}

using M4Trader.ordenes.server.MCContext.ContextAudit.Configuracion;
using M4Trader.ordenes.server.MCContext.ContextAudit.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Auditor
{
    public class DeletetionLogDetailsAuditor : ChangeLogDetailsAuditor
    {
        public DeletetionLogDetailsAuditor(EntityEntry dbEntry, AuditLog log) : base(dbEntry, log)
        {
        }

        protected override bool IsValueChanged(string propertyName)
        {
            if (GlobalTrackingConfig.TrackEmptyPropertiesOnAdditionAndDeletion)
                return true;

            var propertyType = DbEntry.Entity.GetType().GetProperty(propertyName).PropertyType;
            object defaultValue = propertyType.DefaultValue();
            object orginalvalue = OriginalValue(propertyName);

            Comparator comparator = ComparatorFactory.GetComparator(propertyType);

            return !comparator.AreEqual(defaultValue, orginalvalue);
        }

        protected override object CurrentValue(string propertyName)
        {
            return null;
        }
    }
}

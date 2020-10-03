using M4Trader.ordenes.server.MCContext.ContextAudit.Configuracion;
using M4Trader.ordenes.server.MCContext.ContextAudit.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Auditor
{
    public class AdditionLogDetailsAuditor : ChangeLogDetailsAuditor
    {
        public AdditionLogDetailsAuditor(EntityEntry dbEntry, AuditLog log) : base(dbEntry, log)
        {
        }


        protected internal override EntityState StateOfEntity()
        {
            if ((EntityState)DbEntry.State == EntityState.Unchanged)
            {
                return EntityState.Added;
            }

            return base.StateOfEntity();
        }

        protected override bool IsValueChanged(string propertyName)
        {
            if (GlobalTrackingConfig.TrackEmptyPropertiesOnAdditionAndDeletion)
                return true;

            var propertyType = DbEntry.Entity.GetType().GetProperty(propertyName).PropertyType;
            if ((Type)propertyType == typeof(Byte[]))
                return false;

            object defaultValue = propertyType.DefaultValue();
            object currentValue = CurrentValue(propertyName);


            Comparator comparator = ComparatorFactory.GetComparator(propertyType);

            return !comparator.AreEqual(defaultValue, currentValue);
        }

        protected override object OriginalValue(string propertyName)
        {
            return null;
        }
    }
}

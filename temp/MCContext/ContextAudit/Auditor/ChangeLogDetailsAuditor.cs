using M4Trader.ordenes.server.MCContext.ContextAudit.Configuracion;
using M4Trader.ordenes.server.MCContext.ContextAudit.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Auditor
{
    public class ChangeLogDetailsAuditor
    {
        protected readonly EntityEntry DbEntry;
        private readonly AuditLog _log;

        public ChangeLogDetailsAuditor(EntityEntry dbEntry, AuditLog log)
        {
            DbEntry = dbEntry;
            _log = log;
        }


        protected internal virtual EntityState StateOfEntity()
        {
            return (EntityState)DbEntry.State;
        }

        private IEnumerable<string> PropertyNamesOfEntity()
        {
            List<string> propiedades = new List<string>();
            foreach (var property in DbEntry.Entity.GetType().GetTypeInfo().DeclaredProperties)
            {
                propiedades.Add(property.Name);
            }

            return propiedades;
        }

        protected virtual bool IsValueChanged(string propertyName)
        {
            var prop = DbEntry.Property(propertyName);
            var propertyType = DbEntry.Entity.GetType().GetProperty(propertyName).PropertyType;
            
            object originalValue = OriginalValue(propertyName);
            object currentValue = CurrentValue(propertyName);

            Comparator comparator = ComparatorFactory.GetComparator(propertyType);

            var changed = (StateOfEntity() == EntityState.Modified
                && prop.IsModified && !comparator.AreEqual(CurrentValue(propertyName), originalValue));

            if ((Type)propertyType == typeof(Byte[]) && changed)
            {
                if (!((IStructuralEquatable)originalValue).Equals(currentValue, StructuralComparisons.StructuralEqualityComparer))
                    throw new Exception("EX_UltimaActualizacion");
                else
                    return false;
            }
            return changed;
        }

        protected virtual object OriginalValue(string propertyName)
        {
            object originalValue = null;

            if (GlobalTrackingConfig.DisconnectedContext)
            {
                originalValue = DbEntry.Property(propertyName).OriginalValue;  
            }
            else
            {
                originalValue = DbEntry.Property(propertyName).OriginalValue;
            }

            return originalValue;
        }

        protected virtual object CurrentValue(string propertyName)
        {
            var value = DbEntry.Property(propertyName).CurrentValue;
            return value;
        }
    }
}

﻿using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.MCContext.ContextAudit.Core;
using M4Trader.ordenes.server.MCContext.ContextAudit.Model;
using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server.MCContext.ContextAudit
{
    public class AuditContext : DbContext
    {

        public DbSet<AuditLog> Audits { get; set; }

        public void OpenConnection()
        {
            base.Database.OpenConnection();
        }

        public override int SaveChanges()
        {
            
            try
            {
                var auditEntries = OnBeforeSaveChanges();
                var result = base.SaveChanges();
                OnAfterSaveChanges(auditEntries);
                return result;
            }
            catch (System.Exception e)
            {
                //Todo Loggear la colleccion "AddedEntries" al log SQL, como JSON.
                LoggingHelper.Instance.AgregarLog(new LogSqlEntity("AuditContext", "SaveChanges", null, e));

                LoggingHelper.HandleException(e);
                return -1;

            }
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                Type entityType = entry.Entity.GetType();
                TrackChangesAttribute trackChangesAttribute = entityType.GetCustomAttributes(true).OfType<TrackChangesAttribute>().SingleOrDefault();
                if (trackChangesAttribute == null)
                    return null;

                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Metadata.Relational().TableName;
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }
                    if (propertyName.Equals("ConfiguracionSistema") ||
                        propertyName.Equals("RolUsuarioItems") || 
                        propertyName.Equals("ConfiguracionSistemaUrls") ||
                        propertyName.Equals("Pass"))
                    { 
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.eventType = EventType.Added;
                            break;

                        case EntityState.Deleted:
                            auditEntry.eventType = EventType.Deleted;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                                auditEntry.eventType = EventType.Modified;
                            }
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                var au = auditEntry.ToAudit(this);
                if( au != null )
                    Audits.Add(au);
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private int OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return 0;

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the Audit entry
                var au = auditEntry.ToAudit(this);
                if (au != null)
                    Audits.Add(au);
            }

            return base.SaveChanges();
        }
    }

    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }
        public EventType eventType { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public AuditLog ToAudit(DbContext context)
        {
            var auditer = new LogAuditor(Entry);
            AuditLog record = auditer.CreateLogRecord(eventType, context);
            if (record == null) return null;
            record.ValorOriginal = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            record.ValorNuevo = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            return record;
        }
    }
}

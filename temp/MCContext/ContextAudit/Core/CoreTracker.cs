using M4Trader.ordenes.server.MCContext.ContextAudit.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Core
{
    public class CoreTracker
    {
        public event EventHandler<AuditLogGeneratedEventArgs> OnAuditLogGenerated;
        private readonly DbContext _context;

        public CoreTracker(DbContext context)
        {
            _context = context;
        }

        public void AuditChanges()
        {
            // Get all Deleted/Modified entities (not Unmodified or Detached or Added)  EntityState.Deleted ||
            foreach (
                 EntityEntry ent in _context.ChangeTracker.Entries()
                        .Where(p => p.State == EntityState.Modified))
            {
                using (var auditer = new LogAuditor(ent))
                {
                    AuditLog record = auditer.CreateLogRecord(EventType.Modified, _context);

                    if (record != null)
                    {
                        var arg = new AuditLogGeneratedEventArgs(record, ent.Entity);
                        RaiseOnAuditLogGenerated(this, arg);
                        if (!arg.SkipSavingLog)
                        {
                            _context.Add(record);
                            return;
                        }
                    }
                }
            }
        }


        public IEnumerable<EntityEntry> GetAdditions()
        {
            return _context.ChangeTracker.Entries().Where(p => p.State ==  EntityState.Added).ToList();
        }

        public void AuditAdditions(IEnumerable<EntityEntry> addedEntries)
        {
            // Get all Added entities
            foreach (EntityEntry ent in addedEntries)
            {
                using (var auditer = new LogAuditor(ent))
                {
                    AuditLog record = auditer.CreateLogRecord(EventType.Added, _context);
                    if (record != null)
                    {
                        var arg = new AuditLogGeneratedEventArgs(record, ent.Entity);
                        RaiseOnAuditLogGenerated(this, arg);
                        if (!arg.SkipSavingLog)
                        {
                            _context.Add(record);
                        }
                    }
                }
            }
        }


        protected virtual void RaiseOnAuditLogGenerated(object sender, AuditLogGeneratedEventArgs e)
        {
            OnAuditLogGenerated?.Invoke(sender, e);
        }
    }
}

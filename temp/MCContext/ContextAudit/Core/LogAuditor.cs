using M4Trader.ordenes.server.MCContext.ContextAudit.Configuracion;
using M4Trader.ordenes.server.MCContext.ContextAudit.Model;
using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using M4Trader.ordenes.services.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Core
{
    internal class LogAuditor : IDisposable
    {
        private readonly EntityEntry _dbEntry;

        internal LogAuditor(EntityEntry dbEntry)
        {
            _dbEntry = dbEntry;
        }

        public void Dispose()
        {
        }

        internal AuditLog CreateLogRecord(EventType eventType, DbContext context)
        {
            Type entityType = _dbEntry.Entity.GetType().GetEntityType();

            TrackChangesAttribute trackChangesAttribute = entityType.GetCustomAttributes(true).OfType<TrackChangesAttribute>().SingleOrDefault();
            if (trackChangesAttribute == null)
                return null;

            DateTime changeTime = DateTime.Now;
            var keyRepresentation = BuildKeyRepresentation(_dbEntry);

            try
            {
                var newlog = new AuditLog
                {
                    IdUsuario = MAEUserSession.InstanciaCargada? MAEUserSession.Instancia.IdUsuario:1,
                    FechaEvento = changeTime,
                    entityType = eventType,
                    IdClase = (short)trackChangesAttribute.LogAuditoriaClase,
                    IdRegistro = keyRepresentation.Value
                };

                return newlog;

            }
            catch
            {
                return null;
            }
        }

        private static KeyValuePair<string, long> BuildKeyRepresentation(EntityEntry entityEntry)
        {
            var keyProperties = entityEntry.Metadata.GetProperties().Where(x => x.IsPrimaryKey()).ToList();
            if (keyProperties == null)
                throw new ArgumentException("No key found in");
            var keyPropertyEntries = keyProperties.Select(keyProperty => entityEntry.Property(keyProperty.Name)).ToList();
            var keyNameString = new StringBuilder();
            foreach (var keyProperty in keyProperties)
            {
                keyNameString.Append(keyProperty.Name);
            }

            var keyValueString = new StringBuilder();
            foreach (var keyPropertyEntry in keyPropertyEntries)
            {
                keyValueString.Append(keyPropertyEntry.CurrentValue);
            }

            var key = keyNameString.ToString();

            long value = 0;
            if (keyValueString.Length > 0)
            {
                long.TryParse(keyValueString.ToString(), out value);
            }
            return new KeyValuePair<string, long>(key, value);
        }

    }
}

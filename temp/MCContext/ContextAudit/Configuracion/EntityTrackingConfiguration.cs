using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.Linq;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Configuracion
{
    internal static class EntityTrackingConfiguration
    {
        internal static bool IsTrackingEnabled(Type entityType)
        {
            if (typeof(IUnTrackable).IsAssignableFrom(entityType)) return false;

            /*TrackingConfigurationValue value = TrackingDataStore.EntityConfigStore.GetOrAdd(
            entityType.FullName,
            (key) => EntityConfigValueFactory(key, entityType)
            );
            */
            return true;// value.Value;
        }

        internal static TrackingConfigurationValue EntityConfigValueFactory(string key, Type entityType)
        {
            TrackChangesAttribute trackChangesAttribute =
                entityType.GetCustomAttributes(true).OfType<TrackChangesAttribute>().SingleOrDefault();
            bool value = trackChangesAttribute != null;

            return new TrackingConfigurationValue(value);
        }
    }
 
}

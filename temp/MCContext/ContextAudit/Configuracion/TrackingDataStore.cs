using System;
using System.Collections.Concurrent;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Configuracion
{
    internal static class TrackingDataStore
    {
        ////////////////////////// STORE /////////////////////////////

        internal static ConcurrentDictionary<string, TrackingConfigurationValue> EntityConfigStore = new ConcurrentDictionary<string, TrackingConfigurationValue>();
        internal static ConcurrentDictionary<PropertyConfiguerationKey, TrackingConfigurationValue> PropertyConfigStore = new ConcurrentDictionary<PropertyConfiguerationKey, TrackingConfigurationValue>();
    }

    internal class TrackingConfigurationValue
    {
        internal TrackingConfigurationValue(bool value = false, TrackingConfigurationPriority priority = TrackingConfigurationPriority.Default)
        {
            Value = value;
            Priority = priority;
        }

        internal bool Value { get; private set; }
        internal TrackingConfigurationPriority Priority { get; private set; }
    }

    internal class PropertyConfiguerationKey
    {
        internal PropertyConfiguerationKey(string propertyName, string typeFullName)
        {
            PropertyName = propertyName;
            TypeFullName = typeFullName;
        }

        internal string PropertyName { get; }
        internal string TypeFullName { get; }

        public override bool Equals(object obj)
        {
            var otherEntity = (PropertyConfiguerationKey)obj;
            bool isNameSame = otherEntity.PropertyName.Equals(PropertyName, StringComparison.OrdinalIgnoreCase);
            bool isTypeSame = otherEntity.TypeFullName.Equals(TypeFullName, StringComparison.OrdinalIgnoreCase);

            return isNameSame && isTypeSame;
        }

        public override int GetHashCode()
        {
            return (PropertyName + TypeFullName).GetHashCode();
        }

        public override string ToString()
        {
            return TypeFullName + "." + PropertyName;
        }
    }

    internal enum TrackingConfigurationPriority
    {
        Default = 0,
        High = 1
    }
}

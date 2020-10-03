using M4Trader.ordenes.server.MCContext.ContextAudit.Configuracion;
using System;

namespace M4Trader.ordenes.server.MCContext.ContextAudit.Model
{
    internal static class ComparatorFactory
    {
        internal static Comparator GetComparator(Type type)
        {
            if (type.IsNullable<DateTime>())
            {
                return new NullableDateComparator();
            }

            if (type == typeof(DateTime))
            {
                return new DateComparator();
            }

            if (type == typeof(string))
            {
                return new StringComparator();
            }

            if (type.IsNullable())
            {
                return new NullableComparator();
            }

            if (type.IsValueType)
            {
                return new ValueTypeComparator();
            }

            return new Comparator();
        }
    }

    internal class ValueTypeComparator : Comparator
    {
        internal override bool AreEqual(object value1, object value2)
        {
            return value1.Equals(value2);
        }
    }

    internal class NullableComparator : Comparator
    {
        internal override bool AreEqual(object value1, object value2)
        {
            if (value1 == null && value2 == null) return true;
            if (value1 == null && value2 != null) return value2.Equals(value1);

            return value1.Equals(value2);
        }
    }

    internal class StringComparator : Comparator
    {
        internal override bool AreEqual(object value1, object value2)
        {
            return String.CompareOrdinal(Convert.ToString(value1), Convert.ToString(value2)) == 0;
        }
    }

    internal class NullableDateComparator : DateComparator
    {
        internal override bool AreEqual(object value1, object value2)
        {
            DateTime? date1 = (DateTime?)value1 ?? DateTime.MinValue;
            DateTime? date2 = (DateTime?)value2 ?? DateTime.MinValue;

            return base.AreEqual(date1, date2);
        }
    }

    internal class DateComparator : Comparator
    {
        internal override bool AreEqual(object value1, object value2)
        {
            DateTime date1 = (DateTime)value1;
            DateTime date2 = (DateTime)value2;

            return date1.Year == date2.Year &&
                   date1.Month == date2.Month &&
                   date1.Day == date2.Day &&
                   date1.Hour == date2.Hour &&
                   date1.Minute == date2.Minute &&
                   date1.Second == date2.Second;
        }
    }

    internal class Comparator
    {
        internal virtual bool AreEqual(object value1, object value2)
        {
            return value1 == value2;
        }
    }
}

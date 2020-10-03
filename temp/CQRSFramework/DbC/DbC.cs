using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace M4Trader.ordenes.server.CQRSFramework.DbC
{
    public static class DbC
    {
        [Conditional("DEBUG")]
        public static void EnsureTrue(bool trueExpression, string message)
        {
            if (!trueExpression)
            {
                throw new PreConditionNotEnsuredException(message);
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureTrue(params bool[] expresion)
        {
            foreach (var e in expresion)
            {
                if (!e) throw new PreConditionNotEnsuredException();
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureFalse(bool falseExpression)
        {
            if (falseExpression)
            {
                throw new PreConditionNotEnsuredException();
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNull(object notNullReference)
        {
            if (null == notNullReference)
            {
                throw new PreConditionNotEnsuredException();
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNull(params object[] notNullReferences)
        {
            DbC.EnsureNotNullNorEmpty(notNullReferences);

            foreach (var o in notNullReferences)
            {
                if (null == o)
                {
                    throw new PreConditionNotEnsuredException();
                }
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNullNorEmpty(string @string)
        {
            if (string.IsNullOrEmpty(@string))
            {
                throw new PreConditionNotEnsuredException();
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNullNorEmptyNorWhiteSpace(string @string)
        {
            if (string.IsNullOrWhiteSpace(@string))
            {
                throw new PreConditionNotEnsuredException();
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureGreaterThanZero(decimal number)
        {
            if (number <= 0 )
            {
                throw new PreConditionNotEnsuredException();
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNullNorEmpty(params string[] strings)
        {
            foreach (var s in strings)
            {
                if (string.IsNullOrEmpty(s))
                {
                    throw new PreConditionNotEnsuredException();
                }
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNullNorEmptyNorWhiteSpace(params string[] strings)
        {
            foreach (var s in strings)
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    throw new PreConditionNotEnsuredException();
                }
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNull<T>(T t)
        {
            if (null == t)
            {
                throw new PreConditionNotEnsuredException();
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNullNorEmpty<T>(params T[] ts)
        {
            DbC.EnsureNotNullNorEmpty(ts);

            foreach (var t in ts)
            {
                if (null == t)
                {
                    throw new PreConditionNotEnsuredException();
                }
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNullNorEmpty(ICollection collection)
        {
            if (null == collection)
            {
                throw new PreConditionNotEnsuredException();
            }

            if (collection.Count <= 0)
            {
                throw new PreConditionNotEnsuredException();
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNullNorEmpty(params ICollection[] collections)
        {
            DbC.EnsureNotNullNorEmpty(collections);

            foreach (var c in collections)
            {
                if (null == c)
                {
                    throw new PreConditionNotEnsuredException();
                }

                if (c.Count <= 0)
                {
                    throw new PreConditionNotEnsuredException();
                }
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNullNorEmpty<T>(ICollection<T> collection)
        {
            if (null == collection)
            {
                throw new PreConditionNotEnsuredException();
            }

            if (collection.Count <= 0)
            {
                throw new PreConditionNotEnsuredException();
            }
        }

        [Conditional("DEBUG")]
        public static void EnsureNotNullNorEmpty<T>(params ICollection<T>[] collections)
        {
            DbC.EnsureNotNullNorEmpty(collections);

            foreach (var c in collections)
            {
                if (null == c)
                {
                    throw new PreConditionNotEnsuredException();
                }

                if (c.Count <= 0)
                {
                    throw new PreConditionNotEnsuredException();
                }
            }
        }
    }
}

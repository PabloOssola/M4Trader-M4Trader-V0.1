using System;
using System.Collections.Generic;
using System.Data;

namespace M4Trader.ordenes.server.DataAccess
{
    public sealed class TypeConvertor
    {

        private struct DbTypeMapEntry
        {
            public Type Type;
            public DbType DbType;
            public SqlDbType SqlDbType;
            public DbTypeMapEntry(Type type, DbType dbType, SqlDbType sqlDbType)
            {
                this.Type = type;
                this.DbType = dbType;
                this.SqlDbType = sqlDbType;
            }

        };

        private static List<DbTypeMapEntry> _DbTypeList = new List<DbTypeMapEntry>();

        #region Constructors

        static TypeConvertor()
        {
            _DbTypeList.Add(new DbTypeMapEntry(typeof(bool), DbType.Boolean, SqlDbType.Bit));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(byte), DbType.Double, SqlDbType.TinyInt));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(byte[]), DbType.Binary, SqlDbType.Image));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(DateTime), DbType.DateTime, SqlDbType.DateTime));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(Decimal), DbType.Decimal, SqlDbType.Decimal));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(double), DbType.Double, SqlDbType.Float));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(Guid), DbType.Guid, SqlDbType.UniqueIdentifier));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(Int16), DbType.Int16, SqlDbType.SmallInt));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(Int32), DbType.Int32, SqlDbType.Int));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(Int64), DbType.Int64, SqlDbType.BigInt));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(object), DbType.Object, SqlDbType.Variant));
            _DbTypeList.Add(new DbTypeMapEntry(typeof(string), DbType.String, SqlDbType.VarChar));

        }

        private TypeConvertor()
        {

        }

        #endregion

        #region Methods

        
        public static Type ToNetType(DbType dbType)
        {
            DbTypeMapEntry entry = Find(dbType);
            return entry.Type;
        }

        
        public static Type ToNetType(SqlDbType sqlDbType)
        {
            DbTypeMapEntry entry = Find(sqlDbType);
            return entry.Type;
        }

        
        public static DbType ToDbType(Type type)
        {
            DbTypeMapEntry entry = Find(type);
            return entry.DbType;
        }

        
        public static DbType ToDbType(SqlDbType sqlDbType)
        {
            DbTypeMapEntry entry = Find(sqlDbType);
            return entry.DbType;
        }

        
        public static SqlDbType ToSqlDbType(Type type)
        {
            DbTypeMapEntry entry = Find(type);
            return entry.SqlDbType;
        }

        
        public static SqlDbType ToSqlDbType(DbType dbType)
        {
            DbTypeMapEntry entry = Find(dbType);
            return entry.SqlDbType;
        }

        private static DbTypeMapEntry Find(Type type)
        {
            object retObj = null;
            for (int i = 0; i < _DbTypeList.Count; i++)
            {
                DbTypeMapEntry entry = (DbTypeMapEntry)_DbTypeList[i];
                if (entry.Type == (Nullable.GetUnderlyingType(type) ?? type))
                {
                    retObj = entry;
                    break;
                }
            }
            if (retObj == null)
            {
                throw
                new ApplicationException("Referenced an unsupported Type");
            }

            return (DbTypeMapEntry)retObj;
        }

        private static DbTypeMapEntry Find(DbType dbType)
        {
            object retObj = null;
            for (int i = 0; i < _DbTypeList.Count; i++)
            {
                DbTypeMapEntry entry = (DbTypeMapEntry)_DbTypeList[i];
                if (entry.DbType == dbType)
                {
                    retObj = entry;
                    break;
                }
            }
            if (retObj == null)
            {
                throw
                new ApplicationException("Referenced an unsupported DbType");
            }

            return (DbTypeMapEntry)retObj;
        }
        private static DbTypeMapEntry Find(SqlDbType sqlDbType)
        {
            object retObj = null;
            for (int i = 0; i < _DbTypeList.Count; i++)
            {
                DbTypeMapEntry entry = (DbTypeMapEntry)_DbTypeList[i];
                if (entry.SqlDbType == sqlDbType)
                {
                    retObj = entry;
                    break;
                }
            }
            if (retObj == null)
            {
                throw
                new ApplicationException("Referenced an unsupported SqlDbType");
            }

            return (DbTypeMapEntry)retObj;
        }

        #endregion
    }
}

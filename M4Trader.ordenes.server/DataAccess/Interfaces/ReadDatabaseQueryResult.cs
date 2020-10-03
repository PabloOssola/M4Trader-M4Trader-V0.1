using System.Collections;

namespace M4Trader.ordenes.server.DataAccess.Interfaces
{

    public class ResultSet
    {
        public ArrayList Data
        {
            get;
            internal set;
        }

        public string[] Columns
        {
            get;
            internal set;
        }

        public string Name
        {
            get;
            internal set;
        }

        public ResultSet(string name)
        {
            Data = new ArrayList(50);
            Name = name;
        }
    }

    public class DatabaseQueryResult
    {
        public ArrayList ResultSets
        {
            get;
            internal set;
        }
        public DatabaseQueryResult()
        {
            ResultSets = new ArrayList(1);
        }
    }
}
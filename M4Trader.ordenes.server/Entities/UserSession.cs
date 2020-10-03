using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server.Entities
{
    public enum StateType
    {
        Information = 1,
        Warning = 2,
        Error = 3
    }

    public class State
    {

        public string Code
        {
            get;
            set;
        }

        public StateType StateType
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }


    }
}

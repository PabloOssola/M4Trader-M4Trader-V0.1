using System;
using System.Diagnostics;

namespace M4Trader.ordenes.server.CQRSFramework.DbC
{
    public class PreConditionNotEnsuredException : Exception
    {
        public PreConditionNotEnsuredException()
            : base()
        {
        }

        public PreConditionNotEnsuredException(string message)
            : base(message)
        {
        }

        public override string StackTrace
        {
            get
            {
                var st = new StackTrace(this, 1, true);

                return st.ToString();
            }
        }
    }
}

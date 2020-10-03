using System;

namespace M4Trader.ordenes.server.CQRSFramework
{
    public class StringValue : Attribute
    {
        private string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
}

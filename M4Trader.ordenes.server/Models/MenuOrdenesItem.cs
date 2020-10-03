using System.Collections.Generic;

namespace M4Trader.ordenes.server.Models
{
    public class MenuOrdenesItem
    {
        public object key;
        public long actionId;
        public string title = "";
        public string url;
        public string className;
        public string icon;
        public int permissionMask;
        public int permissionPermitted;
        public string value;
        public bool allowed;
        public string name;
        private List<MenuOrdenesItem> _items = new List<MenuOrdenesItem>();
        private List<MenuParameter> _parameters = new List<MenuParameter>();

        public List<MenuOrdenesItem> items
        {
            get { return _items; }
            set { _items = value; }
        }

        public List<MenuParameter> parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                _parameters = value;
            }
        }
    }

    public class MenuParameter
    {
        private string name;
        private string value;

        public MenuParameter()
        {
        }

        public MenuParameter(string aName, string aValue)
        {
            this.Name = aName;
            this.Value = aValue;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
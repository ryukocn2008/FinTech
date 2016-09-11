using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBasicTests.helpers
{
    class OptionItem
    {

        public string name { get; set; }
        public string displayName { get; set; }
        public string selectedValue { get; set; }
        public bool isKey { get; set; }
        public Dictionary<string, OptionItem> items { get; set; }

        public OptionItem()
        {

        }
        public OptionItem(string name)
        {
            this.name = name;
            this.displayName = name;
            this.selectedValue = name;
            this.isKey = false;
        }

        public OptionItem(string name, bool isKey)
        {
            this.name = name;
            this.isKey = isKey;
        }

        public string toString()
        {
            return displayName;
        }
    }
}

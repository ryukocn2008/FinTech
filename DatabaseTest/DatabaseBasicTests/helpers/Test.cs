using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBasicTests.helpers
{
    class Test : OptionItem
    {
        public string SQL { get; set; }

        public Test(string name) : base(name) { }
    }
}

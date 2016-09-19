using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBasicTests.helpers
{
    class Test : OptionItem
    {
        public string query { get; set; }

        public Test(string name) : base(name) { }

        public enumDatabaseCategory databaseCategory { get; set; }
        public enumDatabase database { get; set; }
        public enumTestSet testSet { get; set; }
        public enumConnectionType connectionType { get; set; }
        public string test { get; set; }

    }
}

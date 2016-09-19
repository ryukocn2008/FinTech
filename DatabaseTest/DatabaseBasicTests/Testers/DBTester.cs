using DatabaseBasicTests.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseBasicTests.Testers
{
    class DBTester : IDBTester
    {
        public Test _test { get; set; }
        public DBTester() { }
        public DBTester(Test test)
        {
            this._test = test;
        }

        public bool test()
        {
            return true;
        }

        public BindingSource getResult()
        {
            return result;
        }

        public BindingSource result = null;
    }
}

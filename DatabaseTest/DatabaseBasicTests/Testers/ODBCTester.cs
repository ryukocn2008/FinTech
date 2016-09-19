using DatabaseBasicTests.Domains;
using DatabaseBasicTests.helpers;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseBasicTests.Testers
{
    class ODBCTester : DBTester
    {
        public string DSN { get; set; }
        public string command { get; set; }

        public ODBCTester(Test test, string dsn, string command)
        {
            this._test = test;
            this.DSN = dsn;
            this.command = command;
        }

        private OdbcConnection conn;
        private OdbcCommand comm;

        public new bool test()
        {
            conn = new OdbcConnection("DSN=" + DSN);
            comm = conn.CreateCommand();
            comm.CommandText = command;

            if (this._test.test.Equals("SELECT"))
            {
                return selectTest();
            }
            else if (this._test.test.Equals("UPDATE"))
            {
                return updateTest();
            }


            return false;
        }

        public bool selectTest()
        {
            try
            {

                OdbcDataReader reader = comm.ExecuteReader();
                // Create a BindingSource from reader
                List<TestTable> ret = new List<TestTable>();



                BindingSource binding = new BindingSource();

                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool updateTest()
        {
            return true;
        }
    }
}

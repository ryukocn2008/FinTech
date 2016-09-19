using DatabaseBasicTests.helpers;
using DatabaseBasicTests.Testers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseBasicTests
{
    enum enumDatabaseCategory { UNKNOWN, RationalDatabase, NoSQLDatabase };
    enum enumDatabase { UNKNOWN, MSSQLServer, OracleDB, SybaseASE, MySQL, PostgreSQL };
    enum enumTestSet { UNKNOWN, CRUD, Backup, DDL};
    enum enumConnectionType { UNKNOWN, ODBC, OLEDB, DOTNETProvider, EntityModelEF };

    public partial class MainForm : Form
    {
        OptionItemsReader optionItemsReader;

        enumDatabaseCategory l_databaseCategory = enumDatabaseCategory.UNKNOWN;
        enumDatabase l_database = enumDatabase.UNKNOWN;
        enumTestSet l_testSet = enumTestSet.UNKNOWN;
        enumConnectionType l_connectionType = enumConnectionType.UNKNOWN;
        Test l_test = null;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Build a Tree data structure for dropdown listbox
            optionItemsReader = new OptionItemsReader("OptionItems.xml");
            List<KeyValuePair<string, OptionItem>> databaseCategories = optionItemsReader.getDatabaseCategories();

            // Not working
            /*
            cbbDatabaseCategory.DataSource = new BindingSource(databaseCategories, null);
            cbbDatabaseCategory.DisplayMember = "Value.displayName";
            cbbDatabaseCategory.ValueMember = "Value.selectedValue";
            */
            cbbDatabaseCategory.Items.Clear();
            cbbDatabaseCategory.DisplayMember = "displayName";
            foreach (KeyValuePair<string, OptionItem> pair in databaseCategories)
            {
                cbbDatabaseCategory.Items.Add(pair.Value);
            }

            // Hide all controls exception database category
            lblDatabase.Visible = false;
            cbbDatabase.Visible = false;

            lblTestSet.Visible = false;
            cbbTestSet.Visible = false;

            lblConnectionType.Visible = false;
            cbbConnectionType.Visible = false;

            lblTest.Visible = false;
            cbbTest.Visible = false;

            btnTest.Visible = false;

        }

        private void cbbDatabaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionItem selectedItem = (OptionItem)cbbDatabaseCategory.SelectedItem;

            if (selectedItem.selectedValue.Equals("Rational Database"))
            {
                l_databaseCategory = enumDatabaseCategory.RationalDatabase;
            }
            else if (selectedItem.selectedValue.Equals("NoSQL Database"))
            {
                l_databaseCategory = enumDatabaseCategory.NoSQLDatabase;
            }
            else
            {
                l_databaseCategory = enumDatabaseCategory.UNKNOWN;
            }

            lblDatabase.Visible = true;
            cbbDatabase.Visible = true;

            // Get the values by selected DatabaseCategory
            List<KeyValuePair<string, OptionItem>> databases = optionItemsReader.getDatabases(selectedItem);

            // Set the values
            cbbDatabase.Items.Clear();
            cbbDatabase.DisplayMember = "displayName";

            foreach (KeyValuePair<string, OptionItem> pair in databases)
            {
                cbbDatabase.Items.Add(pair.Value);
            }

            // Hide all controls exception database category, database
            lblTestSet.Visible = false;
            cbbTestSet.Visible = false;

            lblConnectionType.Visible = false;
            cbbConnectionType.Visible = false;

            lblTest.Visible = false;
            cbbTest.Visible = false;
        }

        private void cbbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionItem selectedItem = (OptionItem)cbbDatabase.SelectedItem;

            if (selectedItem.selectedValue.Equals("MS SQL Server"))
            {
                l_database = enumDatabase.MSSQLServer;
            }
            else if (selectedItem.selectedValue.Equals("Oracle Database"))
            {
                l_database = enumDatabase.OracleDB;
            }
            else if (selectedItem.selectedValue.Equals("Sybase ASE"))
            {
                l_database = enumDatabase.SybaseASE;
            }
            else if (selectedItem.selectedValue.Equals("MySQL Server"))
            {
                l_database = enumDatabase.MySQL;
            }
            else if (selectedItem.selectedValue.Equals("PostgreSQL"))
            {
                l_database = enumDatabase.PostgreSQL;
            }
            else
            {
                l_database = enumDatabase.UNKNOWN;
            }

            lblTestSet.Visible = true;
            cbbTestSet.Visible = true;

            // Get the values by selected DatabaseCategory
            List<KeyValuePair<string, OptionItem>> testSets = optionItemsReader.getTestSets(selectedItem);

            // Set the values
            cbbTestSet.Items.Clear();
            cbbTestSet.DisplayMember = "displayName";

            foreach (KeyValuePair<string, OptionItem> pair in testSets)
            {
                cbbTestSet.Items.Add(pair.Value);
            }

            // Hide all controls exception Database Category, Database, Test Set
            lblConnectionType.Visible = false;
            cbbConnectionType.Visible = false;

            lblTest.Visible = false;
            cbbTest.Visible = false;
        }

        private void cbbTestSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionItem selectedItem = (OptionItem)cbbTestSet.SelectedItem;

            if (selectedItem.selectedValue.Equals("CRUD"))
            {
                l_testSet = enumTestSet.CRUD;
            }
            else if (selectedItem.selectedValue.Equals("DDL"))
            {
                l_testSet = enumTestSet.DDL;
            }
            else if (selectedItem.selectedValue.Equals("Backup"))
            {
                l_testSet = enumTestSet.Backup;
            }
            else
            {
                l_testSet = enumTestSet.UNKNOWN;
            }

            lblConnectionType.Visible = true;
            cbbConnectionType.Visible = true;

            // Get the values by selected DatabaseCategory
            List<KeyValuePair<string, OptionItem>> connectionTypes = optionItemsReader.getConnectionTypes(selectedItem);

            // Set the values
            cbbConnectionType.Items.Clear();
            cbbConnectionType.DisplayMember = "displayName";

            foreach (KeyValuePair<string, OptionItem> pair in connectionTypes)
            {
                cbbConnectionType.Items.Add(pair.Value);
            }

            // Hide all controls exception Database Category, Database, Test Set, Connection Type
            lblTest.Visible = false;
            cbbTest.Visible = false;
        }

        private void cbbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionItem selectedItem = (OptionItem)cbbConnectionType.SelectedItem;

            if (selectedItem.selectedValue.Equals("CRUD"))
            {
                l_connectionType = enumConnectionType.ODBC;
            }
            else if (selectedItem.selectedValue.Equals("DDL"))
            {
                l_connectionType = enumConnectionType.OLEDB;
            }
            else if (selectedItem.selectedValue.Equals(".net Provider"))
            {
                l_connectionType = enumConnectionType.DOTNETProvider;
            }
            else if (selectedItem.selectedValue.Equals("Entity Model (EF)"))
            {
                l_connectionType = enumConnectionType.EntityModelEF;
            }
            else
            {
                l_connectionType = enumConnectionType.UNKNOWN;
            }

            lblTest.Visible = true;
            cbbTest.Visible = true;

            // Get the values by selected DatabaseCategory
            List<KeyValuePair<string, OptionItem>> tests = optionItemsReader.getTests(selectedItem);

            // Set the values
            cbbTest.Items.Clear();
            cbbTest.DisplayMember = "displayName";

            foreach (KeyValuePair<string, OptionItem> pair in tests)
            {
                cbbTest.Items.Add(pair.Value);
            }
        }

        private void cbbTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Test selectedItem = (Test)cbbTest.SelectedItem;

            // set the l_test
            l_test = selectedItem;

            // setup other test parameters
            selectedItem.databaseCategory = l_databaseCategory;
            selectedItem.database = l_database;
            selectedItem.testSet = l_testSet;
            selectedItem.connectionType = l_connectionType;
            selectedItem.test = selectedItem.selectedValue;
            //selectedItem.test = l_test;


            // Show the test button
            btnTest.Visible = true;

            // Set the SQL
            txtQuery.Text = selectedItem.query;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (l_test != null)
            { 
                // test, assuming ODBC
                IDBTester test = new ODBCTester(l_test, "", txtQuery.Text.Trim());
                
            }


        }
    }
}

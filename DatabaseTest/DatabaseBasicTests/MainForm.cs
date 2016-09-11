using DatabaseBasicTests.helpers;
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
    public partial class MainForm : Form
    {
        OptionItemsReader optionItemsReader;

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

        }

        private void cbbDatabaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionItem selectedItem = (OptionItem)cbbDatabaseCategory.SelectedItem;

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseBasicTests.helpers;
using System.Xml;
using System.Windows.Forms;

namespace DatabaseBasicTests
{
    class OptionItemsReader
    {
        public Dictionary<string, OptionItem> options { get; set; }
        private string settingFilePath;

        public OptionItemsReader(string path) {
            this.settingFilePath = path;
            this.options = new Dictionary<string, OptionItem>();
            XmlDocument settingXML = new XmlDocument();
            try
            {
                settingXML.Load(this.settingFilePath);
                XmlNode root = settingXML.DocumentElement;
                // root node : OptionItems
                if (root.Name.Equals("OptionItems")) {
                    OptionItem optionItems = new OptionItem();
                    optionItems.name = "OptionItems";
                    options.Add("Root", optionItems);

                    // DatabaseCategory
                    XmlNodeList databaseCategories = root.ChildNodes;
                    optionItems.items = new Dictionary<string, OptionItem>();
                    // Add a counter because Dictionary doesn't allow duplicated key.
                    int counter1 = 0;
                    foreach (XmlNode node1 in databaseCategories)
                    {
                        if (node1.Name.Equals("DatabaseCategory"))
                        {
                            counter1++;
                            OptionItem databaseCategory = new OptionItem(node1.Attributes["Value"].Value);

                            optionItems.items.Add("DatabaseCategory" + counter1.ToString(), databaseCategory);
                            // Database
                            int counter2 = 0;
                            XmlNodeList databases = node1.ChildNodes;
                            databaseCategory.items = new Dictionary<string, OptionItem>();
                            
                            foreach (XmlNode node2 in databases)
                            {
                                if (node2.Name.Equals("Database"))
                                {
                                    counter2++;
                                    OptionItem database = new OptionItem(node2.Attributes["Value"].Value);

                                    databaseCategory.items.Add("Database" + counter2.ToString(), database);
                                    // TestSet
                                    int counter3 = 0;
                                    XmlNodeList testSets = node2.ChildNodes;
                                    database.items = new Dictionary<string, OptionItem>();
                                    
                                    foreach (XmlNode node3 in testSets)
                                    {
                                        if (node3.Name.Equals("TestSet"))
                                        {
                                            counter3++;
                                            OptionItem testSet = new OptionItem(node3.Attributes["Value"].Value);

                                            database.items.Add("TestSet" + counter3.ToString(), testSet);
                                            // ConnectionType
                                            int counter4 = 0;
                                            XmlNodeList connectionTypes = node3.ChildNodes;
                                            testSet.items = new Dictionary<string, OptionItem>();
                                            
                                            foreach (XmlNode node4 in connectionTypes)
                                            {
                                                if (node4.Name.Equals("ConnectionType"))
                                                {
                                                    counter4++;
                                                    OptionItem connectionType = new OptionItem(node4.Attributes["Value"].Value);

                                                    testSet.items.Add("ConnectionType" + counter4.ToString(), connectionType);
                                                    // Test
                                                    int counter5 = 0;
                                                    XmlNodeList tests = node4.ChildNodes;
                                                    connectionType.items = new Dictionary<string, OptionItem>();
                                                    
                                                    foreach (XmlNode node5 in tests)
                                                    {
                                                        if (node5.Name.Equals("Test"))
                                                        {
                                                            counter5++;
                                                            Test test = new Test(node5.Attributes["Value"].Value);
                                                            connectionType.items.Add("Test" + counter5.ToString(), test);

                                                            // Set SQL
                                                            XmlNodeList sqls = node5.ChildNodes;
                                                            foreach (XmlNode node6 in sqls)
                                                            {
                                                                if (node6.Name.Equals("SQL"))
                                                                {
                                                                    test.query = node6.InnerText;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error in loading setting file.\n" + e.Message);
            }

        }

        internal List<KeyValuePair<string, OptionItem>> getTests(OptionItem selectedItem)
        {
            List<KeyValuePair<string, OptionItem>> ret = new List<KeyValuePair<string, OptionItem>>();
            foreach (string itemKey in selectedItem.items.Keys)
            {

                if (itemKey.StartsWith("Test"))
                {
                    KeyValuePair<string, OptionItem> itemPair
                        = new KeyValuePair<string, OptionItem>(itemKey, selectedItem.items[itemKey]);
                    ret.Add(itemPair);
                }

            }

            return ret;
        }

        internal List<KeyValuePair<string, OptionItem>> getConnectionTypes(OptionItem selectedItem)
        {
            List<KeyValuePair<string, OptionItem>> ret = new List<KeyValuePair<string, OptionItem>>();
            foreach (string itemKey in selectedItem.items.Keys)
            {

                if (itemKey.StartsWith("ConnectionType"))
                {
                    KeyValuePair<string, OptionItem> itemPair
                        = new KeyValuePair<string, OptionItem>(itemKey, selectedItem.items[itemKey]);
                    ret.Add(itemPair);
                }

            }

            return ret;
        }

        internal List<KeyValuePair<string, OptionItem>> getTestSets(OptionItem selectedItem)
        {
            List<KeyValuePair<string, OptionItem>> ret = new List<KeyValuePair<string, OptionItem>>();
            foreach (string itemKey in selectedItem.items.Keys)
            {

                if (itemKey.StartsWith("TestSet"))
                {
                    KeyValuePair<string, OptionItem> itemPair
                        = new KeyValuePair<string, OptionItem>(itemKey, selectedItem.items[itemKey]);
                    ret.Add(itemPair);
                }

            }

            return ret;
        }

        public List<KeyValuePair<string, OptionItem>> getDatabases(OptionItem selectedItem)
        {
            List<KeyValuePair<string, OptionItem>> ret = new List<KeyValuePair<string, OptionItem>>();
            foreach (string itemKey in selectedItem.items.Keys)
            {

                if (itemKey.StartsWith("Database"))
                {
                    KeyValuePair<string, OptionItem> itemPair
                        = new KeyValuePair<string, OptionItem>(itemKey, selectedItem.items[itemKey]);
                    ret.Add(itemPair);
                }

            }

            return ret;
        }

        public List<KeyValuePair<string, OptionItem>> getDatabaseCategories() {
            List<KeyValuePair<string, OptionItem>> ret = new List<KeyValuePair<string, OptionItem>>();
            foreach (string optionItem in this.options.Keys) // only for root
            {
                Dictionary<string, OptionItem> items = options[optionItem].items;
                foreach (string item in items.Keys)
                {
                    if (item.StartsWith("DatabaseCategory"))
                    {
                        KeyValuePair<string, OptionItem> itemPair
                            = new KeyValuePair<string, OptionItem>(item, items[item]);
                        ret.Add(itemPair);
                    }
                }
            }
            
            return ret;
        }






    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Data;

namespace Chapter2ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. QueryContacts();
            
            // 2. LINQ to Entities Query
            //QueryLINQ();
            
            // 3. Querying with Object Services by Entity Query
            //QueryEntityQuery();
            
            // 4. Querying with Lambda Expression
            //QueryLambda();

            // 5. Querying by using EntityClient
            QueryEntityClient();
        }

        private static void QueryEntityClient()
        {
            using(EntityConnection conn = new EntityConnection(
                    "name=SampleEntities"))
            {
                conn.Open();

                var query = "SELECT VALUE c " +
                            "FROM SampleEntities.Contacts AS c " +
                            "WHERE c.FirstName = 'Robert'";

                EntityCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                using(EntityDataReader reader = cmd.ExecuteReader(
                        CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        var firstname = reader.GetString(1);
                        var lastname = reader.GetString(2);
                        var title = reader.GetString(3);
                        Console.WriteLine("{0} {1} {2}", title.Trim(), firstname.Trim(), lastname);

                    }
                }
                conn.Close();
            }
        }

        private static void QueryLambda()
        {
            var context = new SampleEntities();
            var contacts = context.Contacts
                          .Where(c => c.FirstName == "Robert");
            foreach (var contact in contacts)
            {
                Console.WriteLine("{0} {1}", contact.FirstName.Trim(), contact.LastName);
            }

        }

        private static void QueryEntityQuery()
        {
            var context = new SampleEntities();
            var query = "SELECT VALUE c " +
                        "FROM SampleEntities.Contacts AS c " +
                        "WHERE c.FirstName = 'Robert'";

            ObjectQuery<Contact> contacts = context.CreateQuery<Contact>(query);
            foreach (var contact in contacts)
            {
                Console.WriteLine("{0} {1}", contact.FirstName.Trim(), contact.LastName);
            }
        }

        private static void QueryLINQ()
        {
            var context = new SampleEntities();
            var contacts = from c in context.Contacts
                           where c.FirstName == "Robert"
                           select c;
            foreach (var contact in contacts)
            {
                Console.WriteLine("{0} {1}", contact.FirstName.Trim(), contact.LastName);
            }

        }

        private static void QueryContacts()
        {
            using (var context = new SampleEntities())
            {
                var contacts = context.Contacts;
                foreach (var contact in contacts)
                {
                    Console.WriteLine("{0} {1}", contact.FirstName.Trim(), contact.LastName);
                }
            }
        }
    }
}

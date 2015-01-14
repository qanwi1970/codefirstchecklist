using System;
using System.Linq;
using CodeFirstChecklist.DAL;
using CodeFirstChecklist.Models;

namespace CodeFirstChecklist
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CodeFirstContext())
            {
                Console.WriteLine("Records already in table: {0}", db.Customers.Count());

                if (args.Length > 0)
                {
                    var fname = args[0];
                    var lname = args.Length > 1 ? args[1] : "Smith";
                    var age = args.Length > 2 ? Int32.Parse(args[2]) : new Random().Next(100);

                    var customerToAdd = new Customer
                    {
                        FirstName = fname,
                        LastName = lname,
                        Age = age
                    };

                    db.Customers.Add(customerToAdd);

                    db.SaveChanges();

                    var customerId = customerToAdd.Id;

                    var addedCustomer = db.Customers.First(c => c.Id == customerId);

                    Console.WriteLine("Customer added: {0}\t{1}\t{2}\t{3}", addedCustomer.Id, addedCustomer.FirstName,
                        addedCustomer.LastName, addedCustomer.Age);
                }

                Console.WriteLine("All done. Press a key...");
                Console.ReadKey();
            }
        }
    }
}

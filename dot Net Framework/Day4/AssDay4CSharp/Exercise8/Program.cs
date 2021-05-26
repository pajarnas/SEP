using System;
using System.Collections.Generic;
using System.Linq;
namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void Query()
        {
            foreach (var c in CreateCustomers())
            {
                var customerStores = new            //Anonymous Type Creation:
                {                                   //Mouse over the var in this
                    /*CustomerID = c.CustomerID,      //statement to see the type
                    City = c.City,
                    CustomerName = c.Name,
                    Stores = from s in CreateStores()
                             where s.City == c.City
                             select s*/

                     c.CustomerID,      //statement to see the type
                     c.City,
                    CustomerName=c.Name,
                    Stores = from s in CreateStores()
                             where s.City == c.City
                             select s
                };

                Console.WriteLine("{0}\t{1}",
              customerStores.City, customerStores.CustomerName);

                foreach (var store in customerStores.Stores)
                    Console.WriteLine("\t<{0}>", store.Name);
            }
        }
        static List<Customer> CreateCustomers()
        {
            return new List<Customer>
                {
                    new Customer(1) { Name = "Maria Anders",     City = "Berlin"    },
                    new Customer(2) { Name = "Laurence Lebihan", City = "Marseille" },
                    new Customer(3) { Name = "Elizabeth Brown",  City = "London"    },
                    new Customer(4) { Name = "Ann Devon",        City = "London"    },
                    new Customer(5) { Name = "Paolo Accorti",    City = "Torino"    },
                    new Customer(6) { Name = "Fran Wilson",      City = "Portland"  },
                    new Customer(7) { Name = "Simon Crowther",   City = "London"    },
                    new Customer(8) { Name = "Liz Nixon",        City = "Portland"  }

                };
        }

        static List<Store> CreateStores()
        {
            return new List<Store>
                    {
                            new Store { Name = "Jim’s Hardware",    City = "Berlin" },
                            new Store { Name = "John’s Books",  City = "London" },
                            new Store { Name = "Lisa’s Flowers",    City = "Torino" },
                            new Store { Name = "Dana’s Hardware",   City = "London" },
                            new Store { Name = "Tim’s Pets",    City = "Portland" },
                            new Store { Name = "Scott’s Books",     City = "London" },
                            new Store { Name = "Paula’s Cafe",  City = "Marseille" },
                    };
        }
    }
}

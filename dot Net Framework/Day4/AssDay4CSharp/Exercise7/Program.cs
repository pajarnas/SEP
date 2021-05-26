using System;
using System.Collections.Generic;
using System.Linq;
namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void Query()
        {
            var stores = CreateStores();
            IEnumerable<Store> results = from s in stores
                                         where s.City == "London"
                                         select s;
            foreach (var s in results)
            {
                Console.WriteLine(s);
            }
        }

        static void Query2()
        {
            var stores = CreateStores();
            var numLondon = stores.Count(s => s.City == "London");
            Console.WriteLine("There are {0} stores in London. ", numLondon);

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

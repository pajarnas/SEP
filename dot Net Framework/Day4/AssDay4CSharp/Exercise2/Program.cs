using System;
using System.Collections.Generic;

namespace Exercise2_3_4_5
{

   
    class Program
    {
        static void Main(string[] args)
        {
            

            var customers = CreateCustomers();
            var customerDictionary = new Dictionary<Customer, string>();
            foreach(var c in customers)
            {
                customerDictionary.Add(c, c.Name.Split(' ')[1]);
            }

            var matches = customerDictionary.FilterBy((customer, lastName) => lastName.StartsWith("A"));

            foreach (var item in matches)
            {
                Console.WriteLine("Matched: "+item);
            }

            /*
            foreach (var c in FindCustomersByCity(customers, "London"))
                Console.WriteLine(c);
            */


            /* Exercise 4
             * 
             * var addedCustomers = new List<Customer>
              {
                  new Customer(9)  { Name = "Paolo Accorti", City = "Torino" },
                  new Customer(10) { Name = "Diego Roel", City = "Madrid" }
              };

              var updatedCustomers = customers.Append(addedCustomers);



              var newCustomer = new Customer(10)
              {
                  Name = "Diego Roel",
                  City = "Madrid"
              };

              foreach (var c in updatedCustomers)
              {
                  if (newCustomer.Compare(c))
                  {
                      Console.WriteLine("The new customer was already in the list");
                      return;
                  }
              }

              Console.WriteLine("The new customer was not in the list");

  */
            /* List<Point> Square = new List<Point>
             {
                 new Point { X=0, Y=5 },
                 new Point { X=5, Y=5 },
                 new Point { X=5, Y=0 },            
                 new Point { X = 0, Y = 0 }
             };
             List<Customer> customers = CreateCustomers();

             Console.WriteLine("Customers:\n");
             foreach (Customer c in customers)
                 Console.WriteLine(c);*/
            // VarTest();

        }

        static void VarTest()
        {

            //Error CS0818  Implicitly - typed variables must be initialized  
            /*var x;
            x = new int[] { 1, 2, 3 };*/
            var x = new [] { 1, 2, 3 };

            //CS0820  Cannot initialize an implicitly-typed variable with an array initializer 
            //var x = { 1, 2, 3 };

            /*An implicit array initialization expression must specify that an array is being created and include new[]. 
             * Also important to note when using implicitly typed local variables, 
             * the initializer cannot be an object or collection initializer by itself.  
             * It can be a new expression that includes an object or collection initializer.*/

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

        public static List<Customer> FindCustomersByCity( List<Customer> customers, string city)
        {
            return customers.FindAll(delegate (Customer c) {return c.City == city;});
        }

        public static List<Customer> FindCustomersByCityLambda(List<Customer> customers,string city) 
        {
            return customers.FindAll(c => c.City == city);
        }


    }

   
}

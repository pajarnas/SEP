using System;

namespace Exercise1
{
    class Program
    {
        public class Customer
        {
            public string CustomerID { get; private set; }
            public string Name { get; set; }
            public string City { get; set; }

            public Customer(int ID)
            {
                CustomerID = ID.ToString();
            }

            public override string ToString()
            {
                return Name + "\t" + City + "\t" + CustomerID;
            }

        }

        static void Main(string[] args)
        {
            Customer c = new Customer(1);
            
            c.Name = "Maria Anders";
            c.City = "Berlin";

            Console.WriteLine(c);

        }
    }
}

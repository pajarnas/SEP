using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise8
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
}

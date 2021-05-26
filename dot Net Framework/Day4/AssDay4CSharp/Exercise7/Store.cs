using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise7
{
    public class Store
    {
        public string Name { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return Name + "\t" + City;
        }
    }

}

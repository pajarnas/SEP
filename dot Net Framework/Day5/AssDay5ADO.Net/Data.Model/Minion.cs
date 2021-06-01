using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Minion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int TownId { get; set; }

        public Town Town { get; set; }
    }
}

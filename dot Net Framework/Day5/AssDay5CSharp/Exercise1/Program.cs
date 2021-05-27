using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
           
                Console.Write("Enter a number =>");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = 1;
            if (a >= 0 && a <= 10)
            {
                Console.Write("{0}", b);
                do
            {
                    b = b << 1;
                    Console.Write(", {0}", b);
                  
                    a--;
            } while (a > 0);
                
                     
                }
                Console.ReadKey();
            
        }
    }

}
   
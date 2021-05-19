using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            String str;
            Console.WriteLine("Enter a string");
           
    
            str = Console.ReadLine();
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine(new string(charArray));
            Console.ReadLine();
        }
    }
}

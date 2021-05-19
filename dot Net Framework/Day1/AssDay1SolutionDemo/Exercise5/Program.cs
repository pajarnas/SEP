using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            int row;
            Console.WriteLine("Enter the Number of Rows:");
            row = Convert.ToInt32(Console.ReadLine());
            int totalCount = 0;
            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((totalCount++ & 1) == 0)
                        Console.Write(1);
                    else
                        Console.Write(0);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

       
        
    }
}

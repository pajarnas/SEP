using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = 0;
            Console.WriteLine("Enter Number of Rows:");
            len = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < len*2+1; i++)
            {
                PrintStars(i, len);
            }
        }
        static void PrintStars(int numberOfLine, int numberOfRows)
        {
            if (numberOfLine > numberOfRows)
                numberOfLine = 2 * numberOfRows - numberOfLine;
            for (int i = 0; i < numberOfRows - numberOfLine; i++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < numberOfLine*2-1; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}

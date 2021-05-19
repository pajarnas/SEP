using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            int big = 0, small = 0, temp = 0;
            Console.WriteLine("Fisrt Number(int)");
            small = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Second Number(int)");
            temp = Convert.ToInt32(Console.ReadLine());
            if (temp < small)
            {
                big = small;
                small = temp;
            }
            else
            {
                big = temp;
            }
            
            findArmstrongNumber(big, small);
            Console.ReadLine();


        }

        static void findArmstrongNumber(int big, int small)
        {
            for (; small < big; small++)
            {
                if (checkArmstrongNumber(small))
                {
                    Console.WriteLine(small);
                }
            }
        }

        static bool checkArmstrongNumber(int n)
        {
            int sum = 0;
            int result = n;
            while (n > 0)
            {
                if (sum > result) return false;
                sum += (int)Math.Pow((double)(n%10),3);
                n /= 10;
            }
            return result == sum;
        }
    }
}

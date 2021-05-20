using System;
using System.Collections;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            Solution s = new Solution();
            s.GetData(ref a, ref b);
            Console.WriteLine("The number of perfect squeares:"+s.FindSolution(a, b));
        }
    }

    class Solution
    {
        public void GetData(ref int a, ref int b)
        {
            Console.WriteLine("Enter the start value");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the end value");
            b = Convert.ToInt32(Console.ReadLine());
        }
        public int FindSolution(int a, int b)
        {
            return (int)Math.Sqrt((double)b) - (int)Math.Sqrt((double)a) + 1;
        }
    }



}

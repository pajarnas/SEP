using System;
using System.Collections;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] a = { 20, 10, 30, 30, 40, 10 };
            Solution s = new Solution();
            s.FindSolution(s.GetData());
        }
    }

    class Solution
    {
        public int [] GetData()
        {
            int size;
            Console.WriteLine("Enter the size of array");
            size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the No.{i+1} value in array");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Done!");
            Console.ReadLine();
            return array;
        }
        public void FindSolution(int[] a)
        {

            Hashtable hashTable = new Hashtable();
            for (int i = 0; i < a.Length; i++)
            {
                if (!hashTable.ContainsKey(a[i]))
                {
                    hashTable.Add(a[i], 0);
                    Console.WriteLine($"Value added for Key = {a[i]} , Value: { hashTable[a[i]]}");
                }
                else
                {
                    
                    hashTable[a[i]] = (int)hashTable[a[i]] + 1;
                    Console.WriteLine($"Value updated for Key = {a[i]} , Value: { hashTable[a[i]]}");
                }
            }
            int max = 0;
            int ptr = a[0];
            ICollection keyColl = hashTable.Keys;
            foreach (int s in keyColl)
            {
                if ((int)hashTable[s] > max)
                {
                    ptr = s;
                }





            }
            Console.WriteLine($"The maxium : {ptr}");
        }
    }



}

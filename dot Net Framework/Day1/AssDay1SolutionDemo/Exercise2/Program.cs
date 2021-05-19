using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            String choice;
            Arithmetic a = new Arithmetic();
            Console.WriteLine("Enter 1:Addition; 2: Subtraction; 3:Multiplication; 4:Division");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    a.Addition();
                    break;
                case "2":
                    a.Subtraction();
                    break;
                case "3":
                    a.Multiplication();
                    break;
                case "4":
                    a.Division();
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
          
          
          
        }
    }

    class Arithmetic
    {
        float a, b;

        public void Addition()
        {
            Console.WriteLine("Enter a");
            a = Convert.ToSingle(Console.ReadLine()); 
            Console.WriteLine("Enter b");
            b = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("a + b = " + Convert.ToString(a+b));
            Console.ReadLine();
        }

        public void Subtraction()
        {
            Console.WriteLine("Enter a");
            a = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter b");
            b = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("a - b = " + Convert.ToString(a - b));
            Console.ReadLine();
        }

        public void Multiplication()
        {
            Console.WriteLine("Enter a");
            a = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter b");
            b = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("a × b = " + Convert.ToString(a * b));
            Console.ReadLine();
        }

        public void Division()
        {
            Console.WriteLine("Enter a");
            a = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter b");
            b = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("a ÷ b = " + Convert.ToString(a / b));
            Console.ReadLine();
        }
    }
}

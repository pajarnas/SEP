using System;

namespace DemoTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.GetData();
            s1.DisplayData();
            Console.ReadKey();
        }
    }

    public class Student
    {
        string Name, Address;
        int Mobile;

        public void GetData()
        {
            Console.WriteLine("Enter your name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your address");
            Address = Console.ReadLine();
            Console.WriteLine("Enter your mobile number");
            Mobile = Convert.ToInt32(Console.ReadLine());
        }

        public void DisplayData()
        {
            Console.WriteLine("Student Name:" + Name);
            Console.WriteLine("Student Address:" + Address);
            Console.WriteLine("Student Mobile:" + Mobile);
        }
    }
}

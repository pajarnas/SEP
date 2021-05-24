using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.GetData();
            Calculate(r);
            Circle c = new Circle();
            c.GetData();
            Calculate(c);
        }

        public static void Calculate(Shape1 S)
        {

            Console.WriteLine("Area : {0}", S.Area());
            Console.WriteLine("Circumference : {0}", S.Circumference());

        }

    }
}

using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.GetData();
            r.Display();
            Console.ReadLine();
        }
    }

    class Rectangle
    {
        double Length = 1;
        double Width = 1;

        public void GetData()
        {
        again:
            Console.WriteLine("Enter length:");
            Length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter width:");
            Width = Convert.ToDouble(Console.ReadLine());
            if (Length < 0 || Length > 20|| Width < 0 || Width > 20)
            {
                Console.WriteLine("Please enter length and width between 0 and 20");
                goto again;
            }
        }

        public double GetArea()
        {
            return Length * Width;
        }
        public double GetPerimeter()
        {
            return 2 * (Length + Width);
        }

        public void Display()
        {
            Console.WriteLine("Length:" + Length);
            Console.WriteLine("Width:" + Width);
            Console.WriteLine("Area:" + this.GetArea());
            Console.WriteLine("Perimeter:" + this.GetPerimeter());
        }

    }
}

using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box();
            box1.setBreadth(12);
            box1.setLength(23);
            box1.setHeight(24);
            box1.Display("Box1");
            Box box2 = new Box(12,3,44);
            box2.Display("Box2");
            Box box3 = new Box(121, 33, 444);
            box3.Display("Box3");

        }


    }

    class Box
    {
        private double Length;
        private double Breadth;
        private double Height;

        public void Display(string name)
        {
            Console.WriteLine($"Volume of {name}: {getVolume()}");
        }
        public Box(double len, double bre, double hei)
        {
            Length = len;
            Breadth = bre;
            Height = hei;
        }

        public Box()
        {
            
        }
        public double getVolume()
        {
            return Length * Breadth * Height;
        }
        public void setLength(double len)
        {
            Length = len;
        }

        public void setBreadth(double bre)
        {
            Breadth = bre;
        }

        public void setHeight(double hei)
        {
            Height = hei;
        }


    }
}

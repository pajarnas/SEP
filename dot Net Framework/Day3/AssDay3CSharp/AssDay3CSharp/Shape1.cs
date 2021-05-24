using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise1
{
    abstract class Shape1
    {
        protected float Radius, Length, Breadth;

        //Abstract methods can have only declarations
        public abstract float Area();
        public abstract float Circumference();

        public abstract void GetData();


    }

    class Rectangle  : Shape1
    {
        public override float Area()
        {
            return Length * Breadth;
        }

        public override float Circumference()
        {
            return 2 * Length * Breadth;
        }

        public override void GetData()
        {
            Console.WriteLine("Enter Breadth:");
            Breadth = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter Length:");
            Length = Convert.ToSingle(Console.ReadLine());

        }

     
    }

    class Circle : Shape1
    {
        private static double PI = 3.1415926;
        public override float Area()
        {
            return (float)PI * Radius * Radius;
        }

        public override float Circumference()
        {
            return (float)PI * 2 * Radius;
        }

        public override void GetData()
        {
            Console.WriteLine("Enter Radius:");
            Radius = Convert.ToSingle(Console.ReadLine());
          

        }

       
    }

}

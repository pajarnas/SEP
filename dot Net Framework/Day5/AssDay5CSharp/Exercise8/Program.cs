using System;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class A
    {
        int X;
        public virtual void f(int n) { }
        public virtual void g(uint n)
        {
            X = (int)n;
        }
        public override string ToString()
        {
            return X.ToString();
        }
}

}

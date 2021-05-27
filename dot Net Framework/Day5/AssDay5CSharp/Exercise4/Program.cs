using System;
class A
{
    static int n =1;
    public void f()
    {
        n++;
    }
    public void Report()
    {
        Console.WriteLine(n.ToString());
    }
}
class Mainclass
{
    [STAThread]
    static void Main (string[]  args)
              {
        A x = new A(), y = new A();
        x.f();
        x.Report();
        y.f();
        y.Report();
    }
}

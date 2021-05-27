using System;

namespace Exercise3 { 
class Mainclass
{
    static  void f(string s)
    {
        s += "world";
    }
    [STAThread]
    static void Main (string[] args)
    {
        string s = "Hello";
        f(s);
        Console.WriteLine(s);
    }
}
}
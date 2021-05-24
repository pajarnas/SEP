using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Greeting();
            Student s = new Student(21, "Smith");
            s.Greeting();
            s.GoToClasses();
            s.ShowAge();
            Teacher t = new Teacher(30, "John", "Science");
            t.Greeting();
            t.Explain();

        }
    }
}

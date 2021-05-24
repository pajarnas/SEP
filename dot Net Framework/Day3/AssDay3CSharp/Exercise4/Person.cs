using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise4
{
    public class Person
    {
        private string Name { get; set; }

        private int Age { get; set; }

        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }

        public Person( )
        {
            
        }

        public void Greeting()
        {
            Console.WriteLine("Hello!");
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetAge(int age)
        {
            Age = age;
        }

        public int GetAge()
        {
            {
                return Age;
            }
        }
    }

        public class Teacher : Person
        {
            private string Subject { get; set; }

            public Teacher(int age, string name, string subject)
                :base(age,name)
        {
            Subject = subject;
        }
            public string GetSubject()
            {
                return Subject;
            }

            public void SetSubject(string subject)
            {
                Subject = subject;
            }
            public void Explain()
            {
                Console.WriteLine("Explanation begins" + Subject);
            }
        }

        public class Student : Person
        {
        public Student(int age, string name)
                : base(age, name)
        {
            
        }

        public void GoToClasses()
                {
                    Console.WriteLine("I am going to class ");
                }

                public void ShowAge()
                {
                    Console.WriteLine("My age is: " + base.GetAge() + "years old");
                }


        }
    
}


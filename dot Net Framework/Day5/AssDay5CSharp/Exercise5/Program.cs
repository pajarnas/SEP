using System;
namespace Exercise5
{
    public class MyClass
    {
        public delegate void LogHandler(string message);
        public void Process(LogHandler logHandler)
        {
            if (logHandler != null)
            {
                logHandler("begin");
            }
            if (logHandler != null)
            {
                logHandler("End");
            }
        }
        public class MyLogger
        {
            public void Logger(string s)
            {
                Console.WriteLine(s);
            }
        }
        public class TestApplication
        {
            static void Logger(string s)
            {
                Console.WriteLine(s);
            }
            static void Main(string[] args)
            {
                //Multicasting of a Delegate
                MyLogger myLogger = new MyLogger();
                MyClass myClass = new MyClass();
                MyClass.LogHandler logHandler = null;
                logHandler += new MyClass.LogHandler(Logger);
                logHandler += new MyClass.LogHandler(myLogger.Logger);
                myClass.Process(logHandler);
                return;
            }
        }
    }
}

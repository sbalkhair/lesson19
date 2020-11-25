using System;
using System.IO;

namespace lesson19
{
    interface ILogger
    {
        void Print(string message);
    }
    class FileLogger : ILogger
    {
        public void Print(string message)
        {
            var stream = new StreamWriter("/Users/sbalkhair/Desktop/nona.txt");
            stream.WriteLine(message);
            stream.Close();
        }
    }
    class ConsoleLogger : ILogger
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Master
    {
        private readonly ILogger logger;

        public Master(ILogger logger)
        {
            this.logger = logger;
        }
        public void DoSomeThing(string message)
        {
            logger.Print(message);
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            var obj = new Master(new ConsoleLogger());
            obj.DoSomeThing(DateTime.Now.ToShortDateString());
            Console.ReadKey();
        }

    }



}

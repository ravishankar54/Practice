using System;
using System.Diagnostics;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new DelegateDemo();
            demo._write = (x) => Console.WriteLine(x.ToLower());
            demo._write("MAIN TEST");
            demo._write.Invoke("CHILD TEST");
            Console.ReadLine();
        }

        public static void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class DelegateDemo
    {
        //WriteMessage _write;
        public WriteMessage _write;
        public DelegateDemo()
        {
            //DebugWindowLogger log1 = new DebugWindowLogger();
            //BetterDebugWindowLogger log2 = new BetterDebugWindowLogger();
            //_write = new WriteMessage(log1.SendMessage);
            //_write += log2.SendMessage;
        }
        public WriteMessage _write2;

        public void DoWork()
        {
            var invk = new WriteMessage(new BetterDebugWindowLogger().SendMessage);

            //_write("Delegate Testing");
        }
    }

    public delegate void WriteMessage(string message);

    public class DebugWindowLogger
    {
        public void SendMessage(string message)
        {
            Debug.WriteLine(message);
        }
    }

    public class BetterDebugWindowLogger
    {
        public void SendMessage(string message)
        {
            Debug.WriteLine(message + " better ");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoAsyncAndAwait
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var task = Task.Factory.StartNew<int>(SlowOperation);
            var taskAsync = SlowOperationAsync();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Slow operation result on: {0}", task.Result);
            Console.WriteLine("Async Slow operation result on: {0}", taskAsync.Result);
            Console.WriteLine("Main compeleted on {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        static int SlowOperation()
        {
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.SpinWait(2000);
            Console.WriteLine("Slow operation compeleted on {0}", Thread.CurrentThread.ManagedThreadId);
            return 42;
        }
        static async Task<int> SlowOperationAsync()
        {
            Console.WriteLine("Async Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            Console.WriteLine("Async Slow operation completed on {0}", Thread.CurrentThread.ManagedThreadId);
            return 42;
        }
    }
}

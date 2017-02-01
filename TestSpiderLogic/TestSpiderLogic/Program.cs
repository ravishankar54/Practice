using System;

namespace TestSpiderLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] p1 = { 5, 3, 10, 15 };
            int p2 = 2;
            int p3 = 20;
            for (var i = p2; i <= p3; i++)
            {
                bool exists = false;
                for (var j = 0; j < 4; j++)//p1.Length in place of 4
                {
                    if (p1[j] == i)
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
    }
}

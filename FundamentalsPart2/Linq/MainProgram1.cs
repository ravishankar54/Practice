using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using static System.Console;
namespace Linq
{
    class MainProgram1
    {

        static void Main(string[] args)
        {
            IEnumerable<string> cities = new[] { "Bangalore", "Belgam", "Bellary", "Vishakhapatnam" };
            foreach (var city in cities)
            {
                //Console.WriteLine(city);
            }
            IEnumerable<string> result = cities.StringThatStartsWith("L");
            foreach (var city in result)
            {
                //WriteLine(city);
            }

            //IEnumerable<string> genericresult = cities.Filter<string>(StringThatStartsWithB);
            //IEnumerable<string> genericresult = cities.Filter<string>(
            //                                                            delegate (string item)
            //                                                        {
            //                                                            return item.StartsWith("V");
            //                                                        });

            IEnumerable<string> genericresult = cities.Filter(item => item.StartsWith("V"));

            foreach (var city in genericresult)
            {
                //WriteLine(city);
            }
            IEnumerable<string> genericresultFunc = cities.FilterFunc(item => item.StartsWith("V"));

            foreach (var city in genericresult)
            {
                //WriteLine(city);
            }
            IEnumerable<string> linqResult = cities.Where(city => city.StartsWith("B"))
                                                    .OrderByDescending(city => city.Length);

            foreach (var city in linqResult)
            {
                WriteLine(city);
            }
            //DateExtension();
            //FuncDemo();
            ReadLine();
        }


        public static void FuncDemo()
        {
            Func<int, int> square = (x) => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Func<int, int, int> subtract = (x, y) => x - y;

            Action write = () => WriteLine();
            Action<int> writesubtract = x => WriteLine(x);
            Action<int, int> writeDetailDemo = (x, y) => Print(Step1Subtract(x, y));

            WriteLine(square(7));
            WriteLine(add(4, 5));

            writesubtract(subtract(39, 10));
            writesubtract.Invoke(subtract(32, 10));
            writeDetailDemo(1905, 35);
            writeDetailDemo.Invoke(45, 35);
        }

        private static int Step1Subtract(int a, int b)
        {
            return a - b;
        }

        private static void Print(int a)
        {
            WriteLine(a);
        }


        static bool StringThatStartsWithB(string str)
        {
            return str.StartsWith("B");
        }

        private static void DateExtension()
        {
            DateTime date = new DateTime(2002, 8, 9);
            int daysStillInMonth = date.DaysToEndOfMonth();
            WriteLine(daysStillInMonth);
        }
    }
    public static class DateUtilites
    {
        public static int DaysToEndOfMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
        }
    }
}

using System;
using System.Linq;
using ExamTest.TestPerson;
using static ExamTest.Vehicle;

namespace ExamTest
{
    class Program1
    {
        public static void Main(string[] args)
        {
            //Base b = new Base();
            //Derived d = new Derived();
            //Base b1 = new Derived();
            //b.Method();
            //d.Method();
            //b1.Method();
            //b.Method1();
            //d.Method1();
            //b1.Method1();
            //var test = new PersonTest();
            //test.Test1();
            //test.Test2();
            //test.Test3();
            //test.Test4();
            // DynamicTest1();
            //DynamicTest3();
            //DynamicTest4();
            TestCar();
            Console.ReadKey();
        }

        static void Main1(string[] args)
        {

            string str = "Test the Thast";
            Console.WriteLine(str.Replace("T", "?"));
            Console.ReadKey();

            string input = "5#9#6#4#6#8#0#7#1#5#9";

            if (!ValidateString(input)) return;

            var arrayStr = input.Split('#');
            var lines = ValidateCount(arrayStr.Length * 2);
            int j = 0;
            int sum = 0;
            if (lines != 0)
            {
                for (int i = 0; i < lines; i++)
                {
                    var star = string.Empty;
                    int k = i;
                    var newarray = new int[i + 1];
                    while (k <= i && k > -1)
                    {
                        newarray[k] = Convert.ToInt32(arrayStr[j]);
                        star += arrayStr[j] + " ";
                        k--;
                        j++;
                    }

                    sum += newarray.Max();
                    Console.WriteLine(star + "Largest number in the line :" + newarray.Max());
                    Console.WriteLine("\n");
                }
            }
            Console.WriteLine("{0}", (sum == 0 ? "invalid input" : "Total sum: " + sum.ToString()));
            Console.ReadKey();
        }

        private static int ValidateCount(int count)
        {
            int i = 0;
            int sum = 0;
            while (true)
            {
                sum = (i) * (i + 1);
                if (sum == count)
                {
                    break;
                }
                if (sum > count)
                {
                    i = 0;
                    break;
                }
                i++;
            }
            return i;
        }
        private static bool ValidateString(string input)
        {
            if (input.Contains("##"))
            {
                return false;
            }
            return true;
        }

        public static void DynamicTest1()
        {
            dynamic obj = new { City = 1 };
            obj.City = "New York";
            Console.WriteLine(obj.City);
        }

        public static void DynamicTest2()
        {
            //dynamic obj = new dynamic();
            //obj.City = "New York";
            // Console.WriteLine(obj.City);
        }

        public static void DynamicTest3()
        {
            dynamic obj = new System.Dynamic.ExpandoObject();
            obj.City = 1;
            obj.City = "New York";
            Console.WriteLine(obj.City);
        }

        public static void DynamicTest4()
        {
            var obj = new { City = "New York" };
            Console.WriteLine(obj.City);
        }

        public static void TestCar()
        {
            var car = new Car(200, "Manual");
            Console.WriteLine(string.Format("Max Speed is {0}, Country is {1} ", car.MaxSpeed, Vehicle.Country));
        }
    }
}

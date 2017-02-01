using System;
using static ExamTest.Vehicle;

namespace ExamTest
{
    class Program1
    {
        public static void Main(string[] args)
        {
            Derived dp = new Derived(10);

            //Base b = new Base();
            //Derived d = new Derived();
            //Base bd = new Derived();

            //b.Method();
            //b.Method1();

            //d.Method();
            //d.Method1();

            //bd.Method();
            //bd.Method1();

            //var test = new PersonTest();
            //test.Test1();
            //test.Test2();
            //test.Test3();
            //test.Test4();
            //DynamicTest1();
            //DynamicTest3();
            //DynamicTest4();
            //TestCar();
            Console.ReadKey();
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
            //Console.WriteLine(obj.City);
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

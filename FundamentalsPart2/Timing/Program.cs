using System;
using System.Diagnostics;

namespace Timing
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = new Hello3 { TestStr = "40" };

            TestStrignReferenceType tstr = new TestStrignReferenceType();
            tstr.Str(str);

            Console.WriteLine(str.TestStr);
            Console.ReadLine();

            //StaticTest.MyPropertyStatic = 10;
            //StaticTest obj = new StaticTest();
            //obj.MyPropertyNonStatic = 20;
            //StaticTest obj2 = new StaticTest();
            //obj.MyPropertyNonStatic = 30;
            //StaticTest.MyPropertyStatic = 29;

            //int a = 20;
            //int* b = &a;
            //SeniroEmployee semp = new SeniroEmployee();

            //semp.Method(10);//base
            //semp.Method("ss");//child
            //semp.Method2(1, "");// child

            //SeniroEmployee emp = new Employee() as SeniroEmployee;

            //emp.Method(1);
            //emp.Method2(2, "234");
            //AbTest test = new GeneralClass();

            // Employee semp = new SeniroEmployee();

            //semp.Method4();
        }



        private static void TimmerDemo()
        {
            var timmer = new Timmer();
            var result = timmer.Mesasure(() => { });

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

    public class Timmer
    {
        public TimeSpan Mesasure(Action action)
        {
            var watch = new Stopwatch();
            watch.Start();
            action();
            return watch.Elapsed;
        }
    }

    public class Employee
    {
        public Employee()
        {

        }

        public Employee(int a, string str)
        {

        }

        public Employee(string str, int a)
        {

        }

        public Employee(int a)
        {

        }
        public Employee(string str)
        {

        }

        public void Method(int a)
        {

        }

        public virtual void Method2(int a, string dtr)
        {

        }

        public virtual void Method3(string dtr, int a)
        {

        }

        public virtual void Method4()
        {

        }
    }

    public class SeniroEmployee : Employee
    {
        public void Method(string a)
        {

        }

        public override void Method2(int a, string dtr)
        {

        }

        public virtual void Method3(int a, string str)
        {

        }

        public override void Method4()
        {

        }
    }

    internal class Test
    {
        private class Hello
        {

        }

        protected class Hello1
        {

        }

        protected internal class Hello2
        {

        }

        public class Hello3
        {

        }
    }

    public abstract partial class AbTest
    {

    }

    public abstract partial class AbTest
    {

    }

    public partial class AbTest
    {

    }

    public class GeneralClass : AbTest
    {

    }

    public class StaticTest
    {
        public static int MyPropertyStatic { get; set; }

        public int MyPropertyNonStatic { get; set; }
    }

    public class TestStrignReferenceType
    {
        public void Str(Hello3 s)
        {
            s.TestStr = "123";
        }
    }
    //public static delegate void WriteMessage(string msg); // not possible
    public delegate void WriteMessage1(string msg);
    public class Hello3
    {


        public string TestStr { get; set; }
    }
}


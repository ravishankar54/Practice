using System;
namespace ExamTest
{
    public class Base
    {
        public Base()
        {
            Console.WriteLine("Base : Default Construtor");
        }
        public Base(int a)
        {
            Console.WriteLine("Base : Parameter Construtor: " + a);
        }
        public virtual void Method()
        {
            Console.WriteLine("Base : Method");
        }

        public virtual void Method1()
        {
            Console.WriteLine("Base : Method1");
        }
    }
}

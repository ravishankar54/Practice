using System;
namespace ExamTest
{
    public class Derived : Base
    {
        public override void Method()
        {
            Console.WriteLine("Derived : Method");
        }

        public virtual new void Method1()
        {
            Console.WriteLine("Dervied : Method1");
        }
    }
}

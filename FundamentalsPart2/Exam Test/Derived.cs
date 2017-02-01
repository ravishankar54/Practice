using System;
namespace ExamTest
{
    public class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("Derived : Default Construtor");
        }
        public Derived(int a) : base(a)
        {
            Console.WriteLine("Derived : Parameter Construtor: " + a);
        }
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

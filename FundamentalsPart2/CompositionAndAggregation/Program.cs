using System;

namespace CompositionAndAggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            //    Employee emp = new Employee("Dummy", "Dummy Street", "Dummy City", "Dumm State", "Dummy code");

            ConcerteClass ob = new ConcerteClass();
            ob.Method();
        }
    }

    public abstract class AbstractDemo
    {
        public abstract void Method();
        public void Method1()
        {

        }

    }
    public interface IInterFaceDemo
    {
        void Method();
    }
    public interface IInterFaceDemo1
    {
        void Method();
    }
    public class ConcerteBaseClass : IInterFaceDemo
    {
        public void Method()
        {
            throw new NotImplementedException();
        }
    }
    public class ConcerteClass : IInterFaceDemo, IInterFaceDemo1
    {
        public virtual void Method()
        {

        }

        void IInterFaceDemo.Method()
        {

        }
        void IInterFaceDemo1.Method()
        {

        }
    }
}

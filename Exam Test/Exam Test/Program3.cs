using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest
{
    public class Program3
    {
        static void Main(string[] args)
        {
            var person = new Person4 { Name = "Mike" };
            person.SaySomething();
        }
    }
    public class Person4
    {
        public string Name { get; set; }

        internal void SaySomething()
        {
            throw new NotImplementedException();
        }
    }

    public class Abstract1
    {

    }
    public class Abstract2
    {

    }

    public class Abstract3 : Abstract2
    {

    }

    public class DeriveClass : Abstract1, Abstract2
    {

    }

    public interface InterFace : Abstract1
    {

    }
    public interface InterFace1
    {

    }
    public interface InterFace2
    {

    }
    public interface InterFace3
    {

    }
    public class DerivedClass1 : DeriveClass, InterFace1, InterFace2, InterFace3
    {

    }
}

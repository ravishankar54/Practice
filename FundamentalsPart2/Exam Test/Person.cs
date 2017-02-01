using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTest
{
    public class Person
    {
        string Name { get; set; }
    }

    public class Group<T> where T : Person
    {
        List<T> Members { get; set; }
    }

    public interface IPerson
    {
        string Name { get; set; }
    }

    public interface IGroup<T> where T : class, IPerson, new()
    {
        List<T> Members { get; set; }
    }

    public struct Person1
    {
        string Name { get; set; }
    }

    public struct Group1<T>
    {
        List<T> Members { get; set; }
    }

    public struct Person2
    {
        string Name { get; set; }
    }

    //public struct Group3<T> where T: Person2
    //{
    //    List<T> Members { get; set; }
    //}
}

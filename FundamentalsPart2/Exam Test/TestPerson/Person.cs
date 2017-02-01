using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamTest.TestPerson
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class PersonTest
    {
        public void Test1()
        {
            var persons = new List<Person>
            {
                new Person {Name="Ravi" },
                new Person {Name="Shankar" },
            };

            var somebody = persons[0];
            somebody.Name = "Boyina";
            Console.WriteLine("Test1 : " + string.Join(" and ", persons.Select(p => p.Name)));
        }

        public void Test2()
        {
            var persons = new List<Person>
            {
                new Person {Name="Bhanu" },
                new Person {Name="Shankar" },
            };

            var team = persons;
            persons[0].Name = "Ravi";
            Console.WriteLine("Test2 : " + string.Join(" and ", team.Select(p => p.Name)));
        }

        public void Test3()
        {
            var persons = new List<Person>
            {
                new Person {Name="Ravi" },
                new Person {Name="Shankar" },
            };

            var ravi = persons[0];
            var shankar = persons[1];
            persons = null;
            Console.WriteLine("Test3 : " + ravi.Name + " and " + shankar.Name);
        }

        public void Test4()
        {
            var persons = new List<Person>
            {
                new Person {Name="Boyina" },
                new Person {Name="Ravi" },
                new Person {Name="Shankar" }
            };

            var team = persons;
            team.RemoveAt(0);
            Console.WriteLine("Test4 : " + string.Join(" and ", team.Select(p => p.Name)));
        }
    }
}

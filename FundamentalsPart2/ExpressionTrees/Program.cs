using System;
using System.Collections.Generic;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter column name to sort:"); // Prompt
            string sortByProp = Console.ReadLine(); // Get string from user
            List<Person> sortedList = null;
            Person p1 = new Person { Name = "Dhoni", Age = 36, JoiningDate = DateTime.Parse("2002-06-06") };
            Person p2 = new Person { Name = "Sachin", Age = 40, JoiningDate = DateTime.Parse("1988-04-23") };
            Person p3 = new Person { Name = "Dravid", Age = 38, JoiningDate = DateTime.Parse("1999-02-17") };

            List<Person> persons = new List<Person>();
            persons.Add(p1);
            persons.Add(p2);
            persons.Add(p3);

            Type sortByPropType = typeof(Person).GetProperty(sortByProp).PropertyType;

            //ParameterExpression pe = Expression.Parameter(typeof(Person), "p");
            //var expr = Expression.Lambda(Expression.Property(pe, sortByProp), pe);

            //IQueryable<Person> query = persons.AsQueryable();

            //MethodInfo orderByMethodInfo =
            //typeof(Queryable).GetMethods(BindingFlags.Public | BindingFlags.Static)
            //        .Single(mi => mi.Name == "OrderBy"
            //        && mi.IsGenericMethodDefinition
            //        && mi.GetGenericArguments().Length == 2
            //        && mi.GetParameters().Length == 2
            //);

            //sortedList =
            //    (orderByMethodInfo.MakeGenericMethod(new Type[]
            //    { typeof(Person), sortByPropType }).Invoke(query,
            //    new object[] { query, expr }) as
            //    IOrderedQueryable<Person>).ToList();

            sortedList = typeof(MyExtensions).GetMethod("CustomSort").
               MakeGenericMethod(new Type[] { typeof(Person), sortByPropType }).
               Invoke(persons, new object[] { persons, sortByProp, "asc" }) as List<Person>;

            //sortedList = persons.CustomSort<Person, int>(sortByProp, "desc");
        }
    }
}

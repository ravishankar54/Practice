using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ExamTest
{
    public class Program
    {
        delegate void Test(int i);
        delegate void Test1(int j);
        static void F1(Test t) { }
        static void F2(Test1 t) { }
        static void Main(string[] args)
        {
            //var list = new[] {"A","B","C","D","E","F" };
            //var half = list.Where(t => indexOf(t) < 3).ToList();

            var list = Enumerable.Range(1, 100).ToList();
            list.ForEach(DoSomething(i => i));
            using (var dc = new MyDataContext())
            {
                IQueryable<Employee> onlyMikeQuery = from p in dc.Employees.Where(GetOnlyMikes()) select p;
            }

            var emp = new Employee { Name = "Ravi" };
            var verifyIfPersonIsMike = GetVerifyingDelegate();
            bool personIsMike = verifyIfPersonIsMike(emp);
            //var list = new[] { "A", "B", "C", "D", "E", "F" };
            //var half = list.Where((t, i) => i < 3).ToList();
            //half.ForEach(i => Console.WriteLine(i));
            Console.ReadKey();

            using (var dc = new MyDataContext())
            {
                var inovices = (from i in dc.Employees.Where(i => i.EmpId > 5)
                                join c in dc.Customers on i.EmpId equals c.CustId
                                select new { i.EmpId, c.Name }).ToList();

            }
        }

        private static Func<Employee, bool> GetVerifyingDelegate()
        {
            throw new NotImplementedException();
        }

        private static Expression<Func<Employee, bool>> GetOnlyMikes()
        {
            throw new NotImplementedException();
        }

        private static Action<int> DoSomething(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        private static Predicate<int> DoSomething(Expression<Func<Employee, bool>> p)
        {
            throw new NotImplementedException();
        }
        private static void DoSomething(int i)
        {
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public int EmpId { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public int CustId { get; set; }
    }
    public class MyDataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}

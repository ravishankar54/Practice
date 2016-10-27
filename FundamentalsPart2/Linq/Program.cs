using System;
using System.Linq.Expressions;
using Linq.DataAccess;
using static System.Console;
namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //SeedDataIntoDB();
            using (MoviesDB context = new MoviesDB())
            {
                //var result = context.Movies.Where(movie => movie.Title.StartsWith("O"))
                //            .OrderByDescending(year => year.ReleaseDate.Year)
                //            .ToList();

                //foreach (var movie in result)
                //{
                //    WriteLine(movie.Title);
                //}
            }
            FuncDemo();
            ReadLine();
        }

        private static void SeedDataIntoDB()
        {
            using (MoviesDB context = new MoviesDB())
            {
                //seed movies data
                context.Movies.Add(new Movie { Title = "Okadu", ReleaseDate = new System.DateTime(2003, 4, 30) });
                context.Movies.Add(new Movie() { Title = "Pokiri", ReleaseDate = new System.DateTime(2006, 7, 25) });
                context.Movies.Add(new Movie() { Title = "Agadu", ReleaseDate = new System.DateTime(2012, 10, 9) });

                //seed revivie data
                context.Reviews.Add(new Review { Rating = 4, ReviewerName = "TOI" });
                context.Reviews.Add(new Review { Rating = 5, ReviewerName = "HINDU" });
                context.Reviews.Add(new Review { Rating = 3, ReviewerName = "DC" });

                //seed videos data

                context.SaveChanges();
            }
        }
        public static void FuncDemo()
        {
            Expression<Func<int, int>> square = (x) => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Func<int, int, int> subtract = (x, y) => x - y;

            Action<int> write = (x) => WriteLine(x);

            //write(square(2));

        }


    }

    public class DyanmicDemo
    {
        public static implicit operator string(DyanmicDemo value)
        {
            return value.ToString();
        }
    }
}

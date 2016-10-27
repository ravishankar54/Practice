using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public static class MyExtensions
    {
        public static List<T> CustomSort<T, TPropertyType>(this IEnumerable<T> collection, string propertyName, string sortOrder)
        {
            List<T> sortedlist = null;
            IQueryable<T> query = collection.AsQueryable<T>();

            ParameterExpression pe = Expression.Parameter(typeof(T), "p");
            MemberExpression me = Expression.Property(pe, propertyName);
            Expression<Func<T, TPropertyType>> expr = Expression.Lambda<Func<T, TPropertyType>>(me, pe);

            if (!string.IsNullOrEmpty(sortOrder) && sortOrder == "desc")
                sortedlist = query.OrderByDescending<T, TPropertyType>(expr).ToList();
            else
                sortedlist = query.OrderBy<T, TPropertyType>(expr).ToList();

            return sortedlist;

        }
        public static List<T> CustomSortCompile<T, TPropertyType>(this IEnumerable<T> collection, string propertyName, string sortOrder)
        {
            List<T> sortedlist = null;

            ParameterExpression pe = Expression.Parameter(typeof(T), "p");
            Expression<Func<T, TPropertyType>> expr = Expression.Lambda<Func<T, TPropertyType>>(Expression.Property(pe, propertyName), pe);

            if (!string.IsNullOrEmpty(sortOrder) && sortOrder == "desc")
                sortedlist = collection.OrderByDescending<T, TPropertyType>(expr.Compile()).ToList();
            else
                sortedlist = collection.OrderBy<T, TPropertyType>(expr.Compile()).ToList();

            return sortedlist;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class FilterExtensions
    {
        public static IEnumerable<string> StringThatStartsWith(this IEnumerable<string> input, string start)
        {
            foreach (var str in input)
            {
                if (str.StartsWith(start))
                {
                    yield return str;
                }
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input, FilteringDeleteDate<T> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public delegate bool FilteringDeleteDate<T>(T item);

        public static IEnumerable<T> FilterFunc<T>(this IEnumerable<T> input, Func<T, bool> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}

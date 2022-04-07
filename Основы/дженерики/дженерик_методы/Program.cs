using System;
using System.Collections;
using System.Collections.Generic;

namespace дженерик_методы
{
    public static class EnumerableExtensions
    {   
        public static T FindMax<T>(this IEnumerable<T> en) where T : IComparable
        {
            bool firstTime = true;
            T max = default(T);
            foreach (var e in en)
                if (firstTime || max.CompareTo(e) < 0)
                {
                    max = e;
                    firstTime = false;
                }
            return max;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var b = new[] { 1, 2, 3 }.FindMax();

        }
    }
}

using System;
using System.Collections.Generic;


namespace Требования_к_дженерик_аргументу
{

    public class SortedList<T> where T : class, IComparable, new()// ограничения
    {
        List<T> list;

        public SortedList()
        {
            list = new List<T>();
        }

        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public void Add(T value)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].CompareTo(value) < 0)
                {
                    list.Insert(i, value);
                    return;
                }
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

using System;
using System.Collections.Generic;

namespace дженерики
{
    public class MyList<T>
    {
        List<T> list;

        public MyList()
        {
            list = new List<T>();
        }


        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public void Add(T item)
        {
            list.Add(item);
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

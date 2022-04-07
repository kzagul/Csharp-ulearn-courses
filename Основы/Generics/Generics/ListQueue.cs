using System;
using System.Collections.Generic;
namespace Generics
{
    public class ListQueue
    {
        List<int> list = new List<int>();

        public void Enqueue(int elem)
        {
            list.Add(elem);
        }

        public int Dequeue()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            var result = list[0];
            list.RemoveAt(0);
            return result;
        }
    }
}

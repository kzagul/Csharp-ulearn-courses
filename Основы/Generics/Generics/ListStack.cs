using System;
using System.Collections.Generic;

namespace Generics
{
    public class ListStack
    {
        List<int> list = new List<int>();

        public void Push(int value)
        {
            list.Add(value);
        }

        public int Pop()
        {
            if (list.Count == 0) throw new Exception();
            var result = list.IndexOf(list.Count - 1);
            list.RemoveAt(list.Count - 1);
            return result;
        }

        public void MakeFull()
        {
            if (list.Count == 0)
            {
                for (int i = 0; i <= 10; i++)
                {
                    list.Add(i);
                }
            }
        }

        public void PrintListStack()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
        }
    }
}
    
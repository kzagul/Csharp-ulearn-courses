using System;
using System.Collections.Generic;

namespace Наследование
{
    public class Stack
    {
        List<int> list = new List<int>();

        public void Push(int value)
        {
            list.Add(value);
        }

        public int Pop(int value)
        {
            if (list.Count == 0) throw new Exception();
            var result = list.IndexOf(list.Count - 1);
            list.RemoveAt(list.Count - 1);
            return result;
        }
    }



}

using System;
using System.Collections.Generic;

namespace stack
{
    public class Stack
    {
        List<int> list = new List<int>();
        public void Push(int value)
        {
            list.Add(value);

        }
        public int Pop()
        { 
        if (list.Count == 0) throw new InvalidOperationException();
        var result = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        return result;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            
            Console.WriteLine(stack.Pop());


            for (int i = 0; i <= 10; i++) stack.Push(i);

            for (int i = 0; i <= 10; i++) Console.WriteLine(stack.Pop());





        }
    }
}

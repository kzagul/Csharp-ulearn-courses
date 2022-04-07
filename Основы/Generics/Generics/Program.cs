using System;
using System.Collections.Generic;
namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            //*
            //* *

            //про стэк

            /*ListStack stack = new ListStack();

            stack.MakeFull();

            stack.PrintListStack();

            Console.WriteLine(" ");

            Console.WriteLine(stack.Pop());*/



            //*
            //* *

            //про очередь

            /*
            var intQueue = new Queue<int>();

            intQueue.Enqueue(1);
            intQueue.Enqueue(2);
            intQueue.Enqueue(3);

            var sum = 0;

            while(!intQueue.IsEmpty)
            {
                sum += intQueue.Dequeue();
            }

            Console.WriteLine(sum);
            */



            var stringArray = new string[] { "A", "B", "C" };

            var pointArray = new Point[]
            {
                new Point {X = 1, Y = 1},
                new Point {X = 40, Y = 40},
                new Point {X = 10, Y = 10}
            };

            GenericSorter<string>.Sort(stringArray);


            GenericSorter<Point>.Sort(pointArray);


        }
    }
}

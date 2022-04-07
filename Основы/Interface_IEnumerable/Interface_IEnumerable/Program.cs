using System;
using System.Threading;

namespace Interface_IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var e in Sequences.Fibonacci)
            {
                Console.WriteLine(e);
                Thread.Sleep(500);
                if (Console.KeyAvailable) break;
            }







            /*var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);


            foreach (var value in queue)
                Console.WriteLine(value);*/
        }
    }
}

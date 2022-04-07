using System;

namespace _1_решение_практика
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            a = 10;
            b = 2;
            int counter;

            Console.WriteLine(a);
            Console.WriteLine(b);

            (a, b) = (b, a);

            //counter = a;
            //a = b;
            //b = counter;

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}

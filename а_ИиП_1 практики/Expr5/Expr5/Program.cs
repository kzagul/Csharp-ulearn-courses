using System;

namespace Expr5
{
    class Program
    {
        static void Main(string[] args)
        {
            // колво високосных лет
            int a = Int32.Parse(Console.ReadLine());
            int b = Int32.Parse(Console.ReadLine());
            int bolee, menee;
            if (a <= b)
            {
                bolee = b;
                menee = a;

            }
            else
            {
                bolee = a;
                menee = b;
            }

            int res = (bolee - menee) / 4;

            Console.WriteLine(res);


        }
    }
}

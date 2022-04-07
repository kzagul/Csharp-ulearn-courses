using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //введем отрезок AB; b > a по условию
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            int k = 2;

            //res = (b - a) / 4;

            if ((a % 4 == 0 && a % 100 != 0) || a % 400 == 0)
                k -= 1;
            if ((b % 4 == 0 && b % 100 != 0) || b % 400 == 0)
                k -= 1;




                Console.WriteLine(((b - a) - k) / 4);




        }
    }
}

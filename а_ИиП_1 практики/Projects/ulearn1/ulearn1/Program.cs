using System;

namespace ulearn1
{
    class Program
    {
        static string GetMinX(int a, int b, int c)
        {
            if (a > 0) return (-1.0 * b / 2.0 / a).ToString();
            if ((a == 0) && (b == 0)) return c.ToString();
            else return "Impossible";
        }
            public static void Main()
            {
                Console.WriteLine(GetMinX(1, 2, 3));
                Console.WriteLine(GetMinX(0, 3, 2));
                Console.WriteLine(GetMinX(1, -2, -3));
                Console.WriteLine(GetMinX(5, 2, 1));
                Console.WriteLine(GetMinX(4, 3, 2));
                Console.WriteLine(GetMinX(0, 4, 5));
            }


        }

    }

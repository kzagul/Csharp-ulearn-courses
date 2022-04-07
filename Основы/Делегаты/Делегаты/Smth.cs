using System;
namespace Делегаты
{
    public class Smth
    {
        public int N { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Smth(int n = 10, int x = 77, int y = 99)
        {
            N = n;
            X = x;
            Y = y;
        }


        public int PrintResultN_Times(int x, int y, Func<int, int, int> action)
        {
                return action(x, y);
        }

        public int Sum(int x, int y)
        {
            //Console.WriteLine(x + y);
            return x + y;
        }

    }
}

using System;

namespace учусь_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = Int32.Parse(Console.ReadLine());
            for (int l = 0; l < counter; l++)
            {
                int i = Int32.Parse(Console.ReadLine());

                int res = 0, k = 1, s = 100;

                for (int j = 0; j < 3; j++)
                {
                    res = res + ((i / k) % 10) * s;
                    k = k * 10;
                    s = s / 10;
                }

                Console.WriteLine(res);




                Console.ReadLine();
            }
        }
    }
}

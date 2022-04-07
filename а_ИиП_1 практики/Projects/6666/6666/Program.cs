using System;

namespace _6666
{
    class Program
    {

        public static int GetMinPowerOfTwoLargerThan(int number)
        {
            int result = 1;
            while (2 * result <= number)
                result = result * 2;
            return result * 2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetMinPowerOfTwoLargerThan(129));
        }
    }
}

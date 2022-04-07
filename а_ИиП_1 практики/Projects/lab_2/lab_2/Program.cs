using System;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {


            // ЗАДАЧА 1

            /*
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int summ = 0;
            foreach (int i in numbers)
            {
                summ += i;
            }

            
            Console.WriteLine(summ);
           

            */


            /*
            
            int[] numbers = new int[] { 7, 1, 3, 9, 5 };

            static int Sum (int[] Array, int i = 0)
            {
                if (i >= Array.Length)
                    return 0;
                int result = Sum(Array, i + 1);

                return Array[i] + result;

            }

            Console.WriteLine(Sum(numbers) );
            */

            /*

            // ЗАДАЧА 2

            
            int a = Convert.ToInt32(Console.ReadLine());

            int b = Convert.ToInt32(Console.ReadLine());


            static int oper(int a, int b)
            {
                if (b == 1)
                    return a;
                else
                    return a + oper(a, --b);

            }


            //Console.WriteLine(a + b);


            Console.WriteLine(oper(a, b));

            */
            




            Console.ReadKey();

        }
    }
}

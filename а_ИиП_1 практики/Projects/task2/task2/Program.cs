using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {



            //создаем массив
            const int n = 10;
            int[] a = new int[n] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] b = new int[n];

            for (int i = 0; i < n; ++i) // вывод
                Console.Write("\t" + a[i]);
            Console.WriteLine();

            int k = Convert.ToInt32(Console.ReadLine()); // кол-во элементов сдвига


            for (int i = 0; i < k; ++i)
            {
                int p = a[n - 1]; // последний элемент массива n
                for (int j = n - 1; j > 0; j--) 
                    a[j] = a[j - 1]; // присваивание предыдущего
                a[0] = p; // тот который в самом концу
            }

          

            for (int i = 0; i < n; ++i) // вывод новый массив
                Console.Write("\t" + a[i]);
        }
    }
}

using System;
using System.Collections.Generic;
namespace цацвыаыа
{
    class Program
    {


        //задание1

        public static int MinElem(int[] numbers)
        {
            // найти номер минимального отрицательного элемента массива
            int min = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    if (min > numbers[i])
                    {
                        min = numbers[i];

                    }
                }
            }

            return min;

        }

        //задание2
        public static int Kratn_eight(int[] numbers)
        {
            var list = new List<int>();
            list.Add(11);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 8 == 0)
                {
                    list.Add(numbers[i]);
                }

            }

            return (int[])list;
        }




        //задание3
        public static void bolee5_menee10(int chislo)
        {
            if ((chislo > 5) && (chislo < 10))
                return "Число больше 5 и меньше 10";
            else
                return "Неизвестное число";

        }


        //задание4
        public static void m_and_n(string text)
        {
            int cnt_m = 0;
            int cnt_n = 0;
            text = text.ToLower();
            foreach (char elem in text.ToCharArray())
            {
                if (elem == 'м')
                    cnt_m++;
                if (elem == 'н')
                    cnt_n++;
            }
            if (cnt_m == cnt_n)
                return "количесвто букв м == количеству букв н";
            else
                if (cnt_m > cnt_n)
                return "Букв м больше чем н";
            else
                return "Букв н больше чем м";

        }


        //задание5
        public static void day(int number)
        {
            List<string> days = new List<string>() { "понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье" };
            return days[number];
        }


        //задание7
        public float func_rec(int[] array, int n)
        {
            if (n == 1)
                return (float)array[n - 1];

            else
                return ((float)(func_rec(array, n - 1) *

                               (n - 1) + array[n - 1]) / n);

        }



        //задание8
        public static double min_elem(double[] array, int n)
        {
            if (n == 1)
            {
                return array[0];
            }
            var newAr = new double[n - 1];
            Array.Copy(array, 1, newAr, 0, n - 1);
            var min = Math.Min(array[0], array[1]);
            newAr[0] = min;
            return min_elem(newAr, n - 1);
        }






        static void Main(string[] args)
        {

            int[] array = new int[42];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(-100, 100);

            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i]);








        }

    }
}
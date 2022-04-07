using System;

namespace expr3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Задано время Н часов (ровно). Вычислить угол в градусах
            между часовой и
            минутной стрелками. Например, 5 часов -> 150 градусов,
            20 часов -> 120 градусов. Не использовать циклы.
             */

            int hour = Int32.Parse(Console.ReadLine());


            int hour_ancle;
            

            int res;
            if (hour > 12)
            {
                hour = hour - 12;
                hour_ancle = 30 * hour;
                if (hour_ancle > 180)
                {
                    res = 360 - hour_ancle;
                }
                else
                {
                    res = hour_ancle;
                }

            }
            else
            {
                hour_ancle = 30 * hour;
                if (hour_ancle > 180)
                {
                    res = 360 - hour_ancle;
                }
                else
                {
                    res = hour_ancle;
                }
            }

            Console.WriteLine(res);

        }
    }
}

using System;
namespace учусь_ООП
{
    public class Point
    {
        public int X;
        public int Y;

        public static void PrintPoint(Point point)
        {
            Console.WriteLine("{0} {1}", point.X, point.Y);
        }

        public void Print()
        {
            Console.WriteLine("{0} {1}", X, Y);
        }
        /*
         Point a1b1 = new Point();
            a1b1.X = 7;
            a1b1.Y = 2;
            Point.PrintPoint(a1b1);


            var point = new Point { X = 5, Y = 5 };

            Point.PrintPoint(point);
            point.Print();

        */


    }
}

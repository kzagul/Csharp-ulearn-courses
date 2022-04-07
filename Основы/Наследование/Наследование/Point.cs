using System;
using System.Collections;

namespace Наследование
{
    public class Point : IComparable
    {
        public int X;
        public int Y;

        public Point(int x = 1, int y = 1)
        {
            X = x;
            Y = y;
        }

        double DistanceToZero(Point point)
        {
            return Math.Sqrt((point.X * point.X) + (point.Y * point.Y));
        }

        public int CompareTo(object obj)
        {
            var point = (Point)obj; // downcast

            var thisDist = DistanceToZero(this);
            var thatDist = DistanceToZero(point);
            if (thisDist > thatDist) return 1;
            else if (thisDist == thatDist) return 0;
            else return -1;
        }

        public void PrintPoint(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine("{0} {1}", points[i].X, points[i].Y);
            }
        }

        public static Point operator+ (Point p1, Point p2)
        {
            return new Point
            {
                X = p1.X + p2.X,
                Y = p1.Y + p2.Y
            };
        }
    }


    class DistanceToZeroComparer : IComparer
    {
        double DistanceToZero(Point point)
        {
            return Math.Sqrt((point.X * point.X) + (point.Y * point.Y));
        }


        public int Compare(object x, object y)
        {
            return DistanceToZero((Point)x).CompareTo(DistanceToZero((Point)y));
        }
    }
}

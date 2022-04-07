using System;
namespace GeometryTasks
{
    public class Newvector
    {
        public double X;
        public double Y;

        public Newvector()
        {
            X = 0;
            Y = 0;
        }

        public Newvector(double x, double y)
        {
            X = x;
            Y = y;
        }

    }

    public class NewGeometry
    {
        public static double GetLength(Newvector vector)
        {
            double length = Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
            return (length);
        }

        public static double Add(Newvector vector1, Newvector vector2)
        {
            double length1 = NewGeometry.GetLength(vector1);
            double length2 = NewGeometry.GetLength(vector2);
            double result_length = length1 + length2;
            return (result_length);
        }
    }
}

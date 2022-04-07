using System;
namespace Interfaces
{
    public interface IFigure
    {
        Point Location { get; set; }

        bool Contains(Point p);

        double Area { get; }

    }

    public static class IFigureExtensions
    {
        public static bool Contains(this IFigure obj, Point[] points)
        {
            foreach (var p in points)
                if (obj.Contains(p)) return true;
            return false;
        }
    }

    class Square : IFigure
    {
        public int Size { get; set; }
        public Point Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double Area
        {
            get
            {
                return Math.Pow(Size, 2);
            }
        }

       
        public bool Contains(Point p)
        {
            return
                Math.Abs(p.X - Location.X) < Size / 2 &&
                Math.Abs(p.Y - Location.Y) < Size / 2;
        }

       
    }

    class Circle : IFigure
    {
        public int Radius { get; set; }

        public double Area
        {
            get
            {
                return Math.PI * Math.Pow(Radius, 2);
            }
        }

        public Point Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Contains(Point p)
        {
            return
            Math.Sqrt(Math.Pow(p.X - Location.X, 2) + Math.Pow(p.Y - Location.Y, 2)) < Radius;
        }

    }
}

using System;

namespace absractClasses
{
    abstract class Figure
    {
        public Point Location { get; set; }

        public virtual bool Contains(Point p)
        {
            return false;
        }

        public bool Contains(Point[] points)
        {
            foreach (var p in points)
                if (Contains(p)) return true;
            return false;
        }


        public virtual double GetArea()
        {
            return 0;
        }

        public abstract double Area { get; }

    }

    class Square : Figure
    {
        public int Size { get; set; }

        public override double Area
        {
            get
            {
                return Math.Pow(Size, 2);
            }
        }

        public override bool Contains(Point p)
        {
            return
                Math.Abs(p.X - Location.X) < Size / 2 &&
                Math.Abs(p.Y - Location.Y) < Size / 2;
        }

        public override double GetArea()
        {
            return Math.Pow(Size, 2);
        }
    }

    class Circle : Figure
    {
        public int Radius { get; set; }

        public override double Area
        {
            get
            {
                return Math.PI * Math.Pow(Radius, 2);
            }
        }

        public override bool Contains(Point p)
        {
            return
            Math.Sqrt(Math.Pow(p.X - Location.X, 2) + Math.Pow(p.Y - Location.Y, 2)) < Radius;
        }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

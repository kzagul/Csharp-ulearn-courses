using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists
{
    public class MyList<T> : IEnumerable<T>
    {
        #region
        T[] array;
        int count = 0;

        public MyList()
        {
            array = new T[100];
        }

        void Enlarge()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            if (count == array.Length)
                Enlarge();
            array[count] = item;
            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get { return count; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > count) throw new IndexOutOfRangeException();
                return array[index];
            }
            set
            {
                if (index < 0 || index > count) throw new IndexOutOfRangeException();
                array[index] = value;
            }
        }

        // ТО ЖЕ САМОЕ, НО в другой форме
        /*
        public T GetElement(int index)
        {
            return array[index];
        }

        public void SetValue(T value, int index)
        {
            array[index] = value;
        }*/
        #endregion


        /*
        public bool Contains(T element)
        {
            foreach (var e in array)
            {
                if (e == element)
                {
                    return true;
                    break;
                }
                return false;
            }
        }*/

        public bool Contains(T value)
        {
            for (int i = 0; i < count; i++)
                if (array[i].Equals(value)) return true;
            return false;
        }

    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;
            var p = obj as Point;
            return this.X == p.X && this.Y == p.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (int)(X * 1023 + Y);
            }
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            if (p1.X == p2.X && p1.Y == p2.Y) return false;
            else
                return true;    
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point { X = p1.X + p2.X, Y = p1.Y + p2.Y };
        }

        public static Point operator *(Point p1, double value)
        {
            return new Point { X = p1.X * value, Y = p1.Y * value };
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }

    }

    struct Size
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override bool Equals(object obj)
        {
            return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            /*
            MyList<int> mylist = new MyList<int>();
            for (int i = 1; i <= 10; i++)
                mylist.Add(i * 5);

            foreach (var elem in mylist)
                Console.WriteLine(elem);
            */



            var pList = new List<Point>();
            var point = new Point { X = 1, Y = 1 };
            var point2 = new Point { X = 1, Y = 1 };

            Console.WriteLine(point == point2);
            Console.WriteLine(point.Equals(point2));
            var point3 = point + point2;
            Console.WriteLine(point3);
            point3 += point;
            Console.WriteLine(point3);
        }
    }
}

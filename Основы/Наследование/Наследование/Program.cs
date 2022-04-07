using System;
using System.Collections.Generic;
using System.Text;

namespace Наследование
{
    public class A
    {
        public int a;
        public static A operator+ (A e1, A e2)
        {
            return new A() { a = e1.a + e1.a };
        }

        public static A operator* (A e1, string e2)
        {
            return new A();
        }

        public static explicit operator string(A e)
        {
            return new string(e.a.ToString());
        }

        public int Direction { get; set; }
    }


    class Program
    {
        public static void Main()
        {
            var scene = new List<Figure>
            {
                new Circle { Location = new Point(1, 1), Radius = 3 },
                new Square { Location = new Point(0, 0), Size = 2 },
                new Figure { Location=new Point(0,1) }
            };

            foreach (var e in scene)
                Console.WriteLine(e.GetArea());
        }



        //int a = new A() + new A() + new A() * "abc";

        /*
        var intArray1 = new int[] { 2, 4, 1, 8 };
        var intArray2 = new int[] { 10, 20, 30, 40 };
        var stringArray = new string[] { "B", "A", "Z" };
        var doubleArray = new double[] { 2.23, 9.44, 7.92 };
        */


        /*
        ArrayExtensions.PrintObject(intArray1.BubbleSort());
        ArrayExtensions.PrintObject(doubleArray.BubbleSort());
        ArrayExtensions.PrintObject(stringArray.BubbleSort());
        */



        /* var newArray = ArrayExtensions.Combine(intArray1, intArray2);

         ArrayExtensions.PrintObject(newArray);
        */

        /*
        var pointArray = new Point[]
        {
        new Point {X = 1, Y = 1 },
        new Point {X = 5, Y = 5 },
        new Point {X = 3, Y = 3 },
        new Point {X = 4, Y = 4 }
        };
        */


        //pointArray.BubbleSort();

        /*
        intArray.Swap(0, 1);
        stringArray.Swap(0, 1);
        doubleArray.Swap(0, 1);
        Matrix.PrintMatrix(intArray);
        Matrix.PrintMatrix(stringArray);

        pointArray.BubbleSort();

        */

        /*
        ArrayExtensions.ProcessArray(intArray);
        ArrayExtensions.ProcessArray(stringArray);

        int[] res = ArrayExtensions.BubbleSort(intArray);

        Matrix.PrintMatrix(res);
        */

        //Compare(pointArray[1], pointArray[2]);


    }
}




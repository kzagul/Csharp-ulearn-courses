using System;

namespace GeometryTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = 5.0;
            double y1 = 5.0;

            double x2 = 7.0;
            double y2 = 7.0;

            var vector_a = new Newvector();
            vector_a.X = x1;
            vector_a.Y = y1;

            var vector_b = new Newvector();
            vector_b.X = x2;
            vector_b.Y = y2;



            Console.WriteLine(NewGeometry.GetLength(vector_a));
            Console.WriteLine(NewGeometry.GetLength(vector_b));

            Console.WriteLine(NewGeometry.Add(vector_a, vector_b));


        }
    }
}

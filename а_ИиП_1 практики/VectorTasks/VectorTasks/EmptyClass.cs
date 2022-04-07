using System;
namespace VectorTasks
{
    public class EmptyClass
    {

        class Vector
        {

            public double X;
            public double Y;

            public Vector()
            {
                X = 0;
                Y = 0;
            }

            public Vector(double x, double y)
            {
                X = x;
                Y = y;
            }


            public double GetLength()
            {
                return Geometry.GetLength(this);
            }


            public Vector Add(Vector vector)
            {
                return Geometry.Add(vector, this);
            }
        }



        class Geometry
        {

        }


    }
}

using System;
using System.Collections.Generic;

namespace Kvur
{
    public class KvurSolver
    {
        public static List<double> Kvur(double a, double b, double c)

        {

            List<double> massiv = new List<double>();
            //double[] xes = new double[2];
            var Discriminant = b * b - 4 * a * c;
            if (Discriminant > 0)
            { 
            massiv.Add(((-1 * b) + Math.Sqrt(Discriminant)) / (2 * a));
            massiv.Add(((-1 * b) - Math.Sqrt(Discriminant)) / (2 * a));
            return massiv;
            }
            else if (Discriminant == 0)
            {
            massiv.Add(((-1 * b) + Math.Sqrt(Discriminant)) / (2 * a));
            massiv.Add(((-1 * b) + Math.Sqrt(Discriminant)) / (2 * a));

                return massiv;
            }
            else
            {

                return massiv;
            }

        }
    }
}

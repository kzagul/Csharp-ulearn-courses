using System;
using System.IO;

namespace учусь_ООП
{

    class Program
    {
        static void Main(string[] args)
        {
            int value = Convert.ToInt32(Console.ReadLine());

            //int n = StaticAlgorithm.StaticRun(value);
            //Console.WriteLine(n);


            Algorithm algorithm = new Algorithm();
            Console.WriteLine(algorithm.Run(value));


        }
    }
}

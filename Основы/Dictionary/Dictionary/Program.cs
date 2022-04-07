using System;
using System.Collections.Generic;
using Kvur;


namespace Dictionary
{
    class Program
    {

        
        static string SayGoodbye() => "GoodBye";
       

        static string GetHello() => "hello";



        public static double Step(double chislo, int deg)
        {
            for (int i = 0; i < deg - 1; i++)
            {
                chislo *= chislo;
            }


            return chislo;
        }
        


        static double Degree (double chislo, int degree)
        {
            for (int i = 0; i < degree - 1; i++)
            {
                chislo *= chislo;
            }
            return chislo;
        }

        static void Main(string[] args)
        {


            var a = double.Parse(Console.ReadLine());

            var b = double.Parse(Console.ReadLine());

            double k = Step(a, b);


            Console.WriteLine(k);



            int x = 5;

            int y = 6;

            var l = x * y;




            /*

            var a = double.Parse(Console.ReadLine());

            var b = double.Parse(Console.ReadLine());

            var c = double.Parse(Console.ReadLine());


            var k = KvurSolver.Kvur(a, b, c);

            Console.WriteLine(k[0]);
            Console.WriteLine(k[1]);

            */
        }

    }
}

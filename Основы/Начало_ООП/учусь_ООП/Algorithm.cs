using System;
namespace учусь_ООП
{
    public static class StaticAlgorithm
    {
        static int temporalValue = 0;
        public static int StaticRun(int value)
        {
            int result = 0;
        for (temporalValue = 0; temporalValue <= value; temporalValue++)
            {
                result += temporalValue;
            }
            return result;
        }

    }
    public class Algorithm
        {
            int temporalValue = 0;
        
            public int Run(int value)
            {
                int result = 0;
                for (temporalValue = 0; temporalValue <= value; temporalValue++)
                {
                    result += temporalValue;
                }
                return result;
            }
        }
    /*
    int value = Convert.ToInt32(Console.ReadLine());

    int n = StaticAlgorithm.StaticRun(value);
    Console.WriteLine(n);


    Algorithm algorithm = new Algorithm();
    Console.WriteLine(algorithm.Run(value));
    */
}

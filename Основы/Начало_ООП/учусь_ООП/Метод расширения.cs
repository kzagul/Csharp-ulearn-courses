using System;
namespace учусь_ООП
{
    static class RandomExtensions
    {
        public static double NextDouble(this Random rnd, Double min, Double max)
        {
            return rnd.NextDouble() * (max - min) + min;

        }
    }

    /*
    static double GenerateDouble(Random rnd, Double min, Double max)
    {
        return rnd.NextDouble() * (max - min) + min;
    }


    static void Main(string[] args)
    {
        //GenerateMenu();

        var rnd = new Random();

        Console.WriteLine(rnd.NextDouble(10, 20));
        Console.WriteLine(GenerateDouble(rnd, 10, 100));
        Console.WriteLine(RandomExtensions.NextDouble(rnd, 10, 12));
    }
    */


}

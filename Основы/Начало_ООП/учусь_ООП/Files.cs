using System;
using System.IO;

namespace учусь_ООП
{
    static class System
    {
        public static void ReadAllText(this string filename)
        {
            Console.WriteLine(File.ReadAllText(filename));
        }

       /* class Program
        {
            public static void ReadFile(string file)
            {
                var content = File.ReadAllText(file);
                Console.WriteLine(content);
            }


            static void Main(string[] args)
            {
                foreach (var file in Directory.GetFiles("."))
                    Console.WriteLine(file);

                string string1 = "choose [1] to open your File: ";
                string string2 = "choose [2] to open Program's File: ";

                Console.WriteLine("{0} {1}", string1, string2);

                int determinator = Convert.ToInt32(Console.ReadLine());

                if (determinator == 1)
                {
                    string PathToFile = Console.ReadLine();
                    ReadFile(PathToFile);
                }
                else
                {
                    ReadFile("/Users/zagulkirill/Desktop/TextFile1.txt");
                }
       
            }
       
        }
     */
    }
}
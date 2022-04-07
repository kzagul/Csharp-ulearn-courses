using System;

namespace _67r76
{
    class Program
    {
        static void Main(string[] args)
        {

            string word1 = "hello";
            string word2 = "moon";


            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();



            foreach (char c in word1)
            {
                list1.Add(c);
            }


            for (int i = 0; i < list1.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

        }
}

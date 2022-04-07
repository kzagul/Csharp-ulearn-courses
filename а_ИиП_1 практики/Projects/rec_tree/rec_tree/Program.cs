using System;
using System.Collections;
using System.Linq;

namespace rec_tree
{
    class Program
    {
        static void Main(string[] args)
        {


            
            ArrayList alphabet = new ArrayList() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            int l = alphabet.IndexOf("d");

            int key = alphabet.IndexOf("e");

            Console.WriteLine(l);

            Console.WriteLine(key);
            
        string word1 = "helloo";
        string word2 = "moon";


        int[] list1 = new int[alphabet.Count];
        int[] list2 = new int[alphabet.Count];

        foreach (int i in list1)
        {
            list1[i] = 0;
        }


        int k = list1.Length;
        foreach (char c in word1)
        {

            int v = alphabet.IndexOf(c);
            list1[v] += 1;

        }

        foreach (char s in word2)
        {
            int v = alphabet.IndexOf(s);
            list1[v] += 1;
        }

        /*foreach (char c in word1)
        {
            foreach (char s in word2)
            {
                if (c == s)
                {
                    list3.Add(c);
                }
            }
        }

        for (int i = 0; i < list1.Length; i++)
        {
            Console.WriteLine(list1[i]);
        }

        /*

        ArrayList alphabet = new ArrayList() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        //string word1 = Convert.ToString(Console.ReadLine());
        //string word2 = Convert.ToString(Console.ReadLine());
        string word1 = "helloo";
        string word2 = "moon";

        //int n = word1.Length;
        int[] a = new int[word1.Length];
        int[] b = new int[word2.Length];



        foreach (char c in word1)
        {
            for (int i = 0; i < word1.Length; i++)
            {

              a[i] = c;
            }

        }





        for (int i = 0; i < word1.Length; i++)
        {

        }





        string s = "wow";


        int repeats = s.Length - s.ToCharArray().Distinct().Count();


        Console.WriteLine(repeats);

        //Console.WriteLine(c);

        /* for (int i = 0; i < word1.Length; i++)
         {

         }


         */




            /* IndexOf(Array, Object)
             Выполняет поиск указанного объекта внутри всего одномерного массива и возвращает индекс его первого вхождения.
           */



        }
    }
}

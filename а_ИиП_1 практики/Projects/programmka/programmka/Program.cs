using System;

namespace programmka
{
    class Program
    {

        public static int LastIndexOf(int[] input, int value)

        {

            if (input != null)

            {

                for (var i = input.Length; i > 0; i--)

                    if (input[i - 1] - value == 0)

                        return i;

            }

            return -1;

        }


        static string N(int m)
        { if (m < 0) return ""; if (m == 0) return m.ToString(); return N(m - 1) + m.ToString(); }


        

        

        public static void Rearrange(int[] array)

        {

            for (var i = 0; i < array.Length / 2; i++)

            {

                var tmp = array[i];

                array[i] = array[array.Length - i - 1];

                array[array.Length - i - 1] = tmp;

            }

            //Console.WriteLine("!");
            for (var i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static string GetMarkDescription1(int mark)
        {
            if (mark == 5) return "Excellent";
            if (mark == 4) return "Good";
            if (mark == 3) return "Satisfactory";
            if (mark == 2) return "Failure";
            throw new IndexOutOfRangeException();
        }

       /* static string GetMarkDescription(int mark)
        {
            List<string> marks = new List<string>() { "Failure", "Satisfactory", "Good", "Excellent"};

            return marks[mark-2]; // mark - 2 для того чтобы получить соответственную строку из списка
            

        }*/

        static int M(int x, int y)
        {
            if (Math.Abs(x - y) <= 2) return (x + y) / 2;
            var a = M(x, (x + y) / 2);
            var b = M((x + y) / 2, y);
            return M(a, b);
        }



        static void Main(string[] args)
        {


             var i  = new[] {new[] {2, 3, 5}, new[] {7, 11, 13},
    new[] {17, 19, 23}}[2][0];

            //var k = "ab\ncd".Length;
            Console.WriteLine(i is int);
            //Console.WriteLine(i);
            //Console.WriteLine(k);

            
            /*int count = 5;
            Console.WriteLine(N(count));
            */


            /*
            var array = new[] { 1, -1, 2, 0, 5 };
            Rearrange(array);
            */
            
            //Console.WriteLine(M(2,7));
        }
    }
}

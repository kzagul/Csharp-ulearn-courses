using System;

namespace morskoyboi
{
    class Program
    {






        public class Figure
        {
            public class Figure1
            {
                public string name;
                public int ship_len;
                public Figure1() { name = "однопалубный"; ship_len = 1; }
            }
            public class Figure2
            {
                public string name;
                public int ship_len;
                public Figure2() { name = "двухпалубный"; ship_len = 2; }
            }

            public class Figure3
            {
                public string name;
                public int ship_len;
                public Figure3() { name = "трехпалубный"; ship_len = 3; }
            }

            public class Figure4
            {
                public string name;
                public int ship_len;
                public Figure4() { name = "четырехпалубный"; ship_len = 4; }
            }
        }




        public class Field 
        {
                public class Field1
            {
                public string type;
                
                public Field1() { type = "красный"; ; }
            }

            public class Field2
            {
                public string type;
                
                public Field2() { type = "синий"; ; }
            }

        }




        public class Kletka
        {

            public class est_mesto
            {

            }

            public class net_mesta
            {

            }

        }






            static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

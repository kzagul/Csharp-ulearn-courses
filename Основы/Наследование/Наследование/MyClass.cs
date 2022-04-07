using System;
namespace Наследование
{
    public class MyClass
    {
        public int publicField;
        private int privateField;
        public static int publicStaticField;

        public int PublicMethod() { return 0; }

        private int PrivateMethod() { return 0; }

        public static int PublicStaticMethod() { return 0; }

        internal int InternalMethod() { return 0; }



        public MyClass(int privateValue)
        {
            privateField = privateValue;
        }
    }

    class SomeClass
    {
        public static int s;
        private int p;
        public int d;
    }


    public class student
    {

        public string name;
        public static string staticname = "black";

        public int year;
        //public static int staticyear = 1;

        public string letter;
        //public static string staticletter = "A";


        public void AcceptStudent(string name, int year, int letter)
        {
            Console.WriteLine("name");
        }

        public void AcceptStudent(string name)
        {
            this.year = 1;
            this.letter = "A";
        }
    }

}

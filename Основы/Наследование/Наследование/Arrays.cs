using System;
namespace Наследование
{
    public static class ArrayExtensions
    {
        public static Array BubbleSort(this Array array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    var element1 = (IComparable)array.GetValue(i);
                    var element2 = (IComparable)array.GetValue(j);

                    if (element1.CompareTo(element2) > 0)
                    {
                        array.Swap(i, j);
                    }
                }
            }
            return array;
        }


        //склейка двух массивов одного типа

        public static Array BadCombine(Array array1, Array array2)
        {
            if (array1.GetType().GetElementType() == array2.GetType().GetElementType())
            {
                var lengthOfBoth = array1.Length + array2.Length;
                var resArray = Array.CreateInstance(array1.GetType().GetElementType(), lengthOfBoth);

                Array.Copy(array1, 0, resArray, 0, array1.Length);
                Array.Copy(array2, 0, resArray, array1.Length, array2.Length);

                return resArray;
            }
            else
                //throw new Exception("массивы не одного типа");
                return null;
        }



        //склейка массивов

        public static Array Combine(params Array[] arrays)
        {
            if (arrays.Length == 0 || arrays == null) return null;

            Type type = arrays[0].GetType().GetElementType();


            int length = 0;

            foreach (var array in arrays)
            {
                if (array.GetType().GetElementType() != type) return null;
                length += array.Length;
            }

            var resArray = Array.CreateInstance(type, length);

            int counter = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                Array.Copy(arrays[i], 0, resArray, counter, arrays[i].Length);

                counter += arrays[i].Length;
            }


            return resArray;

        }







        public static void PrintObject (Array matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.Write(matrix.GetValue(i) + " ");
            }
            Console.WriteLine();
        }



        // минимум трех

        static object Min(Array array)
        {
            //var comparableArray = (IComparable)array;
            var min = (IComparable)array.GetValue(0);
            for (int i = 0; i < array.Length; i++)
            {
                var elem = (IComparable)array.GetValue(i);
                if (min.CompareTo(elem) > 0)
                {
                    min = elem;
                }
            }
            return min;
        }

            static object NewMiddleOfThree(object a, object b, object c)
        {
            var element1 = (IComparable)a;
            var element2 = (IComparable)b;
            var element3 = (IComparable)c;

            if (element1.CompareTo(element2) > 0)
            {
                if (element1.CompareTo(element3) < 0) return element1;
                if (element3.CompareTo(element2) > 0) return element3;
            }
            else if (element2.CompareTo(element3) < 0) return element2;
            else if (element1.CompareTo(element3) > 0) return element1;

            return element3;
        }


        public static void ProcessArray(Array array)
        {
			object obj = array.GetValue(0);
			Console.WriteLine(obj);
        }
        


        //поменять элементы местами

        public static void Swap(this Array array, int i, int j)
        {
            object obj = array.GetValue(i);
            array.SetValue(array.GetValue(j), i);
            array.SetValue(obj, j); 
        }

	}
}

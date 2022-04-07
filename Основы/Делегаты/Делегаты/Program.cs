using System;
using System.Collections.Generic;

namespace Делегаты
{

	public delegate int StringComparer(string x, string y);
	//с дженериками
	public delegate int ObjectComparer<T>(T x, T y);


	class Program
    {

		//типы делегатов: Func<T,T, ... T> и Action<T,T, ... >
		// Func - для возвращаемого типа данных
		// Action - для void

		delegate int Operation(int a, int b); // делегат с параметрами
		delegate void Message(); // делегат без параметров


		public static void HelloWorld()
        {
			Console.WriteLine("Hello World");
		}
		public static void HiThere()
		{
			Console.WriteLine("Hi there");
		}

		public static int Add(int a, int b)
        {
			return a + b;
        }
		public static int Multiply(int a, int b)
		{
			return a * b;
		}



		#region public static void SortStrings(string[] array, StringComparer comparer)


		public static int CompareLength(string x, string y)
		{
			return x.Length.CompareTo(y.Length);
		}

		public static void SortStrings(string[] array, StringComparer comparer)
		{
			for (int i = array.Length - 1; i > 0; i--)
				for (int j = 1; j <= i; j++)
				{
					var element1 = array[j - 1];
					var element2 = array[j];
					if (comparer(element1, element2) > 0)
					{
						var temporary = array[j];
						array[j] = array[j - 1];
						array[j - 1] = temporary;
					}
				}
		}


		public static void SortObjects<T>(T[] array, ObjectComparer<T> comparer)// Func<T,T,int>
		{
			for (int i = array.Length - 1; i > 0; i--)
				for (int j = 1; j <= i; j++)
				{
					var element1 = array[j - 1];
					var element2 = array[j];
					if (comparer(element1, element2) > 0)
					{
						var temporary = array[j];
						array[j] = array[j - 1];
						array[j - 1] = temporary;
					}
				}
		}


		public static void Sort<T>(T[] array, Func<T,T,int> comparer)// Func<T,T,int>
		{
			for (int i = array.Length - 1; i > 0; i--)
				for (int j = 1; j <= i; j++)
				{
					var element1 = array[j - 1];
					var element2 = array[j];
					if (comparer(element1, element2) > 0)
					{
						var temporary = array[j];
						array[j] = array[j - 1];
						array[j - 1] = temporary;
					}
				}
		}


		#endregion

		static Random rnd = new Random();


		static Func<T1, T3> Combine<T1, T2, T3>(Func<T1, T2> f, Func<T2, T3> g)
		{
			//T1 и T3
			return null;
		}


		static void Main(string[] args)
        {




			//лямбда берет int и возвращает int
			Func<int, int> f = (x) => x + 1;
			Console.WriteLine(f(1));

			//лямбда берет () и возвращает int
			Func<int> generator = () => rnd.Next();
			Console.WriteLine(generator());

			//лямбда берет double, double и возвращает double + тут функция в функции
			Func<double, double, double> h = (a, b) => Math.Sqrt(a * a + b * b);
			Console.WriteLine(h(5, 8));

			//лямбда берет double, double и возвращает double
			//случай, когда у нас есть вычисления или дргие функции внутри функции
			Func<double, double, double> hesh = (a, b) =>
			{
				b = a % b;
				return b % a;
			};
			Console.WriteLine(hesh(10, 8));


			//лямбда берет () и возвращает int
			Action<int> print = x => Console.WriteLine(x);
			print(2);

			//лямбда берет () и возвращает ()
			Action random = () => Console.WriteLine(rnd.Next());
			random();
			//или
			Action random1 = () => print(generator());

			Action RandomNumber = () =>
			{
				var number = Math.PI;
				print((int)number);
			};

			RandomNumber();


			//*
			//**
			//***
			// ---> для класса Smth

			var smth = new Smth();
			Action<int, int> action;
			smth.PrintResultN_Times(smth.X, smth.Y, delegate (int x, int y)  {return x + y;});


			smth.PrintResultN_Times(smth.X, smth.Y, (x, y) => x + y);








			// Использование делегатов со статическим методом
			var strings = new[] { "Y", "G","A", "B", "A", "H" };
			
			SortObjects(strings, CompareLength);


			// Использование делегатов с динамическим методом
			var comparer = new AlphabeticComparer();
			comparer.Descending = true;
			var sComparer = new StringComparer(comparer.Compare);
			SortStrings(strings, new StringComparer(comparer.Compare));
			//или
			SortObjects(strings, comparer.Compare);
			//или
			Sort(strings, comparer.Compare);

			//или так, но с использованием лямбда-выражений
			Sort(strings, (x, y) => x.Length.CompareTo(y.Length));



			var stringsInt = new[] { 1, 2, 3, 4, 5 };

			Sort(stringsInt, (x, y) => x.CompareTo(y));


		}
    }
}

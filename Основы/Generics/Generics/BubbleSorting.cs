using System;
using System.Collections.Generic;
namespace Generics
{
	class Point : IComparable
	{
		public int X { get; set; }
		public int Y { get; set; }


        public int CompareTo(Object p)
        {
			var point = (Point)p;
			var thislength = (int)Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
			var thatlength = (int)Math.Sqrt((point.X * point.X) + (point.Y * point.Y));
			if (thatlength > thislength)
            {
				return 1;
            }
			else if (thatlength < thislength)
			{
				return -1;
			}
			else
            {
				return 0;
			}
		}
    }



	public class GenericSorter<T> where T : IComparable
    {
		public static void Sort(T[] array)
		{
			for (int i = array.Length - 1; i > 0; i--)
				for (int j = 1; j <= i; j++)
				{
					var element1 = array[j - 1];
					var element2 = array[j];
					//здесь не нужен каст к интерфейсу, поскольку element1 имеет тип T,
					//а для него есть требование о том, что IComparable должен быть реализован
					if (element1.CompareTo(element2) < 0)
					{
						array[j - 1] = element2;
						array[j] = element1;
					}
				}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
	public static class ExtensionsTask
	{
		public static double Median(this IEnumerable<double> items)
		{
			var itemsList = items.ToList();
			itemsList.Sort();
			int count = itemsList.Count;
            if (count != 0)
				return count % 2 == 1 ? itemsList[count / 2] : (itemsList[count / 2] + itemsList[count / 2 - 1]) / 2;
            else throw new InvalidOperationException();
        }
		public static IEnumerable<Tuple<T, T>> Bigrams<T>(this IEnumerable<T> items)
		{
			var previous = default(T);
			var isFirst = true;
			foreach (var item in items)
			{
				if (isFirst == false)
				{
					yield return Tuple.Create(previous, item);
					previous = item;
				}
				else if (isFirst == true)
				{
					previous = item;
					isFirst = false;
				}
            }
		}
	}
}
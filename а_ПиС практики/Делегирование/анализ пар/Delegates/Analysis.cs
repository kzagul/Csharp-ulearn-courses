using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.PairsAnalysis
{
	public static class Analysis
	{
		public static IEnumerable<Tout> PairSelector<Tin, Tout>(IEnumerable<Tin> data, Func<Tin, Tin, Tout> process)
			where Tin : IComparable<Tin>
		{
			return data.Pairs().Select(pair => process(pair.Item1, pair.Item2));
		}

		public static int FindMaxPeriodIndex(params DateTime[] data)
		{
			return PairSelector(data, (date1, date2) => (date2 - date1).TotalSeconds).MaxIndex();
		}

		public static double FindAverageRelativeDifference(params double[] data)
		{
			return PairSelector(data, (date1, date2) => (date2 - date1) / date1).AverageDifference();
		}
	}

	public static class AnalysisExtension
	{
		public static IEnumerable<Tuple<T, T>> Pairs<T>(this IEnumerable<T> data) 
			where T : IComparable<T>
		{
			var previous = default(T);
			var e = data.GetEnumerator();
			try
			{
				e.MoveNext();
				previous = e.Current;
				e.MoveNext();
			}
			catch
			{
				throw new InvalidOperationException();
			}
			yield return Tuple.Create(previous, e.Current);
			previous = e.Current;
			while (e.MoveNext())
			{
				yield return Tuple.Create(previous, e.Current);
				previous = e.Current;
			}
		}

		public static int MaxIndex<T>(this IEnumerable<T> data) 
			where T : IComparable<T>
		{
			var dataList = data.ToList();
			return dataList.IndexOf(dataList.Max());
		}

		public static double AverageDifference(this IEnumerable<double> differences)
		{
			return differences.Sum() / differences.Count();
		}
	}
}
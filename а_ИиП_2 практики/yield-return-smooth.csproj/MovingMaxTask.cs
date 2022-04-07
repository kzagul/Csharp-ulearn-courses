using System;
using System.Collections.Generic;
using System.Linq;

namespace yield
{
	public static class MovingMaxTask
	{
		public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
		{
			var scope = new Queue<DataPoint>();
			var maxElems = new LinkedList<DataPoint>();
			foreach (var point in data)
            {
				scope.Enqueue(point);
				if (scope.Count > windowWidth
					&& scope.Dequeue().OriginalY == maxElems.First.Value.OriginalY)
                {
					maxElems.RemoveFirst();
                }
				while (maxElems.Count > 0
					&& maxElems.Last.Value.OriginalY < point.OriginalY)
                {
					maxElems.RemoveLast();
                }
				maxElems.AddLast(point);
				yield return point.WithMaxY(maxElems.First.Value.OriginalY);
            }
		}
	}
}
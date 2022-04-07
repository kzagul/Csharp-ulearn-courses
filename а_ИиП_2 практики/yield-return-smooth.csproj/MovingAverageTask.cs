using System.Collections.Generic;

namespace yield
{
	public static class MovingAverageTask
	{
		public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
		{
			double sum = 0;
			var datapoints = new Queue<DataPoint>();
			foreach (var point in data)
            {
				sum += point.OriginalY;
				datapoints.Enqueue(point);
				if (datapoints.Count > windowWidth)
                {
					sum -= datapoints.Dequeue().OriginalY;
                }
				yield return point.WithAvgSmoothedY(sum / datapoints.Count);
            }
		}
	}
}
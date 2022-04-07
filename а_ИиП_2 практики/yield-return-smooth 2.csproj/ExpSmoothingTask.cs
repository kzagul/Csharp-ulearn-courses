using System.Collections;
using System.Collections.Generic;

namespace yield
{
	public static class ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{

			//alpha - задается как параметр 0.1   0.5
			//data - сам массив
			/*
			var firstPoint = true;
			double previousPoint = 0;

			foreach (var elem in data)
			{
				if (firstPoint)
				{
					previousPoint = elem.OriginalY;
					firstPoint = false;
				}

				else
					previousPoint = alpha * elem.OriginalY + (1 - alpha) * previousPoint;

				var newDataPoint = elem.WithExpSmoothedY(previousPoint);

				yield return newDataPoint;
			*/


			var index = 0;
			double Point = 0;
			foreach (var elem in data)
			{
				var dataPoint = new DataPoint()
				{
					X = (index - 3.0) / 2,
					OriginalY = original

				;

				index++;
			}




			}
		}
    }
}
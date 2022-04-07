using System.Collections.Generic;

namespace yield
{
	public static class ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{
			bool start = true;
			double previousExpY = 0;
			foreach(var point in data)
            {
				if(start)
                {
					start = false;
					previousExpY = point.OriginalY;
                }
				else
                {
					previousExpY = alpha * point.OriginalY + (1 - alpha) * previousExpY;
                }
				yield return point.WithExpSmoothedY(previousExpY);
            }
		}
	}
}
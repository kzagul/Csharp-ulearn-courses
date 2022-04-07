using System;
namespace учусь_ООП
{
	public class RTriangle
	{
		public double Hypothenuse
		{
			get
			{
				return Math.Sqrt(Cathete1 * Cathete1 + Cathete2 * Cathete2);
			}
		}
		public double Cathete1;
		public double Cathete2;

		public static double AngleBetweenCathetes { get; } = Math.PI / 2;
	}
}

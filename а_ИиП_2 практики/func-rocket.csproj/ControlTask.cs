using System;
namespace func_rocket
{
	public class ControlTask
	{
        public static double expression;
        public static Turn ControlRocket(Rocket rocket, Vector target)
		{
            var vector = new Vector(target.X - rocket.Location.X, target.Y - rocket.Location.Y);
            if (Math.Abs(vector.Angle - rocket.Direction) < 0.5
                || Math.Abs(vector.Angle - rocket.Velocity.Angle) < 0.5)
            {
                var expression = (vector.Angle - rocket.Direction + vector.Angle - rocket.Velocity.Angle) / 2;
                if (expression < 0)
                    return Turn.Left;
                if (expression > 0)
                    return Turn.Right;
                else
                    return Turn.None;
            }
            else 
            {
                var expression = vector.Angle - rocket.Direction;
                if (expression < 0)
                    return Turn.Left;
                if (expression > 0)
                    return Turn.Right;
                else
                    return Turn.None;
            }
        }
	}
}
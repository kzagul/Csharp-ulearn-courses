using System;
using System.Collections.Generic;

namespace func_rocket
{
    public class LevelsTask
    {
        static readonly Physics sP = new Physics();
        static Rocket rocket = new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI);
        static Vector target = new Vector(600, 200);
        static Gravity whiteGravity = (size, speed) => {
            var delta = target - speed;
            var d = delta.Length;
            return delta.Normalize() * -140 * d / (d * d + 1);
        };
        static Gravity blackGravity = (size, speed) => {
            var delta = (target + rocket.Location) * 0.5 - speed;
            var d = delta.Length;
            return delta.Normalize() * 300 * d / (d * d + 1);
        };
        static Gravity mixedGravity = (size, speed) =>
            (whiteGravity(size, speed) + blackGravity(size, speed)) * 0.5;

        public static IEnumerable<Level> CreateLevels()
        {
            yield return new Level("Zero", rocket, target, (size, speed) => Vector.Zero, sP);
            yield return new Level("Heavy", rocket, target, (size, speed) => new Vector(0, 0.9), sP);

            target = new Vector(700, 500);
            yield return new Level("Up", rocket, target,
                (size, speed) => new Vector(0, -300 / (300 + size.Height - speed.Y)), sP);
            yield return new Level("WhiteHole", rocket, target, whiteGravity, sP);
            yield return new Level("BlackHole", rocket, target, blackGravity, sP);
            yield return new Level("BlackAndWhite", rocket, target, mixedGravity, sP);
        }
    }
}
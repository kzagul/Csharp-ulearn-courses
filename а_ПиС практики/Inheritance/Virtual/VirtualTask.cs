using System;
using System.Collections.Generic;
using System.Linq;

namespace Inheritance.Geometry.Virtual
{
    public abstract class Body
    {

        public abstract bool ContainsPoint(Vector3 point);

        public abstract RectangularCuboid GetBoundingBox();

        public Vector3 Position { get; }

        protected Body(Vector3 position)
        {
            Position = position;
        }

        //public bool ContainsPoint(Vector3 point)
        //{
        //    if (this is Ball ball)
        //    {
        //        var vector = point - Position;
        //        var length2 = vector.GetLength2();
        //        return length2 <= ball.Radius * ball.Radius;
        //    }

        //    if (this is RectangularCuboid cuboid)
        //    {
        //        var minPoint = new Vector3(
        //            Position.X - cuboid.SizeX / 2,
        //            Position.Y - cuboid.SizeY / 2,
        //            Position.Z - cuboid.SizeZ / 2);
        //        var maxPoint = new Vector3(
        //            Position.X + cuboid.SizeX / 2,
        //            Position.Y + cuboid.SizeY / 2,
        //            Position.Z + cuboid.SizeZ / 2);

        //        return point >= minPoint && point <= maxPoint;
        //    }

        //    if (this is Cylinder cylinder)
        //    {
        //        var vectorX = point.X - Position.X;
        //        var vectorY = point.Y - Position.Y;
        //        var length2 = vectorX * vectorX + vectorY * vectorY;
        //        var minZ = Position.Z - cylinder.SizeZ / 2;
        //        var maxZ = minZ + cylinder.SizeZ;

        //        return length2 <= cylinder.Radius * cylinder.Radius && point.Z >= minZ && point.Z <= maxZ;
        //    }

        //    if (this is CompoundBody compound)
        //    {
        //        return compound.Parts.Any(body => body.ContainsPoint(point));
        //    }

        //    throw new NotImplementedException("Unknown figure!");
        //}

        //public RectangularCuboid GetBoundingBox()
        //{
        //    throw new NotImplementedException("TODO");
        //}
    }

    public class Ball : Body
    {
        public double Radius { get; }

        public Ball(Vector3 position, double radius) : base(position)
        {
            Radius = radius;
        }
        public override bool ContainsPoint(Vector3 point)
        {   
            var vector = point - Position;
            var length2 = vector.GetLength2();
            return length2 <= this.Radius * this.Radius;
        }

        public override RectangularCuboid GetBoundingBox()
        {
            return new RectangularCuboid(base.Position, 2 * this.Radius, 2 * this.Radius, 2 * this.Radius);               
                //RectangularCuboid(Vector3 position, double sizeX, double sizeY, double sizeZ);
        }
    }


    public class RectangularCuboid : Body
    {
        public override bool ContainsPoint(Vector3 point)
        {
            var minPoint = new Vector3(
                    Position.X - this.SizeX / 2,
                    Position.Y - this.SizeY / 2,
                    Position.Z - this.SizeZ / 2);
            var maxPoint = new Vector3(
                Position.X + this.SizeX / 2,
                Position.Y + this.SizeY / 2,
                Position.Z + this.SizeZ / 2);

            return point >= minPoint && point <= maxPoint;
        }

        public override RectangularCuboid GetBoundingBox()
        {
            return new RectangularCuboid(this.Position, SizeX, SizeY, SizeZ);
        }

        public double SizeX { get; }
        public double SizeY { get; }
        public double SizeZ { get; }

        public RectangularCuboid(Vector3 position, double sizeX, double sizeY, double sizeZ) : base(position)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;
        }
    }

    public class Cylinder : Body
    {


        public override bool ContainsPoint(Vector3 point)
        {
            var vectorX = point.X - Position.X;
            var vectorY = point.Y - Position.Y;
            var length2 = vectorX * vectorX + vectorY * vectorY;
            var minZ = Position.Z - this.SizeZ / 2;
            var maxZ = minZ + this.SizeZ;

            return length2 <= this.Radius * this.Radius && point.Z >= minZ && point.Z <= maxZ;

        }

        public override RectangularCuboid GetBoundingBox()
        {
            return new RectangularCuboid(this.Position, 2 * this.Radius, 2 * this.Radius, this.SizeZ);
        }

        public double SizeZ { get; }

        public double Radius { get; }

        public Cylinder(Vector3 position, double sizeZ, double radius) : base(position)
        {
            SizeZ = sizeZ;
            Radius = radius;
        }
    }

    public class CompoundBody : Body
    {


        public override bool ContainsPoint(Vector3 point)
        {
            return this.Parts.Any(body => body.ContainsPoint(point));
        }

        public override RectangularCuboid GetBoundingBox()
        {

            IEnumerable<RectangularCuboid> cubes = Parts.Select((cube) => cube.GetBoundingBox());
            Vector3 pointMin = Position;
            Vector3 pointMax = Position;
            foreach (RectangularCuboid cube in cubes)
            {
                //pointMin = pointMin.GetMinVector(cube);
                
                Vector3 vector = pointMin - (cube.Position - new Vector3(cube.SizeX / 2, cube.SizeY / 2, cube.SizeZ / 2));
                pointMin = new Vector3(
                    vector.X > 0 ? pointMin.X - vector.X : pointMin.X,
                    vector.Y > 0 ? pointMin.Y - vector.Y : pointMin.Y,
                    vector.Z > 0 ? pointMin.Z - vector.Z : pointMin.Z);

                //pointMax = pointMax.GetMaxVector(cube);

                Vector3 vectorOther = pointMax - (cube.Position + new Vector3(cube.SizeX / 2, cube.SizeY / 2, cube.SizeZ / 2));
                pointMax = new Vector3(
                    vectorOther.X < 0 ? pointMax.X - vectorOther.X : pointMax.X,
                    vectorOther.Y < 0 ? pointMax.Y - vectorOther.Y : pointMax.Y,
                    vectorOther.Z < 0 ? pointMax.Z - vectorOther.Z : pointMax.Z);
            }
            Vector3 size = pointMax - pointMin;
            

            //var position = (pointMin + pointMax).DevideBy(2);

            
            var position = new Vector3(
                (pointMin + pointMax).X / 2, (pointMin + pointMax).Y / 2, (pointMin + pointMax).Z / 2);
            
            return new RectangularCuboid(position, size.X, size.Y, size.Z);
            
        }

        public IReadOnlyList<Body> Parts { get; }

        public CompoundBody(IReadOnlyList<Body> parts) : base(parts[0].Position)
        {
            Parts = parts;
        }
    }
    public static class Vector3Extended
    {
        public static Vector3 GetMinVector(this Vector3 obj, RectangularCuboid cuboid)
        {
            Vector3 vector = obj - (cuboid.Position - new Vector3(cuboid.SizeX / 2, cuboid.SizeY / 2, cuboid.SizeZ / 2));
            return new Vector3(
                vector.X > 0 ? obj.X - vector.X : obj.X,
                vector.Y > 0 ? obj.Y - vector.Y : obj.Y,
                vector.Z > 0 ? obj.Z - vector.Z : obj.Z);
        }
        public static Vector3 GetMaxVector(this Vector3 obj, RectangularCuboid cuboid)
        {
            Vector3 vector = obj - (cuboid.Position + new Vector3(cuboid.SizeX / 2, cuboid.SizeY / 2, cuboid.SizeZ / 2));
            return new Vector3(
                vector.X < 0 ? obj.X - vector.X : obj.X,
                vector.Y < 0 ? obj.Y - vector.Y : obj.Y,
                vector.Z < 0 ? obj.Z - vector.Z : obj.Z);
        }
        public static Vector3 DevideBy(this Vector3 obj, double number)
        {
            return new Vector3(obj.X / number, obj.Y / number, obj.Z / number);
        }
    }
}
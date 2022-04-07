
using System.Collections.Generic;
using System.Linq;

namespace Inheritance.Geometry.Visitor
{
    public interface IVisitor
    {
        Body Visit(Ball ball);
        Body Visit(RectangularCuboid cube);
        Body Visit(Cylinder cylinder);
        Body Visit(CompoundBody compoundBody);
    }

    public abstract class Body
    {
        public Vector3 Position { get; }

        public abstract Body Accept(IVisitor visitor);

        protected Body(Vector3 position)
        {
            this.Position = position;
        }
    }


    public class Ball : Body
    {
        public double Radius { get; }

        public Ball(Vector3 position, double radius) : base(position)
        {
            Radius = radius;
        }

        public override Body Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class RectangularCuboid : Body
    {
        public double SizeX { get; }
        public double SizeY { get; }
        public double SizeZ { get; }

        public RectangularCuboid(Vector3 position, double sizeX, double sizeY, double sizeZ) : base(position)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;
        }

        public override Body Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class Cylinder : Body
    {
        public double SizeZ { get; }

        public double Radius { get; }

        public Cylinder(Vector3 position, double sizeZ, double radius) : base(position)
        {
            SizeZ = sizeZ;
            Radius = radius;
        }

        public override Body Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class CompoundBody : Body
    {
        public IReadOnlyList<Body> Parts { get; }

        public CompoundBody(IReadOnlyList<Body> parts) : base(parts[0].Position)
        {
            Parts = parts;
        }

        public override Body Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class BoundingBoxVisitor : IVisitor
    {
        public Body Visit(Ball ball)
        {
            return new RectangularCuboid(ball.Position, 2 * ball.Radius, 2 * ball.Radius, 2 * ball.Radius);
        }

        public Body Visit(RectangularCuboid cube)
        {
            return new RectangularCuboid(cube.Position, cube.SizeX, cube.SizeY, cube.SizeZ);
        }

        public Body Visit(Cylinder cylinder)
        {
            return new RectangularCuboid(cylinder.Position, 2 * cylinder.Radius, 2 * cylinder.Radius, cylinder.SizeZ);
        }

        public Body Visit(CompoundBody compoundBody)
        {
            var cubes = compoundBody.Parts
                .Select(part => part.Accept(new BoundingBoxVisitor()) as RectangularCuboid);
            Vector3 pointMin = compoundBody.Position;
            Vector3 pointMax = compoundBody.Position;
            foreach (RectangularCuboid cube in cubes)
            {
                Vector3 vector = pointMin - (cube.Position - new Vector3(cube.SizeX / 2, cube.SizeY / 2, cube.SizeZ / 2));
                pointMin = new Vector3(
                    vector.X > 0 ? pointMin.X - vector.X : pointMin.X,
                    vector.Y > 0 ? pointMin.Y - vector.Y : pointMin.Y,
                    vector.Z > 0 ? pointMin.Z - vector.Z : pointMin.Z);

                Vector3 vectorOther = pointMax - (cube.Position + new Vector3(cube.SizeX / 2, cube.SizeY / 2, cube.SizeZ / 2));
                pointMax = new Vector3(
                    vectorOther.X < 0 ? pointMax.X - vectorOther.X : pointMax.X,
                    vectorOther.Y < 0 ? pointMax.Y - vectorOther.Y : pointMax.Y,
                    vectorOther.Z < 0 ? pointMax.Z - vectorOther.Z : pointMax.Z);
            }
            Vector3 size = pointMax - pointMin;

            var position = new Vector3(
                (pointMin + pointMax).X / 2, (pointMin + pointMax).Y / 2, (pointMin + pointMax).Z / 2);

            return new RectangularCuboid(position, size.X, size.Y, size.Z);

        }
    }

    public class BoxifyVisitor : IVisitor
    {
        public Body Visit(Ball ball)
        {
            return new RectangularCuboid(ball.Position, 2 * ball.Radius, 2 * ball.Radius, 2 * ball.Radius);
        }

        public Body Visit(RectangularCuboid cube)
        {
            return new RectangularCuboid(cube.Position, cube.SizeX, cube.SizeY, cube.SizeZ);
        }

        public Body Visit(Cylinder cylinder)
        {
            return new RectangularCuboid(cylinder.Position, 2 * cylinder.Radius, 2 * cylinder.Radius, cylinder.SizeZ);
        }

        public Body Visit(CompoundBody compoundBody)
        {
            var parts = compoundBody.Parts
                .Select(part => part.Accept(new BoundingBoxVisitor())).ToList();
            
            return new CompoundBody(parts);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Inheritance.Geometry.Virtual
{
    [TestFixture]
    public class VirtualTask_Should
    {
        [TestCase(0, 0, 0, 1)]
        [TestCase(6, 2, 4, 0)]
        [TestCase(-6, 2, 4, 0)]
        [TestCase(-6, -2, 4, 0)]
        [TestCase(-6, -2, -4, 0)]
        [TestCase(6, 2, -4, 0)]
        [TestCase(6, -2, -4, 0)]
        [TestCase(6, 2, 4, 2)]
        [TestCase(-6, 2, 4, 4)]
        [TestCase(-6, -2, 4, 9)]
        [TestCase(-6, -2, -4, 8)]
        [TestCase(6, 2, -4, 7)]
        [TestCase(6, -2, -4, 1)]
        public void Ball_ContainsPoint_IsCorrect(int x, int y, int z, double radius)
        {
            var ball = new Ball(new Vector3(x, y, z), radius);

            AssetContainsPoint(ball, true, ball.Position.X + radius / 2, ball.Position.Y + radius / 2, ball.Position.Z + radius / 2);
            ContainsPoint_ComplexTest(ball, true, radius);
            ContainsPoint_ComplexTest(ball, false, radius + 1);
        }

        [TestCase(0, 0, 0, 1)]
        [TestCase(6, 2, 4, 0)]
        [TestCase(-6, 2, 4, 0)]
        [TestCase(-6, -2, 4, 0)]
        [TestCase(-6, -2, -4, 0)]
        [TestCase(6, 2, -4, 0)]
        [TestCase(6, -2, -4, 0)]
        [TestCase(6, 2, 4, 2)]
        [TestCase(-6, 2, 4, 4)]
        [TestCase(-6, -2, 4, 9)]
        [TestCase(-6, -2, -4, 8)]
        [TestCase(6, 2, -4, 7)]
        [TestCase(6, -2, -4, 1)]
        public void Ball_BoundingBox_IsCorrect(double x, double y, double z, double radius)
        {
            var ball = new Ball(new Vector3(x, y, z), radius);
            var box = ball.GetBoundingBox();
            var length = radius * 2;
            var expectedBox = new RectangularCuboid(new Vector3(x, y, z), length, length, length);
            AssertCuboidsEqual(expectedBox, box);
        }

        [TestCase(0, 0, 0, 8, 8, 8)]
        [TestCase(6, 2, 4)]
        [TestCase(-6, 2, 4)]
        [TestCase(-6, -2, 4)]
        [TestCase(-6, -2, -4)]
        [TestCase(6, 2, -4)]
        [TestCase(6, -2, -4)]
        [TestCase(6, 2, 4, 4, 4, 4)]
        [TestCase(-6, 2, 4)]
        [TestCase(-6, -2, 4)]
        [TestCase(-6, -2, -4)]
        [TestCase(6, 2, -4)]
        [TestCase(6, -2, -4)]
        public void RectangularCuboid_ContainsPoint_IsCorrect(
            double x, double y, double z,
            double sizeX = 8, double sizeY = 4, double sizeZ = 6)
        {
            var cuboid = new RectangularCuboid(new Vector3(x, y, z), sizeX, sizeY, sizeZ);

            ContainsPoint_ComplexTest(cuboid, true, sizeX / 2, sizeY / 2, sizeZ / 2);
            ContainsPoint_ComplexTest(cuboid, false, sizeX / 2 + 1, sizeY / 2 + 1, sizeZ / 2 + 1);
        }

        [TestCase(0, 0, 0, 1, 2, 3)]
        [TestCase(6, 2, 4, 5, 4, 7)]
        [TestCase(-6, 2, 4, 5, 5, 5)]
        [TestCase(-6, -2, 4, 0)]
        [TestCase(-6, -2, -4, 0)]
        [TestCase(6, 2, -4, 0)]
        [TestCase(6, -2, -4, 0)]
        [TestCase(6, 2, 4, 2)]
        [TestCase(-6, 2, 4, 4)]
        [TestCase(-6, -2, 4, 9)]
        [TestCase(-6, -2, -4, 8)]
        [TestCase(6, 2, -4, 7)]
        [TestCase(6, -2, -4, 1)]
        public void RectangularCuboid_BoundingBox_IsCorrect(
            double x, double y, double z,
            double sizeX = 4, double sizeY = 7, double sizeZ = 5)
        {
            var cuboid = new RectangularCuboid(new Vector3(x, y, z), sizeX, sizeY, sizeZ);
            var box = cuboid.GetBoundingBox();
            AssertCuboidsEqual(cuboid, box);
        }

        [TestCase(0, 0, 0, 2, 8)]
        [TestCase(6, 2, 4, 6, 4)]
        [TestCase(-6, 2, 4, 6, 4)]
        [TestCase(-6, -2, 4)]
        [TestCase(-6, -2, -4)]
        [TestCase(6, 2, -4)]
        [TestCase(6, -2, -4)]
        [TestCase(6, 2, 4)]
        [TestCase(-6, 2, 4)]
        [TestCase(-6, -2, 4)]
        [TestCase(-6, -2, -4)]
        [TestCase(6, 2, -4)]
        [TestCase(6, -2, -4)]
        public void Cylinder_ContainsPoint_IsCorrect(
            double x, double y, double z,
            double radius = 4, double sizeZ = 8)
        {
            var cylinder = new Cylinder(new Vector3(x, y, z), sizeZ, radius);
            ContainsPoint_ComplexTest(cylinder, true, radius, radius, sizeZ / 2);
            ContainsPoint_ComplexTest(cylinder, false, radius + 1, radius + 1, sizeZ / 2 + 1);
        }

        [TestCase(0, 0, 0, 1, 2)]
        [TestCase(6, 2, 4, 5, 4)]
        [TestCase(-6, 2, 4, 5, 5)]
        [TestCase(-6, -2, 4)]
        [TestCase(-6, -2, -4)]
        [TestCase(6, 2, -4)]
        [TestCase(6, -2, -4)]
        [TestCase(6, 2, 4)]
        [TestCase(-6, 2, 4)]
        [TestCase(-6, -2, 4)]
        [TestCase(-6, -2, -4)]
        [TestCase(6, 2, -4)]
        [TestCase(6, -2, -4)]
        public void Cylinder_BoundingBox_IsCorrect(double x, double y, double z, double radius = 4, double sizeZ = 5)
        {
            var cylinder = new Cylinder(new Vector3(x, y, z), sizeZ, radius);
            var box = cylinder.GetBoundingBox();
            var cuboid = new RectangularCuboid
            (
                cylinder.Position,
                cylinder.Radius * 2,
                cylinder.Radius * 2,
                cylinder.SizeZ
            );
            AssertCuboidsEqual(cuboid, box);
        }

        [TestCase(0, 0, 0, 1)]
        [TestCase(0, 0, 0, 6)]
        [TestCase(0, 0, 0, 7)]
        [TestCase(1, 1, 1, 7)]
        [TestCase(2, 3, 6, 5)]
        [TestCase(-2, -3, 6, 3)]
        [TestCase(-12, -23, -46, 13)]
        [TestCase(12, -23, 6, 14)]
        [TestCase(8, 5, -16, 12)]
        public void CompoundBody_ContainsPoint_IsCorrect(double x, double y, double z, double radius)
        {
            const int indent = 2;
            foreach (var compoundBody in GetCompoundBodies(new Vector3(x, y, z), radius, indent))
            {
                TestCompoundBodyContainsPoint(compoundBody, radius * 100);
            }
        }

        [Test]
        public void CompoundBody_WithBall_ContainsPoint_IsCorrect()
        {
            AssertCompoundBodyWithSinglePart_Contains_IsEquivalentToItsPartContains(
                new Ball(new Vector3(1, 2, 3), 4));
            AssertCompoundBodyWithSinglePart_Contains_IsEquivalentToItsPartContains(
                new RectangularCuboid(new Vector3(-1, 2, -3), 4, 3, 2));
            AssertCompoundBodyWithSinglePart_Contains_IsEquivalentToItsPartContains(
                new Cylinder(new Vector3(-1, -2, -3), 4, 3));
            AssertCompoundBodyWithSinglePart_Contains_IsEquivalentToItsPartContains(
                new Cylinder(new Vector3(-1, -2, -3), 4, 3));
        }

        [TestCase(1, 2, 3, 2, 1, 3, 5, 5, 4)]
        [TestCase(1, 1, 1, 2, 2, 2, 5, 5, 5)]
        [TestCase(2, 1, 1, 1, 2, 2, 5, 5, 5)]
        public void CompoundBody_Of_TwoCuboids_BoundingBox_Correct(double x0, double y0, double z0, double x1, double y1, double z1, double expectedSizeX, double expectedSizeY, double expectedSizeZ)
        {
            var compoundBody = new CompoundBody(new[]
            {
                new RectangularCuboid(new Vector3(x0, y0, z0), 4, 4, 4), 
                new RectangularCuboid(new Vector3(x1, y1, z1), 4, 4, 4),
            });
            var boundingBox = compoundBody.GetBoundingBox();
            Assert.AreEqual(expectedSizeX, boundingBox.SizeX, "SizeX");
            Assert.AreEqual(expectedSizeY, boundingBox.SizeY, "SizeY");
            Assert.AreEqual(expectedSizeZ, boundingBox.SizeZ, "SizeZ");
        }

        [TestCase(0, 0, 0, 1)]
        [TestCase(0, 0, 0, 6)]
        [TestCase(0, 0, 0, 7)]
        [TestCase(1, 1, 1, 7)]
        [TestCase(2, 3, 6, 5)]
        [TestCase(-2, -3, 6, 3)]
        [TestCase(-12, -23, -46, 13)]
        [TestCase(12, -23, 6, 14)]
        [TestCase(8, 5, -16, 12)]
        public void CompoundBody_BoundingBox_IsCorrect(double x, double y, double z, double radius)
        {
            const int figuresCount = 6;
            const double indent = 2.2;
            var sizeZ = radius * 20 + indent * (figuresCount - 1);
            var expectedBox = new RectangularCuboid(new Vector3(x, y, sizeZ / 2 + z), radius * 2, radius * 2, sizeZ);

            foreach (var compoundBody in GetCompoundBodies(new Vector3(x, y, z), radius, indent))
            {
                AssertCuboidsEqual(expectedBox, compoundBody.GetBoundingBox());
            }
        }

        public static IEnumerable<CompoundBody> GetCompoundBodies(Vector3 startPosition, double radius, double indent)
        {
            var ball = GetBall(startPosition, radius);
            var cylinder = GetCylinder(ball.Position.CreatePoint(dz: ball.Radius + indent), radius);
            var box = GetRectangularCuboid(cylinder.Position.CreatePoint(dz: cylinder.SizeZ / 2 + indent), radius);
            var compound = GetCompoundBody(box.Position.CreatePoint(dz: box.SizeZ / 2 + indent), radius, indent);
            yield return new CompoundBody(new List<Body> { ball, cylinder, box, compound });


            var cylinder2 = GetCylinder(startPosition, radius);
            var ball2 = GetBall(cylinder2.Position.CreatePoint(dz: cylinder2.SizeZ / 2 + indent), radius);
            var box2 = GetRectangularCuboid(ball2.Position.CreatePoint(dz: ball2.Radius + indent), radius);
            var compound2 = GetCompoundBody(box2.Position.CreatePoint(dz: box2.SizeZ / 2 + indent), radius, indent);
            yield return new CompoundBody(new List<Body> { cylinder2, ball2, box2, compound2 });

            var cylinder3 = GetCylinder(startPosition, radius); //
            var box3 = GetRectangularCuboid(cylinder3.Position.CreatePoint(dz: cylinder3.SizeZ / 2 + indent), radius);
            var ball3 = GetBall(box3.Position.CreatePoint(dz: box3.SizeZ / 2 + indent), radius);
            var compound3 = GetCompoundBody(ball3.Position.CreatePoint(dz: ball3.Radius + indent), radius, indent);
            yield return new CompoundBody(new List<Body> { cylinder3, box3, ball3, compound3 });
        }

        private static void AssertCompoundBodyWithSinglePart_Contains_IsEquivalentToItsPartContains(Body part)
        {
            var random = new Random(123123);
            var compound = new CompoundBody(new List<Body> { part });
            var compound2 = new CompoundBody(new List<Body> { compound });
            for (int i = 0; i < 1000; i++)
            {
                var p = new Vector3(
                    random.NextDouble() * 20 - 10,
                    random.NextDouble() * 20 - 10,
                    random.NextDouble() * 20 - 10);
                Assert.AreEqual(part.ContainsPoint(p), compound.ContainsPoint(p));
                Assert.AreEqual(part.ContainsPoint(p), compound2.ContainsPoint(p));
            }
        }

        private void TestCompoundBodyContainsPoint(CompoundBody compoundBody, double radius)
        {
            foreach (var part in compoundBody.Parts)
            {
                Assert.IsTrue(compoundBody.ContainsPoint(part.Position));
                Assert.IsFalse(compoundBody.ContainsPoint(part.Position.CreatePoint(dx: radius)));
                Assert.IsFalse(compoundBody.ContainsPoint(part.Position.CreatePoint(dy: radius)));
                Assert.IsFalse(compoundBody.ContainsPoint(part.Position.CreatePoint(dz: radius)));
            }
        }

        public static Ball GetBall(Vector3 fromPoint, double radius)
        {
            return new Ball(new Vector3(fromPoint.X, fromPoint.Y, fromPoint.Z + radius), radius);
        }

        public static Cylinder GetCylinder(Vector3 fromPoint, double radius)
        {
            return new Cylinder(new Vector3(fromPoint.X, fromPoint.Y, fromPoint.Z + radius), radius * 2, radius);
        }

        public static RectangularCuboid GetRectangularCuboid(Vector3 fromPoint, double radius)
        {
            var sizeZ = radius * 4;
            return new RectangularCuboid
            (
                new Vector3(fromPoint.X, fromPoint.Y, fromPoint.Z + sizeZ / 2),
                radius * 2,
                radius * 2,
                sizeZ
            );
        }

        public static CompoundBody GetCompoundBody(Vector3 fromPoint, double radius, double indent)
        {
            var box1 = GetRectangularCuboid(fromPoint, radius);
            var box2 = GetRectangularCuboid(box1.Position.CreatePoint(dz: box1.SizeZ / 2 + indent), radius);
            var box3 = GetRectangularCuboid(box2.Position.CreatePoint(dz: box2.SizeZ / 2 + indent), radius);
            return new CompoundBody(new List<Body> { box1, box2, box3 });
        }

        private void AssertCuboidsEqual(RectangularCuboid expected, RectangularCuboid actual)
        {
            var message = " is not equal!";
            Assert.That(expected.Position.Equals(actual.Position, Constants.Inaccuracy), $"{expected.Position} != {actual.Position}");
            Assert.AreEqual(expected.SizeX, actual.SizeX, Constants.Inaccuracy, "Length" + message);
            Assert.AreEqual(expected.SizeY, actual.SizeY, Constants.Inaccuracy, "Width" + message);
            Assert.AreEqual(expected.SizeZ, actual.SizeZ, Constants.Inaccuracy, "Height" + message);
        }

        public void ContainsPoint_ComplexTest(Body testBody, bool expected, double dx)
            => ContainsPoint_ComplexTest(testBody, expected, dx, dx, dx);

        public void ContainsPoint_ComplexTest(Body testBody, bool expected, double dx, double dy, double dz)
            => ContainsPoint_ComplexTest(testBody, expected, testBody.Position, dx, dy, dz);

        public void ContainsPoint_ComplexTest(Body testBody, bool expected, Vector3 startPosition, double dx, double dy, double dz)
        {
            AssetContainsPoint(testBody, true, startPosition.X, startPosition.Y, startPosition.Z);

            AssetContainsPoint(testBody, expected, startPosition.X, startPosition.Y, startPosition.Z + dz);
            AssetContainsPoint(testBody, expected, startPosition.X, startPosition.Y + dy, startPosition.Z);
            AssetContainsPoint(testBody, expected, startPosition.X + dx, startPosition.Y, startPosition.Z);
            AssetContainsPoint(testBody, expected, startPosition.X, startPosition.Y, startPosition.Z - dz);
            AssetContainsPoint(testBody, expected, startPosition.X, startPosition.Y - dy, startPosition.Z);
            AssetContainsPoint(testBody, expected, startPosition.X - dx, startPosition.Y, startPosition.Z);
        }

        private void AssetContainsPoint(Body body, bool expected, double x, double y, double z)
        {
            Assert.AreEqual(expected, body.ContainsPoint(new Vector3(x, y, z)));
        }
    }
}

using System.Collections.Generic;
using NUnit.Framework;

namespace Inheritance.Geometry.Visitor
{
    [TestFixture]
    public class BoxifyVisitor_Should
    {
        [Test]
        public void Ball_BoxifyVisitor_IsCorrect()
        {
            const int radius = 4;
            var start = new Vector3(1, 2, 3);
            var ball = new Ball(start, radius);
            var box = ball.TryAcceptVisitor<RectangularCuboid>(new BoxifyVisitor());
            var side = radius * 2;
            var expectedBox = new RectangularCuboid(start, side, side, side);
            AssertCuboidsEqual(expectedBox, box);
        }
        
        [Test]
        public void RectangularCuboid_BoxifyVisitor_IsCorrect()
        {
            var start = new Vector3(1, 2, 3);
            var cuboid = new RectangularCuboid(start, 5, 4, 3);
            var box = cuboid.TryAcceptVisitor<RectangularCuboid>(new BoxifyVisitor());
            AssertCuboidsEqual(cuboid, box);
        }

        [Test]
        public void Cylinder_BoxifyVisitor_IsCorrect()
        {
            const int radius = 4;
            const int height = 6;
            var start = new Vector3(1, 2, 3);
            var cylinder = new Cylinder(start, height, radius);
            var box = cylinder.TryAcceptVisitor<RectangularCuboid>(new BoxifyVisitor());
            var side = radius * 2;
            var expectedBox = new RectangularCuboid(start, side, side, height);
            AssertCuboidsEqual(expectedBox, box);
        }

        [Test]
        public void CompoundBody_BoxifyVisitor_IsCorrect()
        {
            var ball = new Ball(new Vector3(1,2,3), 4);
            var box = new RectangularCuboid(new Vector3(8,9,10), 2, 3, 4);
            var cylinder = new Cylinder(new Vector3(-5, -6, -10), 3, 5);
            var cBall = new Ball(new Vector3(12, 12, 12), 2);
            var cBox = new RectangularCuboid(new Vector3(-12, -12, -12), 2, 2, 2);
            var cCylinder = new Cylinder(new Vector3(25, 25, 25), 2, 3);
            var compound = new CompoundBody(new List<Body> {cBall, cBox, cCylinder});
            var compoundBody = new CompoundBody(new List<Body>{ball, box, cylinder, compound});

            var actual = compoundBody.TryAcceptVisitor<CompoundBody>(new BoxifyVisitor());
            AssertCompoundBodyBoxified(compoundBody, actual);
        }

        private void AssertCompoundBodyBoxified(CompoundBody source, CompoundBody boxifiedBody)
        {
            Assert.AreEqual(source.Parts.Count, boxifiedBody.Parts.Count);
            for (var i = 0; i < source.Parts.Count; i++)
            {
                if (source.Parts[i] is CompoundBody compound)
                {
                    Assert.That(boxifiedBody.Parts[i], Is.InstanceOf<CompoundBody>());
                    AssertCompoundBodyBoxified(compound, (CompoundBody)boxifiedBody.Parts[i]);
                }
                else
                {
                    Assert.That(boxifiedBody.Parts[i], Is.InstanceOf<RectangularCuboid>());
                    Assert.IsTrue(source.Parts[i].Position.Equals(boxifiedBody.Parts[i].Position, Constants.Inaccuracy),
                        $"{boxifiedBody.Parts[i].Position} != {source.Parts[i].Position}");
                }
            }
        }

        private void AssertCuboidsEqual(RectangularCuboid expected, RectangularCuboid actual)
        {
            var message = " is not equal!";
            Assert.That(expected.Position.Equals(actual.Position, Constants.Inaccuracy), $"{expected.Position} != {actual.Position}");
            Assert.AreEqual(expected.SizeX, actual.SizeX, Constants.Inaccuracy, "Length" + message);
            Assert.AreEqual(expected.SizeY, actual.SizeY, Constants.Inaccuracy, "Width" + message);
            Assert.AreEqual(expected.SizeZ, actual.SizeZ, Constants.Inaccuracy, "Height" + message);
        }
    }
}

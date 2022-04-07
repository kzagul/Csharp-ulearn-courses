using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Robots
{
    [TestFixture]
    public class Architecture_Should
    {
        [Test]
        public void BeCorrectForShooterAiWithShooterMover()
        {
            var robot = Robot.Create<IMoveCommand>(new ShooterAI(), new ShooterMover());
            var result = robot.Start(5);

            string ShouldHide(int step) => step % 3 == 0 ? "YES" : "NO";

            var dueResult = Enumerable.Range(1, 5).Select(z => $"MOV {z * 2}, {z * 3}, USE COVER {ShouldHide(z)}");
            CollectionAssert.AreEqual(dueResult, result);
        }

        [Test]
        public void BeCorrectForShooterAiWithStandardMover()
        {
            // Тут мы хотим робота с ShooterMoveCommand. Стандартный Mover ничего не знает про IShooterMoveCommand,
            // но всё равно нам подходит благодаря контрвариации, которую вы добавите в своё решение.
            var robot = Robot.Create<IMoveCommand>(new ShooterAI(), new Mover());
            var result = robot.Start(5);
            var dueResult = Enumerable.Range(1, 5).Select(z => $"MOV {z * 2}, {z * 3}");
            CollectionAssert.AreEqual(dueResult, result);
        }

        [Test]
        public void BeCorrectForBuilder()
        {
            // BuilderAI подходит благодаря ковариации, которую вы добавите в свое решение.
            var robot = Robot.Create<IMoveCommand>(new BuilderAI(), new Mover());
            var result = robot.Start(5).ToArray();
            var dueResult = Enumerable.Range(1, 5).Select(z => $"MOV {z}, {z}");
            CollectionAssert.AreEqual(dueResult, result);
        }
    }
}

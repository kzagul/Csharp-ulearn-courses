using NUnit.Framework;
using Kvur;

namespace KvurTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RightSolve()
        {

            var a = 1;
            var b = -3;
            var c = 2;

            var result = KvurSolver.Kvur(a, b, c);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result[0]);
            Assert.AreEqual(1, result[1]);
            
        }

        [Test]
        public void NoSolution()
        {

            var a = 1;
            var b = 1;
            var c = 1;

            var result = KvurSolver.Kvur(a, b, c);

            Assert.AreEqual(0, result.Count);
            

        }


    }
}
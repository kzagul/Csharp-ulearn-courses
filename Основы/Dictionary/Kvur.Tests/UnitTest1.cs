using System;
using Xunit;
using Kvur;

namespace Kvur.Tests
{
    public class UnitTest1
    {
        [Fact]
        
        public void Test1()
        {
            var a = 1;
            var b = -3;
            var c = 2;

            var result = KvurSolver.Kvur(a, b, c);

            


            /*
            Assert.Are(2, result.Length);
            Assert.AreEqual(2, result[0]);
            Assert.AreEqual(1, result[1]);
            */
        }
    }
}

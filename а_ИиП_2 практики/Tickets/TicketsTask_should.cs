using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
	[TestFixture]
    public class TicketsTask_should
    {
        public void MakeTest(int halfLen, int totalSum, string answer)
        {
            var result = BigInteger.Parse(answer);
            Assert.AreEqual(result, TicketsTask.Solve(halfLen, totalSum));
        }

        [Test]
        public void Test1() { MakeTest(2, 2, "4"); }
        [Test]
        public void Test2() { MakeTest(2, 5, "0"); }
        [Test]
        public void Test6() { MakeTest(10, 10, "4008004"); }
        [Test]
        public void Test7() { MakeTest(20, 20, "401200499400100"); }


        [Test]
        public void Test10() { MakeTest(2, 2, "4"); }
        [Test]
        public void Test20() { MakeTest(2, 5, "0"); }
        [Test]
        public void Test3() { MakeTest(1, 18, "1"); }
        [Test]
        public void Test4() { MakeTest(2, 20, "81"); }
        [Test]
        public void Test5() { MakeTest(3, 54, "1"); }
        [Test]
        public void Test60() { MakeTest(10, 10, "4008004"); }
        [Test]
        public void Test70() { MakeTest(20, 20, "401200499400100"); }
        [Test]
        public void Test8() { MakeTest(3, 52, "9"); }
        [Test]
        public void Test9() { MakeTest(50, 50, "1228576490354119571810717714807944388004"); }





    }
}

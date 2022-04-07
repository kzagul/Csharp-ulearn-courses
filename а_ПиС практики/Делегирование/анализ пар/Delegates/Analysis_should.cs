using NUnit.Framework;
using System;
using System.Globalization;
using System.Linq;

namespace Delegates.PairsAnalysis
{
    [TestFixture]
    public class Analysis_should
    {
        [TestCase(0, new[] { "2001.01.11", "2001.01.12" })]
        [TestCase(2, new[] { "2001.01.11", "2001.01.12", "2001.01.13", "2001.01.20", "2001.01.21" })]
        [TestCase(4, new[] { "2001.01.11", "2001.01.12", "2001.01.13", "2001.01.20", "2001.01.21", "2001.01.31" })]
        public void FindMaxPeriodIndex_ProcessDatesCorrectly(int expectedIndex, string[] dates)
        {
            var parsedDates = dates.Select(d => DateTime.ParseExact(d, "yyyy.MM.dd", CultureInfo.InvariantCulture)).ToArray();
            var actualIndex = Analysis.FindMaxPeriodIndex(parsedDates);
            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [Test]
        public void FindMaxPeriodIndex_ThrowsAtEmptyCollection()
        {
            Assert.Throws(typeof(InvalidOperationException), () => Analysis.FindMaxPeriodIndex());
        }

        [Test]
        public void FindMaxPeriodIndex_ThrowsAtOneElementCollection()
        {
            Assert.Throws(typeof(InvalidOperationException), () => Analysis.FindMaxPeriodIndex(new DateTime(2001, 1, 1)));
        }

        [TestCase(0.0, new[] { 0.1, 0.1 })]
        [TestCase(1.0, new[] { 0.1, 0.2 })]
        [TestCase(-1.0, new[] { 0.1, 0.0 })]
        [TestCase(0.1, new[]{1, 1.1, 1.21, 1.331})]
        [TestCase(1.5, new[]{0.2, 0.5, 1.25})]
        public void FindAverageRelativeDifference_ProcessDoublesCorrectly(double expectedAverage, double[] array)
        {
            Assert.AreEqual(
                expectedAverage,
                Analysis.FindAverageRelativeDifference(array),
                1e-5);
        }

        [Test]
        public void FindAverageRelativeDifference_ThrowsAtEmptyCollection()
        {
            Assert.Throws(typeof(InvalidOperationException), () => Analysis.FindAverageRelativeDifference());
        }

        [Test]
        public void FindAverageRelativeDifference_ThrowsAtOneElementCollection()
        {
            Assert.Throws(typeof(InvalidOperationException), () => Analysis.FindAverageRelativeDifference(0.1));
        }
    }
}

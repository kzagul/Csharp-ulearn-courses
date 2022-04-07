using NUnit.Framework;
using System;
using System.Linq;

namespace Generics.Tables
{
    [TestFixture]
    public class TableOpenIndex_should
    {
        [Test]
        public void AddColumnsAndRows()
        {
            var table = new Table<int, string, double>();
            table.Open[1, "2"] = 3;
            Assert.AreEqual(3, table.Open[1, "2"]);
            Assert.AreEqual(1, table.Rows.Count());
            Assert.AreEqual(1, table.Columns.Count());
        }

        [Test]
        public void DontAddExistedColumnsAndRows1()
        {
            var table = new Table<int, string, double>();
            table.AddRow(1);
            table.AddColumn("2");
            table.Open[1, "2"] = 3;

            Assert.AreEqual(3, table.Open[1, "2"]);
            Assert.AreEqual(1, table.Rows.Count());
            Assert.AreEqual(1, table.Columns.Count());
        }

        [Test]
        public void DontAddExistedColumnsAndRows2()
        {
            var table = new Table<int, string, double>();
            table.Open[1, "2"] = 3;
            table.AddRow(1);
            table.AddColumn("2");

            Assert.AreEqual(3, table.Open[1, "2"]);
            Assert.AreEqual(1, table.Rows.Count());
            Assert.AreEqual(1, table.Columns.Count());
        }

        [Test]
        public void ReturnDefaultIfNoValueSet1()
        {
            var table = new Table<int, string, double>();
            Assert.AreEqual(0, table.Open[1, "2"]);
            Assert.AreEqual(0, table.Rows.Count());
            Assert.AreEqual(0, table.Columns.Count());
        }

        [Test]
        public void ReturnDefaultIfNoValueSet2()
        {
            var table = new Table<int, string, double>();
            table.AddRow(1);
            table.AddColumn("2");
            Assert.AreEqual(0, table.Open[1, "2"]);
            Assert.AreEqual(1, table.Rows.Count());
            Assert.AreEqual(1, table.Columns.Count());
        }
    }

    [TestFixture]
    public class TableExistedIndex_should
    {
        [Test]
        public void FailIfGettingFromNonExistingRow()
        {
            var table = new Table<string, int, double>();
            table.AddColumn(1);
            Assert.Throws(typeof(ArgumentException), () => Console.Write(table.Existed["1", 1]));
        }
        [Test]
        public void FailIfGettingFromNonExistingColumn()
        {
            var table = new Table<string, int, double>();
            table.AddRow("1");
            Assert.Throws(typeof(ArgumentException), () => Console.Write(table.Existed["1", 1]));
        }
        [Test]
        public void FailIfSettingToNonExistingRow()
        {
            var table = new Table<string, int, double>();
            table.AddColumn(1);
            Assert.Throws(typeof(ArgumentException), () => table.Existed["1", 1] = 1);
        }
        [Test]
        public void FailIfSettingToNonExistingColumn()
        {
            var table = new Table<string, int, double>();
            table.AddRow("1");
            Assert.Throws(typeof(ArgumentException), () => table.Existed["1", 1] = 1);
        }

        [Test]
        public void SetToExistedRowAndColumn()
        {
            var table = new Table<string, int, double>();
            table.AddRow("1");
            table.AddColumn(1);
            table.Existed["1", 1] = 1;
            Assert.AreEqual(1, table.Existed["1", 1]);
        }

        [Test]
        public void GetDefaultIfNoValueSet()
        {
            var table = new Table<string, int, double>();
            table.AddRow("1");
            table.AddColumn(1);
            Assert.AreEqual(0, table.Existed["1", 1]);
        }
    }

    [TestFixture]
    public class TableBothIndices_should
    {
        [Test]
        public void WorkTogether1()
        {
            var table = new Table<string, int, double>();
            table.AddRow("1");
            table.AddColumn(1);
            table.Existed["1", 1] = 2;
            Assert.AreEqual(2, table.Open["1", 1]);
        }

        [Test]
        public void WorkTogether2()
        {
            var table = new Table<string, int, double>();
            table.Open["1", 1] = 2;
            Assert.AreEqual(2, table.Existed["1", 1]);
        }

        [Test]
        public void WorkTogether3()
        {
            var table = new Table<string, int, double>();
            table.AddRow("1");
            var existed = table.Existed;
            table.Open["10", 20] = 1;
            Assert.Throws(typeof(ArgumentException), () => Console.Write(existed["1", 1]));
        }
    }
}

using System;
using System.Collections.Generic;

namespace Generics.Tables
{
    public class Counter
    {
        int count { get; set; }

        public void Increase()
        {
            count++;
        }

        public int Count()
        {
            return count;
        }
    }
    public class Table<TRows, TColumns, TValue>
    {
        readonly Dictionary<TRows, Dictionary<TColumns, TValue>> table =
            new Dictionary<TRows, Dictionary<TColumns, TValue>>();

        public Counter Rows = new Counter();
        public Counter Columns = new Counter();

        bool AddRowUncounted(TRows rowItem)
        {
            if (table.ContainsKey(rowItem))return false;
            table.Add(rowItem, new Dictionary<TColumns, TValue>());
            return true;
        }

        public void AddRow(TRows rowItem)
        {
            if (AddRowUncounted(rowItem)) Rows.Increase();
        }

        bool AddColumnUncounted(TColumns columnItem)
        {
            var e = table.Keys.GetEnumerator();
            e.MoveNext();
            if (e.Current == null || table[e.Current].ContainsKey(columnItem))return false;
            foreach (TRows row in table.Keys)
                table[row][columnItem] = default(TValue);
            return true;
        }

        public void AddColumn(TColumns columnItem)
        {
            if (AddColumnUncounted(columnItem)) Columns.Increase();
        }

        public AccessorOpen Open => new AccessorOpen(this);
        public AccessorExisted Existed => new AccessorExisted(this);

        public class AccessorOpen
        {
            readonly Table<TRows, TColumns, TValue> owner;

            public AccessorOpen(Table<TRows, TColumns, TValue> owner)
            {
                this.owner = owner;
            }

            public TValue this[TRows row, TColumns column]
            {
                get
                {
                    owner.AddRowUncounted(row);
                    owner.AddColumnUncounted(column);
                    if (!owner.table.ContainsKey(row)
                        || !owner.table[row].ContainsKey(column))
                        throw new ArgumentException();
                    return owner.table[row][column];
                }
                set
                {
                    owner.AddRow(row);
                    owner.AddColumn(column);
                    if (!owner.table.ContainsKey(row)
                        || !owner.table[row].ContainsKey(column))
                        throw new ArgumentException();
                    owner.table[row][column] = value;
                }
            }
        }

        public class AccessorExisted
        {
            readonly Table<TRows, TColumns, TValue> owner;

            public AccessorExisted(Table<TRows, TColumns, TValue> owner)
            {
                this.owner = owner;
            }

            public TValue this[TRows row, TColumns column]
            {
                get
                {
                    if (!owner.table.ContainsKey(row)
                        || !owner.table[row].ContainsKey(column))
                        throw new ArgumentException();
                    return owner.table[row][column];
                }
                set
                {
                    if (!owner.table.ContainsKey(row)
                        || !owner.table[row].ContainsKey(column))
                        throw new ArgumentException();
                    owner.table[row][column] = value;
                }
            }
        }
    }
}
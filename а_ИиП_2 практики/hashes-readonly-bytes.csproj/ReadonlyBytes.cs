using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace hashes
{
    public class ReadonlyBytes : IEnumerable<byte>
    {
        readonly byte[] array;
        int hash;

		public ReadonlyBytes(params byte[] bytes)
        {
			if (bytes == null) throw new ArgumentNullException();
			array = bytes;
        }

        public IEnumerator<byte> GetEnumerator()
        {
			foreach (var elem in array)
				yield return elem;
        }

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ReadonlyBytes other)
				|| other.GetType().IsSubclassOf(this.GetType())
				|| array.Length != other.Length) // реализовываем отдельно
				return false;
			for (int i = 0; i < Length; i++)
				if (array[i] != other[i]) return false;
			return true;
		}

		internal byte this[int index]
        {
			get
			{
				try
				{
					return array[index];
				}
				catch (IndexOutOfRangeException e)
				{
					throw e;
				}
			}
            set
            {
				try
				{
					array[index] = value;
				}
				catch (IndexOutOfRangeException e)
				{
					throw e;
				}
			}
        }

		public int Length
		{
			get
			{
				return array.Length;
			}
		}

        public override string ToString()
        {
			if (array.Length == 0) return "[]";
			var builder = new StringBuilder();
			builder.Append("[");
			for (int i = 0; i < array.Length; i++)
				builder.Append(i == array.Length - 1 ? $"{array[i]}]" : $"{array[i]}, ");
			return builder.ToString();
		}

        public override int GetHashCode()
		{
			if (hash != default(int))
				return hash;
			unchecked
			{
				const uint fnv = 0x01000193;
				uint hval = 0x811c9dc5;
				foreach (var elem in array)
                {
					hval *= fnv;
					hval ^= elem;
                }
				hash = (int)hval;
				return hash;
			}
		}
	}
}
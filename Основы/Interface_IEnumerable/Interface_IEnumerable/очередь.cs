using System;
using System.Collections;
using System.Collections.Generic;

namespace Interface_IEnumerable
{
    public class Queue<T> : IEnumerable<T>
    {
		QueueItem<T> head;
		QueueItem<T> tail;

		public  IEnumerator<T> GetEnumerator()
		{
			var current = head;
			while (current != null)
            {
				yield return current.Value;
				current = current.Next;
            }
		}




		
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		public bool IsEmpty { get { return head == null; } }

		public void Enqueue(T value)
		{
			if (IsEmpty)
				tail = head = new QueueItem<T> { Value = value, Next = null };
			else
			{
				var item = new QueueItem<T> { Value = value, Next = null };
				tail.Next = item;
				tail = item;
			}
		}

		public T Dequeue()
		{
			if (head == null) throw new InvalidOperationException();
			var result = head.Value;
			head = head.Next;
			if (head == null)
				tail = null;
			return result;
		}

		//NEW Class

		
	}


    public class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }
    }
}

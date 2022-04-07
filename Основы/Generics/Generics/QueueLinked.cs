using System;
namespace Generics
{
    public class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }
    }

    


    public class Queue<T>
    {
        QueueItem<T> head;
        QueueItem<T> tail;

        public bool IsEmpty { get { return head == null; } }

        public void Enqueue(T value)
        {
            if (head == null)
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
    }
}

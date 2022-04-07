using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Generics.BinaryTrees
{
    public class BinaryTree
    {
        public static BinaryTree<T> Create<T>(params T[] list) where T : IComparable
        {
            BinaryTree<T> binaryTree = new BinaryTree<T>();
            foreach (var e in list)
                binaryTree.Add(e);
            return binaryTree;
        }
    }

    public class BinaryNode<T> : IEnumerable<T>
           where T : IComparable
    {
        public T Value { get; private set; }
        public BinaryNode<T> Left { get; private set; }
        public BinaryNode<T> Right { get; private set; }
        public BinaryNode(T item = default(T))
        {
            Value = item;
        }

        public void Add(T item)
        {
            if (Value == null)
            {
                Value = item;
                return;
            }
            if (item.CompareTo(Value) > 0)
            {
                switch (Right)
                {
                    case null:
                        Right = new BinaryNode<T> { Value = item };
                        break;
                    default:
                        Right.Add(item);
                        break;
                }
            }
            else
            {
                switch (Left)
                {
                    case null:
                        Left = new BinaryNode<T> { Value = item };
                        break;
                    default:
                        Left.Add(item);
                        break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<T> GetEnumerator()
        {
            if (Left != null)
                foreach (var e in Left)
                    yield return e;

            yield return Value;

            if (Right != null)
                foreach (var e in Right)
                    yield return e;
        }
    }

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        BinaryNode<T> main;
        public T Value
        {
            get
            {
                return main.Value;
            }
        }
        public BinaryNode<T> Left
        {
            get
            {
                return main.Left;
            }
        }
        public BinaryNode<T> Right
        {
            get
            {
                return main.Right;
            }
        }

        public void Add(T item)
        {
            if (main == null)
                main = new BinaryNode<T>(item);
            else
                main.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator()
        {
            if (main == null)
                return Enumerable.Empty<T>().GetEnumerator();
            return main.GetEnumerator();
        }
    }
}
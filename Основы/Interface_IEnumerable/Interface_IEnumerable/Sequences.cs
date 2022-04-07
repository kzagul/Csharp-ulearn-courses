using System;
using System.Collections;
using System.Collections.Generic;
namespace Interface_IEnumerable
{
    public class Sequences // последовательности
    {

        public static IEnumerable<int> Fibonacci
        {
            get
            {
                int previous = 1;
                int current = 1;
                yield return 1;
                yield return 1;
                while (true)
                {
                    var newValue = previous + current;
                    previous = current;
                    current = newValue;
                    yield return current;
                }
            }
        }

        private static IEnumerable<int> ZipSum(IEnumerable<int> first, IEnumerable<int> second)
        {
            var e1 = first.GetEnumerator();
            var e2 = second.GetEnumerator();
            while (true)
            {
                var newValue = e1.Current + e2.Current;
                yield return newValue;
                e1.MoveNext();
                e2.MoveNext();
            }
        }

        public static IEnumerable<int> Exponential(int multiplier)
        {
            var a = 1;

            while (true)
            {
                yield return a;
                a *= multiplier;
            }
        }

    }
    /*
    public class FibonacciEnumerator : IEnumerator<int>
    {

        int currentIndex = -1;
        int currentValue = 1;
        int previousValue = 1;


        public int Current
        {
            get
            {
                if (currentIndex == 0) return 1;
                else if (currentIndex == 1) return 1;
                else
                    return currentValue;
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();


        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentIndex++;
            if (currentIndex > 1)
            {
                var newValue = currentValue + previousValue;
                previousValue = currentValue;
                currentValue = newValue;
            }
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }*/


    //

    /*
    public class FibonacciSequences : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            //return new FibonacciEnumerator();
            int previous = 1;
            int current = 1;
            yield return 1;
            yield return 1;
            while (true)
            {
                var newValue = previous + current;
                previous = current;
                current = newValue;
                yield return current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }*/
}

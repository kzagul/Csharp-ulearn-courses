using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Weights
{
    public class Indexer
    {
        private int length;
        public int Length { get { return length; } }

        private int start;
        public int Start { get { return start; } }

        private static double[] massiv;
        private static bool access = false;

        public Indexer(double[] array, int start, int length)
        {
            if (start < 0)
                throw new ArgumentException();

            if (length < 0)
                throw new ArgumentException();

            if (length > array.Length)
                throw new ArgumentException();

            if (length > array.Length - start)
                throw new ArgumentException();


            this.length = length;
            this.start = start;

            if (access == false)
                massiv = array;
        }

        public double this[int index]
        {
            get
            {
                if (index > length - 1) 
                    throw new IndexOutOfRangeException();
                if (index < 0) 
                    throw new IndexOutOfRangeException();
                return massiv[index + start];
            }
            set
            {
                if (index < 0) 
                    throw new IndexOutOfRangeException();
                if (index > length - 1) 
                    throw new IndexOutOfRangeException();
                massiv[index + start] = value;
            }
        }

    }
}

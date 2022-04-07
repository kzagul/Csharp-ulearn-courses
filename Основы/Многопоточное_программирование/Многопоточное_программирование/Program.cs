using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Многопоточное_программирование
{
    class Program
    {
		private static  List<int> list = new List<int>();


        static void MakeWork()
        {
            for (int i = 0; ; i++)
            {
               
                lock (list)
                {
                    list.Add(i);
                }
            }
        }


        public static void Main()
		{
            new Action(MakeWork).BeginInvoke(null, null);
            while (true)
            {
                if (list.Count > 100000)
            }


        }
	}
}

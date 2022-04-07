using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class TicketsTask
    {
        int halfLength;
        
        public int HalfLength
        {
            get { return halfLength; }
            set
            {
                if (value >= 1 && value <= 50)
                    halfLength = value;
            }
        }

        int fullSum;
        public int FullSum
        {
            get { return fullSum; }
            set
            {
                if (value >= 0 && value <= 2000)
                    fullSum = value;
            }
        }

        public static BigInteger Solve(int halfLength, int fullSum)
        {
            BigInteger[,] tickets = new BigInteger[101, 2001];
            for (var i = 0; i < 100; i++)
                for (var j = 0; j < 2000; j++)
                    tickets[i, j] = -1;
            if (fullSum % 2 == 0) return BigInteger.Pow(GetAmount(
                tickets,
                halfLength,
                fullSum / 2), 2);
            return 0;
        }

        //рекурсия
        public static BigInteger GetAmount(BigInteger[,] tickets, int length, int sum)
        {
            if (tickets[length, sum] < 0)
            {
                if (sum <= 0) return 1;
                if (length <= 0) return 0;
                else tickets[length, sum] = 0;
                for (int i = 10 - 1; i >= 0; i--)
                    if (sum - i >= 0)
                        tickets[length, sum] = tickets[length, sum] + GetAmount(tickets, length - 1, sum - i);
                return tickets[length, sum];
            }
            return tickets[length, sum];
        }

    }
}
using System;
using System.Collections.Generic;

namespace Antiplagiarism
{
    public static class LongestCommonSubsequenceCalculator
    {
        public static List<string> Calculate(List<string> first, List<string> second)
        {

            return RestoreAnswer(CreateOptimizationTable(first, second), first, second, first.Count, second.Count);
        }
        private static int[,] CreateOptimizationTable(List<string> first, List<string> second)
        {
            int[,] optimal = new int[first.Count + 1, second.Count + 1];
            
            for (int i = 1; i <= first.Count; i++)
                for (int j = 1; j <= second.Count; j++)
                {
                    LargestCommonSubsequence(first, second, optimal, i, j);// Наибольшая общая подпоследовательность
                }
            return optimal;
        }
        private static void LargestCommonSubsequence(List<string> first, List<string> second, int[,] optimal, int i, int j)
        {
            if (first[i - 1] == second[j - 1])
                optimal[i, j] = optimal[i - 1, j - 1] + 1;
            if (first[i - 1] != second[j - 1])
                optimal[i, j] = Math.Max(optimal[i, j - 1], optimal[i - 1, j]);
        }
        private static List<string> RestoreAnswer(int[,] optimal, List<string> first, List<string> second, int i, int j)
        {
            if (i == 0 || j == 0)
                return new List<string>();
            if (first[i - 1] == second[j - 1])
            {
                var result = RestoreAnswer(optimal, first, second, i - 1, j - 1);
                result.Add(first[i - 1]);
                return result;
            }
            if (optimal[i, j - 1] > optimal[i - 1, j])
                return RestoreAnswer(optimal, first, second, i, j - 1);
            return RestoreAnswer(optimal, first, second, i - 1, j);
        }
    }
}
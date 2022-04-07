using System;
using System.Configuration;
using System.Collections.Generic;

//using DocumentTokens = System.Collections.Generic.List<string>;

namespace Antiplagiarism
{
    public class LevenshteinCalculator
    {
        public List<ComparisonResult> CompareDocumentsPairwise(List<List<string>> documents)
        {
            List<ComparisonResult> result = new List<ComparisonResult>();
            for (int i = 0; i < documents.Count; i++)
                for (int j = i + 1; j < documents.Count; j++)
                {
                    ComparisonResult levenshteinNumber = LevenshteinDistance(documents[i], documents[j]);
                    result.Add(levenshteinNumber);
                }
            return result;
        }

        public static Func<double, double, double, double> MinimalOfThree = 
            (obj1, obj2, obj3) => Math.Min(Math.Min(obj1, obj2), obj3);

        public static ComparisonResult LevenshteinDistance(List<string> first, List<string> second)
        {
            double[,] optimal = new double[first.Count + 1, second.Count + 1];

            for (int i = 0; i <= first.Count; ++i) optimal[i, 0] = i;
            for (int i = 0; i <= second.Count; ++i) optimal[0, i] = i;
            for (int i = 1; i <= first.Count; ++i)
                for (int j = 1; j <= second.Count; ++j)
                    Levenshtein(first, second, optimal, i, j);
            return new ComparisonResult(first, second, optimal[first.Count, second.Count]);
        }

        private static void Levenshtein(List<string> first, List<string> second, double[,] optimal, int i, int j)
        {
            double d = TokenDistanceCalculator.GetTokenDistance(first[i - 1], second[j - 1]);
            if (first[i - 1] == second[j - 1])
                optimal[i, j] = optimal[i - 1, j - 1];
            if (first[i - 1] != second[j - 1])
                optimal[i, j] = MinimalOfThree(
                    optimal[i - 1, j] + 1, 
                    optimal[i, j - 1] + 1, 
                    optimal[i - 1, j - 1] + d);
        }
    }
}





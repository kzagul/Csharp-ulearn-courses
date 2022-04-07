using System;
namespace Наследование
{
    public class Matrix
    {
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintMatrix <T>(T[] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {       
                    Console.Write(matrix[i] + " "); 
            }
            Console.WriteLine();
        }

        public static int[,] Transpose(int[,] matrix)
        {
            int[,] res = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res[j, i] = matrix[i, j];
                }
            }
            return res;
        }

        /*int[,] a = {
        {1, 2, 3, 4},
        {5, 6, 7, 8}
        };
        int[,] res = Matrix.Transpose(a);
        Matrix.PrintMatrix(a);
        Console.WriteLine();
        Matrix.PrintMatrix(res);*/



    }
}

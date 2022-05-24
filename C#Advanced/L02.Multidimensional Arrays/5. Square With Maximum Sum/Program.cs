using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read the matrix dimensions: rows, cols
            int[] dimensions = Console.ReadLine()
                 .Split(", ")
                 .Select(int.Parse).ToArray();
            (int rowsCount, int colsCount) = (dimensions[0], dimensions[1]);

            //Read the numbers for the matrix
            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] line = Console.ReadLine().Split(", ")
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            long maxSum = long.MinValue;
            int maxRowIndex = int.MinValue;
            int maxColIndex = int.MinValue;

            
            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int col = 0; col < colsCount - 1; col++)
                {
                    long sum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRowIndex = row;
                        maxColIndex = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRowIndex, maxColIndex]} {matrix[maxRowIndex, maxColIndex + 1]}");
            Console.WriteLine($"{matrix[maxRowIndex + 1, maxColIndex]} {matrix[maxRowIndex + 1, maxColIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}

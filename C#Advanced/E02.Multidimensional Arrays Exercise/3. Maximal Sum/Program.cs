using System;
using System.Linq;
using System.Collections.Generic;
namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //int sizeOfMatrix = int.Parse(Console.ReadLine());

           // int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            string input = Console.ReadLine(); //"3 4". Split() -> ["3", "4"]
            int rows = int.Parse(input.Split()[0]);
            int cols = int.Parse(input.Split()[1]);

            int[,] matrix = new int[rows, cols];

            

            FillMatrix(matrix);

            int sum = int.MinValue; //sum of matrix 3x3
            int indexOfRow = int.MinValue;
            int indexOfCol = int.MinValue;


            //елемент == елемент от дясно == елемент долу == елемент по диагнонал

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        indexOfRow = row;
                        indexOfCol = col;
                    }

                }
            }

            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"{matrix[indexOfRow, indexOfCol]} {matrix[indexOfRow, indexOfCol + 1]} {matrix[indexOfRow, indexOfCol + 2]}");
            Console.WriteLine($"{matrix[indexOfRow + 1, indexOfCol]} {matrix[indexOfRow + 1, indexOfCol + 1]} {matrix[indexOfRow + 1, indexOfCol + 2]}");
            Console.WriteLine($"{matrix[indexOfRow + 2, indexOfCol]} {matrix[indexOfRow + 2, indexOfCol + 1]} {matrix[indexOfRow + 2, indexOfCol + 2]}");
        }

        
            private static void FillMatrix(int[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int[] currentRow = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = currentRow[col];
                    }
                }
            }

        
    }


}

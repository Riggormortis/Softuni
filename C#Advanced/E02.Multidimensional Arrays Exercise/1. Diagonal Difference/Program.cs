using System;
using System.Linq;
namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            FillMatrix(matrix);
                                  

            int sumPrime = 0;
                        

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int col = row;
                sumPrime += matrix[row, col];
            }

            
            int sumSecondary = 0;
            int currentCol = 0;

            for (int rowSec = matrix.GetLength(0) - 1; rowSec >= 0; rowSec--)
            {
                sumSecondary += matrix[rowSec, currentCol];
                currentCol++;
            }

            int difference = sumPrime - sumSecondary;

            Console.WriteLine(Math.Abs(difference));
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

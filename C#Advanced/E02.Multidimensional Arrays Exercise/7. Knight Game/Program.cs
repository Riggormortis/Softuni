using System;
using System.Linq;
namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];

            FillMatrix(matrix);


            int removedKnights = 0;


            while (true)
            {
                int knightRow = int.MinValue;
                int knightCol = int.MinValue;
                int totalAtacks = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int tempAtacks = CountAttacks(matrix, row, col);

                            if (tempAtacks > totalAtacks)
                            {
                                totalAtacks = tempAtacks;
                                knightRow = row;
                                knightCol = col;
                            }
                        }

                    }
                }

                if (totalAtacks > 0)
                {
                    matrix[knightRow, knightCol] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }


            Console.WriteLine(removedKnights);

        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                    

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
        private static int CountAttacks(char[,] matrix, int row, int col)
        {
            int attacks = 0;

            if (isValid(row - 2, col + 1, matrix))
            {
                attacks++;
            }
            if (isValid(row - 2, col - 1, matrix))
            {
                attacks++;
            }
            if (isValid(row - 1, col - 2, matrix))
            {
                attacks++;
            }
            if (isValid(row + 1, col - 2, matrix))
            {
                attacks++;
            }
            if (isValid(row + 2, col - 1, matrix))
            {
                attacks++;
            }
            if (isValid(row + 2, col + 1, matrix))
            {
                attacks++;
            }
            if (isValid(row - 1, col + 2, matrix))
            {
                attacks++;
            }
            if (isValid(row + 1, col + 2, matrix))
            {
                attacks++;
            }

            return attacks;
        }

        private static bool isValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1)
                && matrix[row, col] == 'K';
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //"3 4". Split() -> ["3", "4"]
            int rows = int.Parse(input.Split()[0]);
            int cols = int.Parse(input.Split()[1]);

            string[,] matrix = new string[rows, cols];
            FillMatrix(matrix);

            int count = 0; //брой на матриците 2х2

            //елемент == елемент от дясно == елемент долу == елемент по диагнонал

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] & //element otdqsno
                        matrix[row, col] == matrix[row + 1, col] & //element otdolu
                        matrix[row, col] == matrix[row + 1, col + 1]) //element po diagonal
                    {
                        count++;
                    }

                }
            }

            Console.WriteLine(count);

        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(" ");
                    

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }


}

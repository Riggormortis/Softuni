using System;
using System.Linq;
using System.Collections.Generic;
namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            //пълнене на матрица
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            }

            //analiz na matricata
            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(el => el * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(el => el * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(el => el / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(el => el / 2).ToArray();
                }

            }

            //commands
            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                int row = int.Parse(cmd.Split()[1]);
                int col = int.Parse(cmd.Split()[2]);
                int value = int.Parse(cmd.Split()[3]);

                if (cmd.StartsWith("Add"))
                {
                    // "Add {row} {col} {value}".Split => ["Add", "row", "col", "value"]
                    
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length) //validirame dali e v matricata
                    {
                        matrix[row][col] = matrix[row][col] + value;
                        // matrix[row][col] += value;
                    }

                }
                else if (cmd.StartsWith("Subtract"))
                {
                    if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length) //validirame dali e v matricata
                    {
                        matrix[row][col] = matrix[row][col] - value;
                        // matrix[row][col] -= value;
                    }
                }


                cmd = Console.ReadLine();
            }


            //printing matrix

            foreach(var row in matrix)
            {
                Console.WriteLine(String.Join(' ', row));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    class Program
    {


        static void Main(string[] args)
        {


            int[] dimensions = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            int[,] matrix = new int[n, m];

            int flowerRow = 0;
            int flowerCol = 0;


            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                int[] tokens = command.Split().Select(int.Parse).ToArray();

                int plantRow = tokens[0];
                int plantCol = tokens[1];

                if (!IsInRange(plantRow, plantCol, n, m))
                {
                    Console.WriteLine("Invalid coordinates.");
                
                }

                flowerRow = plantRow;
                flowerCol = plantCol;


                for (int r1 = 0; r1 < matrix.GetLength(0); r1++)
                {
                    for (int c1 = 0; c1 < matrix.GetLength(1); c1++)
                    {
                        if (r1 == flowerRow || c1 == flowerCol)
                        {
                            matrix[r1, c1] += 1;
                        }

                    }
                }

                command = Console.ReadLine();
            }

            PrintMatrix(matrix);
            
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");

                }
                Console.WriteLine();
            }
        }

        private static bool IsInRange(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }

    
    }
}
 


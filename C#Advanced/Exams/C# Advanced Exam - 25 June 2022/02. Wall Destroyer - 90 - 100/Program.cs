using System;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        private static int VankoRow;
        private static int VankoCol;

        private static char[,] matrix;

        private static bool IsOutOfSquare = false;
        private static bool Electrocuted = false;
        private static int countRods = 0;
        private static int countHoles = 1;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //size of forest (matrix) - count rows == count columns

            matrix = new char[n, n];//forset = array of chars

            //filling the matrix
            for (int row = 0; row <= n - 1; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'V')
                    {
                        VankoRow = row;
                        VankoCol = col;
                    }

                }
            }



            string command = Console.ReadLine();

            while (command != "End")
            {
                switch (command)
                {
                    case "up":
                        Movement(-1, 0);
                        break;
                    case "down":
                        Movement(1, 0);
                        break;
                    case "left":
                        Movement(0, -1);
                        break;
                    case "right":
                        Movement(0, 1);
                        break;
                }

                

                command = Console.ReadLine();
            }


            Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countRods} rod(s).");
            PrintMatrix(matrix);


        }

        public static void Movement(int row, int col)
        {
            int currVankoRow = VankoRow;
            int currVankoCol = VankoCol;
            matrix[VankoRow, VankoCol] = '*';
            VankoRow += row;
            VankoCol += col;

            if (!IsInMatrix(VankoRow, VankoCol))
            {
                VankoRow -= row;
                VankoCol -= col;

                matrix[VankoRow, VankoCol] = 'V';
            }

            else if (IsInMatrix(VankoRow, VankoCol))
            {
                if (matrix[VankoRow, VankoCol] == 'R')
                {
                    countRods++;
                    VankoRow -= row;
                    VankoCol -= col;
                    matrix[VankoRow, VankoCol] = 'V';
                    Console.WriteLine("Vanko hit a rod!");
                    
                }
                else if (matrix[VankoRow, VankoCol] == 'C')
                {
                    countHoles++;
                    matrix[VankoRow, VankoCol] = 'E';
                    Electrocuted = true;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
                    PrintMatrix(matrix);
                    Environment.Exit(0);

                }
                else if (matrix[VankoRow, VankoCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{VankoRow}, {VankoCol}]!");
                }
                else
                {
                    countHoles++;
                    matrix[VankoRow, VankoCol] = 'V';
                }


            }
            else
            {
                matrix[VankoRow, VankoCol] = 'V';
            }

        }
        public static bool IsInMatrix(int row, int col)
        {

            bool isValid = row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1);
            IsOutOfSquare = isValid;
            return isValid;
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }

                Console.WriteLine();
            }
        }
    }
}

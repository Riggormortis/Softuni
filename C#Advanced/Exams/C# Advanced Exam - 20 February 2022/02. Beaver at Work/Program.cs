using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    public class Program
    {
        private static char[,] matrix;
        private static int[] beaverPosition = new int[2];
        private static Stack<char> branchColections = new Stack<char>();
        private static string command = string.Empty;
        private static int branches = 0;
        static void Main(string[] args)
        {
            int martrixSize = int.Parse(Console.ReadLine());
            matrix = new char[martrixSize, martrixSize];
            ReadMadrix(matrix, beaverPosition);
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                }
                if (branches == 0)
                {
                    break;
                }
            }
            if (branches > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branches} branches left.");
            }
            else
            {
                List<char> printBranchCollection = branchColections.ToList();
                printBranchCollection.Reverse();
                Console.WriteLine($"The Beaver successfully collect {branchColections.Count} wood branches: {string.Join(", ", printBranchCollection)}.");
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] printLine = new char[matrix.GetLength(1)];
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    printLine[col] = matrix[row, col];
                }
                Console.WriteLine(string.Join(" ", printLine));
            }
        }

        private static void Move(int moveToRow, int moveToCol)
        {
            if (!isValidPosition(beaverPosition[0] + moveToRow, beaverPosition[1] + moveToCol))
            {
                if (branchColections.Count > 0)
                {
                    branchColections.Pop();
                }
                return;
            }
            matrix[beaverPosition[0], beaverPosition[1]] = '-';
            beaverPosition[0] += moveToRow;
            beaverPosition[1] += moveToCol;
            if (char.IsLower(matrix[beaverPosition[0], beaverPosition[1]]))
            {
                branchColections.Push(matrix[beaverPosition[0], beaverPosition[1]]);
                matrix[beaverPosition[0], beaverPosition[1]] = 'B';
                branches--;
            }
            else if (matrix[beaverPosition[0], beaverPosition[1]] == 'F')
            {
                matrix[beaverPosition[0], beaverPosition[1]] = '-';
                if (command == "up")
                {
                    if (beaverPosition[0] == 0)
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverPosition[1]]))
                        {
                            branchColections.Push(matrix[matrix.GetLength(0) - 1, beaverPosition[1]]);
                            branches--;
                        }
                        matrix[matrix.GetLength(0) - 1, beaverPosition[1]] = 'B';
                        beaverPosition[0] = matrix.GetLength(0) - 1;
                    }
                    else
                    {
                        if (char.IsLower(matrix[0, beaverPosition[1]]))
                        {
                            branchColections.Push(matrix[0, beaverPosition[1]]);
                            branches--;
                        }
                        matrix[beaverPosition[0], beaverPosition[1]] = 'B';
                    }
                }
                else if (command == "down")
                {
                    if (beaverPosition[0] == matrix.GetLength(0) - 1)
                    {
                        if (char.IsLower(matrix[0, beaverPosition[1]]))
                        {
                            branchColections.Push(matrix[0, beaverPosition[1]]);
                            branches--;
                        }
                        matrix[0, beaverPosition[1]] = 'B';
                        beaverPosition[0] = 0;
                    }
                    else
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverPosition[1]]))
                        {
                            branchColections.Push(matrix[matrix.GetLength(0) - 1, beaverPosition[1]]);
                            branches--;
                        }
                        matrix[matrix.GetLength(0) - 1, beaverPosition[1]] = 'B';
                    }
                }
                else if (command == "left")
                {
                    if (beaverPosition[1] == 0)
                    {
                        if (char.IsLower(matrix[beaverPosition[0], matrix.GetLength(1) - 1]))
                        {
                            branchColections.Push(matrix[beaverPosition[0], matrix.GetLength(1) - 1]);
                            branches--;
                        }
                        matrix[beaverPosition[1], matrix.GetLength(1) - 1] = 'B';
                        beaverPosition[1] = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverPosition[0], 0]))
                        {
                            branchColections.Push(matrix[beaverPosition[0], 0]);
                            branches--;
                        }
                        matrix[beaverPosition[0], 0] = 'B';
                    }
                }
                else if (command == "right")
                {
                    if (beaverPosition[1] == matrix.GetLength(1) - 1)
                    {
                        if (char.IsLower(matrix[beaverPosition[0], 0]))
                        {
                            branchColections.Push(matrix[beaverPosition[0], 0]);
                            branches--;
                        }
                        matrix[beaverPosition[0], 0] = 'B';
                        beaverPosition[1] = 0;
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverPosition[0], matrix.GetLength(1) - 1]))
                        {
                            branchColections.Push(matrix[beaverPosition[0], matrix.GetLength(1) - 1]);
                            branches--;
                        }
                        matrix[beaverPosition[0], matrix.GetLength(1) - 1] = 'B';
                    }
                }
            }
            else
            {
                matrix[beaverPosition[0], beaverPosition[1]] = 'B';
            }
        }
        private static bool isValidPosition(int newRowPosition, int newColPosition)
        {
            bool isValid = newRowPosition >= 0 && newColPosition >= 0 && newRowPosition < matrix.GetLength(0) && newColPosition < matrix.GetLength(1);
            return isValid;
        }

        private static void ReadMadrix(char[,] matrix, int[] beaverPositin)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputString = string.Join("", Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
                char[] input = inputString.ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (char.IsLower(input[col]))
                    {
                        branches++;
                    }
                    matrix[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        beaverPositin[0] = row;
                        beaverPositin[1] = col;
                    }
                }
            }
        }
    }
}

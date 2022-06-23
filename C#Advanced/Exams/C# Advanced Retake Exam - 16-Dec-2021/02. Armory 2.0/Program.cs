using System;
using System.Linq;

namespace _02._Armory
{
    class Program
    {
        private static char[,] matrix;
        private static int[] officerPosition = new int[2];
        private static int amount = 0;
        private static int[] mirrorsPosition = new int[4];
        private static string command = string.Empty;
        private static bool IsOutOfSquare = false;
        static void Main(string[] args)
        {
             //size of armory (matrix) - count rows == count columns
            //armory = array of chars

            int matrixSize = int.Parse(Console.ReadLine());
            matrix = new char[matrixSize, matrixSize];
            ReadMatrix(matrix, officerPosition, mirrorsPosition);

            while (true)
            {
                command = Console.ReadLine();
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
                if (!IsOutOfSquare)
                {
                    break;
                }
                if (amount >= 65)
                {
                    break;
                }
            }
            if (!IsOutOfSquare)
            {
                Console.WriteLine("I do not need more swords!");
                Console.WriteLine($"The king paid {amount} gold coins.");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
                Console.WriteLine($"The king paid {amount} gold coins.");
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
                Console.WriteLine(string.Join("", printLine));
            }
        }

        private static void Move(int moveToRow, int moveToCol)
        {
            if (!isValidPosition(officerPosition[0] + moveToRow, officerPosition[1] + moveToCol))
            {
                matrix[officerPosition[0], officerPosition[1]] = '-';
                return;
            }
            matrix[officerPosition[0], officerPosition[1]] = '-';
            officerPosition[0] += moveToRow;
            officerPosition[1] += moveToCol;
            if (matrix[officerPosition[0], officerPosition[1]] == 'M')
            {
                matrix[officerPosition[0], officerPosition[1]] = 'A';
                if (officerPosition[0] == mirrorsPosition[0] && officerPosition[1] == mirrorsPosition[1])
                {
                    matrix[mirrorsPosition[0], mirrorsPosition[1]] = '-';
                    officerPosition[0] = mirrorsPosition[2];
                    officerPosition[1] = mirrorsPosition[3];
                    matrix[officerPosition[0], officerPosition[1]] = 'A';
                }
                else
                {
                    matrix[mirrorsPosition[2], mirrorsPosition[3]] = '-';
                    officerPosition[2] = mirrorsPosition[0];
                    officerPosition[3] = mirrorsPosition[1];
                    matrix[officerPosition[0], officerPosition[1]] = 'A';
                }

            }
            else if (command == "up")
            {
                if (char.IsDigit(matrix[officerPosition[0], officerPosition[1]]))
                {
                    amount += int.Parse(matrix[officerPosition[0], officerPosition[1]].ToString());
                    matrix[officerPosition[0], officerPosition[1]] = 'A';
                }
            }
            else if (command == "down")
            {
                if (char.IsDigit(matrix[officerPosition[0], officerPosition[1]]))
                {
                    amount += int.Parse(matrix[officerPosition[0], officerPosition[1]].ToString());
                    matrix[officerPosition[0], officerPosition[1]] = 'A';
                }
            }
            else if (command == "left")
            {
                if (char.IsDigit(matrix[officerPosition[0], officerPosition[1]]))
                {
                    amount += int.Parse(matrix[officerPosition[0], officerPosition[1]].ToString());
                    matrix[officerPosition[0], officerPosition[1]] = 'A';
                }
            }
            else if (command == "right")
            {
                if (char.IsDigit(matrix[officerPosition[0], officerPosition[1]]))
                {
                    amount += int.Parse(matrix[officerPosition[0], officerPosition[1]].ToString());
                    matrix[officerPosition[0], officerPosition[1]] = 'A';
                }
            }

        }

        private static bool isValidPosition(int newRowPosition, int newColPosition)
        {
            bool isValid = newRowPosition >= 0 && newColPosition >= 0 && newRowPosition < matrix.GetLength(0) && newColPosition < matrix.GetLength(1);
            IsOutOfSquare = isValid;
            return isValid;
        }
        private static void ReadMatrix(char[,] matrix, int[] officerPosition, int[] mirrorsPosition)
        {
            int mirrorCounter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'A')
                    {
                        officerPosition[0] = row;
                        officerPosition[1] = col;
                    }
                    if (matrix[row, col] == 'M')
                    {
                        if (mirrorCounter == 0)
                        {
                            mirrorsPosition[0] = row;
                            mirrorsPosition[1] = col;
                            mirrorCounter++;
                        }
                        else
                        {
                            mirrorsPosition[2] = row;
                            mirrorsPosition[3] = col;
                        }
                    }
                }
            }
        }
    }
}

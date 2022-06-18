using System;
using System.Linq;

namespace _02._Warships
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int[] coordinates = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            string[,] matrix = new string[n, n];

            int firstPlayer = 0; //<
            int secondPlayer = 0; //>
            int totalShips = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == "<")
                    {
                        firstPlayer++;
                    }
                    else if (matrix[row, col] == ">")
                    {
                        secondPlayer++;
                    }
                }
            }

            totalShips = firstPlayer + secondPlayer;

            for (int i = 0; i < coordinates.Length; i += 2)
            {
                int row = coordinates[i];
                int col = coordinates[i + 1];

                if (!IsInRange(matrix, row, col))
                {
                    continue;
                }

                if (matrix[row, col] == ">")
                {
                    secondPlayer--;
                    matrix[row, col] = "X";
                }
                else if (matrix[row, col] == "<")
                {
                    firstPlayer--;
                    matrix[row, col] = "X";
                }
                else if (matrix[row, col] == "#")
                {
                    //up
                    if (IsInRange(matrix, row - 1, col))
                    {
                        if (matrix[row - 1, col] == ">")
                        {
                            secondPlayer--;
                        }
                        else if (matrix[row - 1, col] == "<")
                        {
                            firstPlayer--;
                        }
                        matrix[row - 1, col] = "X";
                    }
                    //down
                    if (IsInRange(matrix, row + 1, col))
                    {
                        if (matrix[row + 1, col] == ">")
                        {
                            secondPlayer--;
                        }
                        else if (matrix[row + 1, col] == "<")
                        {
                            firstPlayer--;
                        }
                        matrix[row + 1, col] = "X";
                    }
                    //right/left
                    //right
                    if (IsInRange(matrix, row, col + 1))
                    {
                        if (matrix[row, col+1] == ">")
                        {
                            secondPlayer--;
                        }
                        else if (matrix[row, col + 1] == "<")
                        {
                            firstPlayer--;
                        }
                        matrix[row, col + 1] = "X";
                    }
                    //left
                    if (IsInRange(matrix, row, col - 1))
                    {
                        if (matrix[row, col - 1] == ">")
                        {
                            secondPlayer--;
                        }
                        else if (matrix[row, col - 1] == "<")
                        {
                            firstPlayer--;
                        }
                        matrix[row, col - 1] = "X";
                    }
                    //up left/up right
                    //up left
                    if (IsInRange(matrix, row - 1, col - 1))
                    {
                        if (matrix[row - 1, col - 1] == ">")
                        {
                            secondPlayer--;
                        }
                        else if (matrix[row - 1, col - 1] == "<")
                        {
                            firstPlayer--;
                        }
                        matrix[row - 1, col - 1] = "X";
                    }
                    //up right
                    if (IsInRange(matrix, row - 1, col + 1))
                    {
                        if (matrix[row - 1, col + 1] == ">")
                        {
                            secondPlayer--;
                        }
                        else if (matrix[row - 1, col + 1] == "<")
                        {
                            firstPlayer--;
                        }
                        matrix[row - 1, col + 1] = "X";
                    }
                    //down left/down right
                    //down left
                    if (IsInRange(matrix, row + 1, col - 1))
                    {
                        if (matrix[row + 1, col - 1] == ">")
                        {
                            secondPlayer--;
                        }
                        else if (matrix[row + 1, col - 1] == "<")
                        {
                            firstPlayer--;
                        }
                        matrix[row + 1, col - 1] = "X";
                    }
                    //down right
                    if (IsInRange(matrix, row + 1, col + 1))
                    {
                        if (matrix[row + 1, col + 1] == ">")
                        {
                            secondPlayer--;
                        }
                        else if (matrix[row + 1, col + 1] == "<")
                        {
                            firstPlayer--;
                        }
                        matrix[row + 1, col + 1] = "X";
                    }


                }

                if (firstPlayer == 0 || secondPlayer == 0)
                {
                    break;
                }
            }

            if (firstPlayer > 0 && secondPlayer > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayer} ships left. Player Two has {secondPlayer} ships left.");
            }
            else if (firstPlayer > 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShips - (firstPlayer + secondPlayer)} ships have been sunk in the battle.");
            }
            else if (secondPlayer > 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShips - (firstPlayer + secondPlayer)} ships have been sunk in the battle.");
            }
            

        }

        private static bool IsInRange(string[,] matrix, int row, int col)
            => row >= 0 && row < matrix.GetLength(0)
            && col >= 0 && col < matrix.GetLength(1);

    }
}

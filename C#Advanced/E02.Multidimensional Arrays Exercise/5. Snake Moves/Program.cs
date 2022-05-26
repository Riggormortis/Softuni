using System;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //"3 4".Split() -> ["3", "4"]
            int rows = int.Parse(input.Split()[0]); //бр. редове
            int cols = int.Parse(input.Split()[1]); //бр. колони


            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();

            int index = 0; //obhojdane na snake

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    // cheten red
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[index];
                        index++;
                        if (index >= snake.Length)
                        {
                            index = 0;
                        }
                    }
                }
                else
                {
                    //necheten red
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[index];
                        index++;
                        if (index >= snake.Length)
                        {
                            index = 0;
                        }
                    }
                }
            }

            PrintMatrix(matrix);

        }


        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

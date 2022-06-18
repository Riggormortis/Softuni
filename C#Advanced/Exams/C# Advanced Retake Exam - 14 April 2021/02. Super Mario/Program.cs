using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {

            int marioLives = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            int marioRow = default;
            int marioCol = default;

            for (int i = 0; i < rows; i++)
            {
                var currRow = Console.ReadLine().ToCharArray();
                matrix[i] = currRow;
                if (currRow.Contains('M'))
                {
                    marioRow = i;
                    marioCol = currRow.ToList().IndexOf('M');
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string cmd = tokens[0];
                int enemyROw = int.Parse(tokens[1]);
                int enemyCol = int.Parse(tokens[2]);

                matrix[enemyROw][enemyCol] = 'B';
                marioLives--;

                matrix[marioRow][marioCol] = '-';
                
                if (cmd == "W" && marioRow - 1 >= 0) //up
                {
                    marioRow--;
                }
                else if (cmd == "S" && marioRow + 1 < rows)//down
                {
                    marioRow++;
                }
                else if (cmd == "A" && marioCol - 1 >= 0) //left 
                {
                    marioCol--;
                }
                else if (cmd == "D" && marioCol + 1 < matrix[0].Length) //right
                {
                    marioCol++;
                }

                if (matrix[marioRow][marioCol] == 'B')
                {
                    marioLives -= 2;
                }
                else if (matrix[marioRow][marioCol] == 'P')
                {
                    matrix[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                    break;
                }

                if (marioLives<= 0)
                {
                    matrix[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                matrix[marioRow][marioCol] = 'M';
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(new string(matrix[i]));
            }
        }
    }
}

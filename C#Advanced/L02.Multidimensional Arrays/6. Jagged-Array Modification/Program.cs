using System;
using System.Collections.Generic;
using System.Linq;
namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = ReadJaggedArray(rows);

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                var cmdTokens = cmd.Split(" ");
                int row = int.Parse(cmdTokens[1]);
                int col = int.Parse(cmdTokens[2]);
                int value = int.Parse(cmdTokens[3]);
                if (row < 0 || col < 0 || row >= jagged.Length || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (cmdTokens[0] == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (cmdTokens[0] == "Subtract")
                {
                    jagged[row][col] -= value;
                }


                cmd = Console.ReadLine();
            }

            PrintJagged(jagged);
        }


        public static int[][] ReadJaggedArray(int rows)
        {
            int[][] jagged = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            return jagged;
        }

        static void PrintJagged(int[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine($"{String.Join(" ", jagged[row])}");
            }
           
        }

    }
}

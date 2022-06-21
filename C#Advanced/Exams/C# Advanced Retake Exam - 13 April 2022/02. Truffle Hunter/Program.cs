using System;

namespace _02._Truffle_Hunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine()); //size of forest (matrix) - count rows == count columns
            char[,] matrix = new char[size, size];//forset = array of chars

            //filling the matrix
            for (int row = 0; row <= size - 1; row++)
            {
                char[] currRowElements = Console.ReadLine()
                    .Replace(" ", string.Empty)
                    .ToCharArray();
                //"B W S - -" => "BWS--".ToCharArray() -> ['B', 'W', 'S', '-', '-']

                for (int col = 0; col < currRowElements.Length; col++)
                {
                    matrix[row, col] = currRowElements[col];
                }
            }

            int countBlack = 0;
            int countSummer = 0;
            int countWhite = 0;
            int eatenTruffles = 0;
            string cmd = Console.ReadLine();

            while (cmd != "Stop the hunt")
            {
                string[] input = cmd.Split();
                //1. "Collect {row} {col}"
                //2. "Wild_Boar {row} {col} {direction}" 
                string commandName = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                
                if (commandName == "Collect")
                {
                    //take truffle
                    char truffel = matrix[row, col]; //B, S, W
                    matrix[row, col] = '-';
                    if (truffel == 'B')
                    {
                        countBlack++;
                    }
                    else if (truffel == 'S')
                    {
                        countSummer++;
                    }
                    else if (truffel == 'W')
                    {
                        countWhite++;
                    }
                }
                else if (commandName == "Wild_Boar")
                {
                    string direction = input[3];
                    //"up", "down", "left" and "right"
                    if (direction == "up")
                    {
                        //while there are rows above
                        //repeat = moves up and we check if there is a truffle
                       
                        while (IsValidRow(row, size))
                        {
                            if (EatBoar(row, col, matrix))
                            {
                                eatenTruffles++;
                            }                          
                            //row -= 2; col stays the same
                            row -= 2;
                        }         
                    }
                    else if (direction == "down")
                    {
                        while (IsValidRow(row, size))
                        {
                            if (EatBoar(row, col, matrix))
                            {
                                eatenTruffles++;
                            }
                            //row += 2; col stays the same
                            row += 2;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (IsValidCol(col, size))
                        {
                            if (EatBoar(row, col, matrix))
                            {
                                eatenTruffles++;
                            }
                            //row stays the same; col -= 2
                            col -= 2;
                        }
                    }
                    else if (direction == "right")
                    {
                        while (IsValidCol(col, size))
                        {
                            if (EatBoar(row, col, matrix))
                            {
                                eatenTruffles++;
                            }
                            //row stays the same; col += 2
                            col += 2;
                        }
                    }


                }

                cmd = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {countBlack} black, {countSummer} summer, and {countWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffles} truffles.");
            PrintMatrix(matrix);
            

        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static bool EatBoar(int row, int col, char[, ] matrix)
        {
            char currentSymbol = matrix[row, col];
            if (currentSymbol == 'S' || currentSymbol == 'B' || currentSymbol == 'W')
            {
                matrix[row, col] = '-';
                return true;
            }
            return false;
        }
        public static bool IsValidRow(int row, int size)
        {
            return row >= 0 && row < size;
        }
        public static bool IsValidCol(int col, int size)
        {
            return col >= 0 && col < size;
        }



    }
}
